Imports System.IO
Imports System.Linq
Imports System.Net.WebRequestMethods
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports BrightIdeasSoftware

Public Class frmMain

    ' Private properties
    Private _FileList As List(Of cSimpleFile) 'we should change this to a linked list for more performant deletes
    Private WithEvents _duplicateFinder As cDuplicateFinder
    Private _ProgressBarText As New ProgressBarText
    Private _computing As Boolean = False
    Private _finderTask As Task(Of Long)
    Private Shared alphaRegex As New Regex("\d")
    Private _updateFrequency As Integer = 1000
    Private _fileListChunkSize As Integer = 1000
    Private _fileHashMap As Dictionary(Of String, cSimpleFile)
    Private _pause As Boolean = False
    Private Const strGo = "    Go!"
    Private Const strStop = "   Stop"
    Private Const strPause = "   Pause"
    Private Const strUnPause = "   UnPause"
    Private Const strRestart = "   Restart"

    ' Public events
    Public Event BeginComputing()
    Public Event EndComputing(ByVal time As Long)

    ' Constructor
    Public Sub New(ByRef finder As cDuplicateFinder)
        InitializeComponent()

        _FileList = New List(Of cSimpleFile)

        ' Set pgb properties
        Me._ProgressBarText.Dock = DockStyle.Fill
        Me._ProgressBarText.Label = Me.lblTop

        ' Set finder propeties
        _duplicateFinder = finder
        _duplicateFinder.ProgressBarText = Me._ProgressBarText

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Configure the columns to bind to your data properties
        ConfigureColumns()

        ' Add event handlers for checkbox changes
        AddHandler vlvFiles.ItemChecked, AddressOf vlvFiles_ItemChecked

        ' Set up row formatting for background colors
        vlvFiles.RowFormatter = AddressOf FormatRow

        Me.Panel1.Controls.Add(Me._ProgressBarText)
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub

    Private Sub ConfigureColumns()
        ' Configure each column to display the appropriate data
        OlvColumn0.AspectName = "_GroupId"
        OlvColumn0.Text = "Group"
        OlvColumn0.Width = 70

        OlvColumn1.AspectName = "_Path"
        OlvColumn1.Text = "File"
        OlvColumn1.Width = 200

        OlvColumn2.AspectName = "_FileType"
        OlvColumn2.Text = "Type"
        OlvColumn2.Width = 100

        ' Use the formatted size method for better display
        OlvColumn3.AspectName = "_Size"
        OlvColumn3.Text = "Size"
        OlvColumn3.Width = 100

        ' Use the formatted date method for better display
        OlvColumn4.AspectGetter = Function(x As Object) If(x Is Nothing, "MM/dd/yyyy HH:mm", DirectCast(x, cSimpleFile).CreatedDate())
        OlvColumn4.Text = "Created Date"
        OlvColumn4.Width = 150

        ' Use the formatted date method for better display
        OlvColumn5.AspectGetter = Function(x As Object) If(x Is Nothing, "MM/dd/yyyy HH:mm", DirectCast(x, cSimpleFile).ModifiedDate())
        OlvColumn5.Text = "Modified Date"
        OlvColumn5.Width = 150


        ' Configure checkbox handling
        vlvFiles.CheckedAspectName = "_Checked"

    End Sub

    Private Sub cmdGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim time As Long

        If Not (_computing) Then
            RaiseEvent BeginComputing()

            ' Some GUI changes
            lblError.Text = Nothing
            Me._ProgressBarText.Visible = True
            Me._ProgressBarText.BringToFront()
            Me.btnGo.BringToFront()
            Me.vlvFiles.Items.Clear()
            Me._ProgressBarText.SetProgressAndTextFormatted(0, 11, "")
            Me.reCalculateStats()
            Me.vlvFiles.Enabled = False

            ' Start finder
            Me.btnGo.Image = My.Resources.control_stop_square
            Me.btnGo.Text = strStop
            Me.btnPause.Text = strPause
            _computing = True

            ' Call Go() like this to avoid blocking the UI.  Note that this runs in a separate thread:
            _finderTask = Task.Run(Function() As Long
                                       Return Me._duplicateFinder.Go(time) 'where all the computation occurs
                                   End Function)

        Else
            ' Currently computing -> stop it !
            Me._duplicateFinder.Stop()
        End If
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        _pause = Not _pause

        _duplicateFinder._pause = _pause
        FileOperationEngine._pause = _pause

        If (_pause) Then
            btnPause.Text = strUnPause
        Else
            btnPause.Text = strPause
        End If
    End Sub

    Private Sub vlvFiles_ItemChecked(sender As Object, e As ItemCheckedEventArgs)
        ' Update the underlying data when checkbox state changes
        Dim item As ListViewItem = e.Item
        If item.Tag IsNot Nothing AndAlso TypeOf item.Tag Is cSimpleFile Then
            Dim data As cSimpleFile = DirectCast(item.Tag, cSimpleFile)
            data._Checked = item.Checked
        End If
    End Sub

    Private Sub FormatRow(olvi As BrightIdeasSoftware.OLVListItem)
        If TypeOf olvi.RowObject Is cSimpleFile Then
            Dim data As cSimpleFile = DirectCast(olvi.RowObject, cSimpleFile)

            olvi.BackColor = Color.FromArgb(CInt(200 + data._Hash(4) / 5), CInt(200 + data._Hash(5) / 5), CInt(200 + data._Hash(6) / 5))
        End If
    End Sub

    Private Sub _finder_OnComplete(sender As Object, e As EventArgs) Handles _duplicateFinder.CompleteEvent
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
        Me._ProgressBarText.SetProgressAndTextFormatted(10, 11, String.Format("Adding items to list ({0} files)...", Me._duplicateFinder.Files.Count))

        Await _finderTask 'don't use Wait() here or the UI thread will be blocked which is bad
        result = _finderTask.Result 'get's the length of time it took
        Me.lblTop.Text = "Elapsed time: " & (result \ 10000000).ToString & " seconds"

        _FileList = _duplicateFinder.Files
        '_FileList = PopulateFileList(1000000)

        ' Now fill list
        Me.vlvFiles.BeginUpdate()

        vlvFiles.VirtualListDataSource = New FileListDataSource(_FileList)

        Dim gpNumber As Integer
        Dim count As Integer

        If (_FileList.Count > 0) Then
            gpNumber = _FileList.Last._GroupId
            count = _FileList.Count
        Else
            gpNumber = 0
            count = 0
        End If

        vlvFiles.VirtualListSize = count

        Me.calculateStats(gpNumber)
        _computing = False

        ' Some GUI changes
        Me._ProgressBarText.Visible = False
        Me.btnGo.Image = My.Resources.control
        Me.btnGo.Text = strGo
        Me.btnPause.Text = strPause
        Me.vlvFiles.Enabled = True
        Me.vlvFiles.Invalidate()
        vlvFiles.EndUpdate()

        RaiseEvent EndComputing(DateTime.Now.Ticks)
    End Sub

    Private Sub _finder_OnStop() Handles _duplicateFinder.StopEvent

        If Me.InvokeRequired Then
            ' Use a lambda to capture parameters and avoid recursion
            Me.BeginInvoke(Sub() 'do no use Invoke here.  It runs on the current thread and not the handle owner thread
                               _finder_OnStop() ' Recursive call on UI thread
                           End Sub)
            Return
        End If

        ' Safe UI updates here (runs on UI thread)
        Me.vlvFiles.Items.Clear()
        Me.vlvFiles.Groups.Clear()

        ' Display some stats
        Me.lblDuplicateCount.Text = "0"
        Me.lblGroupsCount.Text = "0"

        ' Calculating wasted space
        Me.lblWastedSpaceBytes.Text = Misc.GetFormatedSize(0, , True)

        ' Some GUI changes
        Me._ProgressBarText.Visible = False
        Me.btnGo.Image = My.Resources.control
        Me.btnGo.Text = strGo
        Me.btnPause.Text = strPause
        _computing = False
        Me.vlvFiles.Enabled = True

        RaiseEvent EndComputing(DateTime.Now.Ticks)
    End Sub


    Private Sub calculateStats(ByVal gpNumber As Integer)
        ' Display some stats
        Me._ProgressBarText.SetProgressAndTextFormatted(11, 11, "Calculating stats...")
        If Me._FileList.Count > 0 Then
            Me.lblDuplicateCount.Text = (Me._FileList.Count - gpNumber).ToString
        Else
            Me.lblDuplicateCount.Text = "0"
        End If
        Me.lblGroupsCount.Text = gpNumber.ToString

        ' Calculating wasted space
        Me.reCalculateStats()
    End Sub

    Private Sub reCalculateStats()

        ' Get the number of different groups
        Dim gpNumber As Integer = 0
        Dim _hash As New Dictionary(Of Byte(), Integer)
        Dim wastedSpace As Long = 0
        For Each item In _FileList
            If _hash.ContainsKey(item._Hash) = False Then
                gpNumber += 1
                _hash.Add(item._Hash, gpNumber)
            Else
                wastedSpace += item._Size
            End If
        Next
        Me.lblWastedSpaceBytes.Text = Misc.GetFormattedSize(wastedSpace, , True)

        ' Display some stats
        If _FileList.Count > 0 Then
            Me.lblDuplicateCount.Text = (_FileList.Count - gpNumber).ToString
        Else
            Me.lblDuplicateCount.Text = "0"
        End If
        Me.lblGroupsCount.Text = gpNumber.ToString

    End Sub

    Private Sub lv_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vlvFiles.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim atLeastOneItem As Boolean = _FileList.Count > 0
            Dim atLeastOneSelectedItem As Boolean = (Me.vlvFiles.SelectedIndices.Count > 0)
            Dim atLeastOneCheckedItem As Boolean = HasCheckedItems()

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
            Me.mnuFile.Show(Me.vlvFiles, e.Location)
        End If

    End Sub

    Private Function HasCheckedItems() As Boolean
        For Each item In _FileList
            If (item._Checked) Then
                Return True
            End If
        Next

        Return False
    End Function


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
            Me.vlvFiles.BeginUpdate()

            Dim dirLen As Integer = dir.Length
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim s As String = Me._FileList(x)._Path
                If s.Length > dirLen Then
                    If s.Substring(0, dirLen).ToUpper <> dir Then
                        Me._FileList.RemoveAt(x)
                    End If
                End If
            Next

            Me.vlvFiles.Invalidate()
            Me.vlvFiles.EndUpdate()
            Me.reCalculateStats()
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
            Me.vlvFiles.BeginUpdate()

            Dim dirLen As Integer = dir.Length
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim s As String = Me._FileList(x)._Path
                If s.Length > dirLen Then
                    If s.Substring(0, dirLen).ToUpper = dir Then
                        Me._FileList.RemoveAt(x)
                    End If
                End If
            Next
            Me.vlvFiles.Invalidate()
            Me.vlvFiles.EndUpdate()
            Me.reCalculateStats()
        End If
    End Sub

    Private Sub MenuItemRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRefresh.Click
        ' Here we refresh list
        ' We remove all none existing files !
        Me.vlvFiles.BeginUpdate()

        For x As Integer = Me._FileList.Count - 1 To 0 Step -1
            If IO.File.Exists(Me._FileList(x)._Path) = False Then
                Me._FileList.RemoveAt(x)
            End If
        Next

        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
        Me.reCalculateStats()
    End Sub

    Private Sub MenuItemCopyFilePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopyFilePath.Click
        ' Copy all selected file path
        Me.vlvFiles.Enabled = False
        Dim sb As New StringBuilder()

        For Each index As Integer In vlvFiles.SelectedIndices
            sb.AppendLine(_FileList(index)._Path)
        Next

        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(sb.ToString())
        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemCopyFileHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopyFileHash.Click
        ' Copy all selected file hash
        Me.vlvFiles.Enabled = False
        Dim sb As New StringBuilder()

        For Each index As Integer In vlvFiles.SelectedIndices
            sb.AppendLine(_FileList(index)._Hash.ToString())
        Next

        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(sb.ToString())
        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCheckAll.Click
        Me.vlvFiles.Enabled = False
        For Each it As ListViewItem In Me.vlvFiles.Items
            it.Checked = True
        Next
        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemCheckNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCheckNone.Click
        Me.vlvFiles.Enabled = False
        For Each it As ListViewItem In Me.vlvFiles.CheckedItems
            it.Checked = False
        Next
        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemOpenFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOpenFileLocation.Click
        Me.vlvFiles.Enabled = False
        For Each index As Integer In vlvFiles.SelectedIndices
            Dim it = _FileList(index)
            cFile.OpenDirectory(it._Path)
        Next

        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOpenFile.Click
        Dim f As New cFile(_FileList(vlvFiles.SelectedIndex)._Path)
        f.ShellOpenFile(Me.Handle)
    End Sub

    Private Sub MenuItemSelCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelCheck.Click
        Me.vlvFiles.Enabled = False
        For Each index As Integer In vlvFiles.SelectedIndices
            Dim it = _FileList(index)
            it._Checked = True
        Next

        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemSelUncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelUncheck.Click
        Me.vlvFiles.Enabled = False
        For Each index As Integer In vlvFiles.SelectedIndices
            Dim it = _FileList(index)
            it._Checked = False
        Next
        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemFileProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFileProperties.Click
        Me.vlvFiles.Enabled = False
        For Each index As Integer In vlvFiles.SelectedIndices
            Dim it = _FileList(index)
            cFile.ShowFileProperty(it._Path, Me.Handle)
        Next

        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemSelRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelRemove.Click
        Me.vlvFiles.BeginUpdate()

        For x As Integer = Me._FileList.Count - 1 To 0 Step -1
            If Me.vlvFiles.Items(x).Selected Then
                Me._FileList.RemoveAt(x)
            End If
        Next
        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemChRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemChRemove.Click
        Me.vlvFiles.BeginUpdate()

        For x As Integer = Me._FileList.Count - 1 To 0 Step -1
            If Me.vlvFiles.Items(x).Checked Then
                Me._FileList.RemoveAt(x)
            End If
        Next
        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemSelRecycle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelToTrash.Click
        PerformFileOperation(FileOperationType.Recycle, True, "Do you want to recycle all selected files?")
    End Sub

    Private Sub MenuItemSelDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSelDelete.Click
        PerformFileOperation(FileOperationType.Delete, True, "Do you want to delete all selected files?")
    End Sub

    Private Sub MenuItemChRecycle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemChToTrash.Click
        PerformFileOperation(FileOperationType.Recycle, False, "Do you want to recycle all checked files?")
    End Sub

    Private Sub MenuItemChDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemChDelete.Click
        PerformFileOperation(FileOperationType.Delete, False, "Do you want to delete all checked files?")
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
            PerformFileOperation(FileOperationType.Move, True, "Do you want to move all the selected files?", dest)
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
            PerformFileOperation(FileOperationType.Move, False, "Do you want to move all the checked files?", dest)
        End If
    End Sub

    Private Sub MenuItemCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopyAll.Click
        ' Copy all selected file info
        Me.vlvFiles.Enabled = False
        Dim sb As New StringBuilder()

        For Each index As Integer In vlvFiles.SelectedIndices
            Dim it = _FileList(index)
            sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\n", it.Id.ToString(), it._GroupId.ToString(), it._Checked.ToString(), it._Path, it._FileType, it._Size.ToString(), it.CreatedDate, it.ModifiedDate)
        Next

        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(sb.ToString())
        Me.vlvFiles.Enabled = True
    End Sub

    Private Sub MenuItemSaveList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSaveList.Click
        ' Save to CSV file
        If Me.SaveFileDialog.ShowDialog = DialogResult.OK Then

            Dim sFile As String = Me.SaveFileDialog.FileName

            Me.vlvFiles.Enabled = False
            Dim file As IO.StreamWriter = System.IO.File.CreateText(sFile)
            Try
                For Each it As ListViewItem In Me.vlvFiles.Items
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

            Me.vlvFiles.Invalidate()
            vlvFiles.EndUpdate()
            Me.vlvFiles.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' probably should add a confirmation dialog here
    ''' </summary>
    ''' <param name="operation"></param>
    Private Sub PerformFileOperation(operation As FileOperationType, selected As Boolean, confirmationMessage As String, Optional destinationPath As String = Nothing)

        If (Ask4Confirmation(confirmationMessage) <> DialogResult.OK) Then
            Return
        End If

        ''construct hashtable map of the file list
        '_fileHashMap = New Dictionary(Of String, cSimpleFile)
        'For Each file In _FileList
        '    _fileHashMap(file.Path) = file
        'Next

        MenuItemChToTrash.Enabled = False
        MenuItemChDelete.Enabled = False
        MenuItemCheckAll.Enabled = False
        MenuItemCheckNone.Enabled = False
        MenuItemChMove.Enabled = False
        MenuItemChRemove.Enabled = False
        MenuItemSelCheck.Enabled = False
        MenuItemSelDelete.Enabled = False
        MenuItemSelMove.Enabled = False
        MenuItemSelRemove.Enabled = False
        MenuItemSelToTrash.Enabled = False
        MenuItemSelUncheck.Enabled = False
        MenuItemCopyAll.Enabled = False


        Dim files As IEnumerable(Of String)
        If (selected) Then
            Dim selectedIndices = vlvFiles.SelectedIndices

            files = vlvFiles.SelectedIndices.Cast(Of Integer) _
            .Select(Function(index) _FileList(index)._Path) _
            .ToList()
        Else
            files = _FileList.Where(Function(o) o._Checked).Select(Function(o) o.Path)
        End If

        files = files.OrderBy(Function(o) o) 'sort by path order so we can get multiple updates to single directories for more speed

        Dim filehandler = New FileOperationEngine()

        AddHandler filehandler.ProgressChanged, AddressOf FileOperationProgress
        AddHandler filehandler.Completed, AddressOf FileOperationComplete

        _ProgressBarText.Visible = True
        _ProgressBarText.BringToFront()

        filehandler.PerformFileOperationInBackground(files, operation, destinationPath)

        Application.DoEvents()
    End Sub

    Private Sub FileOperationProgress(processedCount As Integer, totalCount As Integer, files As IEnumerable(Of String), message As String)
        If Me.InvokeRequired Then
            ' Use a lambda to capture parameters and avoid recursion
            Me.BeginInvoke(Sub() 'do no use Invoke here.  It runs on the current thread and not the handle owner thread
                               FileOperationProgress(processedCount, totalCount, files, message) ' Recursive call on UI thread
                           End Sub)
            Return
        End If

        ' Safe UI updates here (runs on UI thread)

        If files IsNot Nothing AndAlso files.Count > 0 Then
            Dim hashSet = files.ToHashSet()
            _FileList.RemoveAll(Function(o) hashSet.Contains(o._Path))

            _ProgressBarText.SetProgressAndText(processedCount, totalCount, message)

            vlvFiles.VirtualListSize = _FileList.Count
            Me.vlvFiles.Invalidate()
            Me.reCalculateStats()
        End If

        'Application.DoEvents()
    End Sub

    Private Sub FileOperationComplete(success As Boolean, errorMessage As String)
        If Me.InvokeRequired Then
            ' Use a lambda to capture parameters and avoid recursion
            Me.BeginInvoke(Sub() 'do no use Invoke here.  It runs on the current thread and not the handle owner thread
                               FileOperationComplete(success, errorMessage) ' Recursive call on UI thread
                           End Sub)
            Return
        End If

        ' Safe UI updates here (runs on UI thread)
        If (Not String.IsNullOrEmpty(errorMessage)) Then
            lblError.Text = errorMessage
        End If

        Me.vlvFiles.Invalidate()
        Me.reCalculateStats()

        MenuItemChToTrash.Enabled = True
        MenuItemChDelete.Enabled = True
        MenuItemCheckAll.Enabled = True
        MenuItemCheckNone.Enabled = True
        MenuItemChMove.Enabled = True
        MenuItemChRemove.Enabled = True
        MenuItemSelCheck.Enabled = True
        MenuItemSelDelete.Enabled = True
        MenuItemSelMove.Enabled = True
        MenuItemSelRemove.Enabled = True
        MenuItemSelToTrash.Enabled = True
        MenuItemSelUncheck.Enabled = True
        MenuItemCopyAll.Enabled = True

    End Sub


