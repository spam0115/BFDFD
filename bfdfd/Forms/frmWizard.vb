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
Imports System.Threading
Imports Native.Api

Public Class frmWizard

    ' Usercontrols for different steps
    Private WithEvents _step1 As ctlStep1
    Private WithEvents _step2 As ctlStep2
    Private WithEvents _step3 As ctlStep3
    Private WithEvents _step4 As ctlStep4
    'Private WithEvents _step5 As ctlStep5

    ' Number of steps
    Private Const STEP_NUMBER As Integer = 5

    ' Current step
    Private _currentStep As Integer = 1

    ' File finder
    Private _finder As New cDuplicateFinder

    Public Delegate Sub NewUpdateAvailableNotification(ByVal release As cUpdate.NewReleaseInfos)
    Public Delegate Sub NoNewUpdateAvailableNotification()
    Public Delegate Sub FailedToCheckUpDateNotification(ByVal msg As String)

    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Static first As Boolean = True
        If first Then
            Me._step1.cmdStartWizard.Focus()
            first = False
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Tray.Icon = My.Resources.icon

        Misc.SetToolTip(Me.cmdNextStep, "Go next step")
        Misc.SetToolTip(Me.cmdPreviousStep, "Go previous step")

        ' Disable 'start as admin' if we are not on Vista or above
        If cEnvironment.SupportsUac = False _
                OrElse cEnvironment.GetElevationType <> NativeEnums.ElevationType.Limited Then
            Me.mnuMain.MenuItems.Remove(Me.MenuItemMainElevate)
        End If

        ' Instantiate steps
        _step1 = New ctlStep1(_finder)
        _step2 = New ctlStep2(_finder)
        _step3 = New ctlStep3(_finder)
        _step4 = New ctlStep4(_finder)
        '_step5 = New ctlStep5(_finder)
        Program._frmMain = New frmMain(_finder)

        ' Configure tray
        Me.Tray.ContextMenu = Me.mnuMain
        Me.Tray.Visible = True

        ' Set some ctl properties
        Me._step1.Dock = DockStyle.Fill
        Me._step2.Dock = DockStyle.Fill
        Me._step3.Dock = DockStyle.Fill
        Me._step4.Dock = DockStyle.Fill
        'Me._step5.Dock = DockStyle.Fill

        ' Display first step
        Me.DisplayStep(_currentStep, True)

    End Sub

    Public Sub GotoStart()
        DisplayStep(1, True)
    End Sub

    Private Sub DisplayStep(ByVal n As Integer, ByVal _next As Boolean)
        ' Display step n
        If n >= 1 AndAlso n <= STEP_NUMBER Then
            Me.splitMain.Panel2.Controls.Clear()
            Me.lblStepNoutOfN.Text = String.Format("Step {0}/{1}", n, STEP_NUMBER)

            Select Case n
                Case 1
                    Me.splitMain.Panel2.Controls.Add(Me._step1)
                    Me.cmdNextStep.Enabled = Me._step1.NextStepOK
                Case 2
                    If _next Then
                        Me._step1.NextStep()
                    End If
                    Me.splitMain.Panel2.Controls.Add(Me._step2)
                    Me.cmdNextStep.Enabled = Me._step2.NextStepOK
                Case 3
                    If _next Then
                        Me._step2.NextStep()
                    End If
                    Me.splitMain.Panel2.Controls.Add(Me._step3)
                    Me.cmdNextStep.Enabled = Me._step3.NextStepOK
                Case 4
                    If _next Then
                        Me._step3.NextStep()
                    End If
                    Me.splitMain.Panel2.Controls.Add(Me._step4)
                    Me.cmdNextStep.Enabled = Me._step4.NextStepOK
                Case 5
                    If _next Then
                        Me._step4.NextStep()
                    End If
                    'Me.splitMain.Panel2.Controls.Add(Me._step5)
                    'Me.cmdNextStep.Enabled = Me._step5.NextStepOK

                    Me.Hide()
                    Program._frmMain.Show()
            End Select

            Me.cmdPreviousStep.Enabled = (n > 1)
            Me.cmdNextStep.Enabled = Me.cmdNextStep.Enabled And (n < STEP_NUMBER)
        End If
    End Sub

    Private Sub MenuItemMainCheckUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMainCheckUpdate.Click
        ' Check if up to date
        Program.Updater.CheckUpdates(False)
    End Sub

    Private Sub MenuItemMainExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMainExit.Click
        ' Exit Big Fast Duplicate File Deleter!
        Program.ExitProgram()
    End Sub

    Private Sub MenuItemMainElevate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMainElevate.Click
        ' Restart elevated !
        cEnvironment.RestartElevated()
    End Sub

    Private Sub Tray_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tray.MouseDown
        ' Hide some menus if no window displayed
        If Me.MenuItemMainWindow.MenuItems.Count = 0 Then
            Me.MenuItemMainWindow.Visible = False
            Me.MenuItemSeparator2.Visible = False
        Else
            Me.MenuItemMainWindow.Visible = True
            Me.MenuItemSeparator2.Visible = True
        End If
    End Sub

    Private Sub MenuItemMainAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMainAbout.Click
        Dim frm As New frmAboutG
        frm.TopMost = True
        frm.ShowDialog()
    End Sub

    Private Sub cmdNextStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextStep.Click
        _currentStep += 1
        Me.DisplayStep(_currentStep, True)
    End Sub

    Private Sub cmdPreviousStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousStep.Click
        _currentStep -= 1
        Me.DisplayStep(_currentStep, False)
    End Sub

