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

Public Class DirNode
    Inherits TreeNode

    ' Private attributes
    Private _alreadyExpanded As Boolean = False
    Private _checkState As System.Windows.Forms.CheckState = System.Windows.Forms.CheckState.Unchecked

    ' Properties
    Public Property AlreadyExpanded() As Boolean
        Get
            Return _alreadyExpanded
        End Get
        Set(ByVal value As Boolean)
            _alreadyExpanded = value
        End Set
    End Property
    Public Property CheckState() As System.Windows.Forms.CheckState
        Get
            Return _checkState
        End Get
        Set(ByVal value As System.Windows.Forms.CheckState)
            _checkState = value
            Me.StateImageIndex = value
        End Set
    End Property

    Public Overloads Property Checked() As Boolean
        Get
            Return _checkState <> CheckState.Unchecked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Me.CheckState = Windows.Forms.CheckState.Checked
            Else
                Me.CheckState = Windows.Forms.CheckState.Unchecked
            End If
        End Set
    End Property


    ' Constructors
    Public Sub New(ByVal text As String, ByVal imageIndex As Integer, ByVal selectedImageIndex As Integer)
        MyBase.New(text, imageIndex, selectedImageIndex)
    End Sub
    Public Sub New(ByVal text As String)
        MyBase.New(text)
    End Sub

End Class
