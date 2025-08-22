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

Imports Misc

Public Class frmPreferences

    ' Constants
    Private Const ARCHIVES_EXT_DEF As String = "*.rar;*.zip;*.7z;*.iso;*.tar;*.ace;*.cab"
    Private Const IMAGES_EXT_DEF As String = "*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff;*.pict"
    Private Const MUSIC_EXT_DEF As String = "*.mp3;*.ogg;*.wma;*.mid;*.midi;*.aac;*.wav"
    Private Const VIDEOS_EXT_DEF As String = "*.avi;*.h264;*.wmv;*.ogm;*.mpg;*.mpeg;*.mpa;*.mov;*.qt;*.flv;*.m1v;*.m2v;*.mp4"

    Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
        Select Case My.Settings.Priority
            Case 0
                System.Diagnostics.Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.Idle
            Case 1
                System.Diagnostics.Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.BelowNormal
            Case 2
                System.Diagnostics.Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.Normal
            Case 3
                System.Diagnostics.Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.AboveNormal
            Case 4
                System.Diagnostics.Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.High
            Case 5
                System.Diagnostics.Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.RealTime
        End Select
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        ' Save
        My.Settings.UpdateAlpha = Me.chkUpdateAlpha.Checked
        My.Settings.UpdateBeta = Me.chkUpdateBeta.Checked
        My.Settings.UpdateAuto = Me.chkUpdateAuto.Checked
        My.Settings.UpdateServer = Me.txtUpdateServer.Text
        My.Settings.Priority = Me.cbPriority.SelectedIndex
        My.Settings.WindowsStartup = Me.chkStart.Checked
        My.Settings.extArchives = Me.txtArchives.Text
        My.Settings.extImages = Me.txtImages.Text
        My.Settings.extMusic = Me.txtMusic.Text
        My.Settings.extVideos = Me.txtVideos.Text
        My.Settings.HashAlgo = CByte(Me.cbHash.SelectedIndex)

        ' Apply 'start with windows'
        Misc.StartWithWindows(My.Settings.WindowsStartup)

        Try
            My.Settings.Save()
            Misc.ShowMsg("Preferences", Nothing, "Saved preferences sucessfully.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Misc.ShowError(ex, "Failed to save preferences")
        End Try

    End Sub

    Private Sub frmPreferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CloseWithEchapKey(Me)

        SetToolTip(Me.chkStart, "Start Big Fast Duplicate File Deleter! on Windows startup")
        SetToolTip(Me.cmdSave, "Save configuration")
        SetToolTip(Me.cmdQuit, "Quit without saving")
        SetToolTip(Me.cmdDefaut, "Set default configuration")
        SetToolTip(Me.cbPriority, "Priority of Big Fast Duplicate File Deleter!")
        SetToolTip(Me.chkUpdateAlpha, "Check for alpha releases")
        SetToolTip(Me.chkUpdateBeta, "Check for beta releases")
        SetToolTip(Me.chkUpdateAuto, "Check for updates at startup")
        SetToolTip(Me.cmdUpdateCheckNow, "Check for updates now")
        SetToolTip(Me.txtUpdateServer, "Update server")
        SetToolTip(Me.txtArchives, "Extensions for archives")
        SetToolTip(Me.txtImages, "Extensions for images")
        SetToolTip(Me.txtMusic, "Extensions for music")
        SetToolTip(Me.txtVideos, "Extensions for videos")
        SetToolTip(Me.cbHash, "Hash algorithm to use. If you don't understand this, just leave the default value :-)")

        ' Set control's values
        Me.chkStart.Checked = My.Settings.WindowsStartup
        Me.cbPriority.SelectedIndex = My.Settings.Priority
        Me.chkUpdateAlpha.Checked = My.Settings.UpdateAlpha
        Me.chkUpdateBeta.Checked = My.Settings.UpdateBeta
        Me.chkUpdateAuto.Checked = My.Settings.UpdateAuto
        Me.txtUpdateServer.Text = My.Settings.UpdateServer
        Me.txtArchives.Text = My.Settings.extArchives
        Me.txtImages.Text = My.Settings.extImages
        Me.txtMusic.Text = My.Settings.extMusic
        Me.txtVideos.Text = My.Settings.extVideos
        Me.cbHash.SelectedIndex = My.Settings.HashAlgo

    End Sub

    Private Sub cmdDefaut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefaut.Click
        ' Defaut settings
        Me.chkStart.Checked = False
        Me.cbPriority.SelectedIndex = 3
        Me.chkUpdateAlpha.Checked = False
        Me.chkUpdateBeta.Checked = False
        Me.chkUpdateAuto.Checked = False
        Me.txtUpdateServer.Text = "http://yadfr.sourceforge.net/update.xml"
        Me.txtArchives.Text = ARCHIVES_EXT_DEF
        Me.txtImages.Text = IMAGES_EXT_DEF
        Me.txtMusic.Text = MUSIC_EXT_DEF
        Me.txtVideos.Text = VIDEOS_EXT_DEF
        Me.cbHash.SelectedIndex = cSimpleFile.EHashAlgorithm.MD5
    End Sub

    Private Sub cmdUpdateCheckNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCheckNow.Click
        ' Check for updates manually
        ' No silent mode, so it will cause a messagebox to be displayed
        My.Settings.UpdateAlpha = Me.chkUpdateAlpha.Checked
        My.Settings.UpdateBeta = Me.chkUpdateBeta.Checked
        Program.Updater.CheckUpdates(False)
    End Sub

    Private Sub cmdDefArchives_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefArchives.Click
        Me.txtArchives.Text = ARCHIVES_EXT_DEF
    End Sub

    Private Sub cmdDefImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefImages.Click
        Me.txtImages.Text = IMAGES_EXT_DEF
    End Sub

    Private Sub cmdDefMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefMusic.Click
        Me.txtMusic.Text = MUSIC_EXT_DEF
    End Sub

    Private Sub cmdDefVideos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefVideos.Click
        Me.txtVideos.Text = VIDEOS_EXT_DEF
    End Sub
End Class