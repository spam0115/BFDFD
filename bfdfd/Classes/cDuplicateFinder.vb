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

Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent
Imports System.Linq

Public Class cDuplicateFinder

    ' List of directories
    Private _Idirs As List(Of String)
    Private _Edirs As List(Of String)

    ' List of found files and their size
    Private _files As List(Of cSimpleFile)

    ' ProgessBarText for progress
    Private _progressBarText As ProgressBarText

    ' Stopped ?
    Private _stopped As Boolean = False
    Public _pause As Boolean = False

    ' File enumerator
    Private WithEvents _enum As New FileEnumerator

    ' Thread configuration
    'Private _maxThreads As Integer = Math.Min(4, Environment.ProcessorCount) 'gains after 2 threads are small

    Private _UiLock As New Object()


    ' Public events
    Public Event StopEvent()
    Public Event CompleteEvent(sender As Object, e As EventArgs)

    Public Sub New()
        _Idirs = New List(Of String)
        _Edirs = New List(Of String)
        _files = New List(Of cSimpleFile)
    End Sub

    ' List of directories to include
    Public Property IncludedDirectories() As List(Of String)
        Get
            Return _Idirs
        End Get
        Set(ByVal value As List(Of String))
            _Idirs = value
        End Set
    End Property

    ' List of directories to exclude
    Public Property ExcludedDirectories() As List(Of String)
        Get
            Return _Edirs
        End Get
        Set(ByVal value As List(Of String))
            _Edirs = value
        End Set
    End Property

    ' Result
    Public ReadOnly Property Files() As List(Of cSimpleFile)
        Get
            Return _files
        End Get
    End Property

    ' ProgressBarText
    Public Property ProgressBarText() As ProgressBarText
        Get
            Return _progressBarText
        End Get
        Set(ByVal value As ProgressBarText)
            _progressBarText = value
        End Set
    End Property

    ' File enumerator
    Public Property FileEnumerator() As FileEnumerator
        Get
            Return _enum
        End Get
        Set(ByVal value As FileEnumerator)
            _enum = value
        End Set
    End Property


    ' GO !
    Public Function Go(ByRef time As Long) As Long

        time = Date.Now.Ticks

        ' Clear list
        _files.Clear()

        ' Enumerate files
        Me.setProgressText(1, 11, "Creating list of files...")
        _enum.ExcludedDirectories = Me.ExcludedDirectories
        Dim listAllFiles As New List(Of cSimpleFile)
        For Each path In _Idirs
            Dim root As New IO.DirectoryInfo(path)
            Dim listFilesTmp As New List(Of cSimpleFile)
            _enum.EnumerateFiles(root, "*", listFilesTmp)
            If _stopped Then
                _stopped = False
                RaiseEvent StopEvent()
                Return 0
            End If
            For Each file In listFilesTmp
                listAllFiles.Add(file)
                If _stopped Then
                    _stopped = False
                    RaiseEvent StopEvent()
                    Return 0
                End If
            Next
        Next

        ' Now sort file list by file size
        Me.setProgressText(2, 11, String.Format("Sorting list by file size ({0} files)...", listAllFiles.Count))
        listAllFiles.Sort(AddressOf cSimpleFile.CompareByLength)

        ' Now remove all files with a unique size
        Me.setProgressText(3, 11, String.Format("Removing files with a unique file size from list ({0} files)...", listAllFiles.Count))
        Dim listFilesFilteredForSize As New List(Of cSimpleFile)
        For i As Integer = 1 To listAllFiles.Count - 2
            If listAllFiles(i)._Size > 0 AndAlso ((listAllFiles(i)._Size = listAllFiles(i - 1)._Size) OrElse (listAllFiles(i)._Size = listAllFiles(i + 1)._Size)) Then
                listFilesFilteredForSize.Add(listAllFiles(i))
            End If
            If _stopped Then
                _stopped = False
                RaiseEvent StopEvent()
                Return 0
            End If
        Next

        If listAllFiles.Count > 0 AndAlso listAllFiles(listAllFiles.Count - 1)._Size > 0 AndAlso (listAllFiles(listAllFiles.Count - 1)._Size = listAllFiles(listAllFiles.Count - 2)._Size) Then
            listFilesFilteredForSize.Add(listAllFiles(listAllFiles.Count - 1))
        End If
        listAllFiles = Nothing

        ' Now read the middle 64bits of the file for big files (MULTI-THREADED)
        listFilesFilteredForSize.Sort(Function(o As cSimpleFile, o2 As cSimpleFile) o.Id.CompareTo(o2.Id))
        'listFilesFilteredForSize = listFilesFilteredForSize.OrderBy(Function(o) o.OriginalOrder).ToList() 'sort by original order to provide better file spatial locality
        Me.setProgressText(4, 11, "Checking the middle bits")

        Dim maxThreads As Integer = Math.Min(8, Environment.ProcessorCount) 'gains after 2 threads are small
        If Not ProcessFilesInParallel(listFilesFilteredForSize, AddressOf ProcessMiddleContent, maxThreads, "Checking the middle bits") Then
            Return 0
        End If

        ' Now sort file list by middle bits
        Me.setProgressText(5, 11, String.Format("Sorting list by content ({0} files)...", listFilesFilteredForSize.Count))
        listFilesFilteredForSize.Sort(Function(o As cSimpleFile, o2 As cSimpleFile) o._MiddleContent.CompareTo(o2._MiddleContent))

        ' Now remove all files with a unique middle bytes
        Me.setProgressText(6, 11, String.Format("Removing files with unique content from list ({0} files)...", listFilesFilteredForSize.Count))
        Dim listFilesFilteredByMiddleData As New List(Of cSimpleFile)
        For i As Integer = 0 To listFilesFilteredForSize.Count - 1
            If (i < listFilesFilteredForSize.Count - 1 _
                    AndAlso (listFilesFilteredForSize(i)._MiddleContent = listFilesFilteredForSize(i + 1)._MiddleContent) _
                    OrElse (i > 0 AndAlso (listFilesFilteredForSize(i)._MiddleContent = listFilesFilteredForSize(i - 1)._MiddleContent))) Then
                listFilesFilteredByMiddleData.Add(listFilesFilteredForSize(i))
            End If
            If _stopped Then
                _stopped = False
                RaiseEvent StopEvent()
                Return 0
            End If
        Next
        listFilesFilteredForSize = Nothing

        ' Now calculate hashs (MULTI-THREADED)
        listFilesFilteredByMiddleData.Sort(Function(o As cSimpleFile, o2 As cSimpleFile) o.Id.CompareTo(o2.Id)) 'sort by original order again to provide better file spatial locality
        'listFilesFilteredByMiddleData = listFilesFilteredByMiddleData.OrderBy(Function(o) o.OriginalOrder).ToList() 'sort by original order again to provide better file spatial locality
        Me.setProgressText(7, 11, "Calculating hashes")
        cSimpleFile.HashAlgorithm = CType(My.Settings.HashAlgo, cSimpleFile.EHashAlgorithm)
        maxThreads = Math.Min(4, Environment.ProcessorCount) 'gains after 2 threads are small
        If Not ProcessFilesInParallel(listFilesFilteredByMiddleData, AddressOf ProcessHash, maxThreads, "Calculating hashes") Then
            Return 0
        End If

        ' Now sort file list by file hash
        Me.setProgressText(8, 11, String.Format("Sorting list by hash ({0} files)...", listFilesFilteredByMiddleData.Count))
        listFilesFilteredByMiddleData.Sort(AddressOf cSimpleFile.CompareByHash)

        ' Now remove all files with a unique hash
        Me.setProgressText(9, 11, String.Format("Removing files with unique hash from list ({0} files)...", listFilesFilteredByMiddleData.Count))
        Dim listFilesFilteredByHash As New List(Of cSimpleFile)
        For i As Integer = 0 To listFilesFilteredByMiddleData.Count - 1
            If listFilesFilteredByMiddleData(i)._Hash IsNot Nothing AndAlso (i < listFilesFilteredByMiddleData.Count - 1 AndAlso (listFilesFilteredByMiddleData(i)._Hash.SequenceEqual(listFilesFilteredByMiddleData(i + 1)._Hash)) _
                    OrElse (i > 0 AndAlso listFilesFilteredByMiddleData(i)._Hash.SequenceEqual(listFilesFilteredByMiddleData(i - 1)._Hash))) Then
                listFilesFilteredByHash.Add(listFilesFilteredByMiddleData(i))
            End If
            If _stopped Then
                _stopped = False
                RaiseEvent StopEvent()
                Return 0
            End If
        Next
        listFilesFilteredByMiddleData = Nothing

        'add group numbers
        Dim g As Integer = 1
        'Dim j As UInt32 = 0
        If (listFilesFilteredByHash.Count > 0) Then
            Dim priorFile As cSimpleFile = listFilesFilteredByHash(0)
            For Each file In listFilesFilteredByHash
                If Not file._Hash.SequenceEqual(priorFile._Hash) Then
                    g += 1
                    priorFile = file
                End If

                'file.Id = j
                file._GroupId = g
                'j += 1UI
            Next
        End If

        '
        _files = listFilesFilteredByHash

        time = Date.Now.Ticks - time

        Trace.WriteLine("It took " & (time \ 10000).ToString & " ms")

        RaiseEvent CompleteEvent(Me, New EventArgs())
        Return time

    End Function

    ' Generic method to process files in parallel
    Private Function ProcessFilesInParallel(fileList As List(Of cSimpleFile),
                                            processor As Action(Of cSimpleFile),
                                            maxThreads As Integer,
                                            progressText As String) As Boolean

        Dim processedCount As Integer = 0
        Dim totalCount As Integer = fileList.Count
        Dim text As String
        Dim parallelOptions As New ParallelOptions() ' Configure parallel options
        parallelOptions.MaxDegreeOfParallelism = maxThreads

        Try
            Parallel.For(0, totalCount, parallelOptions,
                Sub(i As Integer)
                    If _stopped Then Return

                    While (_pause)
                        Thread.Sleep(250)
                    End While

                    ' Process the file
                    processor(fileList(i))

                    ' Update progress
                    Dim currentCount = Interlocked.Increment(processedCount)
                    If (currentCount Mod 100) = 0 OrElse currentCount = totalCount Then
                        text = String.Format("{0} {1}/{2}...", progressText, currentCount, totalCount)
                        Me.setProgressText(currentCount, totalCount, text)
                    End If
                End Sub)

        Catch ex As OperationCanceledException
            Me.setProgressText(0, 11, "Canceled")
        End Try

        If _stopped Then
            _stopped = False
            RaiseEvent StopEvent()
            Return False
        End If

        Return True
    End Function

    ' Process middle content for a single file
    Private Sub ProcessMiddleContent(file As cSimpleFile)
        Try
            file.ReadMiddle64Bits()
        Catch ex As Exception
            Dim rng As New Random()
            Dim bytes(7) As Byte
            rng.NextBytes(bytes)
            file._MiddleContent = BitConverter.ToUInt64(bytes, 0)
        End Try
    End Sub

    ' Process hash for a single file
    Private Sub ProcessHash(file As cSimpleFile)
        Try
            file.ComputeHash()
        Catch ex As Exception
            Dim rng As New Random()
            rng.NextBytes(file._Hash)
        End Try
    End Sub

    ' Stop !
    Public Sub [Stop]()
        _stopped = True
        _enum.Stop()
    End Sub


    ' Set progress on ProgressBarText (thread safe)
    Public Sub setProgressText(ByVal val As Integer, ByVal max As Integer, ByVal text As String)
        SyncLock Me._progressBarText
            Dim pbt = Me._progressBarText ' Local reference to avoid race conditions
            If pbt IsNot Nothing Then
                If (val = -1) Then 'do not change
                    val = pbt.Value
                End If

                If (max = -1) Then 'do not change
                    max = pbt.Maximum
                End If

                ' Marshal UI update to the main thread
                pbt.BeginInvoke(Sub()
                                    If pbt.IsHandleCreated Then
                                        pbt.SetProgressAndText(val, max, text)
                                    End If
                                End Sub)
            End If
        End SyncLock
    End Sub

    Public Sub setProgress(ByVal val As Integer, ByVal max As Integer)
        SyncLock Me._progressBarText
            Dim pbt = Me._progressBarText ' Local reference to avoid race conditions
            If pbt IsNot Nothing Then
                ' Marshal UI update to the main thread
                pbt.BeginInvoke(Sub()
                                    If pbt.IsHandleCreated Then
                                        pbt.SetProgress(val, max)
                                    End If
                                End Sub)
            End If
        End SyncLock
    End Sub

    Private Sub _enum_HasStopped() Handles _enum.HasStopped
        _stopped = True
        RaiseEvent StopEvent()
    End Sub

End Class
