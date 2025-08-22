Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms.VisualStyles

Public Class FileOperationEngine

    Private Const CLSID_FileOperation As String = "3ad05575-8857-4850-9277-11b85bdb8e09"

    Private _totalFiles As Integer
    Private _processedFiles As Integer
    Private _isRunning As Boolean
    Private ReadOnly _chunkSize As Integer = 200

    Public Shared _pause As Boolean = False
    Public Event ProgressChanged(processedCount As Integer, totalCount As Integer, files As IEnumerable(Of String), message As String)
    Public Event Completed(success As Boolean, errorMessage As String)

#Region "Private interfaces"
    ' Add declaration to create COM object from CLSID
    <DllImport("ole32.dll", PreserveSig:=False)>
    Private Shared Function CoCreateInstance(
        <MarshalAs(UnmanagedType.LPStruct)> rclsid As Guid,
        pUnkOuter As IntPtr,
        dwClsContext As CLSCTX,
        <MarshalAs(UnmanagedType.LPStruct)> riid As Guid) As IFileOperation
    End Function

    Private Enum CLSCTX As UInteger
        CLSCTX_INPROC_SERVER = &H1
        CLSCTX_INPROC_HANDLER = &H2
        CLSCTX_LOCAL_SERVER = &H4
        CLSCTX_REMOTE_SERVER = &H10
        CLSCTX_ALL = CLSCTX_INPROC_SERVER Or CLSCTX_INPROC_HANDLER Or CLSCTX_LOCAL_SERVER Or CLSCTX_REMOTE_SERVER
    End Enum

    ' Minimal definition of IFileOperationProgressSink (we only pass Nothing)
    <ComImport>
    <Guid("04b0f1a7-9490-44bc-96e1-4296a31252e2")>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IFileOperationProgressSink
        ' Empty interface - we only need the declaration
    End Interface

    <ComImport>
    <Guid("947aab5f-0a5c-4c13-b4d6-4bf7836fc9f8")>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IFileOperation
        Function Advise(pfops As IFileOperationProgressSink, ByRef pdwCookie As UInteger) As Integer
        Function Unadvise(dwCookie As UInteger) As Integer
        Function SetOperationFlags(dwOperationFlags As FileOperationFlags) As Integer
        Function SetProgressMessage(<MarshalAs(UnmanagedType.LPWStr)> pszMessage As String) As Integer
        Function SetProgressDialog(popd As Object) As Integer
        Function SetProperties(pproparray As Object) As Integer
        Function SetOwnerWindow(hwndOwner As IntPtr) As Integer
        Function ApplyPropertiesToItem(psiItem As IShellItem) As Integer
        Function ApplyPropertiesToItems(punkItems As Object) As Integer
        Function RenameItem(psiItem As IShellItem, <MarshalAs(UnmanagedType.LPWStr)> pszNewName As String, pfopsItem As IFileOperationProgressSink) As Integer
        Function RenameItems(pUnkItems As Object, <MarshalAs(UnmanagedType.LPWStr)> pszNewName As String) As Integer
        Function MoveItem(psiItem As IShellItem, psiDestinationFolder As IShellItem, <MarshalAs(UnmanagedType.LPWStr)> pszNewName As String, pfopsItem As IFileOperationProgressSink) As Integer
        Function MoveItems(punkItems As Object, psiDestinationFolder As IShellItem) As Integer
        Function CopyItem(psiItem As IShellItem, psiDestinationFolder As IShellItem, <MarshalAs(UnmanagedType.LPWStr)> pszCopyName As String, pfopsItem As IFileOperationProgressSink) As Integer
        Function CopyItems(punkItems As Object, psiDestinationFolder As IShellItem) As Integer
        Function DeleteItem(psiItem As IShellItem, pfopsItem As IFileOperationProgressSink) As Integer
        Function DeleteItems(punkItems As Object) As Integer
        Function NewItem(psiDestinationFolder As IShellItem, dwFileAttributes As UInteger, <MarshalAs(UnmanagedType.LPWStr)> pszName As String, <MarshalAs(UnmanagedType.LPWStr)> pszTemplateName As String, pfopsItem As IFileOperationProgressSink) As Integer
        Function PerformOperations() As Integer
        Function GetAnyOperationsAborted(ByRef pfAnyOperationsAborted As Boolean) As Integer
    End Interface

    <ComImport>
    <Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IShellItem
        Sub BindToHandler(pbc As IntPtr, <MarshalAs(UnmanagedType.LPStruct)> bhid As Guid, <MarshalAs(UnmanagedType.LPStruct)> riid As Guid, ByRef ppv As IntPtr)
        Sub GetParent(ByRef ppsi As IShellItem)
        Sub GetDisplayName(sigdnName As SIGDN, <MarshalAs(UnmanagedType.LPWStr)> ByRef ppszName As String)
        Sub GetAttributes(sfgaoMask As UInteger, ByRef psfgaoAttribs As UInteger)
        Sub Compare(psi As IShellItem, hint As UInteger, ByRef piOrder As Integer)
    End Interface

    <Flags>
    Private Enum FileOperationFlags As UInteger
        FOF_SILENT = &H4
        FOF_NOCONFIRMATION = &H10
        FOF_ALLOWUNDO = &H40
        FOF_NO_UI = FOF_SILENT Or FOF_NOCONFIRMATION Or FOF_NOERRORUI 'Or FOF_NOCONFIRMMKDIR
        FOF_NOERRORUI = &H400
        FOF_WANTNUKEWARNING = &H4000
    End Enum

    Private Enum SIGDN As UInteger
        SIGDN_DESKTOPABSOLUTEEDITING = &H8004C000UI
        SIGDN_DESKTOPABSOLUTEPARSING = &H80028000
        SIGDN_FILESYSPATH = &H80058000
        SIGDN_NORMALDISPLAY = 0
        SIGDN_PARENTRELATIVE = &H80080001
        SIGDN_PARENTRELATIVEEDITING = &H80031001
        SIGDN_PARENTRELATIVEFORADDRESSBAR = &H8007C001
        SIGDN_PARENTRELATIVEPARSING = &H80018001
        SIGDN_URL = &H80068000
    End Enum

    <DllImport("shell32.dll", CharSet:=CharSet.Unicode, PreserveSig:=False)>
    Private Shared Sub SHCreateItemFromParsingName(
        <[In], MarshalAs(UnmanagedType.LPWStr)> pszPath As String,
        <[In]> pbc As IntPtr,
        <[In], MarshalAs(UnmanagedType.LPStruct)> riid As Guid,
        <Out> ByRef ppv As IShellItem)
    End Sub