#Region "Menu handlers for duplicate selectors"

    Private Sub UncheckOriginalPerGroup(selector As Func(Of cSimpleFile, Long), isMin As Boolean)

        ' Dictionary: groupID -> (extremeValue, item)
        Dim groupExtremes As New Dictionary(Of Integer, (Value As Long, Item As cSimpleFile))
        Dim i As Integer = 0

        Me.vlvFiles.Enabled = False
        Me.vlvFiles.BeginUpdate()

        ' First pass: Find extreme value per group
        For Each sf As cSimpleFile In _FileList
            Dim groupId = sf._GroupId
            Dim value = selector(sf)

            If groupExtremes.TryGetValue(groupId, Nothing) Then
                Dim current = groupExtremes(groupId)
                If (isMin AndAlso value < current.Value) OrElse (Not isMin AndAlso value > current.Value) Then
                    groupExtremes(groupId) = (value, sf)
                End If
            Else
                groupExtremes.Add(groupId, (value, sf))
            End If
        Next

        ' Create set of original items to uncheck
        Dim originals As New HashSet(Of cSimpleFile)(groupExtremes.Values.Select(Function(extreme) extreme.Item))

        ' Second pass: Update checked states
        i = 0
        For Each item As cSimpleFile In _FileList
            item._Checked = Not originals.Contains(item)
        Next

        vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
        Me.vlvFiles.Enabled = True
    End Sub

    Private Function NonNumericNameLength(sf As cSimpleFile) As Long
        Dim fileName = sf.Path.Substring(sf.Path.LastIndexOf("\"c) + 1)
        Return alphaRegex.Replace(fileName, "").Length
    End Function

    ''' <summary>
    ''' 'original item' is the file which has the most recent creation date
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_mc_Click(sender As Object, e As EventArgs) Handles MenuItemDS_mc.Click
        UncheckOriginalPerGroup(Function(sf) sf._CreatedDate, False)
    End Sub

    ''' <summary>
    ''' check all items except the 'original item' of each group
    ''' 'original item' is the file which has the less recent creation date
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_lc_Click(sender As Object, e As EventArgs) Handles MenuItemDS_lc.Click
        UncheckOriginalPerGroup(Function(sf) sf._CreatedDate, True)
    End Sub

    ''' <summary>
    ''' 'original item' is the file which has the most recent modification date
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_mm_Click(sender As Object, e As EventArgs) Handles MenuItemDS_mm.Click
        UncheckOriginalPerGroup(Function(sf) sf._ModifiedDate, False)
    End Sub

    ''' <summary>
    ''' 'original item' is the file which has the less recent modification date
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_lm_Click(sender As Object, e As EventArgs) Handles MenuItemDS_lm.Click
        UncheckOriginalPerGroup(Function(sf) sf._ModifiedDate, True)
    End Sub

    ''' <summary>
    ''' 'original item' is the file which has the shortest filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_shortestname_Click(sender As Object, e As EventArgs) Handles MenuItemDS_shortestname.Click
        UncheckOriginalPerGroup(Function(sf) sf._Path.Substring(sf.Path.LastIndexOf("\"c) + 1).Length, True)
    End Sub

    ''' <summary>
    ''' 'original item' is the file which has the longest filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_longestname_Click(sender As Object, e As EventArgs) Handles MenuItemDS_longestname.Click
        UncheckOriginalPerGroup(Function(sf) sf._Path.Substring(sf.Path.LastIndexOf("\"c) + 1).Length, False)
    End Sub

    ''' <summary>
    ''' 'original item' is the file which has the shortest non-numeric portion of its filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_shortestnonnumericname_Click(sender As Object, e As EventArgs) Handles MenuItemDS_shortestnonnumericname.Click
        UncheckOriginalPerGroup(AddressOf NonNumericNameLength, True)
    End Sub

    ''' <summary>
    ''' 'original item' is the file which has the longest non-numeric portion of its filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_longestnonnumericname_Click(sender As Object, e As EventArgs) Handles MenuItemDS_longestnonnumericname.Click
        UncheckOriginalPerGroup(AddressOf NonNumericNameLength, False)
    End Sub

    ''' <summary>
    ''' 'original item' is the file which has the shortest path
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_ShortestPath_Click(sender As Object, e As EventArgs) Handles MenuItemDS_ShortestPath.Click
        UncheckOriginalPerGroup(Function(sf) sf._Path.Substring(0, sf.Path.LastIndexOf("\"c)).Length, True)
    End Sub

    ''' <summary>
    '''  'original item' is the file which has the longest path
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MenuItemDS_LongestPath_Click(sender As Object, e As EventArgs) Handles MenuItemDS_LongestPath.Click
        UncheckOriginalPerGroup(Function(sf) sf._Path.Substring(0, sf.Path.LastIndexOf("\"c)).Length, False)
    End Sub

#End Region

#Region "other menu functions"
    Private Sub MenuItemOrphan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOrphan.Click

        Me.vlvFiles.BeginUpdate()


        Dim _dico As Dictionary(Of Integer, List(Of ListViewItem)) = Me.groupItemsByGroupId(False)

        ' Uncheck the original item
        For Each pair As Generic.KeyValuePair(Of Integer, List(Of ListViewItem)) In _dico
            If pair.Value.Count = 1 Then
                ' Remove from list
                Me.vlvFiles.Items.Remove(pair.Value(0))
            End If
        Next

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFRVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRVideos.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extVideos.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()


        If Me.MenuItemFRVideos.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRVideos.Checked = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRVideos.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.vlvFiles.Items.Add(it)
            End While
        End If

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFRImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRImages.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extImages.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        If Me.MenuItemFRImages.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRImages.Checked = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRImages.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.vlvFiles.Items.Add(it)
            End While
        End If

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFRArchives_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRArchives.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extArchives.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        If Me.MenuItemFRArchives.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRArchives.Checked = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRArchives.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.vlvFiles.Items.Add(it)
            End While
        End If

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFRMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRMusic.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extMusic.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        If Me.MenuItemFRMusic.Checked Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFRMusic.Checked = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
                End If
            Next
        Else
            ' Then re-add to list
            Me.MenuItemFRMusic.Checked = True
            ' Pop items from stack
            While _backup.Count > 0
                Dim it As ListViewItem = _backup.Pop
                Me.vlvFiles.Items.Add(it)
            End While
        End If

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFRCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFRCustom.Click
        ' Prompt user for extensions
        Dim s As String = Interaction.InputBox("Format must be *.xx;*.yy;*.zz for multiple extensions.", "Which extensions to remove from list", "*.xx")
        Dim col As New List(Of String)
        For Each ss As String In s.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        For x As Integer = Me._FileList.Count - 1 To 0 Step -1
            If cFile.DoesExtensionMatch(Me._FileList(x)._Path, col) Then
                Me._FileList.RemoveAt(x)
            End If
        Next

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFOArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOArchive.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extArchives.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        If Me.MenuItemFOArchive.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOArchive.Checked = True
            Me.MenuItemFOVideos.Enabled = False
            Me.MenuItemFOImages.Enabled = False
            Me.MenuItemFOMusic.Enabled = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
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
                Me.vlvFiles.Items.Add(it)
            End While
        End If

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFOImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOImages.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extImages.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        If Me.MenuItemFOImages.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOImages.Checked = True
            Me.MenuItemFOVideos.Enabled = False
            Me.MenuItemFOArchive.Enabled = False
            Me.MenuItemFOMusic.Enabled = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
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
                Me.vlvFiles.Items.Add(it)
            End While
        End If

        Me.reCalculateStats()
        Me.vlvFiles.Invalidate()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFOMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOMusic.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extMusic.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        If Me.MenuItemFOMusic.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOMusic.Checked = True
            Me.MenuItemFOVideos.Enabled = False
            Me.MenuItemFOArchive.Enabled = False
            Me.MenuItemFOImages.Enabled = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
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
                Me.vlvFiles.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.vlvFiles.EndUpdate()
    End Sub

    Private Sub MenuItemFOVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFOVideos.Click
        ' Backup of items
        Static _backup As New Stack(Of ListViewItem)
        ' Create list of extensions
        Dim col As New List(Of String)
        For Each ss As String In My.Settings.extVideos.ToUpper.Split(CChar(";"))
            col.Add(ss)
        Next
        Me.vlvFiles.BeginUpdate()

        If Me.MenuItemFOVideos.Checked = False Then
            ' Then remove from list and add to temp stack...
            Me.MenuItemFOVideos.Checked = True
            Me.MenuItemFOArchive.Enabled = False
            Me.MenuItemFOImages.Enabled = False
            Me.MenuItemFOMusic.Enabled = False
            ' Push items to stack
            For x As Integer = Me._FileList.Count - 1 To 0 Step -1
                Dim it As ListViewItem = Me.vlvFiles.Items(x)
                If cFile.DoesExtensionMatch(it.Text, col) = False Then
                    _backup.Push(it)
                    Me._FileList.RemoveAt(x)
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
                Me.vlvFiles.Items.Add(it)
            End While
        End If
        Me.reCalculateStats()
        Me.vlvFiles.EndUpdate()
    End Sub
#End Region

#End Region

    ' Parse the file list and group by group and place into a dictionnary
    Private Function groupItemsByGroupId(Optional ByVal setChecked As Boolean = True) As Dictionary(Of Integer, List(Of ListViewItem))
        Dim _dict As New Dictionary(Of Integer, List(Of ListViewItem))

        If (setChecked) Then Me.vlvFiles.BeginUpdate()

        For Each item As ListViewItem In Me.vlvFiles.Items

            If (setChecked) Then item.Checked = True     ' Check all for now ' do not do this here when they will just be unset later.  ui operations are very expensive

            'Dim key As String = CType(it.Tag, cSimpleFile).Hash
            Dim key = CType(item.Tag, cSimpleFile)._GroupId
            If _dict.ContainsKey(key) = False Then
                Dim lst As New List(Of ListViewItem)
                _dict.Add(key, lst)
            End If
            _dict(key).Add(item)
        Next
        Me.vlvFiles.EndUpdate()
        Return _dict
    End Function


    Private Function Ask4Confirmation(message As String) As DialogResult
        Dim result As DialogResult = MessageBox.Show(message,
                                           "Are you sure?",
                                           MessageBoxButtons.OKCancel,
                                           MessageBoxIcon.Question)

        Return result
    End Function

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub


    Private Function PopulateFileList(count As Integer) As List(Of cSimpleFile)

        ' Generate persistent data collection
        _FileList = New List(Of cSimpleFile)(count)

        Dim rnd As New Random()
        Dim fileTypes() As String = {"Text", "Image", "Video", "Audio", "Document", "Spreadsheet", "Presentation"}

        For i As UInt32 = 0 To CUInt(count) - 1UI
            Dim id = i
            Dim fileName As String = $"file_{rnd.Next(0, 99999999)}.txt"
            Dim fileType As String = fileTypes(rnd.Next(fileTypes.Length))
            Dim fileSizeBytes As Long = CLng(rnd.NextDouble() * 10 * 1024 * 1024 * 1024) + 1
            Dim createdDate As DateTime = DateTime.Now.AddDays(-rnd.Next(0, 3650)).AddSeconds(-rnd.Next(0, 86400))
            Dim modifiedDate As DateTime = createdDate.AddDays(-rnd.Next(0, 3650))
            Dim group As Integer = rnd.Next(1, count \ 10)
            Dim checked As Boolean = rnd.Next(0, 1) = 1

            _FileList.Add(New cSimpleFile(i, fileName, fileType, fileSizeBytes, createdDate, modifiedDate, group, checked))
        Next

        Return _FileList

    End Function

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click

        frmWizard.Show()

        frmWizard.GotoStart()

        Me.Close()
    End Sub

End Class