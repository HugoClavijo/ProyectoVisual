Public Class WinUser

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim log As Login
        log = Me.Owner
        log.Show()
        log.loggedIn = False
    End Sub

    Private Sub menuDatos_Click(sender As Object, e As RoutedEventArgs) Handles menuDatos.Click
        Dim facturar As New WinFacturar
        facturar.Owner = Me
        Me.Hide()
        facturar.Show()
    End Sub

    Private Sub menuSinDatos_Click(sender As Object, e As RoutedEventArgs) Handles menuSinDatos.Click
        Dim facturar As New WinFacturar
        facturar.Owner = Me
        Me.Hide()
        facturar.Show()
        facturar.txtCliente.Text = "Consumidor final"
        facturar.txtCliente.IsEnabled = False
        facturar.txtDireccion.IsEnabled = False
        facturar.txtCedulaRuc.IsEnabled = False


    End Sub
End Class
