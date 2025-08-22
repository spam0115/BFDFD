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


Imports BrightIdeasSoftware

Public Module Program

    ' Main form
    Public _frmWizard As frmWizard
    Public _frmMain As frmMain

    Private WithEvents _updater As cUpdate
    Private _time As Integer

    Public ReadOnly Property ElapsedTime() As Integer
        Get
            Return Native.Api.Win32.GetElapsedTime - _time
        End Get
    End Property

    Public ReadOnly Property Updater() As cUpdate
        Get
            Return _updater
        End Get
    End Property


    Public Sub Main()


        ' ======= Some basic initialisations
        ' /!\ Looks like Comctl32 v6 could not be initialized before
        ' a form is loaded. So as Comctl32 v5 can not display VistaDialogBoxes,
        ' all error messages before instanciation of a form should use classical style.
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)    ' Use GDI, not GDI+

        ' ======= Save time of start
        _time = Native.Api.Win32.GetElapsedTime

        ' ======= Check if framework is 2.0 or above
        If cEnvironment.IsFramework4OrAbove = False Then
            Misc.ShowError(".Net Framework 4.5+ must be installed.", True)
            Application.Exit()
        End If

        ' ======= Set handler for exceptions
        AddHandler Application.ThreadException, AddressOf MYThreadHandler
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf MYExnHandler
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

        ' ======= Instanciate all classes
        _frmWizard = New frmWizard              ' Main form
        _updater = New cUpdate              ' Updater class

        ' ======= Load preferences
        If My.Settings.ShouldUpgrade Then
            Try
                ' Try to update settings from a previous version of Big Fast Duplicate File Deleter!
                My.Settings.Upgrade()
            Catch ex As Exception
                Misc.ShowDebugError(ex)
            End Try
            My.Settings.ShouldUpgrade = False
            My.Settings.Save()
        End If
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

        ' First start -> message
        Try
            If My.Settings.FirstTime Then
                Misc.ShowMsg("This is the first time Big Fast Duplicate File Deleter! starts",
                             "Please read this (this message won't be displayed anymore) :",
                             "Thanks for using Big Fast Duplicate File Deleter! !",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information)
                My.Settings.FirstTime = False
                My.Settings.Save()
            End If
        Catch ex As Exception
            ' Preference file corrupted/missing
            Misc.ShowMsg("Startup error", "Failed to load preferences.", "Preference file is missing or corrupted and will be now recreated.", MessageBoxButtons.OK, MessageBoxIcon.Error, True)
            My.Settings.Save()
        End Try


        ' ======= Check update
        If My.Settings.UpdateAuto Then
            Program.Updater.CheckUpdates(True)
        End If


        ' ======= Launch program
        Try
            Application.Run(_frmWizard)
        Catch ex As MungerException
            Misc.ShowDebugError(ex)
        Catch ex As Exception
            Misc.ShowDebugError(ex)
        End Try

    End Sub

    ' Handler for exceptions
    Private Sub MYExnHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim ex As Exception
        ex = CType(e.ExceptionObject, Exception)
        Console.WriteLine(ex.StackTrace)
        Dim t As New frmError(ex)
        t.TopMost = True
#If RELEASE_MODE = 1 Then
        t.ShowDialog()
