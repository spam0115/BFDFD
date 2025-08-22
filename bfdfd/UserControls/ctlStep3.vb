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

Public Class ctlStep3
    Implements ICtlStep

    ' Public events
    Public Event NextStepOkChanged(ByVal isOk As Boolean)

    ' Private attributes
    Private _finder As cDuplicateFinder
    Private _nextOK As Boolean = False

    Public Sub New(ByRef finder As cDuplicateFinder)
        InitializeComponent()
        _finder = finder
    End Sub

    Private Sub ctlStep2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Native.Api.NativeFunctions.SetWindowTheme(Me.lvI.Handle, "explorer", Nothing)
        Native.Api.NativeFunctions.SetWindowTheme(Me.lvE.Handle, "explorer", Nothing)
        Misc.SetToolTip(Me.txtInclude, "This field accepts the '*' char")
        Misc.SetToolTip(Me.txtExclude, "This field accepts the '*' char")
        Misc.SetToolTip(Me.lvE, "Excluded extensions")
        Misc.SetToolTip(Me.lvI, "Included extensions")
        Misc.SetToolTip(Me.chkEArchives, "Exclude archives (*.zip, *.rar, *.iso...)")
        Misc.SetToolTip(Me.chkECustom, "Exclude custom extensions")
        Misc.SetToolTip(Me.chkEImages, "Exclude images (*.jpg, *.bmp, *.png...)")
        Misc.SetToolTip(Me.chkEMusic, "Exclude music (*.mp3, *.wma, *.ogg...)")
        Misc.SetToolTip(Me.chkEVideos, "Exclude videos (*.avi, *.mpg, *.wmv...)")
        Misc.SetToolTip(Me.chkIAll, "Include all files")
        Misc.SetToolTip(Me.chkIArchives, "Include archives (*.zip, *.rar, *.iso...)")
        Misc.SetToolTip(Me.chkICustom, "Include custom extensions")
        Misc.SetToolTip(Me.chkIImages, "Include images (*.jpg, *.bmp, *.png...)")
        Misc.SetToolTip(Me.chkIMusic, "Include music (*.mp3, *.wma, *.ogg...)")
        Misc.SetToolTip(Me.chkIVideos, "Include videos (*.avi, *.mpg, *.wmv...)")
        Me.chkECustom.Checked = True
        Me.lvE.Items.Add("*.dll")
        Me.lvE.Items.Add("*.manifest")
        Me.lvE.Items.Add("*.mui")
        Me.lvE.Items.Add("*.sys")
    End Sub

    Private Sub ctlStep2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.header1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
        Me.header2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub cmdAddIncludeFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIncludeFilter.Click
        ' Add to list of included dirs
        Dim s As String = Me.txtInclude.Text
        If s.Length > 2 AndAlso s.Substring(0, 2) = "*." Then
            s = s.Substring(2, s.Length - 2)
        End If
        Misc.AddToListIfNotPresentAndNotNull(Me.lvI, s, "*.")
        Me.raiseEventNextReady()
        Me.txtInclude.Text = ""
    End Sub

    Private Sub cmdAddExcludeFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddExcludeFilter.Click
        ' Add to list of excluded dirs
        Dim s As String = Me.txtExclude.Text
        If s.Length > 2 AndAlso s.Substring(0, 2) = "*." Then
            s = s.Substring(2, s.Length - 2)
        End If
        Misc.AddToListIfNotPresentAndNotNull(Me.lvE, s, "*.")
        Me.txtExclude.Text = ""
    End Sub

    Private Sub chkIAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIAll.CheckedChanged
        Me.chkIArchives.Enabled = Not (Me.chkIAll.Checked)
        Me.chkIImages.Enabled = Not (Me.chkIAll.Checked)
        Me.chkIMusic.Enabled = Not (Me.chkIAll.Checked)
        Me.chkIVideos.Enabled = Not (Me.chkIAll.Checked)
        Me.chkICustom.Enabled = Not (Me.chkIAll.Checked)
        If Me.chkIAll.Checked Then
            Me.splitIncludeCustom.Enabled = False
        Else
            Me.splitIncludeCustom.Enabled = Me.chkIArchives.Checked
        End If
        Me.raiseEventNextReady()
    End Sub

    Private Sub lvE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvE.KeyDown
        Misc.RemoveFromListIfDeleteKeyDown(Me.lvE, e)
    End Sub

    Private Sub lvI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvI.KeyDown
        Misc.RemoveFromListIfDeleteKeyDown(Me.lvI, e)
        Me.raiseEventNextReady()
    End Sub

    Public Sub NextStep() Implements ICtlStep.NextStep
        _finder.FileEnumerator.ExcludeByFileExtension = (Me.chkEArchives.Checked OrElse Me.chkEImages.Checked OrElse Me.chkEMusic.Checked OrElse Me.chkEVideos.Checked OrElse (Me.chkECustom.Checked AndAlso Me.lvE.Items.Count > 0))
        _finder.FileEnumerator.IncludeByFileExtension = (Me.chkIAll.Checked = False)
        If _finder.FileEnumerator.ExcludeByFileExtension Then
            _finder.FileEnumerator.ExcludedExtensions.Clear()
            If Me.chkEArchives.Checked Then
                For Each ss As String In My.Settings.extArchives.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.ExcludedExtensions.Add(ss)
                Next
            End If
            If Me.chkECustom.Checked Then
                For Each it As ListViewItem In Me.lvE.Items
                    _finder.FileEnumerator.ExcludedExtensions.Add(it.Text)
                Next
            End If
            If Me.chkEImages.Checked Then
                For Each ss As String In My.Settings.extImages.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.ExcludedExtensions.Add(ss)
                Next
            End If
            If Me.chkEMusic.Checked Then
                For Each ss As String In My.Settings.extMusic.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.ExcludedExtensions.Add(ss)
                Next
            End If
            If Me.chkEVideos.Checked Then
                For Each ss As String In My.Settings.extVideos.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.ExcludedExtensions.Add(ss)
                Next
            End If
        End If
        If _finder.FileEnumerator.IncludeByFileExtension Then
            _finder.FileEnumerator.IncludedExtensions.Clear()
            If Me.chkIArchives.Checked Then
                For Each ss As String In My.Settings.extArchives.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.IncludedExtensions.Add(ss)
                Next
            End If
            If Me.chkICustom.Checked Then
                For Each it As ListViewItem In Me.lvI.Items
                    _finder.FileEnumerator.IncludedExtensions.Add(it.Text)
                Next
            End If
            If Me.chkIImages.Checked Then
                For Each ss As String In My.Settings.extImages.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.IncludedExtensions.Add(ss)
                Next
            End If
            If Me.chkIMusic.Checked Then
                For Each ss As String In My.Settings.extMusic.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.IncludedExtensions.Add(ss)
                Next
            End If
            If Me.chkIVideos.Checked Then
                For Each ss As String In My.Settings.extVideos.ToUpper.Split(CChar(";"))
                    _finder.FileEnumerator.IncludedExtensions.Add(ss)
                Next
            End If
        End If
    End Sub

    Public ReadOnly Property NextStepOK() As Boolean Implements ICtlStep.NextStepOk
        Get
            Return _nextOK
        End Get
    End Property

    ' Raise the event "NextStepOkChanged" is value has changed
    Private Sub raiseEventNextReady()
        Static _old As Boolean = True
        _nextOK = Me.chkIAll.Checked OrElse _
                    Me.chkIImages.Checked OrElse _
                    Me.chkIMusic.Checked OrElse _
                    Me.chkIVideos.Checked OrElse _
                    Me.chkIArchives.Checked OrElse _
                    (Me.chkICustom.Checked And Me.lvI.Items.Count > 0)
        If _nextOK <> _old Then
            _old = _nextOK
            RaiseEvent NextStepOkChanged(_nextOK)
        End If
    End Sub

    Private Sub chkIArchive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIArchives.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkEArchive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEArchives.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkIImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIImages.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkIMusic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIMusic.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkIVideos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIVideos.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkECustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkECustom.CheckedChanged
        Me.splitExcludeCustom.Enabled = Me.chkECustom.Checked
    End Sub

    Private Sub chkICustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkICustom.CheckedChanged
        Me.splitIncludeCustom.Enabled = Me.chkICustom.Checked
        Me.raiseEventNextReady()
    End Sub

    Private Sub txtExclude_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExclude.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdAddExcludeFilter_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtInclude_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInclude.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdAddIncludeFilter_Click(Nothing, Nothing)
        End If
    End Sub
End Class
