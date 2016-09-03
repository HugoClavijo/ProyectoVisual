Public Class WinUser

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim log As Login
        log = Me.Owner
        log.Show()
        log.loggedIn = False
    End Sub

End Class
