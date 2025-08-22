Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

Public Class FileHandlingShellUi
    ' Define a custom event to track completion
    Public Event KillFilesCompleted(sender As Object, e As FileOperationCompletedEventArgs)
    Public Event RecycleFilesCompleted(sender As Object, e As FileOperationCompletedEventArgs)


    ' Custom event arguments class (renamed for both operations)
    Public Class FileOperationCompletedEventArgs
        Inherits EventArgs
        Public Property Result As Integer
        Public Property Files As List(Of String)
        Public Property Hwnd As IntPtr
    End Class

    ' Parameters for background operation (renamed for both operations)
    Private Class FileOperationParams
        Public Property Files As List(Of String)
        Public Property Hwnd As IntPtr
        Public Property Operation As FileOperationType
    End Class

    ' Result container for background operation
    Private Class FileOperationResult
        Public Property ResultValue As Integer
        Public Property Params As FileOperationParams
    End Class

    ' Background work handler (handles both operations)
    Private Sub FileOperationWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim params As FileOperationParams = DirectCast(e.Argument, FileOperationParams)
        Dim result As Integer

        Select Case params.Operation
            Case FileOperationType.Delete
                result = DoDeleteFiles(params.Files, params.Hwnd)
            Case FileOperationType.Recycle
                result = DoRecycleFiles(params.Files, params.Hwnd)
            Case Else
                result = -1 ' Error case
        End Select

        e.Result = New FileOperationResult With {
            .ResultValue = result,
            .Params = params
        }
    End Sub


    ' Completion handler (handles both operations)
    Private Sub FileOperationWorker_Completed(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Error IsNot Nothing Then
            ' Handle errors here if needed
            Return
        End If

        Dim resultData As FileOperationResult = DirectCast(e.Result, FileOperationResult)

        ' Raise appropriate completion event based on operation type
        Select Case resultData.Params.Operation
            Case FileOperationType.Delete
                RaiseEvent KillFilesCompleted(Nothing, New FileOperationCompletedEventArgs With {
                    .Result = resultData.ResultValue,
                    .Files = resultData.Params.Files,
                    .Hwnd = resultData.Params.Hwnd
                })
            Case FileOperationType.Recycle
                RaiseEvent RecycleFilesCompleted(Nothing, New FileOperationCompletedEventArgs With {
                    .Result = resultData.ResultValue,
                    .Files = resultData.Params.Files,
                    .Hwnd = resultData.Params.Hwnd
                })
        End Select
    End Sub
    Public Sub DeleteFiles(ByVal files As List(Of String), ByVal hwnd As IntPtr)
        Dim worker As New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf FileOperationWorker_DoWork
        AddHandler worker.RunWorkerCompleted, AddressOf FileOperationWorker_Completed

        ' Package parameters
        Dim params As New FileOperationParams With {
            .Files = files,
            .Hwnd = hwnd,
            .Operation = FileOperationType.Delete
        }

        ' Start async operation
        worker.RunWorkerAsync(params)
    End Sub

    ' Asynchronous version of KillFiles that returns a Task(Of Integer)
    Public Function DeleteFilesAsync(ByVal files As IEnumerable(Of String), ByVal hwnd As IntPtr) As Task(Of Integer)
        Return Task.Run(Function() DoDeleteFiles(files, hwnd))
    End Function

    ' Helper function that performs actual file deletion
    Private Function DoDeleteFiles(ByVal files As IEnumerable(Of String), ByVal hwnd As IntPtr) As Integer
        Dim s As New Native.Api.NativeStructs.SHFILEOPSTRUCT
        Dim multiFrom As String = StringArrayToMultiString(files)
        Dim multiTo As String = StringArrayToMultiString(Nothing)

        ' Allocate unmanaged memory
        Dim pFrom As IntPtr = Marshal.StringToHGlobalUni(multiFrom)
        Dim pTo As IntPtr = Marshal.StringToHGlobalUni(multiTo)

        Try
            With s
                .fAnyOperationsAborted = 0
                .fFlags = Native.Api.NativeEnums.FILEOP_FLAGS_ENUM.FOF_SIMPLEPROGRESS Or Native.Api.NativeEnums.FILEOP_FLAGS_ENUM.FOF_NOCONFIRMATION
                .hNameMappings = IntPtr.Zero
                .hwnd = hwnd
                .lpszProgressTitle = "Delete files"
                .pFrom = pFrom
                .pTo = pTo
                .wFunc = Native.Api.NativeEnums.FO_Func.FO_DELETE
            End With

            Dim ret As Integer = Native.Api.NativeFunctions.SHFileOperation(s)

            Native.Api.NativeFunctions.SHChangeNotify(
                Native.Api.NativeEnums.HChangeNotifyEventID.SHCNE_ALLEVENTS,
                Native.Api.NativeEnums.HChangeNotifyFlags.SHCNF_DWORD,
                IntPtr.Zero,
                IntPtr.Zero
            )

            Return ret
        Finally
            ' Clean up unmanaged memory
            Marshal.FreeHGlobal(pFrom)
            Marshal.FreeHGlobal(pTo)
        End Try
    End Function

    ' New RecycleFiles function (runs asynchronously)
    Public Sub RecycleFiles(ByVal files As List(Of String), ByVal hwnd As IntPtr)
        Dim worker As New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf FileOperationWorker_DoWork
        AddHandler worker.RunWorkerCompleted, AddressOf FileOperationWorker_Completed

        ' Package parameters
        Dim params As New FileOperationParams With {
            .Files = files,
            .Hwnd = hwnd,
            .Operation = FileOperationType.Recycle
        }

        ' Start async operation
        worker.RunWorkerAsync(params)
    End Sub

    ' Asynchronous version of RecycleFiles that returns a Task(Of Integer)
    Public Function RecycleFilesAsync(ByVal files As IEnumerable(Of String), ByVal hwnd As IntPtr) As Task(Of Integer)
        Return Task.Run(Function() DoRecycleFiles(files, hwnd))
    End Function

    ' Helper function that performs actual file recycling
    Private Function DoRecycleFiles(ByVal files As IEnumerable(Of String), ByVal hwnd As IntPtr) As Integer
        Dim s As New Native.Api.NativeStructs.SHFILEOPSTRUCT
        Dim multiFrom As String = StringArrayToMultiString(files)
        Dim multiTo As String = StringArrayToMultiString(Nothing)

        ' Allocate unmanaged memory
        Dim pFrom As IntPtr = Marshal.StringToHGlobalUni(multiFrom)
        Dim pTo As IntPtr = Marshal.StringToHGlobalUni(multiTo)

        Try
            With s
                .fAnyOperationsAborted = 0
                ' Add FOF_ALLOWUNDO flag to send files to recycle bin
                .fFlags = Native.Api.NativeEnums.FILEOP_FLAGS_ENUM.FOF_SIMPLEPROGRESS Or
                         Native.Api.NativeEnums.FILEOP_FLAGS_ENUM.FOF_ALLOWUNDO Or Native.Api.NativeEnums.FILEOP_FLAGS_ENUM.FOF_NOCONFIRMATION
                .hNameMappings = IntPtr.Zero
                .hwnd = hwnd
                .lpszProgressTitle = "Recycle files"
                .pFrom = pFrom
                .pTo = pTo
                .wFunc = Native.Api.NativeEnums.FO_Func.FO_DELETE ' Still use FO_DELETE but with FOF_ALLOWUNDO
            End With

            Dim ret As Integer = Native.Api.NativeFunctions.SHFileOperation(s)

            Native.Api.NativeFunctions.SHChangeNotify(
                Native.Api.NativeEnums.HChangeNotifyEventID.SHCNE_ALLEVENTS,
                Native.Api.NativeEnums.HChangeNotifyFlags.SHCNF_DWORD,
                IntPtr.Zero,
                IntPtr.Zero
            )

            Return ret
        Finally
            ' Clean up unmanaged memory
            Marshal.FreeHGlobal(pFrom)
            Marshal.FreeHGlobal(pTo)
        End Try
    End Function

    Private Shared Function StringArrayToMultiString(ByVal strings As IEnumerable(Of String)) As String
        Dim multiString As String = ""
        If strings Is Nothing Then
            Return ""
        End If
        For Each s As String In strings
            multiString &= s + ControlChars.NullChar
        Next
        multiString &= ControlChars.NullChar
        Return multiString
    End Function


End Class
