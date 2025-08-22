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

Public Class ctlStep1
    Implements ICtlStep

    ' Path of the help file
    Private HELP_FILE_PATH As String = Application.StartupPath & "\help.rtf"

    ' Public events
    Public Event NextStepOkChanged(ByVal isOk As Boolean)
    Public Event NextStepNow()
    Public Event ShowPreferences()
    Public Event ShowAbout()

    ' Private properties
    Private _finder As cDuplicateFinder

    Public Sub New(ByRef finder As cDuplicateFinder)
        InitializeComponent()
        _finder = finder
    End Sub

    Public Sub NextStep() Implements ICtlStep.NextStep

    End Sub

    Public ReadOnly Property NextStepOK() As Boolean Implements ICtlStep.NextStepOk
        Get
            Return True
        End Get
    End Property

    Private Sub cmdStartWizard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStartWizard.Click
        RaiseEvent NextStepNow()
    End Sub

    Private Sub ctlStep1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load help file
        If IO.File.Exists(HELP_FILE_PATH) Then
            'Me.rtbHelp.LoadFile(HELP_FILE_PATH, RichTextBoxStreamType.RichText)
        Else
            'Me.rtbHelp.Text = "Failed to load help file !"
        End If
        'Misc.SetToolTip(Me.rtbHelp, "Help file")
        Misc.SetToolTip(Me.cmdDonate, "Please donate to this Open Source project !")
        Misc.SetToolTip(Me.cmdStartWizard, "Start the wizard now")
        Misc.SetToolTip(Me.cmdPreferences, "Change preferences")
    End Sub

    Private Sub ctlStep1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    End Sub

    Private Sub cmdDonate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDonate.Click
        cFile.ShellOpenFile("http://sourceforge.net/projects/yadfr/donate/", Me.Handle)
    End Sub

    Private Sub cmdPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreferences.Click
        RaiseEvent ShowPreferences()
    End Sub

    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        RaiseEvent ShowAbout()
    End Sub

    Private Sub txtWelcome_TextChanged(sender As Object, e As EventArgs) Handles txtWelcome.TextChanged

    End Sub

    Private Sub lblStepDescription_Click(sender As Object, e As EventArgs) Handles lblStepDescription.Click

    End Sub
End Class
