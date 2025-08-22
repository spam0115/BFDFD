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

Imports System.Threading

Public Class ProgressBarText
    Inherits ProgressBar

    ' Label
    Private lbl As Label

    Public Property TheText() As String
        Get
            Return lbl.Text
        End Get
        Set(ByVal value As String)
            lbl.Text = value
        End Set
    End Property
    Public Property Label() As Label
        Get
            Return lbl
        End Get
        Set(ByVal value As Label)
            lbl = value
        End Set
    End Property

    ' Set progress on ProgressBarText
    Public Sub SetProgress(ByVal val As Integer, ByVal max As Integer)
        Console.WriteLine($"UI Update Queued: {val}/{max} Thread: {Thread.CurrentThread.ManagedThreadId}")
        With Me
            '.Minimum = 0
            .Maximum = max
            .Value = val
        End With
        'Application.DoEvents() 'do not call doevents in these functions.  It causes recursion and a stack overflow
    End Sub
    Public Sub SetProgressAndText(ByVal val As Integer, ByVal max As Integer, ByVal text As String)
        With Me
            .TheText = text
            .SetProgress(val, max)
            'Application.DoEvents()
        End With
    End Sub
    Public Sub SetProgressAndTextFormatted(ByVal val As Integer, ByVal max As Integer, ByVal text As String)
        With Me
            .TheText = text & String.Format(" Step {0}/{1}", val, max)
            .SetProgress(val, max)
            'Application.DoEvents()
        End With
    End Sub

End Class
