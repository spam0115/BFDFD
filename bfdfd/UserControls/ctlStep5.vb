' =======================================================
' Yet Another Duplicate File Remover (YADFR)
' Copyright (c) 2008-2009 Alain Descotes (violent_ken)
' https://sourceforge.net/projects/yadfr/
' =======================================================


' Yet Another Duplicate File Remover is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 3 of the License, or
' (at your option) any later version.
'
' Yet Another Duplicate File Remover is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with Yet Another Duplicate File Remover; if not, see http://www.gnu.org/licenses/.

Option Strict On

Imports System
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock

Public Class ctlStep5
    Implements ICtlStep

    ' Private properties
    Private WithEvents _finder As cDuplicateFinder
    Private _ProgressBarText As New ProgressBarText
    Private _computing As Boolean = False
    Private _finderTask As Task(Of Long)
    Private _updateFrequency As Integer = 1000

    ' Public events
    Public Event BeginComputing()
    Public Event EndComputing(ByVal time As Long)

    'new stuff
    Private _FileList As List(Of cSimpleFile)
    Private _listViewItemsCache As New Dictionary(Of Integer, ListViewItem)
    Private lastCacheStart As Integer = -1
    Private lastCacheEnd As Integer = -1
    Private sortedIndices As Integer()
    Private sortColumn As Integer = -1
    Private sortOrder As SortOrder = SortOrder.None

    ' Constructor
    Public Sub New(ByRef finder As cDuplicateFinder)
        InitializeComponent()

        _FileList = New List(Of cSimpleFile)

        ' Set pgb properties
        Me._ProgressBarText.Dock = DockStyle.Fill
        Me._ProgressBarText.Label = Me.lblProgress

        ' Set finder propeties
        _finder = finder
        _finder.ProgressBarText = Me._ProgressBarText

    End Sub

    Private Sub ctlStep5_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Native.Api.NativeFunctions.SetWindowTheme(Me.dlv.Handle, "explorer", Nothing)
        Misc.SetToolTip(Me.cmdGo, "Start/stop the research")
    End Sub

    ' Start file research now and also handles stopping after searching has started
    Private Sub cmdGo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGo.Click
        Dim time As Long

        If Not (_computing) Then
            RaiseEvent BeginComputing()

            ' Some GUI changes
            Me.SplitContainerCmdGo.Panel1.Controls.Add(Me._ProgressBarText)
            Me._ProgressBarText.BringToFront()
            Me.cmdGo.BringToFront()
            Me.dlv.Items.Clear()
            Me._ProgressBarText.SetProgressAndTextFormatted(0, 11, "")
            Me.reCalculateStats()
            Me.dlv.Enabled = False

            ' Start finder
            Me.cmdGo.Image = My.Resources.control_stop_square
            Me.cmdGo.Text = "  Stop"
            _computing = True

            ' Call Go() like this to avoid blocking the UI.  Note that this runs in a separate thread:
            _finderTask = Task.Run(Function() As Long
                                       Return Me._finder.Go(time) 'where all the computation occurs
                                   End Function)

        Else
            ' Currently computing -> stop it !
            Me._finder.Stop()
        End If

    End Sub

    Private Sub _finder_OnComplete(sender As Object, e As EventArgs) 'Handles _finder.CompleteEvent
        If Me.InvokeRequired Then
            ' Use a lambda to capture parameters and avoid recursion
            Me.BeginInvoke(Sub() 'do no use Invoke here.  It runs on the current thread and not the handle owner thread
                               _finder_OnComplete(sender, e) ' Recursive call on UI thread
                           End Sub)
            Return
        End If

        ' Safe UI updates here (runs on UI thread)
        HandleFinderCompletion()
    End Sub

    Private Async Sub HandleFinderCompletion()
        Dim result As Long

        ' Other GUI changes
        Me.splitRes.Panel2.Enabled = False
        Me._ProgressBarText.SetProgressAndTextFormatted(10, 11, String.Format("Adding items to list ({0} files)...", Me._finder.Files.Count))

        Await _finderTask 'don't use Wait() here or the UI thread will be blocked which is bad
        result = _finderTask.Result 'get's the lenght of time it took

        _FileList = _finder.Files

        ' Now fill list
        Me.dlv.BeginUpdate()
        Me.dlv.Sorting = SortOrder.None
        Me.dlv.PreventSort()
        'Dim _hash As New Dictionary(Of String, Integer)
        Dim i As Integer = 0
        Dim gpNumber As Integer = 0
        Dim count As Integer = _FileList.Count
        'For Each simpleFile As cSimpleFile In _FileList
        '    If (i Mod _updateFrequency) = 0 Then
        '        Me.dlv.BeginUpdate()
        '        Me.dlv.Sorting = SortOrder.None
        '        Me.dlv.PreventSort()
        '    End If

        '    Dim it As New ListViewItem(simpleFile.Path)
        '    it.BackColor = Color.FromArgb(CInt(200 + simpleFile.HashA(4) / 5), CInt(200 + simpleFile.HashA(5) / 5), CInt(200 + simpleFile.HashA(6) / 5))
        '    it.Tag = simpleFile
        '    ' Custom color derivated from hash...
        '    it.SubItems.Add(cFile.GetFileExtension(simpleFile.Path))
        '    it.SubItems.Add(Misc.GetFormattedSize(simpleFile.Size, , True))
        '    it.SubItems.Add(DateTime.FromFileTime(simpleFile._CreatedDate).ToLocalTime().ToString())
        '    it.SubItems.Add(simpleFile.GroupId.ToString())
        '    Me.lv.Items.Add(it)

        '    If (i Mod _updateFrequency) = 0 Then
        '        Me._ProgressBarText.SetProgress(i, count)
        '        Me.dlv.EndUpdate()
        '        Application.DoEvents()
        '    End If

        '    i += 1
        'Next
        '
        'Me._ProgressBarText.SetProgress(count, count)
        'Me.dlv.EndUpdate()

        ' Initialize sorted indices
        sortedIndices = Enumerable.Range(0, count).ToArray()

        ' Reset cache
        _listViewItemsCache.Clear()
        lastCacheStart = -1
        lastCacheEnd = -1

        dlv.VirtualListSize = count

        Me.calculateStats(gpNumber)
        Me.lblProgress.Text = "Elapsed time: " & (result \ 10000000).ToString & " seconds"

        ' Some GUI changes
        Me.splitRes.Panel2.Enabled = True
        Me.SplitContainerCmdGo.Panel1.Controls.Remove(Me._ProgressBarText)
        Me.cmdGo.Image = My.Resources.control
        Me.cmdGo.Text = "    Go !"
        _computing = False
        Me.dlv.Enabled = True
        dlv.EndUpdate()

        RaiseEvent EndComputing(DateTime.Now.Ticks)
    End Sub

    Private Sub _finder_OnStop() Handles _finder.StopEvent

        If Me.InvokeRequired Then
            ' Use a lambda to capture parameters and avoid recursion
            Me.BeginInvoke(Sub() 'do no use Invoke here.  It runs on the current thread and not the handle owner thread
                               _finder_OnStop() ' Recursive call on UI thread
                           End Sub)
            Return
        End If

        ' Safe UI updates here (runs on UI thread)
        HandleFinderStop()
    End Sub

    Private Sub HandleFinderStop()

        Me.dlv.Items.Clear()
        Me.dlv.Groups.Clear()

        ' Display some stats
        Me.lblDuplicateCount.Text = "0"
        Me.lblGroups.Text = "0"

        ' Calculating wasted space
        Me.lblWastedSpace.Text = Misc.GetFormatedSize(0, , True)

        ' Some GUI changes
        Me.splitRes.Panel2.Enabled = True
        Me.splitA.Panel1.Controls.Remove(Me._ProgressBarText)
        'Me.lblProgress.Text = ""
        Me.cmdGo.Image = My.Resources.control
        _computing = False
        Me.dlv.Enabled = True

        RaiseEvent EndComputing(-1)
    End Sub

    Private Sub ListView2_RetrieveVirtualItem(sender As Object, e As RetrieveVirtualItemEventArgs) Handles dlv.RetrieveVirtualItem
        Dim dataIndex = sortedIndices(e.ItemIndex)

        If _listViewItemsCache.ContainsKey(dataIndex) Then
            e.Item = _listViewItemsCache(dataIndex)
        Else
            e.Item = CreateListViewItemFromData(_FileList(dataIndex))
            _listViewItemsCache(dataIndex) = e.Item
        End If
    End Sub

    Private Sub ListView2_CacheVirtualItems(sender As Object, e As CacheVirtualItemsEventArgs) Handles dlv.CacheVirtualItems
        If lastCacheStart >= e.StartIndex AndAlso lastCacheEnd <= e.EndIndex Then
            Return
        End If

        lastCacheStart = e.StartIndex
        lastCacheEnd = e.EndIndex
        'randomCache.Clear() 'why do this?  A cache with little data is of little use

        For i As Integer = e.StartIndex To e.EndIndex
            Dim dataIndex = sortedIndices(i)
            _listViewItemsCache(dataIndex) = CreateListViewItemFromData(_FileList(dataIndex))
        Next
    End Sub

    Private Function CreateListViewItemFromData(simpleFile As cSimpleFile) As ListViewItem
        Dim item As New ListViewItem(simpleFile.Path)

        item.Checked = simpleFile._Checked
        item.SubItems.Add(cFile.GetFileExtension(simpleFile.Path))
        item.SubItems.Add(simpleFile.Size)
        item.SubItems.Add(simpleFile.CreatedDate)
        item.SubItems.Add(simpleFile._GroupId.ToString())

        item.BackColor = Color.FromArgb(CInt(200 + simpleFile.Hash(4) / 5), CInt(200 + simpleFile.Hash(5) / 5), CInt(200 + simpleFile.Hash(6) / 5))
        '    

        Return item
    End Function

    Private Sub calculateStats(ByVal gpNumber As Integer)
        ' Display some stats
        Me._ProgressBarText.SetProgressAndTextFormatted(11, 11, "Calculating stats...")
        If Me.dlv.Items.Count > 0 Then
            Me.lblDuplicateCount.Text = (Me.dlv.Items.Count - gpNumber).ToString
        Else
            Me.lblDuplicateCount.Text = "0"
        End If
        Me.lblGroups.Text = gpNumber.ToString

        ' Calculating wasted space
        Me.reCalculateStats()
    End Sub

    Private Sub reCalculateStats()

        ' Get the number of different groups
        Dim gpNumber As Integer = 0
        Dim _hash As New Dictionary(Of Byte(), Integer)
        Dim wastedSpace As Long = 0
        For Each item In _FileList
            If _hash.ContainsKey(item.Hash) = False Then
                gpNumber += 1
                _hash.Add(item.Hash, gpNumber)
            Else
                wastedSpace += item._Size
            End If
        Next
        Me.lblWastedSpace.Text = Misc.GetFormattedSize(wastedSpace, , True)

        ' Display some stats
        If _FileList.Count > 0 Then
            Me.lblDuplicateCount.Text = (_FileList.Count - gpNumber).ToString
        Else
            Me.lblDuplicateCount.Text = "0"
        End If
        Me.lblGroups.Text = gpNumber.ToString

    End Sub

    Public Sub NextStep() Implements ICtlStep.NextStep
        ' No next step ;-)
    End Sub

    Public ReadOnly Property NextStepOK() As Boolean Implements ICtlStep.NextStepOk
        Get
            Return False
        End Get
    End Property

    Private Sub lv_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dlv.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim atLeastOneItem As Boolean = (Me.dlv.Items.Count > 0)
            Dim atLeastOneSelectedItem As Boolean = (Me.dlv.SelectedItems.Count > 0)
            Dim atLeastOneCheckedItem As Boolean
            If Me.dlv.Items.Count < 5000 Then
                atLeastOneCheckedItem = (Me.dlv.CheckedItems.Count > 0)
            Else
                ' Prevent to much CPU usage...
                atLeastOneCheckedItem = True
            End If
            Me.MenuItemSelDelete.Enabled = atLeastOneSelectedItem
            Me.MenuItemSelRemove.Enabled = atLeastOneSelectedItem
            Me.MenuItemSelToTrash.Enabled = atLeastOneSelectedItem
            Me.MenuItemOpenFile.Enabled = atLeastOneSelectedItem
            Me.RMenuItemCopy.Enabled = atLeastOneSelectedItem
            Me.MenuItemSelMove.Enabled = atLeastOneSelectedItem
            Me.MenuItemOpenFileLocation.Enabled = atLeastOneSelectedItem
            Me.MenuItemSelCheck.Enabled = atLeastOneSelectedItem
            Me.MenuItemSelUncheck.Enabled = atLeastOneSelectedItem
            Me.MenuItemFileProperties.Enabled = atLeastOneSelectedItem
            Me.MenuItemChDelete.Enabled = atLeastOneCheckedItem
            Me.MenuItemChRemove.Enabled = atLeastOneCheckedItem
            Me.MenuItemChToTrash.Enabled = atLeastOneCheckedItem
            Me.MenuItemChMove.Enabled = atLeastOneCheckedItem
            Me.MenuItemSaveList.Enabled = atLeastOneItem
            Me.RMenuItemDupSel.Enabled = atLeastOneItem
            Me.MenuItemCheckAll.Enabled = atLeastOneItem
            Me.MenuItemCheckNone.Enabled = atLeastOneItem AndAlso atLeastOneCheckedItem
            Me.MenuItemOrphan.Enabled = atLeastOneItem
            Me.mnuFile.Show(Me.dlv, e.Location)
        End If
    End Sub

