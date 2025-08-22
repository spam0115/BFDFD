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

Imports System.Runtime.InteropServices
Imports Native.Api

Public Class cEnvironment

    Public Enum PrivilegeToRequest
        ShutdownPrivilege
        DebugPrivilege
    End Enum

    ' Public properties


    ' Retrieve elevation type
    Public Shared ReadOnly Property GetElevationType() As NativeEnums.ElevationType
        Get
            Static retrieved As Boolean = False
            Static valRetrieved As NativeEnums.ElevationType

            If retrieved Then
                Return valRetrieved
            Else

                Dim hTok As IntPtr
                Dim hProc As IntPtr = NativeFunctions.OpenProcess(Native.Api.NativeConstants.Process_QueryInformation, _
                                                                  False, _
                                                                  NativeFunctions.GetCurrentProcessId)
                If hProc.IsNotNull Then
                    ' ?
                End If
                Call NativeFunctions.OpenProcessToken(hProc, Native.Api.NativeConstants.Token_Query, hTok)
                NativeFunctions.CloseHandle(hProc)

                Dim value As Integer
                Dim ret As Integer

                ' Get tokeninfo length
                NativeFunctions.GetTokenInformation(hTok, _
                                                    Native.Api.NativeConstants.Token_TokenElevationType, _
                                                    IntPtr.Zero, _
                                                    0, _
                                                    ret)
                Using memAlloc As New Native.Memory.MemoryAlloc(ret)
                    ' Get token information
                    NativeFunctions.GetTokenInformation(hTok, _
                                                        Native.Api.NativeConstants.Token_TokenElevationType, _
                                                        memAlloc, _
                                                        memAlloc.Size, _
                                                        0)
                    ' Get a valid structure
                    value = memAlloc.ReadInt32(0)
                    valRetrieved = CType(value, NativeEnums.ElevationType)

                    NativeFunctions.CloseHandle(hTok)

                    If valRetrieved = NativeEnums.ElevationType.Default Then
                        If cEnvironment.IsAdmin = False Then
                            valRetrieved = NativeEnums.ElevationType.Limited
                        Else
                            valRetrieved = NativeEnums.ElevationType.Full
                        End If
                    End If

                    retrieved = True

                    Return valRetrieved

                End Using
            End If
        End Get
    End Property

    Public Shared ReadOnly Property IsAdmin() As Boolean
        Get
            Return My.User.IsAuthenticated AndAlso My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
        End Get
    End Property

    Public Shared ReadOnly Property Is32Bits() As Boolean
        Get
            Return System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) = 4
        End Get
    End Property

    Public Shared ReadOnly Property IsFramework4OrAbove() As Boolean
        Get
            Return Environment.Version.Major >= 4
        End Get
    End Property

    Public Shared ReadOnly Property IsWindowsVistaOrAbove() As Boolean
        Get
            Return (Environment.OSVersion.Platform = PlatformID.Win32NT) And (Environment.OSVersion.Version.Major >= 6)
        End Get
    End Property

    Public Shared ReadOnly Property IsWindows7() As Boolean
        Get
            Return (Environment.OSVersion.Platform = PlatformID.Win32NT) And (Environment.OSVersion.Version.Major = 6 And Environment.OSVersion.Version.Minor = 1)
        End Get
    End Property


#Region "SupportsXXX properties"

    Public Shared ReadOnly Property SupportsTaskDialog() As Boolean
        Get
            Return IsWindowsVistaOrAbove
        End Get
    End Property

    Public Shared ReadOnly Property SupportsUac() As Boolean
        Get
            Return IsWindowsVistaOrAbove
        End Get
    End Property

    Public Shared ReadOnly Property SupportsGetNextThreadProcessFunctions() As Boolean
        Get
            Return IsWindowsVistaOrAbove
        End Get
    End Property

    Public Shared ReadOnly Property SupportsGetThreadIdFunction() As Boolean
        Get
            Return IsWindowsVistaOrAbove
        End Get
    End Property

    Public Shared ReadOnly Property SupportsQueryFullProcessImageNameFunction() As Boolean
        Get
            Return IsWindowsVistaOrAbove
        End Get
    End Property

    Public Shared ReadOnly Property SupportsMinRights() As Boolean
        Get
            Return IsWindowsVistaOrAbove
        End Get
    End Property

