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

Public Class ctlNumericTextBox
    Inherits TextBox

    Private SpaceOK As Boolean = False

    ' Restrict paste
    Private Const WM_RBUTTONUP As Long = &H205
    Private Const WM_COPY As Integer = &H301
    Private Const WM_PASTE As Integer = &H302

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_RBUTTONUP Then
            Return
        End If
        If m.Msg = WM_PASTE Then
            Return
        End If
        MyBase.WndProc(m)
    End Sub


    ' Restricts the entry of characters to digits (including hex),
    ' the negative sign, the e decimal point, and editing keystrokes (backspace).
    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        If isCharOK(e.KeyChar) = False Then
            e.Handled = True
        End If

    End Sub

    Private Function isCharOK(ByVal c As Char) As Boolean
        Dim numberFormatInfo As Globalization.NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
        Dim decimalSeparator As String = numberFormatInfo.NumberDecimalSeparator
        Dim groupSeparator As String = numberFormatInfo.NumberGroupSeparator
        Dim negativeSign As String = numberFormatInfo.NegativeSign
        Dim otherDecimalSeparator As String = "" '"."

        Dim keyInput As String = c.ToString()

        If [Char].IsDigit(c) Then
            Return True
        ElseIf keyInput.Equals(otherDecimalSeparator) OrElse _
                keyInput.Equals(decimalSeparator) OrElse _
                keyInput.Equals(groupSeparator) OrElse _
                keyInput.Equals(negativeSign) Then
            Return True
        ElseIf c = vbBack Then
            Return True
        ElseIf Me.SpaceOK AndAlso c = " "c Then
            Return True
        Else
            ' Not valid
            Return False
        End If

    End Function

    Public ReadOnly Property IntValue() As Integer
        Get
            Return Int32.Parse(Me.Text)
        End Get
    End Property

    Public ReadOnly Property DecimalValue() As Decimal
        Get
            Return [Decimal].Parse(Me.Text)
        End Get
    End Property

    Public Property AllowSpace() As Boolean
        Get
            Return Me.SpaceOK
        End Get
        Set(ByVal value As Boolean)
            Me.SpaceOK = value
        End Set
    End Property
End Class