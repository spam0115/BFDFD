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

Option Strict On

Public Class ctlStep2
    Implements ICtlStep

    ' Public events
    Public Event NextStepOkChanged(ByVal isOk As Boolean)
    Private _img As New FileTreeView.StateImageList
    Private _img2 As ImageList

    ' Private properties
    Private WithEvents dirExplorer As FileTreeView.FileTreeView
    Private _finder As cDuplicateFinder
    Private _nextOK As Boolean = False

    Public Sub New(ByRef finder As cDuplicateFinder)
        InitializeComponent()
        _finder = finder
        ' Initializes ImageList
        _img2 = New ImageList
        _img2.ImageSize = New Size(16, 16)
        _img2.ColorDepth = ColorDepth.Depth32Bit
        _img2.Images.Add("drive", My.Resources.drive)
        _img2.Images.Add("folder", My.Resources.folder)

        ' Create dirExplorer
        Me.dirExplorer = New FileTreeView.FileTreeView(_img.ImageList)
        Me.dirExplorer.ImageList = Me._img2
        Me.dirExplorer.Cursor = System.Windows.Forms.Cursors.Default
        Me.dirExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dirExplorer.Location = New System.Drawing.Point(0, 0)
        Me.dirExplorer.TabIndex = 1
        Me.splitInclude.Panel2.Controls.Add(Me.dirExplorer)
    End Sub

    Private Sub ctlStep1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Native.Api.NativeFunctions.SetWindowTheme(Me.lvExclude.Handle, "explorer", Nothing)
        Misc.SetToolTip(Me.txtExclude, "This field accepts the '*' char")
        Misc.SetToolTip(Me.dirExplorer, "Directories to include")
        Misc.SetToolTip(Me.lvExclude, "Excluded directories. 'Del' key to remove from list")
        Misc.SetToolTip(Me.cmdBrowseExclude, "Select a directory to exclude")
        Misc.SetToolTip(Me.cmdAddExclude, "Add to the excluded directories list")

        ' Add windir by default
        Me.lvExclude.Items.Add(Environment.GetEnvironmentVariable("windir"))

    End Sub

    Private Sub cmdBrowseExclude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseExclude.Click
        ' Browse for a directory to exclude
        Dim brwse As New FolderBrowserDialog
        With brwse
            .Description = "Select directories to exclude"
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If brwse.ShowDialog = DialogResult.OK Then
            Me.txtExclude.Text = brwse.SelectedPath
        End If
    End Sub

    Private Sub cmdAddExclude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddExclude.Click
        ' Add to list of excluded dirs
        Misc.AddToListIfNotPresentAndNotNull(Me.lvExclude, Me.txtExclude.Text)
        Me.txtExclude.Text = ""
    End Sub

    Private Sub ctlStep1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.header1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub lvExclude_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvExclude.KeyDown
        Misc.RemoveFromListIfDeleteKeyDown(Me.lvExclude, e)
    End Sub

    Public Sub NextStep() Implements ICtlStep.NextStep

        ' Save include directories
        _finder.IncludedDirectories.Clear()
        For Each Dir As FileTreeView.DirNode In Me.dirExplorer.GetDirectories
            _finder.IncludedDirectories.Add(Dir.FullPath)
        Next

        ' Save exclude directories
        _finder.ExcludedDirectories.Clear()
        For Each it As ListViewItem In Me.lvExclude.Items
            _finder.ExcludedDirectories.Add(it.Text.ToUpper)
        Next

    End Sub

    Public ReadOnly Property NextStepOK() As Boolean Implements ICtlStep.NextStepOk
        Get
            Return _nextOK
        End Get
    End Property

    Private Sub dirExplorer_NodeClicked() Handles dirExplorer.NodeClicked
        Static _old As Boolean = False
        _nextOK = Me.dirExplorer.GetDirectories.Count > 0
        If _old <> _nextOK Then
            _old = _nextOK
            RaiseEvent NextStepOkChanged(_nextOK)
        End If
    End Sub

    Private Sub txtExclude_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExclude.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtExclude_KeyDown(Nothing, Nothing)
        End If
    End Sub
End Class
