Public Class WinAdminFacturas

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim admin As WinAdmin
        admin = Me.Owner
        admin.Show()
    End Sub


End Class
