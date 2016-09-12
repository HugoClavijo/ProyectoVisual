Public Class WinUser

    Dim usuario As String

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim log As Login
        log = Me.Owner
        log.Show()
        log.loggedIn = False
    End Sub

    Private Sub menuDatos_Click(sender As Object, e As RoutedEventArgs) Handles menuDatos.Click
        Dim facturar As New WinFacturar
        facturar.Owner = Me
        facturar.CargarUsuario(Me.usuario)
        Me.Hide()
        facturar.Show()
    End Sub

    Private Sub menuSinDatos_Click(sender As Object, e As RoutedEventArgs) Handles menuSinDatos.Click
        Dim facturar As New WinFacturar
        facturar.Owner = Me
        facturar.CargarUsuario(Me.usuario)
        Me.Hide()
        facturar.txtCliente.Text = "consumidor final"
        facturar.txtCedulaRuc.Text = "1"
        facturar.txtDireccion.Text = "desconocida"
        facturar.txtCliente.IsEnabled = False
        facturar.txtDireccion.IsEnabled = False
        facturar.txtCedulaRuc.IsEnabled = False
        facturar.Show()
    End Sub

    Private Sub menuFacturas_Click(sender As Object, e As RoutedEventArgs) Handles menuFacturas.Click
        Dim buscarFactura As New WinUserBuscarFacturas
        buscarFactura.Owner = Me
        buscarFactura.CargarUsuario(Me.usuario)
        Me.Hide()
        buscarFactura.Show()
    End Sub

    Private Sub menuClientes_Click(sender As Object, e As RoutedEventArgs) Handles menuClientes.Click
        Dim buscarClientes As New WinUserClientes
        buscarClientes.Owner = Me
        Me.Hide()
        buscarClientes.Show()
    End Sub

    Private Sub menuProductos_Click(sender As Object, e As RoutedEventArgs) Handles menuProductos.Click
        Dim buscarProductos As New WinUserProductos
        buscarProductos.Owner = Me
        Me.Hide()
        buscarProductos.Show()
    End Sub

    Public Sub CargarUsuario(user As String)
        Me.usuario = user
    End Sub

End Class
