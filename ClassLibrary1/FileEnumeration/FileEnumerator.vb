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

' From http://tom-shelton.net/index.php/2010/01/02/using-extension-methods-and-the-win32-api-to-efficiently-enumerate-the-file-system/

Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports NativeWin32

Public Class FileEnumerator
    ' Private
    Private _counter As UInt32 = 0

    ' Excluded directories
    Private _Edirs As List(Of String)
    Private _stopped As Boolean = False

    ' Min/max file size
    Private _maxESize As Long
    Private _minESize As Long
    Private _bEMaxSize As Boolean
    Private _bEMinSize As Boolean
    Private _maxISize As Long
    Private _minISize As Long
    Private _bIMaxSize As Boolean
    Private _bIMinSize As Boolean

    ' File extensions
    Private _bIExt As Boolean
    Private _bEExt As Boolean
    Private _IExt As New List(Of String)
    Private _EExt As New List(Of String)

    ' Dates
    Private _IDateType As DATE_TYPE
    Private _bIDateMin As Boolean
    Private _bIDateMax As Boolean
    Private _IDateMin As Long
    Private _IDateMax As Long
    Private _EDateType As DATE_TYPE
    Private _bEDateMin As Boolean
    Private _bEDateMax As Boolean
    Private _EDateMin As Long
    Private _EDateMax As Long


    ' Public events
    Public Event HasStopped()

    ' Type of date to use
    Public Enum DATE_TYPE
        CreationDate
        LastAccessDate
        LastModifiedDate
    End Enum

#Region "File extensions properties"
    Public Property ExcludeByFileExtension() As Boolean
        Get
            Return _bEExt
        End Get
        Set(ByVal value As Boolean)
            _bEExt = value
        End Set
    End Property
    Public Property ExcludedExtensions() As List(Of String)
        Get
            Return _EExt
        End Get
        Set(ByVal value As List(Of String))
            _EExt = value
        End Set
    End Property
    Public Property IncludeByFileExtension() As Boolean
        Get
            Return _bIExt
        End Get
        Set(ByVal value As Boolean)
            _bIExt = value
        End Set
    End Property
    Public Property IncludedExtensions() As List(Of String)
        Get
            Return _IExt
        End Get
        Set(ByVal value As List(Of String))
            _IExt = value
        End Set
    End Property
#End Region

#Region "Min/max file size"
    Public Property ExcludeByMinSize() As Boolean
        Get
            Return _bEMinSize
        End Get
        Set(ByVal value As Boolean)
            _bEMinSize = value
        End Set
    End Property
    Public Property ExcludeByMaxSize() As Boolean
        Get
            Return _bEMaxSize
        End Get
        Set(ByVal value As Boolean)
            _bEMaxSize = value
        End Set
    End Property
    Public Property EMinSize() As Long
        Get
            Return _minESize
        End Get
        Set(ByVal value As Long)
            _minESize = value
        End Set
    End Property
    Public Property EMaxSize() As Long
        Get
            Return _maxESize
        End Get
        Set(ByVal value As Long)
            _maxESize = value
        End Set
    End Property
    Public Property IncludeByMinSize() As Boolean
        Get
            Return _bIMinSize
        End Get
        Set(ByVal value As Boolean)
            _bIMinSize = value
        End Set
    End Property
    Public Property IncludeByMaxSize() As Boolean
        Get
            Return _bIMaxSize
        End Get
        Set(ByVal value As Boolean)
            _bIMaxSize = value
        End Set
    End Property
    Public Property IMinSize() As Long
        Get
            Return _minISize
        End Get
        Set(ByVal value As Long)
            _minISize = value
        End Set
    End Property
    Public Property IMaxSize() As Long
        Get
            Return _maxISize
        End Get
        Set(ByVal value As Long)
            _maxISize = value
        End Set
    End Property
#End Region