#End If
    End Sub

    Private Sub MYThreadHandler(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
        Console.WriteLine(e.Exception.StackTrace)
        Dim t As New frmError(e.Exception)
        t.TopMost = True
#If RELEASE_MODE = 1 Then
        t.ShowDialog()
#End If
    End Sub

    ' Free memory (GC)
    Public Sub CollectGarbage()
        ' Use GC to collect
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub

    ' Generate an unhandled error
    Public Sub ThrowUnhandledError()
        Dim x As IntPtr = IntPtr.Zero
        Runtime.InteropServices.Marshal.ReadInt64(x, 0)
    End Sub


    ' Exit application
    Public Sub ExitProgram()

        ' Save settings
        My.Settings.Save()

        ' Close forms & exit
        If _frmWizard IsNot Nothing Then
            _frmWizard.Close()
        End If
        Application.Exit()

    End Sub

    Private Sub _updater_FailedToCheckVersion(ByVal silent As Boolean, ByVal msg As String) Handles _updater.FailedToCheckVersion
        ' Failed to check update
        If silent Then
            ' Silent mode -> only displays a tooltip
            If _frmWizard IsNot Nothing AndAlso _frmWizard.Tray IsNot Nothing Then
                With _frmWizard.Tray
                    .BalloonTipText = msg
                    .BalloonTipIcon = ToolTipIcon.Info
                    .BalloonTipTitle = "Could not check if Big Fast Duplicate File Deleter! us ip to date."
                    .ShowBalloonTip(3000)
                End With
            End If
        Else
            _frmWizard.Invoke(New frmWizard.FailedToCheckUpDateNotification(AddressOf impFailedToCheckUpDateNotification), msg)
        End If
    End Sub

    Private Sub _updater_NewVersionAvailable(ByVal silent As Boolean, ByVal release As cUpdate.NewReleaseInfos) Handles _updater.NewVersionAvailable
        ' A new version of Big Fast Duplicate File Deleter! is available
        If silent Then
            ' Silent mode -> only displays a tooltip
            If _frmWizard IsNot Nothing AndAlso _frmWizard.Tray IsNot Nothing Then
                With _frmWizard.Tray
                    .BalloonTipText = release.Infos
                    .BalloonTipIcon = ToolTipIcon.Info
                    .BalloonTipTitle = "A new version of Big Fast Duplicate File Deleter! is available !"
                    .ShowBalloonTip(3000)
                End With
            End If
        Else
            _frmWizard.Invoke(New frmWizard.NewUpdateAvailableNotification(AddressOf impNewUpdateAvailableNotification), release)
        End If
    End Sub

    Private Sub _updater_ProgramUpToDate(ByVal silent As Boolean) Handles _updater.ProgramUpToDate
        ' Big Fast Duplicate File Deleter! is up to date (no new version available)
        If silent Then
            ' Silent mode -> only displays a tooltip
            If _frmWizard IsNot Nothing AndAlso _frmWizard.Tray IsNot Nothing Then
                With _frmWizard.Tray
                    .BalloonTipText = "Big Fast Duplicate File Deleter! is up to date !"
                    .BalloonTipIcon = ToolTipIcon.Info
                    .BalloonTipTitle = "No new version of Big Fast Duplicate File Deleter! is available."
                    .ShowBalloonTip(3000)
                End With
            End If
        Else
            _frmWizard.Invoke(New frmWizard.NoNewUpdateAvailableNotification(AddressOf impNoNewUpdateAvailableNotification))
        End If
    End Sub

    ' Called when a new update is available
    ' It's here cause of thread safety
    Public Sub impNewUpdateAvailableNotification(ByVal release As cUpdate.NewReleaseInfos)
        Dim frm As New frmNewVersionAvailable(release)
        frm.ShowDialog()
    End Sub

    ' Called when no new update is available
    ' It's here cause of thread safety
    Public Sub impNoNewUpdateAvailableNotification()
        Misc.ShowMsg("Big Fast Duplicate File Deleter! update",
                          "Big Fast Duplicate File Deleter! is up to date !",
                          "The current version (" & My.Application.Info.Version.ToString & ") is the latest available for download.",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)
    End Sub

    ' Called when failed to check is Big Fast Duplicate File Deleter! is up to date
    Public Sub impFailedToCheckUpDateNotification(ByVal msg As String)
        Misc.ShowMsg("Big Fast Duplicate File Deleter! update",
                                "Could not check if Big Fast Duplicate File Deleter! is up to date.",
                                msg,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
    End Sub

End Module
