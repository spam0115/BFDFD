If (i Mod _updateFrequency) = 0 Then
Me.lv.BeginUpdate()
Me.lv.Sorting = SortOrder.None
Me.lv.PreventSort()
End If


If (i Mod _updateFrequency) = 0 Then
Me._ProgressBarText.SetProgress(i, count)
Me.lv.EndUpdate()
Application.DoEvents()
End If