#Region "Dates"
    Public Property IncludedDatesType() As DATE_TYPE
        Get
            Return _IDateType
        End Get
        Set(ByVal value As DATE_TYPE)
            _IDateType = value
        End Set
    End Property
    Public Property IncludeByDateMin() As Boolean
        Get
            Return _bIDateMin
        End Get
        Set(ByVal value As Boolean)
            _bIDateMin = value
        End Set
    End Property
    Public Property IncludeByDateMax() As Boolean
        Get
            Return _bIDateMax
        End Get
        Set(ByVal value As Boolean)
            _bIDateMax = value
        End Set
    End Property
    Public Property IMinDate() As Long
        Get
            Return _IDateMin
        End Get
        Set(ByVal value As Long)
            _IDateMin = value
        End Set
    End Property
    Public Property IMaxDate() As Long
        Get
            Return _IDateMax
        End Get
        Set(ByVal value As Long)
            _IDateMax = value
        End Set
    End Property
    Public Property ExcludedDatesType() As DATE_TYPE
        Get
            Return _EDateType
        End Get
        Set(ByVal value As DATE_TYPE)
            _EDateType = value
        End Set
    End Property
    Public Property ExcludeByDateMin() As Boolean
        Get
            Return _bEDateMin
        End Get
        Set(ByVal value As Boolean)
            _bEDateMin = value
        End Set
    End Property
    Public Property ExcludeByDateMax() As Boolean
        Get
            Return _bEDateMax
        End Get
        Set(ByVal value As Boolean)
            _bEDateMax = value
        End Set
    End Property
    Public Property EDateMin() As Long
        Get
            Return _EDateMin
        End Get
        Set(ByVal value As Long)
            _EDateMin = value
        End Set
    End Property
    Public Property EMaxDate() As Long
        Get
            Return _EDateMax
        End Get
        Set(ByVal value As Long)
            _EDateMax = value
        End Set
    End Property
#End Region

    ' List of directories to exclude
    ' MUST BE UPPER CASE
    Public Property ExcludedDirectories() As List(Of String)
        Get
            Return _Edirs
        End Get
        Set(ByVal value As List(Of String))
            _Edirs = value
        End Set
    End Property

    ' Stop enumeration
    Public Sub [Stop]()
        _stopped = True
    End Sub

    ' Public sub
    Public Sub EnumerateFiles(ByVal target As DirectoryInfo, ByVal searchPattern As String, ByRef list As List(Of cSimpleFile))
        _stopped = False
        _counter = 0
        pvtEnumerateFiles(target, searchPattern, list)
    End Sub

