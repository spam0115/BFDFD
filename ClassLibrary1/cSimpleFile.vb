
Option Strict On
' =======================================================
' Big Fast Duplicate File Deleter! (BFDFD)
' Copyright (c) 2008-2009 Alain Descotes (violent_ken)
' https://sourceforge.net/projects/yadfr/
' =======================================================


' Big Fast Duplicate File Deleter! is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 3 of the License, or
' (at your option) any later version.
'
' Big Fast Duplicate File Deleter! is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with Big Fast Duplicate File Deleter!; if not, see http://www.gnu.org/licenses/.

' Structure concerning a file

Imports Native.Api

Public Class cSimpleFile

    ' Private attributes
    Public Id As Integer
    Public _GroupId As Integer
    Public _CreatedDate As Long = -1
    Public _ModifiedDate As Long = -1
    Public _AccessedDate As Long = -1
    Public _Path As String
    Public _FileType As String
    Public _Size As Long = -1
    'Private _find_data As NativeWin32.WIN32_FIND_DATA
    Public _Checked As Boolean = False
    Public _MiddleContent As UInt64
    Public _Hash As Byte()

    Private Shared ReadOnly INVALID_HANDLE_VALUE As IntPtr = New IntPtr(-1)

    'public
    Public OriginalOrder As UInt32 = 0

    ' Public enum
    Public Enum EHashAlgorithm
        MD5 = 0
        SHA1 = 1
    End Enum

    ' Shared
    Private Shared _HashAlgorithm As EHashAlgorithm
    Private Shared _hashExpectedSize As Integer
    Public Shared Property HashAlgorithm() As EHashAlgorithm
        Get
            Return _HashAlgorithm
        End Get
        Set(ByVal value As EHashAlgorithm)
            _HashAlgorithm = value
            Select Case _HashAlgorithm
                Case EHashAlgorithm.MD5
                    _hashExpectedSize = &H10
                Case EHashAlgorithm.SHA1
                    _hashExpectedSize = &H14
            End Select
        End Set
    End Property


    ' Constructor
    Public Sub New(ByRef file As NativeWin32.WIN32_FIND_DATA, ByVal path As String)
        _Path = path
        '_find_data = file

        _Size = file.Size
        _CreatedDate = file.DateC
        _ModifiedDate = file.DateW
        _FileType = _Path.Split("."c).Last()

    End Sub

    Public Sub New(id As Integer, fileName As String, fileType As String, fileSizeBytes As Long, createdDate As DateTime, modifiedDate As DateTime, group As Integer, checked As Boolean)
        Me.Id = id
        Me._Path = fileName
        Me._FileType = fileType
        Me._Size = fileSizeBytes
        Me._CreatedDate = createdDate.ToFileTime
        Me._ModifiedDate = modifiedDate.ToFileTime
        Me._GroupId = group
        Me._Checked = checked

        _Hash = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8,
         &H9, &HA, &HB, &HC, &HD, &HE, &HF, &H10,
         &H11, &H12, &H13, &H14, &H15, &H16, &H17, &H18,
         &H19, &H1A, &H1B, &H1C, &H1D, &H1E, &H1F, &H20}
    End Sub

    ' Public properties

    Public ReadOnly Property CreatedDate() As String
        Get
            Return DateTime.FromFileTime(_CreatedDate).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff")
        End Get
    End Property

    Public ReadOnly Property ModifiedDate() As String
        Get
            Return DateTime.FromFileTime(_ModifiedDate).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss.fff")
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            Return _Path
        End Get
    End Property
    Public ReadOnly Property Size() As String
        Get
            'If _Size = -1 Then
            '    _Size = _find_data.Size
            'End If

            If _Size < 1024 Then
                Return $"{_Size} B"
            ElseIf _Size < 1048576 Then
                Return $"{_Size / 1024:F2} KB"
            ElseIf _Size < (1048576 * 1024) Then
                Return $"{_Size / (1048576):F2} MB"
            Else
                Return $"{_Size / (1048576 * 1024):F2} GB"
            End If

        End Get

    End Property

    Public ReadOnly Property Hash() As Byte()
        Get
            Return _Hash
        End Get
    End Property

    ' Comparison methods for SimpleFile struct
    Public Shared Function CompareByLength(ByVal x As cSimpleFile, ByVal y As cSimpleFile) As Integer
        Return x._Size.CompareTo(y._Size)
    End Function

    Public Shared Function CompareByHash(ByVal x As cSimpleFile, ByVal y As cSimpleFile) As Integer
        Return CompareByteArrays(x._Hash, y._Hash)
    End Function

    Public Shared Function CompareByteArrays(array1 As Byte(), array2 As Byte()) As Integer
        ' Handle null/Nothing cases
        If array1 Is Nothing Then Return If(array2 Is Nothing, 0, -1)
        If array2 Is Nothing Then Return 1

        ' Compare byte-by-byte up to the length of the shorter array
        Dim minLength As Integer = Math.Min(array1.Length, array2.Length)
        For i As Integer = 0 To minLength - 1
            Select Case array1(i).CompareTo(array2(i))
                Case Is < 0 : Return -1
                Case Is > 0 : Return 1
            End Select
        Next

        ' All compared bytes are equal - compare lengths
        Return array1.Length.CompareTo(array2.Length)
    End Function

    Public Shared Function CompareByContent(ByVal x As cSimpleFile, ByVal y As cSimpleFile) As Integer
        Dim x1 As String = x.Size & "-" & x._MiddleContent.ToString()
        Dim y1 As String = y.Size & "-" & y._MiddleContent.ToString()
        Return x1.CompareTo(y1)
    End Function

    ' Compute hash
    Public Sub ComputeHash()
        Select Case cSimpleFile.HashAlgorithm
            Case EHashAlgorithm.MD5
                _Hash = cHash.GetMD5HashFromFile(_Path)
            Case EHashAlgorithm.SHA1
                _Hash = cHash.GetSHA1HashFromFile(_Path)
        End Select
    End Sub

    ' Retrieve 64bits from the middle of the file.
    ' The idea here is to do a simple comparison of 64bits before calculating a hash.
    ' Calculating the hash is expensive so doing a simple comparison can remove the need to calculate a hash if the file fails the simple comparison.
    ' However, performing an additional IO is expensive so it is better to just do the hash if the file size is small.
    ' Given that it take 1 milliseconds to compute a hash for an average file and .1 milliseconds to access a file on an nvme drive, 
    ' it is not worth avoiding the hash calculation if the file is less than ~1/10th the size of an average file.  However, since unequal files matching in size coincidentally when 
    ' the size number is > 1million is low, the odds of the middle comparison helping you out is low so we will use a threshold value
    ' bigger than 1/2MB.
    Public Sub ReadMiddle64Bits()
        ' Read it only if size > minSize
        If Me._Size >= 1048576 / 30 Then
            ' At the middle of the file
            _MiddleContent = BitConverter.ToUInt64(ReadBytesFromFile(Path, _Size \ 2, 8), 0)
        End If
    End Sub

    ' Read a byte in a file
    Public Shared Function ReadBytesFromFile(ByVal file As String, ByVal pos As Long, ByVal size As Integer) As Byte()
        Dim ret(size - 1) As Byte
        Dim hFile As IntPtr = Native.Api.NativeFunctions.CreateFile(file,
                            Native.Api.NativeEnums.EFileAccess._GenericRead,
                            Native.Api.NativeEnums.EFileShare._Read,
                            IntPtr.Zero,
                            Native.Api.NativeEnums.ECreationDisposition._OpenExisting,
                            0,
                            IntPtr.Zero)
        If hFile.IsNotNull And hFile <> INVALID_HANDLE_VALUE Then
            Dim pt As Long
            Native.Api.NativeFunctions.SetFilePointerEx(hFile,
                                                        pos,
                                                        pt,
                                                        Native.Api.NativeEnums.EMoveMethod.FILE_BEGIN)
            Dim read As UInteger
            Native.Api.NativeFunctions.ReadFile(hFile, ret, CUInt(size), read, IntPtr.Zero)
            Native.Api.NativeFunctions.CloseHandle(hFile)
        End If
        Return ret
    End Function

End Class