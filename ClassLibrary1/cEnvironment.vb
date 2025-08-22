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
Imports System.Windows.Forms
Imports System.Drawing
Imports Native.Api

Public Class cEnvironment

    Public Enum PrivilegeToRequest
        ShutdownPrivilege
        DebugPrivilege
    End Enum

    ' Public properties


    ' Retrieve elevation type
    Public Shared ReadOnly Property GetElevationType() As Native.Api.NativeEnums.ElevationType
        Get
            Static retrieved As Boolean = False
            Static valRetrieved As Native.Api.NativeEnums.ElevationType

            If retrieved Then
                Return valRetrieved
            Else

                Dim hTok As IntPtr
                Dim hProc As IntPtr = Native.Api.NativeFunctions.OpenProcess(Native.Api.NativeConstants.Process_QueryInformation,
                                                                  False,
                                                                  Native.Api.NativeFunctions.GetCurrentProcessId)
                If hProc.IsNotNull Then
                    ' ?
                End If
                Call Native.Api.NativeFunctions.OpenProcessToken(hProc, Native.Api.NativeConstants.Token_Query, hTok)
                Native.Api.NativeFunctions.CloseHandle(hProc)

                Dim value As Integer
                Dim ret As Integer

                ' Get tokeninfo length
                Native.Api.NativeFunctions.GetTokenInformation(hTok,
                                                    Native.Api.NativeConstants.Token_TokenElevationType,
                                                    IntPtr.Zero,
                                                    0,
                                                    ret)
                Using memAlloc As New Native.Memory.MemoryAlloc(ret)
                    ' Get token information
                    Native.Api.NativeFunctions.GetTokenInformation(hTok,
                                                        Native.Api.NativeConstants.Token_TokenElevationType,
                                                        memAlloc,
                                                        memAlloc.Size,
                                                        0)
                    ' Get a valid structure
                    value = memAlloc.ReadInt32(0)
                    valRetrieved = CType(value, Native.Api.NativeEnums.ElevationType)

                    Native.Api.NativeFunctions.CloseHandle(hTok)

                    If valRetrieved = Native.Api.NativeEnums.ElevationType.Default Then
                        If cEnvironment.IsAdmin = False Then
                            valRetrieved = Native.Api.NativeEnums.ElevationType.Limited
                        Else
                            valRetrieved = Native.Api.NativeEnums.ElevationType.Full
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
            Return Marshal.SizeOf(IntPtr.Zero) = 4
        End Get
    End Property

    Public Shared ReadOnly Property IsFramework2OrAbove() As Boolean
        Get
            Return Environment.Version.Major >= 2
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

        Dim startInfo As New Native.Api.NativeStructs.ShellExecuteInfo
        With startInfo
            .cbSize = Marshal.SizeOf(startInfo)
            '.hwnd = _frmMain.Handle
            .lpFile = Application.ExecutablePath
            .lpVerb = "runas"
            .nShow = Native.Api.NativeEnums.ShowWindowType.ShowNormal
        End With

        Try
            If Native.Api.NativeFunctions.ShellExecuteEx(startInfo) Then
                ' Then the new process has started -> 
                '   - we hide tray icon
                '   - we brutaly terminate this instance
                '   - new instance will start
                '_frmMain.Tray.Visible = False
                Native.Api.NativeFunctions.ExitProcess(0)
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
        Native.Api.NativeFunctions.SendMessage(btn.Handle, BCM_SETSHIELD, IntPtr.Zero, Native.Api.NativeConstants.InvalidHandleValue)
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
            btn.Size = New Size(WID, HGT)
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