#End Region

    ' Restart Big Fast Duplicate File Deleter! elevated
    Public Shared Sub RestartElevated()

        Dim startInfo As New NativeStructs.ShellExecuteInfo
        With startInfo
            .cbSize = System.Runtime.InteropServices.Marshal.SizeOf(startInfo)
            .hwnd = _frmWizard.Handle
            .lpFile = Application.ExecutablePath
            .lpVerb = "runas"
            .nShow = NativeEnums.ShowWindowType.ShowNormal
        End With

        Try
            If NativeFunctions.ShellExecuteEx(startInfo) Then
                ' Then the new process has started -> 
                '   - we hide tray icon
                '   - we brutaly terminate this instance
                '   - new instance will start
                _frmWizard.Tray.Visible = False
                NativeFunctions.ExitProcess(0)
            End If
        Catch ex As Exception
            Misc.ShowDebugError(ex)
        End Try

    End Sub


    ' Return a bitmap containing the UAC shield.
    ' Got this code here : http://www.vb-helper.com/howto_2008_uac_shield.html
    ' But this is not the best way to do it...
    Public Shared Sub AddShieldToButton(ByVal btn As Button)
        Const BCM_SETSHIELD As Int32 = &H160C

        btn.FlatStyle = Windows.Forms.FlatStyle.System
        NativeFunctions.SendMessage(btn.Handle, BCM_SETSHIELD, IntPtr.Zero, NativeConstants.InvalidHandleValue)
    End Sub
    Public Shared Function GetUacShieldImage() As Bitmap
        Static shield_bm As Bitmap = Nothing
        If shield_bm Is Nothing Then
            Const WID As Integer = 50
            Const HGT As Integer = 50
            Const MARGIN As Integer = 4

            ' Make the button. For some reason, it must
            ' have text or the UAC shield won't appear.
            Dim btn As New Button
            btn.Text = " "
            btn.Size = New System.Drawing.Size(WID, HGT)
            AddShieldToButton(btn)

            ' Draw the button onto a bitmap.
            Dim bm As New Bitmap(WID, HGT)
            btn.Refresh()
            btn.DrawToBitmap(bm, New Rectangle(0, 0, WID, HGT))

            ' Find the part containing the shield.
            Dim min_x As Integer = WID
            Dim max_x As Integer = 0
            Dim min_y As Integer = WID
            Dim max_y As Integer = 0

            ' Fill on the left.
            For y As Integer = MARGIN To HGT - MARGIN - 1
                ' Get the leftmost pixel's color.
                Dim target_color As Color = bm.GetPixel(MARGIN, _
                    y)

                ' Fill in with this color as long as we see the
                ' target.
                For x As Integer = MARGIN To WID - MARGIN - 1
                    ' See if this pixel is part of the shield.
                    If bm.GetPixel(x, y).Equals(target_color) _
                        Then
                        ' It's not part of the shield.
                        ' Clear the pixel.
                        bm.SetPixel(x, y, Color.Transparent)
                    Else
                        ' It's part of the shield.
                        If min_y > y Then min_y = y
                        If min_x > x Then min_x = x
                        If max_y < y Then max_y = y
                        If max_x < x Then max_x = x
                    End If
                Next x
            Next y

            ' Clip out the shield part.
            Dim shield_wid As Integer = max_x - min_x + 1
            Dim shield_hgt As Integer = max_y - min_y + 1
            shield_bm = New Bitmap(shield_wid, shield_hgt)
            Dim shield_gr As Graphics = _
                Graphics.FromImage(shield_bm)
            shield_gr.DrawImage(bm, 0, 0, _
                New Rectangle(min_x, min_y, shield_wid, _
                    shield_hgt), _
                GraphicsUnit.Pixel)
        End If

        Return shield_bm
    End Function


End Class
