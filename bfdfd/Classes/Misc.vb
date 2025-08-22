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
Imports Microsoft.Win32

Public Class Misc


    ' ========================================
    ' Private constants
    ' ========================================
    Private Shared sizeUnits() As String = {"Bytes", "KB", "MB", "GB", "TB", "PB", "EB"}


    ' ========================================
    ' Private attributes
    ' ========================================



    ' ========================================
    ' Public
    ' ========================================

    ' Array equals ?
    Public Shared Function AreArraysIdentical(ByRef a1() As Byte, ByRef a2() As Byte) As Boolean
        Return (Native.Api.NativeFunctions.memcmp(a1, a2, a1.Length) = 0)
    End Function

    ' Set tool tips
    Public Shared Sub SetToolTip(ByVal ctrl As Control, ByVal text As String)
        Dim tToolTip As ToolTip = New System.Windows.Forms.ToolTip
        With tToolTip
            .SetToolTip(ctrl, text)
            .IsBalloon = False
            .Active = True
        End With
    End Sub

    ' Escape will close the form frm
    Public Shared Sub CloseWithEchapKey(ByRef frm As System.Windows.Forms.Form)
        frm.KeyPreview = True
        Dim oo As New System.Windows.Forms.KeyEventHandler(AddressOf handlerCloseForm_)
        AddHandler frm.KeyDown, oo
    End Sub

    ' Show an error message as a debug message (now messagebox)
    Public Shared Sub ShowDebugError(ByVal ex As Exception)
        Debug.WriteLine("================================================================")
        Debug.WriteLine("GOT AN ERROR")
        Debug.WriteLine("       Source : " & ex.Source)
        Debug.WriteLine("       Message : " & ex.Message)
        If (ex.InnerException IsNot Nothing) Then
            Debug.WriteLine("       Inner Message : " & ex.InnerException.Message)
        End If
        Debug.WriteLine("       Trace : " & ex.StackTrace)
        Debug.WriteLine("================================================================")
    End Sub

    ' Show an error message
    Public Shared Sub ShowError(ByVal ex As Exception, ByVal msg As String, Optional ByVal forceClassical As Boolean = False)
        Dim t0 As New cError(msg, ex)
        t0.ShowMessage(forceClassical)
    End Sub
    Public Shared Sub ShowError(ByVal msg As String, Optional ByVal forceClassical As Boolean = False)
        Dim t0 As New cError(msg)
        t0.ShowMessage(forceClassical)
    End Sub

    ' Get icon from file
    ' NOT IMPLEMENTED
    'Public Shared Function GetIcon(ByVal fName As String, Optional ByVal small As Boolean = True) As System.Drawing.Icon

    '    Dim hImgSmall As Integer
    '    Dim hImgLarge As Integer
    '    Dim shinfo As Native.Api.NativeStructs.SHFileInfo
    '    shinfo = New Native.Api.NativeStructs.SHFileInfo()

    '    If System.IO.File.Exists(fName) = False Then Return Nothing

    '    If small Then
    '        hImgSmall = Native.Api.NativeFunctions.SHGetFileInfo(fName, 0, shinfo, _
    '            Marshal.SizeOf(shinfo), _
    '             Native.Api.NativeConstants.SHGFI_ICON Or Native.Api.NativeConstants.SHGFI_SMALLICON)
    '    Else
    '        hImgLarge = Native.Api.NativeFunctions.SHGetFileInfo(fName, 0, _
    '            shinfo, Marshal.SizeOf(shinfo), _
    '            Native.Api.NativeConstants.SHGFI_ICON Or Native.Api.NativeConstants.SHGFI_LARGEICON)
    '    End If

    '    Dim img As System.Drawing.Icon = Nothing
    '    Try
    '        If shinfo.hIcon.IsNotNull Then
    '            img = System.Drawing.Icon.FromHandle(shinfo.hIcon)
    '        End If
    '    Catch ex As Exception
    '        ' Can't retrieve icon
    '    End Try

    '    Return img

    'End Function

    ' Start (or not) with windows startup
    Public Shared Sub StartWithWindows(ByVal value As Boolean)
        Try
            Dim regKey As RegistryKey
            regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

            If value Then
                regKey.SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                regKey.DeleteValue(Application.ProductName)
            End If
        Catch ex As Exception
            Misc.ShowDebugError(ex)
        End Try
    End Sub

    ' General ShowMessage function
    Public Shared Function ShowMsg(ByVal Title As String, _
                                Optional ByVal HeaderText As String = "", _
                                Optional ByVal Text As String = "", _
                                Optional ByVal Buttons As MessageBoxButtons = MessageBoxButtons.OK, _
                                Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.Information, _
                                Optional ByVal DefButtonIsNoButton As Boolean = False) As DialogResult

        ' Standard message box
        Dim message As String = ""
        If HeaderText Is Nothing Then
            message = Text
        Else
            message = HeaderText
            If Text IsNot Nothing Then
                message &= vbNewLine & Text
            End If
        End If

        Dim defButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1
        If DefButtonIsNoButton Then
            defButton = MessageBoxDefaultButton.Button2
        End If

        Return MessageBox.Show(message, _
                               Title, _
                               Buttons, _
                               Icon, _
                               defButton)
    End Function

    ' Get a formated value as a string (in Bytes, KB, MB or GB) from an Integer
    Public Shared Function GetFormatedSize(ByVal size As Double, Optional ByVal digits As Integer = 3, Optional ByVal forceZeo As Boolean = False) As String
        Return GetFormattedSize(New Decimal(size), digits)
    End Function
    Public Shared Function GetFormatedSize(ByVal size As Integer, Optional ByVal digits As Integer = 3, Optional ByVal forceZeo As Boolean = False) As String
        Return GetFormattedSize(New Decimal(size), digits)
    End Function
    Public Shared Function GetFormatedSize(ByVal size As ULong, Optional ByVal digits As Integer = 3, Optional ByVal forceZeo As Boolean = False) As String
        Return GetFormattedSize(New Decimal(size), digits)
    End Function
    Public Shared Function GetFormatedSize(ByVal size As IntPtr, Optional ByVal digits As Integer = 3, Optional ByVal forceZeo As Boolean = False) As String
        Return GetFormattedSize(New Decimal(size.ToInt64), digits)
    End Function
    Public Shared Function GetFormatedSize(ByVal size As UInteger, Optional ByVal digits As Integer = 3, Optional ByVal forceZeo As Boolean = False) As String
        Return GetFormattedSize(New Decimal(size), digits)
    End Function
    Public Shared Function GetFormattedSize(ByVal size As Decimal, Optional ByVal digits As Integer = 3, Optional ByVal forceZeo As Boolean = False) As String
        Dim t As Decimal = size
        Dim dep As Integer = 0

        While t >= 1024
            t /= 1024
            dep += 1
        End While

        Dim d As Double = Math.Round(t, digits)

        If d > 0 Then
            Return d.ToString & " " & sizeUnits(dep)
        Else
            If forceZeo Then
                Return "0 " & sizeUnits(0)
            Else
                Return ""
            End If
        End If

    End Function
    Public Shared Function GetSizeFromFormatedSize(ByVal _frmtSize As String) As Long
        ' Get position of space
        If _frmtSize Is Nothing OrElse _frmtSize.Length < 4 Then
            Return 0
        End If

        Dim x As Integer = -1
        For Each _unit As String In sizeUnits
            x += 1
            Dim i As Integer = InStrRev(_frmtSize, " " & _unit)
            If i > 0 Then
                Dim z As String = _frmtSize.Substring(0, i - 1)
                Return CLng(Double.Parse(z, Globalization.NumberStyles.Float) * 1024 ^ x)
            End If
        Next

    End Function

    ' Get formated size per second
    Public Shared Function GetFormatedSizePerSecond(ByVal size As Double, Optional ByVal digits As Integer = 3, Optional ByVal forceZeroDisplay As Boolean = False) As String
        Return GetFormatedSizePerSecond(New Decimal(size), digits, forceZeroDisplay)
    End Function
    Public Shared Function GetFormatedSizePerSecond(ByVal size As Decimal, Optional ByVal digits As Integer = 3, Optional ByVal forceZeroDisplay As Boolean = False) As String
        Dim t As Decimal = size
        Dim dep As Integer = 0

        While t >= 1024
            t /= 1024
            dep += 1
        End While

        If forceZeroDisplay OrElse size > 0 Then
            Return CStr(Math.Round(t, digits)) & " " & sizeUnits(dep) & "/s"
        Else
            Return ""
        End If

    End Function

    ' Return true if a string is (or seems to be) a formated size
    Public Shared Function IsFormatedSize(ByVal _str As String) As Boolean
        If _str Is Nothing OrElse _str.Length < 4 Then
            Return False
        End If
        ' Try to find " UNIT" in _str
        ' Return true if first char is a numeric value
        For Each _unit As String In sizeUnits
            Dim i As Integer = InStrRev(_str, " " & _unit)
            If i > 0 AndAlso (i + _unit.Length) = _str.Length Then
                Return IsNumeric(_str.Substring(0, 1))
            End If
        Next
        Return False
    End Function

    ' Return true if a string is (or seems to be) a hexadecimal expression
    Public Shared Function IsHex(ByVal _str As String) As Boolean
        If _str Is Nothing OrElse _str.Length < 4 Then
            Return False
        End If
        Return (_str.Substring(0, 2) = "0x")
    End Function

    ' Return long value from hex value
    Public Shared Function HexToLong(ByVal _str As String) As Long
        If _str Is Nothing OrElse _str.Length < 4 Then
            Return 0
        End If
        Return Long.Parse(_str.Substring(2, _str.Length - 2), _
                          Globalization.NumberStyles.AllowHexSpecifier)
    End Function

    ' Get a formated percentage
    Public Shared Function GetFormatedPercentage(ByVal p As Double, Optional ByVal digits As Integer = 3, Optional ByVal forceZeroDisplay As Boolean = False) As String
        If forceZeroDisplay OrElse p > 0 Then
            Dim d100 As Double = p * 100
            Dim d As Double = Math.Round(d100, digits)
            Dim tr As Double = Math.Truncate(d)
            Dim lp As Integer = CInt(tr)
            Dim rp As Integer = CInt((d100 - tr) * 10 ^ digits)

            Return CStr(IIf(lp < 10, "0", "")) & CStr(lp) & "." & CStr(IIf(rp < 10, "00", "")) & CStr(IIf(rp < 100 And rp >= 10, "0", "")) & CStr(rp)
        Else
            Return ""
        End If
    End Function

    ' Return a well formated path
    Public Shared Function GetWellFormatedPath(ByVal path As String) As String
        Try
            If path IsNot Nothing Then
                If path.ToUpperInvariant.StartsWith("\SYSTEMROOT\") Then
                    path = path.Substring(12, path.Length - 12)
                    Dim ii As Integer = InStr(path, "\", CompareMethod.Binary)
                    If ii > 0 Then
                        path = path.Substring(ii, path.Length - ii)
                        path = Environment.SystemDirectory & "\" & path
                    End If
                ElseIf path.StartsWith("\??\") Then
                    path = path.Substring(4)
                End If
            End If
            Return path
        Catch ex As Exception
            Return path
        End Try
    End Function

    ' Remove items in a listview if delete is pressed
    Public Shared Sub RemoveFromListIfDeleteKeyDown(ByVal lv As ListView, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            For i As Integer = lv.Items.Count - 1 To 0 Step -1
                If lv.Items.Item(i).Selected Then
                    lv.Items.RemoveAt(i)
                End If
            Next
        End If
    End Sub

    ' Add item to a lv if not yet present and not null
    Public Shared Sub AddToListIfNotPresentAndNotNull(ByVal lv As ListView, ByVal item As String)
        If String.IsNullOrEmpty(item) = False Then
            Dim present As Boolean = False
            For Each it As ListViewItem In lv.Items
                If it.Text = item Then
                    present = True
                    Exit For
                End If
            Next
            If Not (present) Then
                lv.Items.Add(item)
            End If
        End If
    End Sub
    Public Shared Sub AddToListIfNotPresentAndNotNull(ByVal lv As ListView, ByVal item As String, ByVal prefix As String)
        If String.IsNullOrEmpty(item) = False Then
            item = prefix & item
            Dim present As Boolean = False
            For Each it As ListViewItem In lv.Items
                If it.Text = item Then
                    present = True
                    Exit For
                End If
            Next
            If Not (present) Then
                lv.Items.Add(item)
            End If
        End If
    End Sub


    ' ========================================
    ' Private functions
    ' ========================================

    Private Shared Sub handlerCloseForm_(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = System.Windows.Forms.Keys.Escape Then
            Try
                Dim _tmp As System.Windows.Forms.Form = DirectCast(sender, System.Windows.Forms.Form)
                _tmp.DialogResult = Windows.Forms.DialogResult.Cancel
                _tmp.Close()
            Catch ex As Exception
                Misc.ShowDebugError(ex)
            End Try
            e.Handled = True
        End If
    End Sub



End Class