#Region "Private"

    Private Sub pvtEnumerateFiles(ByVal target As DirectoryInfo, ByVal searchPattern As String, ByRef list As List(Of cSimpleFile))
        ' Get sur dir recursive
        If _Edirs.Contains(target.FullName.ToUpper) = False Then

            ' Enumerate files
            For Each subdir In EnumerateDirectories(target, searchPattern)
                EnumerateFiles(subdir, searchPattern, list)
                If _stopped Then
                    RaiseEvent HasStopped()
                    Exit Sub
                End If
                'Application.DoEvents()
            Next

            ' Add files to list
            Dim hasToCheckSize As Boolean = (_bEMaxSize OrElse _
                                             _bEMinSize OrElse _
                                             _bIMaxSize OrElse _
                                             _bIMinSize)
            Dim hasToCheckDate As Boolean = (_bEDateMax OrElse _
                                             _bEDateMin OrElse _
                                             _bIDateMax OrElse _
                                             _bIDateMin)

            For Each _file In EnumerateFiles(target, searchPattern)
                Dim toAdd As Boolean = True
                Dim fileSize As Long = 0
                Dim fileDate As Long = 0

                ' =========== Check extensions
                ' Excluded extensions
                If _bEExt Then
                    If cFile.DoesExtensionMatch(_file.Path, _EExt) Then
                        toAdd = False
                    End If
                End If

                ' Included extensions
                If toAdd Then
                    If _bIExt Then
                        If Not (cFile.DoesExtensionMatch(_file.Path, _IExt)) Then
                            toAdd = False
                        End If
                    End If
                End If


                ' =========== Check sizes
                ' Get file size if necessary
                If toAdd Then
                    If hasToCheckSize Then
                        fileSize = _file._Size
                    End If

                    ' Exclude by file size
                    If (_bEMinSize AndAlso fileSize < _minESize) Then
                        toAdd = False
                    End If
                    If (_bEMaxSize AndAlso fileSize > _maxESize) Then
                        toAdd = False
                    End If

                    ' Include by file size
                    If toAdd Then
                        If (_bIMinSize AndAlso Not (fileSize < _minISize)) Then
                            toAdd = False
                        End If
                        If (_bIMaxSize AndAlso Not (fileSize > _maxISize)) Then
                            toAdd = False
                        End If
                    End If
                End If


                ' =========== Check dates
                If toAdd Then

                    If hasToCheckDate Then
                        ' For now, _IDateType == _EDateType
                        Select Case _IDateType
                            Case DATE_TYPE.CreationDate
                                fileDate = _file._CreatedDate
                            Case DATE_TYPE.LastModifiedDate
                                fileDate = _file._ModifiedDate
                            Case Else
                                fileDate = _file._AccessedDate
                        End Select
                    End If

                    ' Excluded dates
                    If (_bEDateMin AndAlso fileDate < _EDateMin) Then
                        toAdd = False
                    End If
                    If (_bEDateMax AndAlso fileDate > _EDateMax) Then
                        toAdd = False
                    End If

                    ' Included dates
                    If toAdd Then
                        If (_bIDateMin AndAlso Not (fileDate < _IDateMin)) Then
                            toAdd = False
                        End If
                        If (_bIDateMax AndAlso Not (fileDate > _IDateMax)) Then
                            toAdd = False
                        End If
                    End If
                End If


                ' =========== Add to the list
                If toAdd Then
                    _file.OriginalOrder = _counter
                    list.Add(_file)
                    _counter += CUInt(1)
                End If

            Next
        End If
    End Sub

    Private Function EnumerateDirectories(ByVal target As DirectoryInfo) As IEnumerable(Of DirectoryInfo)
        Return EnumerateDirectories(target, "*")
    End Function

    Private Function EnumerateDirectories(ByVal target As DirectoryInfo, ByVal searchPattern As String) As IEnumerable(Of DirectoryInfo)
        Dim ret As New List(Of DirectoryInfo)
        Dim searchPath As String = Path.Combine(target.FullName, searchPattern)
        Dim findData As New NativeWin32.WIN32_FIND_DATA
        Using hFindFile As NativeWin32.SafeSearchHandle = NativeWin32.FindFirstFile(searchPath, findData)
            If Not hFindFile.IsInvalid Then
                Do
                    If (findData.dwFileAttributes And FileAttributes.Directory) <> 0 AndAlso findData.cFileName <> "." AndAlso findData.cFileName <> ".." Then
                        ret.Add(New DirectoryInfo(Path.Combine(target.FullName, findData.cFileName)))
                    End If
                Loop While NativeWin32.FindNextFile(hFindFile, findData)
            End If
        End Using
        Return ret
    End Function

    Private Function EnumerateFiles(ByVal target As DirectoryInfo) As IEnumerable(Of cSimpleFile)
        Return EnumerateFiles(target, "*")
    End Function

    Private Function EnumerateFiles(ByVal target As DirectoryInfo, ByVal searchPattern As String) As IEnumerable(Of cSimpleFile)
        Dim ret As New List(Of cSimpleFile)
        Dim searchPath As String = Path.Combine(target.FullName, searchPattern)
        Dim findData As New NativeWin32.WIN32_FIND_DATA
        Using hFindFile As NativeWin32.SafeSearchHandle = NativeWin32.FindFirstFile(searchPath, findData)
            If Not hFindFile.IsInvalid Then
                Do
                    If (findData.dwFileAttributes And FileAttributes.Directory) = 0 AndAlso findData.cFileName <> "." AndAlso findData.cFileName <> ".." Then
                        ret.Add(New cSimpleFile(findData, Path.Combine(target.FullName, findData.cFileName)))
                    End If
                Loop While NativeWin32.FindNextFile(hFindFile, findData)
            End If
        End Using
        Return ret
    End Function

#End Region

End Class