#Region "MenuItems management"

    Private Sub MenuItemRIPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRIPath.Click
        ' Browse for a directory to include
        Dim brwse As New FolderBrowserDialog
        With brwse
            .Description = "Select the only directory to include"
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If brwse.ShowDialog = DialogResult.OK Then
            Dim dir As String = brwse.SelectedPath.ToUpper
            ' Now remove from list
            Me.dlv.BeginUpdate()
            Me.dlv.PreventSort()
            Dim dirLen As Integer = dir.Length
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim s As String = Me.dlv.Items(x).Text
                If s.Length > dirLen Then
                    If s.Substring(0, dirLen).ToUpper <> dir Then
                        Me.dlv.Items.RemoveAt(x)
                    End If
                End If
            Next
            Me.reCalculateStats()
            Me.dlv.EndUpdate()
        End If
    End Sub

    Private Sub MenuItemFRFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRFolder.Click
        ' Browse for a directory to exclude
        Dim brwse As New FolderBrowserDialog
        With brwse
            .Description = "Select directory to exclude"
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If brwse.ShowDialog = DialogResult.OK Then
            Dim dir As String = brwse.SelectedPath.ToUpper
            ' Now remove from list
            Me.dlv.BeginUpdate()
            Me.dlv.PreventSort()
            Dim dirLen As Integer = dir.Length
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim s As String = Me.dlv.Items(x).Text
                If s.Length > dirLen Then
                    If s.Substring(0, dirLen).ToUpper = dir Then
                        Me.dlv.Items.RemoveAt(x)
                    End If
                End If
            Next
            Me.reCalculateStats()
            Me.dlv.EndUpdate()
        End If
    End Sub

    Private Sub MenuItemRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRefresh.Click
        ' Here we refresh list
        ' We remove all none existing files !
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
            If IO.File.Exists(Me.dlv.Items(x).Text) = False Then
                Me.dlv.Items.RemoveAt(x)
            End If
        Next
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemCopyFilePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopyFilePath.Click
        ' Copy all selected file path
        Me.dlv.Enabled = False
        Dim s As String = ""
        For Each it As ListViewItem In Me.dlv.SelectedItems
            s &= it.Text & Environment.NewLine
        Next
        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(s)
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemCopyFileHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopyFileHash.Click
        ' Copy all selected file hash
        Me.dlv.Enabled = False
        Dim s As String = ""
        For Each it As ListViewItem In Me.dlv.SelectedItems
            s &= it.SubItems(3).Text & Environment.NewLine
        Next
        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(s)
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCheckAll.Click
        Me.dlv.Enabled = False
        For Each it As ListViewItem In Me.dlv.Items
            it.Checked = True
        Next
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemCheckNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCheckNone.Click
        Me.dlv.Enabled = False
        For Each it As ListViewItem In Me.dlv.CheckedItems
            it.Checked = False
        Next
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemOpenFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOpenFileLocation.Click
        Me.dlv.Enabled = False
        For Each it As ListViewItem In Me.dlv.SelectedItems
            cFile.OpenDirectory(it.Text)
        Next
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOpenFile.Click
        Dim f As New cFile(Me.dlv.SelectedItems(0).Text)
        f.ShellOpenFile(Me.Handle)
    End Sub

    Private Sub MenuItemSelCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelCheck.Click
        Me.dlv.Enabled = False
        For Each it As ListViewItem In Me.dlv.SelectedItems
            it.Checked = True
        Next
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemSelUncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelUncheck.Click
        Me.dlv.Enabled = False
        For Each it As ListViewItem In Me.dlv.SelectedItems
            it.Checked = False
        Next
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemFileProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFileProperties.Click
        Me.dlv.Enabled = False
        For Each it As ListViewItem In Me.dlv.SelectedItems
            cFile.ShowFileProperty(it.Text, Me.Handle)
        Next
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemSelRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelRemove.Click
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
            If Me.dlv.Items(x).Selected Then
                Me.dlv.Items.RemoveAt(x)
            End If
        Next
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemChRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemChRemove.Click
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
            If Me.dlv.Items(x).Checked Then
                Me.dlv.Items.RemoveAt(x)
            End If
        Next
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemSelToTrash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelToTrash.Click
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        Dim files As New List(Of String)
        For Each it As ListViewItem In Me.dlv.SelectedItems
            files.Add(it.Text)
        Next
        cFile.MoveFilesToTrash(files, Me.Handle)
        Call Me.MenuItemRefresh_Click(Nothing, Nothing)
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemChToTrash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemChToTrash.Click
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        Dim files As New List(Of String)
        For Each it As ListViewItem In Me.dlv.CheckedItems
            files.Add(it.Text)
        Next
        cFile.MoveFilesToTrash(files, Me.Handle)
        Call Me.MenuItemRefresh_Click(Nothing, Nothing)
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemChDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemChDelete.Click
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        Dim files As New List(Of String)
        For Each it As ListViewItem In Me.dlv.CheckedItems
            files.Add(it.Text)
        Next
        cFile.KillFiles(files, Me.Handle)
        Call Me.MenuItemRefresh_Click(Nothing, Nothing)
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemSelDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelDelete.Click
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        Dim files As New List(Of String)
        For Each it As ListViewItem In Me.dlv.SelectedItems
            files.Add(it.Text)
        Next
        cFile.KillFiles(files, Me.Handle)
        Call Me.MenuItemRefresh_Click(Nothing, Nothing)
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemSelMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelMove.Click
        Dim brwse As New FolderBrowserDialog
        With brwse
            .Description = "Select target directory"
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If brwse.ShowDialog = DialogResult.OK Then
            Dim dest As String = brwse.SelectedPath

            Me.dlv.BeginUpdate()
            Me.dlv.PreventSort()
            Dim files As New List(Of String)
            For Each it As ListViewItem In Me.dlv.SelectedItems
                files.Add(it.Text)
            Next
            cFile.MoveFiles(files, dest, Me.Handle)
            Call Me.MenuItemRefresh_Click(Nothing, Nothing)
            Me.dlv.EndUpdate()

        End If
    End Sub

    Private Sub MenuItemChMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemChMove.Click
        Dim brwse As New FolderBrowserDialog
        With brwse
            .Description = "Select target directory"
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If brwse.ShowDialog = DialogResult.OK Then
            Dim dest As String = brwse.SelectedPath

            Me.dlv.BeginUpdate()
            Me.dlv.PreventSort()
            Dim files As New List(Of String)
            For Each it As ListViewItem In Me.dlv.CheckedItems
                files.Add(it.Text)
            Next
            cFile.MoveFiles(files, dest, Me.Handle)
            Call Me.MenuItemRefresh_Click(Nothing, Nothing)
            Me.dlv.EndUpdate()

        End If
    End Sub

    Private Sub MenuItemCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopyAll.Click
        ' Copy all selected file info
        Me.dlv.Enabled = False
        Dim s As String = ""
        For Each it As ListViewItem In Me.dlv.SelectedItems
            For Each subit As ListViewItem.ListViewSubItem In it.SubItems
                s &= subit.Text & vbTab
            Next
            s &= Environment.NewLine
        Next
        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(s)
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemSaveList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSaveList.Click
        ' Save to CSV file
        If Me.SaveFileDialog.ShowDialog = DialogResult.OK Then

            Dim sFile As String = Me.SaveFileDialog.FileName

            Me.dlv.Enabled = False
            Dim file As IO.StreamWriter = System.IO.File.CreateText(sFile)
            Try
                For Each it As ListViewItem In Me.dlv.Items
                    Dim s As String = ""
                    For Each subit As ListViewItem.ListViewSubItem In it.SubItems
                        s &= subit.Text & ";"
                    Next
                    file.WriteLine(s)
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Could not save file !", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                file.Close()
            End Try

            dlv.EndUpdate()
            Me.dlv.Enabled = True
        End If
    End Sub