#Region "Step event handlers"

    'Private Sub _step5_BeginComputing() Handles _step5.BeginComputing
    '    Me.cmdNextStep.Enabled = False
    '    Me.cmdPreviousStep.Enabled = False
    'End Sub

    'Private Sub _step5_EndComputing(ByVal time As Long) Handles _step5.EndComputing
    '    Me.cmdNextStep.Enabled = False
    '    Me.cmdPreviousStep.Enabled = True
    '    If time > 0 Then
    '        ' Display time it required
    '        Me.Text = String.Format("Big Fast Duplicate File Deleter! -- it took {0}", New Date(time).ToLongTimeString)
    '    Else
    '        Me.Text = "Big Fast Duplicate File Deleter! -- operation aborted"
    '    End If
    'End Sub

    Private Sub _step1_NextStepNow() Handles _step1.NextStepNow
        Me.cmdNextStep_Click(Nothing, Nothing)
    End Sub

    Private Sub _step1_NextStepOkChanged(ByVal isOk As Boolean) Handles _step1.NextStepOkChanged
        Me.cmdNextStep.Enabled = isOk
    End Sub

    Private Sub _step2_NextStepOkChanged(ByVal isOk As Boolean) Handles _step2.NextStepOkChanged
        Me.cmdNextStep.Enabled = isOk
    End Sub

    Private Sub _step3_NextStepOkChanged(ByVal isOk As Boolean) Handles _step3.NextStepOkChanged
        Me.cmdNextStep.Enabled = isOk
    End Sub

    Private Sub _step4_NextStepOkChanged(ByVal isOk As Boolean) Handles _step4.NextStepOkChanged
        Me.cmdNextStep.Enabled = isOk
    End Sub

#End Region

    Private Sub _step1_ShowAbout() Handles _step1.ShowAbout
        Me.MenuItemMainAbout_Click(Nothing, Nothing)
    End Sub

    Private Sub _step1_ShowPreferences() Handles _step1.ShowPreferences
        Dim frm As New frmPreferences
        frm.TopMost = True
        frm.ShowDialog()
    End Sub

    Private Sub MenuItemHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemHide.Click
        If Me.MenuItemHide.Checked Then
            Me.MenuItemHide.Checked = False
            Me.Show()
        Else
            Me.MenuItemHide.Checked = True
            Me.Hide()
        End If
    End Sub

    Private Sub Tray_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tray.MouseDoubleClick
        If Me.MenuItemHide.Checked Then
            Me.MenuItemHide.Checked = False
        End If
        Me.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