#End Region

    Private Shared Function CreateFileOperation() As IFileOperation
        Dim clsid As New Guid(CLSID_FileOperation)
        Dim iid As Guid = GetType(IFileOperation).GUID
        Return CoCreateInstance(clsid, IntPtr.Zero, CLSCTX.CLSCTX_ALL, iid)
    End Function

    ''' <summary>
    ''' Sends a file or directory to the Recycle Bin
    ''' </summary>
    Public Shared Sub SendToRecycleBin(path As String)
        PerformFileOperation(path, True)
    End Sub

    ''' <summary>
    ''' Permanently deletes a file or directory (bypasses Recycle Bin)
    ''' </summary>
    Public Shared Sub DeletePermanently(path As String)
        PerformFileOperation(path, False)
    End Sub

    Private Shared Sub PerformFileOperation(path As String, recycle As Boolean)
        If String.IsNullOrEmpty(path) Then
            Throw New ArgumentException("Path cannot be null or empty", NameOf(path))
        End If

        If Not File.Exists(path) AndAlso Not Directory.Exists(path) Then
            Throw New FileNotFoundException("Path not found", path)
        End If

        Dim fileOp As IFileOperation = Nothing
        Dim item As IShellItem = Nothing

        Try
            ' Create IFileOperation instance
            fileOp = CreateFileOperation()

            ' Configure flags
            Dim flags As FileOperationFlags = FileOperationFlags.FOF_NO_UI
            If recycle Then flags = flags Or FileOperationFlags.FOF_ALLOWUNDO

            fileOp.SetOperationFlags(flags)

            ' Create IShellItem from path
            Dim shellItemGuid As Guid = GetType(IShellItem).GUID
            SHCreateItemFromParsingName(path, IntPtr.Zero, shellItemGuid, item)

            ' Queue deletion
            fileOp.DeleteItem(item, Nothing)

            ' Execute operation
            fileOp.PerformOperations()
        Catch ex As Exception
            Throw New InvalidOperationException(
                $"Failed to {(If(recycle, "recycle", "permanently delete"))} file/directory", ex)
        Finally
            ' Cleanup COM objects
            If item IsNot Nothing Then Marshal.FinalReleaseComObject(item)
            If fileOp IsNot Nothing Then Marshal.FinalReleaseComObject(fileOp)
        End Try
    End Sub

    ''' <summary>
    ''' Sends multiple files/directories to the Recycle Bin (bulk operation)
    ''' </summary>
    Public Shared Sub SendToRecycleBin(paths As IEnumerable(Of String))
        PerformBulkOperation(paths, FileOperationType.Recycle)
    End Sub

    Private Shared Sub DeletePermanently(paths As IEnumerable(Of String))
        PerformBulkOperation(paths, FileOperationType.Delete)
    End Sub

    Private Shared Sub MoveFiles(paths As List(Of String), destinationPath As String)
        PerformBulkOperation(paths, FileOperationType.Move, destinationPath)
    End Sub

    Private Shared Sub PerformBulkOperation(paths As IEnumerable(Of String), operationType As FileOperationType, Optional destinationPath As String = Nothing)
        Dim fileOp As IFileOperation = Nothing
        Dim shellItems As New List(Of IShellItem)
        Dim destinationItem As IShellItem = Nothing
        Dim resultCount As Integer = 0

        Try
            ' Create IFileOperation instance
            fileOp = CreateFileOperation()

            ' Configure flags
            Dim flags As FileOperationFlags = FileOperationFlags.FOF_NO_UI
            If operationType = FileOperationType.Recycle Then
                flags = flags Or FileOperationFlags.FOF_ALLOWUNDO
            End If

            fileOp.SetOperationFlags(flags)

            ' Create destination shell item for move operations
            If operationType = FileOperationType.Move Then
                If String.IsNullOrEmpty(destinationPath) Then
                    Throw New ArgumentException("'destinationPath' must have a value when trying to move files.")
                End If

                Dim shellItemGuid As Guid = GetType(IShellItem).GUID
                SHCreateItemFromParsingName(destinationPath, IntPtr.Zero, shellItemGuid, destinationItem)
            End If

            ' Process all paths
            For Each path As String In paths
                If String.IsNullOrEmpty(path) Then Continue For

                Dim shellItemGuid As Guid = GetType(IShellItem).GUID
                Dim item As IShellItem = Nothing
                SHCreateItemFromParsingName(path, IntPtr.Zero, shellItemGuid, item)

                Select Case operationType
                    Case FileOperationType.Delete, FileOperationType.Recycle
                        fileOp.DeleteItem(item, Nothing)
                    Case FileOperationType.Move
                        If destinationItem IsNot Nothing Then
                            fileOp.MoveItem(item, destinationItem, Nothing, Nothing)
                        Else
                            Throw New ArgumentException("Destination path is required for move operations")
                        End If
                End Select

                shellItems.Add(item)
            Next

            While (_pause)
                Thread.Sleep(250)
            End While

            ' Execute if we have items
            If shellItems.Count > 0 Then
                resultCount = fileOp.PerformOperations()
            End If
        Finally
            ' Cleanup all COM objects
            For Each item In shellItems
                If item IsNot Nothing Then Marshal.FinalReleaseComObject(item)
            Next
            If destinationItem IsNot Nothing Then Marshal.FinalReleaseComObject(destinationItem)
            If fileOp IsNot Nothing Then Marshal.FinalReleaseComObject(fileOp)
        End Try
    End Sub

    ''' <summary>
    ''' Processes files in background with progress reporting and chunked operations
    ''' </summary>
    Public Sub PerformFileOperationInBackground(paths As IEnumerable(Of String), operation As FileOperationType, destinationPath As String)

        _totalFiles = If(paths IsNot Nothing, paths.Count(), 0)

        If _isRunning Then Throw New InvalidOperationException("Operation already running")
        If _totalFiles = 0 Then
            RaiseEvent Completed(True, "Zero files to process.")
            Return
        End If

        _isRunning = True
        _processedFiles = 0

        Task.Run(Sub() ProcessFilesBackground(paths, operation, destinationPath)) 'this has to be done before any calls to "Appplication.DoEvents" because DoEvents will exit the current program flow

        RaiseEvent ProgressChanged(0, _totalFiles, Nothing, Nothing) 'initial notification with zero 

    End Sub

    Public ReadOnly Property IsRunning() As Boolean
        Get
            Return _isRunning
        End Get
    End Property


    Private Sub ProcessFilesBackground(paths As IEnumerable(Of String), operation As FileOperationType, Optional destinationPath As String = Nothing)
        Dim success = True
        Dim errorMsg As String = Nothing

        Try
            ' Split into chunks of 1000 files
            Dim chunks = paths.ChunkBy(_chunkSize)
            Dim currentChunk As Integer = 0

            For Each chunk In chunks
                currentChunk += 1
                Dim chunkList = chunk.ToList()

                Try
                    ' Process the batch (recycle or delete)
                    If operation = FileOperationType.Recycle Then
                        FileOperationEngine.SendToRecycleBin(chunkList)
                    ElseIf operation = FileOperationType.Delete Then
                        FileOperationEngine.DeletePermanently(chunkList)
                    Else
                        FileOperationEngine.MoveFiles(chunkList, destinationPath)
                    End If
                Catch ex As Exception
                    ' Record first error but continue processing
                    If success Then
                        success = False
                        errorMsg = $"Error processing chunk {currentChunk}: {chunks.Count()}\n\n{ex.Message}"
                        RaiseEvent ProgressChanged(_processedFiles, _totalFiles, Nothing, errorMsg)
                    End If
                End Try

                ' Update progress
                _processedFiles += chunkList.Count
                RaiseEvent ProgressChanged(_processedFiles, _totalFiles, chunk, Nothing)
            Next
        Catch ex As Exception
            success = False
            errorMsg = $"Critical error: {ex.Message}"
        Finally
            _isRunning = False
            RaiseEvent Completed(success, errorMsg)
        End Try
    End Sub


End Class