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

Imports System.Windows.Forms

Namespace Async

    ' Some async and thread safe functions for the Listview control
    Public Class ListViewC

        Private Delegate Function degAddItem(ByVal lv As Windows.Forms.ListView, ByVal text As String) As Windows.Forms.ListViewItem
        Public Shared Function AddItem(ByVal lv As Windows.Forms.ListView, ByVal text As String) As Windows.Forms.ListViewItem
            If lv.InvokeRequired Then
                Dim d As New degAddItem(AddressOf AddItem)
                Return CType(lv.Invoke(d, lv, text), ListViewItem)
            Else
                Dim it As ListViewItem = lv.Items.Add(text)
                Return it
            End If
        End Function

        Private Delegate Sub degChangeVirtualListSize(ByVal lv As Windows.Forms.ListView, ByVal value As Integer)
        Public Shared Sub ChangeVirtualListSize(ByVal lv As Windows.Forms.ListView, ByVal value As Integer)
            If lv.InvokeRequired Then
                Dim d As New degChangeVirtualListSize(AddressOf ChangeVirtualListSize)
                lv.Invoke(d, lv, value)
            Else
                lv.VirtualListSize = value
            End If
        End Sub

        Private Delegate Function degEnsureItemVisible(ByVal lv As ListView, ByVal text As String) As ListViewItem
        Public Shared Function EnsureItemVisible(ByVal lv As ListView, ByVal text As String) As ListViewItem
            If lv.InvokeRequired Then
                Dim d As New degEnsureItemVisible(AddressOf EnsureItemVisible)
                Return CType(lv.Invoke(d, lv, text), ListViewItem)
            Else
                Dim it As ListViewItem = lv.FindItemWithText(text)
                If it IsNot Nothing Then
                    it.Selected = True
                    it.EnsureVisible()
                End If
                Return it
            End If
        End Function

    End Class



    ' Some async and threaf safe functions for the ProgressBar control
    Public Class ProgressBarC

        Private Delegate Sub degChangeValue(ByVal pgb As Windows.Forms.ProgressBar, ByVal value As Integer)
        Public Shared Sub ChangeValue(ByVal pgb As Windows.Forms.ProgressBar, ByVal value As Integer)
            If pgb.InvokeRequired Then
                Dim d As New degChangeValue(AddressOf ChangeValue)
                pgb.Invoke(d, pgb, value)
            Else
                pgb.Value = value
            End If
        End Sub

        Private Delegate Sub degChangeMaximum(ByVal pgb As Windows.Forms.ProgressBar, ByVal value As Integer)
        Public Shared Sub ChangeMaximum(ByVal pgb As Windows.Forms.ProgressBar, ByVal value As Integer)
            If pgb.InvokeRequired Then
                Dim d As New degChangeMaximum(AddressOf ChangeMaximum)
                pgb.Invoke(d, pgb, value)
            Else
                pgb.Maximum = value
            End If
        End Sub

    End Class



    ' Some async and threaf safe functions for the SplitContainer control
    Public Class SplitContainerC

        Private Delegate Sub degChangeEnabled(ByVal tb As Windows.Forms.SplitContainer, ByVal value As Boolean)
        Public Shared Sub ChangeEnabled(ByVal tb As Windows.Forms.SplitContainer, ByVal value As Boolean)
            If tb.InvokeRequired Then
                Dim d As New degChangeEnabled(AddressOf ChangeEnabled)
                tb.Invoke(d, tb, value)
            Else
                tb.Enabled = value
            End If
        End Sub

    End Class


    ' Some async and threaf safe functions for the Groupbox control
    Public Class GroupBoxC

        Private Delegate Sub degChangeEnabled(ByVal tb As Windows.Forms.GroupBox, ByVal value As Boolean)
        Public Shared Sub ChangeEnabled(ByVal tb As Windows.Forms.GroupBox, ByVal value As Boolean)
            If tb.InvokeRequired Then
                Dim d As New degChangeEnabled(AddressOf ChangeEnabled)
                tb.Invoke(d, tb, value)
            Else
                tb.Enabled = value
            End If
        End Sub

    End Class


    ' Some async and threaf safe functions for the Form control
    Public Class FormC

        Private Delegate Sub degChangeEnabled(ByVal frm As Windows.Forms.Form, ByVal value As Boolean)
        Public Shared Sub ChangeEnabled(ByVal frm As Windows.Forms.Form, ByVal value As Boolean)
            If frm.InvokeRequired Then
                Dim d As New degChangeEnabled(AddressOf ChangeEnabled)
                frm.Invoke(d, frm, value)
            Else
                frm.Enabled = value
            End If
        End Sub

        Private Delegate Sub degChangeCaption(ByVal frm As Windows.Forms.Form, ByVal value As String)
        Public Shared Sub ChangeCaption(ByVal frm As Windows.Forms.Form, ByVal value As String)
            If frm.InvokeRequired Then
                Dim d As New degChangeCaption(AddressOf ChangeCaption)
                frm.Invoke(d, frm, value)
            Else
                frm.Text = value
            End If
        End Sub

    End Class

End Namespace