#Region "Menu handlers for duplicate selectors"

    Private Sub MenuItemDS_mc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_mc.Click

        ' Now check all items except the 'original item' of each group
        ' 'original item' is the file which has the most recent creation date
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalDate As Long = Long.MinValue

            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                ' Original = greatest CDate
                If sf._CreatedDate > originalDate Then
                    originalDate = sf._CreatedDate
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    ''' <summary>
    ''' check all items except the 'original item' of each group
    ''' 'original item' is the file which has the less recent creation date
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_lc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles MenuItemDS_lc.Click

        Me.dlv.Enabled = False
        Me.dlv.PreventSort()
        Me.dlv.Sorting = SortOrder.None

        Dim i As Integer = 0
        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' check/uncheck items
        For Each lst As List(Of ListViewItem) In _dico.Values
            If (i Mod _updateFrequency) = 0 Then
                Me.dlv.BeginUpdate()
            End If

            Dim original As ListViewItem = lst(0)
            Dim originalDate As Long = Long.MaxValue
            For Each item As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(item.Tag, cSimpleFile)
                ' Original = lowest CDate
                If sf._CreatedDate < originalDate Then
                    originalDate = sf._CreatedDate
                    original = item
                End If
            Next
            original.Checked = False ' Uncheck original

            If (i Mod _updateFrequency) = 0 Then
                Me.dlv.EndUpdate()
                Me._ProgressBarText.SetProgress(i, dlv.Items.Count)
                Application.DoEvents()
            End If

            i += 1
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_lc_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_lc.Click
        Dim i As Integer = 0

        ' 1. Precompute group originals in single pass
        Dim originals As New HashSet(Of ListViewItem)()
        Dim groupMin As New Dictionary(Of Integer, (MinDate As Long, Item As ListViewItem))()

        ' Single pass through all items
        Me.dlv.Enabled = False
        dlv.BeginUpdate()
        For Each item As ListViewItem In dlv.Items
            Dim sf = DirectCast(item.Tag, cSimpleFile)
            Dim currentDate = sf._CreatedDate

            ' Update group max tracking
            If groupMin.TryGetValue(sf._GroupId, Nothing) Then
                If currentDate < groupMin(sf._GroupId).MinDate Then
                    groupMin(sf._GroupId) = (currentDate, item)
                End If
            Else
                groupMin.Add(sf._GroupId, (currentDate, item))
            End If

            'update ui occasionally
            If (i Mod _updateFrequency) = 0 Then
                Application.DoEvents()
            End If
            i += 1
        Next

        ' Build hashset of originals (O(groups) operation)
        For Each kvp In groupMin.Values
            originals.Add(kvp.Item)
        Next

        ' 2. Efficient checked state update
        i = 0
        For Each item As ListViewItem In dlv.Items
            item.Checked = Not originals.Contains(item)

            'update ui occasionally
            If (i Mod _updateFrequency) = 0 Then
                Application.DoEvents()
            End If
            i += 1
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_mm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_mm.Click

        ' Now check all items except the 'original item' of each group
        ' 'original item' is the file which has the most recent modification date
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalDate As Long = Long.MinValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                ' Original = greatest MDate
                If sf._CreatedDate > originalDate Then
                    originalDate = sf._CreatedDate
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_lm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_lm.Click

        ' Now check all items except the 'original item' of each group
        ' 'original item' is the file which has the less recent modification date
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalDate As Long = Long.MaxValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                ' Original = greatest CDate
                If sf._CreatedDate < originalDate Then
                    originalDate = sf._CreatedDate
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_ma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_ma.Click

        ' Now check all items except the 'original item' of each group
        ' 'original item' is the file which has the most recent access date
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalDate As Long = Long.MinValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                ' Original = greatest CDate
                If sf._AccessedDate > originalDate Then
                    originalDate = sf._AccessedDate
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_ra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_ra.Click

        ' Now check all items except the 'original item' of each group
        ' 'original item' is the file which has the less recent access date
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalDate As Long = Long.MaxValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                ' Original = greatest CDate
                If sf._AccessedDate < originalDate Then
                    originalDate = sf._AccessedDate
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_shortestname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_shortestname.Click
        ' Check all items except the 'original item' of each group
        ' 'original item' is the file which has the shorted filename
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalNameLength As Integer = Integer.MaxValue

            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                Dim iLength As Integer

                ' Original = shortest name
                iLength = sf.Path.Substring(sf.Path.LastIndexOf("\"c) + 1).Length
                If iLength < originalNameLength Then
                    originalNameLength = iLength
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_longestname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_longestname.Click
        ' Check all items except the 'original item' of each group
        ' 'original item' is the file which has the shorted filename
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalNameLength As Integer = Integer.MinValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                Dim itLength As Integer

                ' Original = longest name
                itLength = sf.Path.Substring(sf.Path.LastIndexOf("\"c) + 1).Length
                If itLength > originalNameLength Then
                    originalNameLength = itLength
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_shortestnonnumericname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_shortestnonnumericname.Click

        ' Check all items except the 'original item' of each group
        ' 'original item' is the file which has the shorted filename
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId
        Dim alpha As New Regex("\d")

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalNameLength As Integer = Integer.MaxValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                ' Original = greatest CDate
                Dim nonnumericname = alpha.Replace(sf.Path.Substring(sf.Path.LastIndexOf("\"c) + 1), "")
                If nonnumericname.Length < originalNameLength Then
                    originalNameLength = nonnumericname.Length
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_longestnonnumericname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDS_longestnonnumericname.Click
        ' Check all items except the 'original item' of each group
        ' 'original item' is the file which has the shorted filename
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId
        Dim alpha As New Regex("\d")

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In _dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalNameLength As Integer = Integer.MinValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                ' Original = longest non-numeric name
                Dim nonnumericname = alpha.Replace(sf.Path.Substring(sf.Path.LastIndexOf("\"c) + 1), "")
                If nonnumericname.Length > originalNameLength Then
                    originalNameLength = nonnumericname.Length
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_ShortestPath_Click(sender As System.Object, e As System.EventArgs) Handles MenuItemDS_ShortestPath.Click
        ' Check all items except the 'original item' of each group
        ' 'original item' is the file which has the shorted filename
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalNameLength As Integer = Integer.MaxValue

            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                Dim iLength As Integer

                ' Original = shortest name
                iLength = sf.Path.Substring(0, sf.Path.LastIndexOf("\"c)).Length
                If iLength < originalNameLength Then
                    originalNameLength = iLength
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

    Private Sub MenuItemDS_LongestPath_Click(sender As System.Object, e As System.EventArgs) Handles MenuItemDS_LongestPath.Click
        ' Check all items except the 'original item' of each group
        ' 'original item' is the file which has the shorted filename
        Me.dlv.Enabled = False
        dlv.BeginUpdate()

        Dim dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId

        ' Uncheck the original item
        For Each lst As List(Of ListViewItem) In dico.Values
            Dim original As ListViewItem = lst(0)
            Dim originalNameLength As Integer = Integer.MinValue
            For Each it As ListViewItem In lst
                Dim sf As cSimpleFile = DirectCast(it.Tag, cSimpleFile)
                Dim itLength As Integer

                ' Original = longest name
                itLength = sf.Path.Substring(0, sf.Path.LastIndexOf("\"c)).Length
                If itLength > originalNameLength Then
                    originalNameLength = itLength
                    original = it
                End If
            Next
            original.Checked = False    ' Uncheck original
        Next

        dlv.EndUpdate()
        Me.dlv.Enabled = True
    End Sub

#End Region

#Region "other menu functions"
    Private Sub MenuItemOrphan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOrphan.Click

        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()

        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId(False)

        ' Uncheck the original item
        For Each pair As Generic.KeyValuePair(Of Integer, List(Of ListViewItem)) In _dico
            If pair.Value.Count = 1 Then
                ' Remove from list
                Me.dlv.Items.Remove(pair.Value(0))
            End If
        Next

        Me.reCalculateStats()

        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFRVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRVideos.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extVideos.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()

        If Me.MenuItemFRVideos.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRVideos.Checked = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRVideos.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFRImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRImages.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extImages.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        If Me.MenuItemFRImages.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRImages.Checked = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRImages.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFRArchives_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRArchives.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extArchives.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        If Me.MenuItemFRArchives.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRArchives.Checked = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRArchives.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFRMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRMusic.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extMusic.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        If Me.MenuItemFRMusic.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRMusic.Checked = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRMusic.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFRCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRCustom.Click
        ' Prompt user for extensions
        Dim s As String = Interaction.InputBox("Format must be *.xx;*.yy;*.zz for multiple extensions.", "Which extensions to remove from list", "*.xx")
        Dim col As New List(Of String)
        For Each ss As String In s.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
            If cFile.DoesExtensionMatch(Me.dlv.Items(x).Text, col) Then
                Me.dlv.Items.RemoveAt(x)
            End If
        Next
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFOArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOArchive.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extArchives.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        If Me.MenuItemFOArchive.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOArchive.Checked = True
            Me.MenuItemFOVideos.Enabled = False
            Me.MenuItemFOImages.Enabled = False
            Me.MenuItemFOMusic.Enabled = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFOArchive.Checked = False
            Me.MenuItemFOVideos.Enabled = True
            Me.MenuItemFOImages.Enabled = True
            Me.MenuItemFOMusic.Enabled = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFOImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOImages.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extImages.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        If Me.MenuItemFOImages.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOImages.Checked = True
            Me.MenuItemFOVideos.Enabled = False
            Me.MenuItemFOArchive.Enabled = False
            Me.MenuItemFOMusic.Enabled = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFOImages.Checked = False
            Me.MenuItemFOVideos.Enabled = True
            Me.MenuItemFOArchive.Enabled = True
            Me.MenuItemFOMusic.Enabled = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFOMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOMusic.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extMusic.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        If Me.MenuItemFOMusic.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOMusic.Checked = True
            Me.MenuItemFOVideos.Enabled = False
            Me.MenuItemFOArchive.Enabled = False
            Me.MenuItemFOImages.Enabled = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFOMusic.Checked = False
            Me.MenuItemFOVideos.Enabled = True
            Me.MenuItemFOArchive.Enabled = True
            Me.MenuItemFOImages.Enabled = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub

    Private Sub MenuItemFOVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOVideos.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extVideos.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.dlv.BeginUpdate()
        Me.dlv.PreventSort()
        If Me.MenuItemFOVideos.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOVideos.Checked = True
            Me.MenuItemFOArchive.Enabled = False
            Me.MenuItemFOImages.Enabled = False
            Me.MenuItemFOMusic.Enabled = False
            ' Push items to stack
            For x As Integer = Me.dlv.Items.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.dlv.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me.dlv.Items.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFOVideos.Checked = False
            Me.MenuItemFOArchive.Enabled = True
            Me.MenuItemFOImages.Enabled = True
            Me.MenuItemFOMusic.Enabled = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.dlv.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.dlv.EndUpdate()
    End Sub
#End Region

#End Region

    ' Parse the file list and group by group and place into a dictionnary
    Private Function groupItemsByGroupId(Optional ByVal setChecked As Boolean = True) As Dictionary(Of Integer, List(Of ListViewItem))
        Dim _dict As New Dictionary(Of Integer, List(Of ListViewItem))

        If (setChecked) Then Me.dlv.BeginUpdate()

        For Each item As ListViewItem In Me.dlv.Items

            If (setChecked) Then item.Checked = True     ' Check all for now ' do not do this here when they will just be unset later.  ui operations are very expensive

            'Dim key As String = CType(it.Tag, cSimpleFile).Hash
            Dim key = CType(item.Tag, cSimpleFile)._GroupId
            If _dict.ContainsKey(key) = False Then
                Dim lst As New List(Of ListViewItem)
                _dict.Add(key, lst)
            End If
            _dict(key).Add(item)
        Next
        Me.dlv.EndUpdate()
        Return _dict
    End Function

    Private Sub dlv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dlv.SelectedIndexChanged

    End Sub
End Class
