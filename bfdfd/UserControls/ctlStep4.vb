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

Public Class ctlStep4
    Implements ICtlStep

    ' Public events
    Public Event NextStepOkChanged(ByVal isOk As Boolean)

    ' Private attributes
    Private _finder As cDuplicateFinder
    Private _nextOK As Boolean = False

    Public Sub New(ByRef finder As cDuplicateFinder)
        InitializeComponent()
        _finder = finder
    End Sub

    Private Sub ctlStep3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cbEDateType.SelectedIndex = 0
        Me.cbIDateType.SelectedIndex = 0
        Me.cbESizeUnitGT.SelectedIndex = 0
        Me.cbISizeUnitGT.SelectedIndex = 0
        Me.cbESizeUnitLT.SelectedIndex = 0
        Me.cbISizeUnitLT.SelectedIndex = 0
        Misc.SetToolTip(Me.txtESizeGT, "Comparison size")
        Misc.SetToolTip(Me.txtESizeLT, "Comparison size")
        Misc.SetToolTip(Me.txtISizeGT, "Comparison size")
        Misc.SetToolTip(Me.txtISizeLT, "Comparison size")
        Misc.SetToolTip(Me.cbEDateType, "Date type to use")
        Misc.SetToolTip(Me.cbESizeUnitGT, "Size unit")
        Misc.SetToolTip(Me.cbESizeUnitLT, "Size unit")
        Misc.SetToolTip(Me.cbIDateType, "Date type to use")
        Misc.SetToolTip(Me.cbISizeUnitGT, "Size unit")
        Misc.SetToolTip(Me.cbISizeUnitLT, "Size unit")
        Misc.SetToolTip(Me.chkEDate, "Exclude files by date")
        Misc.SetToolTip(Me.chkEDateGT, "Exclude if date is greater than this date")
        Misc.SetToolTip(Me.chkEDateLT, "Exclude if date is lower than this date")
        Misc.SetToolTip(Me.chkENone, "Exclude no files")
        Misc.SetToolTip(Me.chkESize, "Exclude files by size")
        Misc.SetToolTip(Me.chkESizeGT, "Exclude if size is greater than this size")
        Misc.SetToolTip(Me.chkESizeLT, "Exclude if size is lower than this size")
        Misc.SetToolTip(Me.chkIAll, "Include all files")
        Misc.SetToolTip(Me.chkIDate, "Include files by date")
        Misc.SetToolTip(Me.chkISizeGT, "Include if size is greater than this size")
        Misc.SetToolTip(Me.chkISizeLT, "Include if size is lower than this size")
        Misc.SetToolTip(Me.chkISize, "Include files by size")
        Misc.SetToolTip(Me.chkIDateGT, "Include if date is greater than this date")
        Misc.SetToolTip(Me.chkIDateLT, "Include if date is lower than this date")
        Misc.SetToolTip(Me.dtEGT, "Comparison date")
        Misc.SetToolTip(Me.dtELT, "Comparison date")
        Misc.SetToolTip(Me.dtIGT, "Comparison date")
        Misc.SetToolTip(Me.dtILT, "Comparison date")
    End Sub

    Private Sub chkIAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIAll.CheckedChanged
        Me.chkIDate.Enabled = Not (Me.chkIAll.Checked)
        Me.chkISize.Enabled = Not (Me.chkIAll.Checked)
        If Me.chkIAll.Checked Then
            Me.splitI.Panel1.Enabled = False
            Me.splitI.Panel2.Enabled = False
        Else
            Me.splitI.Panel2.Enabled = Me.chkIDate.Checked
            Me.splitI.Panel1.Enabled = Me.chkISize.Checked
        End If
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkENone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkENone.CheckedChanged
        Me.chkEDate.Enabled = Not (Me.chkENone.Checked)
        Me.chkESize.Enabled = Not (Me.chkENone.Checked)
        If Me.chkENone.Checked Then
            Me.splitE.Panel1.Enabled = False
            Me.splitE.Panel2.Enabled = False
        Else
            Me.splitE.Panel2.Enabled = Me.chkEDate.Checked
            Me.splitE.Panel1.Enabled = Me.chkESize.Checked
        End If
    End Sub

    Private Sub chkISize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkISize.CheckedChanged
        Me.splitI.Panel1.Enabled = Me.chkISize.Checked
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkIDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDate.CheckedChanged
        Me.splitI.Panel2.Enabled = Me.chkIDate.Checked
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkESize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkESize.CheckedChanged
        Me.splitE.Panel1.Enabled = Me.chkESize.Checked
    End Sub

    Private Sub chkEDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEDate.CheckedChanged
        Me.splitE.Panel2.Enabled = Me.chkEDate.Checked
    End Sub

    Public Sub NextStep() Implements ICtlStep.NextStep

        With _finder.FileEnumerator

            ' Exclude by size
            .ExcludeByMaxSize = Me.chkESizeGT.Checked AndAlso Me.chkESizeGT.Enabled
            If .ExcludeByMaxSize Then
                .EMaxSize = Misc.GetSizeFromFormatedSize(Me.txtESizeGT.Text & " " & Me.cbESizeUnitGT.Text)
            End If
            .ExcludeByMinSize = Me.chkESizeLT.Checked AndAlso Me.chkESizeLT.Enabled
            If .ExcludeByMinSize Then
                .EMinSize = Misc.GetSizeFromFormatedSize(Me.txtESizeLT.Text & " " & Me.cbESizeUnitLT.Text)
            End If

            ' Include by size
            .IncludeByMaxSize = Me.chkISizeGT.Checked AndAlso Me.chkISizeGT.Enabled
            If .IncludeByMaxSize Then
                .IMaxSize = Misc.GetSizeFromFormatedSize(Me.txtISizeGT.Text & " " & Me.cbISizeUnitGT.Text)
            End If
            .IncludeByMinSize = Me.chkISizeLT.Checked AndAlso Me.chkISizeLT.Enabled
            If .IncludeByMinSize Then
                .IMinSize = Misc.GetSizeFromFormatedSize(Me.txtISizeLT.Text & " " & Me.cbISizeUnitLT.Text)
            End If

            ' Exclude by date
            .ExcludeByDateMax = Me.chkEDateGT.Checked AndAlso Me.chkEDateGT.Enabled
            If .ExcludeByDateMax Then
                .EMaxDate = Me.dtEGT.Value.ToFileTime
            End If
            .ExcludeByDateMin = Me.chkEDateLT.Checked AndAlso Me.chkEDateLT.Enabled
            If .ExcludeByDateMin Then
                .EDateMin = Me.dtELT.Value.ToFileTime
            End If

            ' Include by date
            .IncludeByDateMax = Me.chkIDateGT.Checked AndAlso Me.chkIDateGT.Enabled
            If .IncludeByDateMax Then
                .IMaxDate = Me.dtIGT.Value.ToFileTime
            End If
            .IncludeByDateMin = Me.chkIDateLT.Checked AndAlso Me.chkIDateLT.Enabled
            If .IncludeByDateMin Then
                .IMinDate = Me.dtILT.Value.ToFileTime
            End If

        End With

    End Sub

    Public ReadOnly Property NextStepOK() As Boolean Implements ICtlStep.NextStepOk
        Get
            Return _nextOK
        End Get
    End Property

    ' Raise the event "NextStepOkChanged" is value has changed
    Private Sub raiseEventNextReady()
        Static _old As Boolean = True
        _nextOK = Me.chkIAll.Checked OrElse _
                    (Me.chkIDate.Checked AndAlso (Me.chkIDateGT.Checked OrElse Me.chkIDateLT.Checked)) OrElse _
                    (Me.chkISize.Checked AndAlso ((Me.chkISizeGT.Checked And Me.txtISizeGT.Text.Length > 0 And Me.cbISizeUnitGT.Text.Length > 0) OrElse (Me.chkISizeLT.Checked And Me.txtISizeLT.Text.Length > 0 And Me.cbISizeUnitLT.Text.Length > 0)))
        If _nextOK <> _old Then
            _old = _nextOK
            RaiseEvent NextStepOkChanged(_nextOK)
        End If
    End Sub

    Private Sub chkISizeGT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkISizeGT.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkISizeLT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkISizeLT.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkIDateGT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDateGT.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub chkIDateLT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDateLT.CheckedChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub txtISizeGT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtISizeGT.TextChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub txtISizeLT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtISizeLT.TextChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub cbISizeUnitGT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbISizeUnitGT.SelectedIndexChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub cbISizeUnitLT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbISizeUnitLT.SelectedIndexChanged
        Me.raiseEventNextReady()
    End Sub

    Private Sub cbIDateType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIDateType.SelectedIndexChanged
        Me.cbEDateType.SelectedIndex = Me.cbIDateType.SelectedIndex
    End Sub

    Private Sub cbEDateType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEDateType.SelectedIndexChanged
        Me.cbIDateType.SelectedIndex = Me.cbEDateType.SelectedIndex
    End Sub
End Class
