Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Win32

Module FormPlacement

    Public Sub Restore(form As Form)
        Try
            form.StartPosition = FormStartPosition.Manual

            Using k As RegistryKey = GetFormKey(form, createIfMissing:=False)
                If k Is Nothing Then Return

                Dim left As Integer = CInt(k.GetValue("Left", Integer.MinValue))
                Dim top As Integer = CInt(k.GetValue("Top", Integer.MinValue))
                Dim width As Integer = CInt(k.GetValue("Width", Integer.MinValue))
                Dim height As Integer = CInt(k.GetValue("Height", Integer.MinValue))
                Dim ws As FormWindowState = CType(CInt(k.GetValue("WindowState", CInt(FormWindowState.Normal))), FormWindowState)

                If left = Integer.MinValue OrElse top = Integer.MinValue OrElse width <= 0 OrElse height <= 0 Then
                    Return
                End If

                Dim r As New Rectangle(New Point(left, top), New Size(width, height))
                r = EnsureVisible(r)

                ' Set size/location first, then window state
                form.Location = r.Location
                form.Size = r.Size
                form.WindowState = ws
            End Using
        Catch
            ' ignore restore issues
        End Try
    End Sub

    Public Sub Save(form As Form)
        Try
            Dim r As Rectangle = If(form.WindowState = FormWindowState.Normal, form.Bounds, form.RestoreBounds)

            Using k As RegistryKey = GetFormKey(form, createIfMissing:=True)
                k.SetValue("Left", r.Left, RegistryValueKind.DWord)
                k.SetValue("Top", r.Top, RegistryValueKind.DWord)
                k.SetValue("Width", r.Width, RegistryValueKind.DWord)
                k.SetValue("Height", r.Height, RegistryValueKind.DWord)
                k.SetValue("WindowState", CInt(form.WindowState), RegistryValueKind.DWord)
            End Using
        Catch
            ' ignore save issues
        End Try
    End Sub

    Private Function GetFormKey(form As Form, createIfMissing As Boolean) As RegistryKey
        Dim path As String = $"Software\{Application.CompanyName}\{Application.ProductName}\WindowState\{form.Name}"
        If createIfMissing Then
            Return Registry.CurrentUser.CreateSubKey(path)
        Else
            Return Registry.CurrentUser.OpenSubKey(path, writable:=False)
        End If
    End Function

    Private Function EnsureVisible(r As Rectangle) As Rectangle
        ' If off-screen (e.g., monitor removed), center on primary screen and clamp
        Dim onScreen As Boolean = False
        For Each scr In Screen.AllScreens
            If scr.WorkingArea.IntersectsWith(r) Then
                onScreen = True
                Exit For
            End If
        Next
        If Not onScreen Then
            Dim wa = Screen.PrimaryScreen.WorkingArea
            Dim w = Math.Min(r.Width, wa.Width)
            Dim h = Math.Min(r.Height, wa.Height)
            Dim x = wa.Left + (wa.Width - w) \ 2
            Dim y = wa.Top + (wa.Height - h) \ 2
            Return New Rectangle(x, y, w, h)
        End If

        ' Clamp to current screen working area
        Dim wa2 = Screen.FromRectangle(r).WorkingArea
        Dim width = Math.Min(r.Width, wa2.Width)
        Dim height = Math.Min(r.Height, wa2.Height)
        Dim x2 = Math.Max(wa2.Left, Math.Min(r.Left, wa2.Right - width))
        Dim y2 = Math.Max(wa2.Top, Math.Min(r.Top, wa2.Bottom - height))
        Return New Rectangle(x2, y2, width, height)
    End Function

End Module