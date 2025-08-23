Public Class PersistentForm
    Inherits Form

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        FormPlacement.Restore(Me)
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        FormPlacement.Save(Me)
        MyBase.OnFormClosing(e)
    End Sub
End Class