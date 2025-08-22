' =======================================================
' Big Fast Duplicate File Deleter! (BFDFD)
' Copyright (c) 2025 Zhi Wong
' https://github.com/spam0115/BFDFD
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

Imports System.Runtime.InteropServices
Imports Misc

Public Class frmAboutG

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub lnklblSF_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblSF.LinkClicked
        cFile.ShellOpenFile("http://sourceforge.net/projects/yadfr/", Me.Handle)
    End Sub

    Private Sub frmAboutG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CloseWithEchapKey(Me)

        SetToolTip(Me.cmdLicense, "Display license of Big Fast Duplicate File Deleter!")
        SetToolTip(Me.btnOK, "Close this window")
        SetToolTip(Me.lnklblSF, "Visit Big Fast Duplicate File Deleter! webpage on sourceforge.net")
        SetToolTip(Me.lnkWebsite, "Visit Big Fast Duplicate File Deleter! website")
        SetToolTip(Me.lnkTryYAPM, "Try out YAPM !")
        SetToolTip(Me.lblMe, "Send feedback")
        SetToolTip(Me.cmdDonate, "Please donate to this Open Source project !")

        Me.lblVersion.Text = My.Application.Info.Version.ToString

    End Sub

    Private Sub lblMe_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblMe.LinkClicked
        cFile.ShellOpenFile("mailto:violent_ken@users.sourceforge.net", Me.Handle)
    End Sub

    Private Sub cmdLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLicense.Click
        Dim frm As New frmAbout
        frm.TopMost = True
        frm.ShowDialog()
    End Sub

    Private Sub lnkWebsite_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkWebsite.LinkClicked
        cFile.ShellOpenFile("http://sourceforge.net/projects/yadfr/", Me.Handle)
    End Sub

    Private Sub lnkTryYAPM_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkTryYAPM.LinkClicked
        cFile.ShellOpenFile("http://yaprocmon.sf.net", Me.Handle)
    End Sub

    Private Sub cmdDonate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDonate.Click
        cFile.ShellOpenFile("http://sourceforge.net/projects/yadfr/donate/", Me.Handle)
    End Sub
End Class