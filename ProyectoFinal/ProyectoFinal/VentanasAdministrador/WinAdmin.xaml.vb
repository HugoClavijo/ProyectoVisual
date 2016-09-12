Public Class WinAdmin

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim log As Login
        log = Me.Owner
        log.Show()
        log.loggedIn = False
    End Sub

    Private Sub MenuEmpresa_Click(sender As Object, e As RoutedEventArgs) Handles menuEmpresa.Click
        Dim winEmpresa As New WinEmpresa
        winEmpresa.Owner = Me
        Me.Hide()
        winEmpresa.Show()
    End Sub

    Private Sub MenuUsuarios_Click(sender As Object, e As RoutedEventArgs) Handles menuUsuarios.Click
        Dim winUsers As New WinAdminUsuarios
        winUsers.Owner = Me
        Me.Hide()
        winUsers.Show()
    End Sub

    Private Sub MenuClientes_Click(sender As Object, e As RoutedEventArgs) Handles addCliente.Click
        Dim winClients As New WinAdminClientes
        winClients.Owner = Me
        Me.Hide()
        winClients.Show()
    End Sub

    Private Sub MenuAddCategoria_Click(sender As Object, e As RoutedEventArgs) Handles addCategoria.Click
        Dim winAddCate As New WinAdminCategorias
        winAddCate.Owner = Me
        Me.Hide()
        winAddCate.Show()
    End Sub

    Private Sub MenuAdminProductos_Click(sender As Object, e As RoutedEventArgs) Handles adminProductos.Click
        Dim winAdProduct As New WinAdminProductos
        winAdProduct.Owner = Me
        Me.Hide()
        winAdProduct.Show()
    End Sub

    Private Sub MenuAdminFacturas_Click(sender As Object, e As RoutedEventArgs) Handles adminFacturas.Click
        Dim winAdFact As New WinAdminFacturas
        winAdFact.Owner = Me
        Me.Hide()
        winAdFact.Show()
    End Sub


    Private Sub MenuAdminPagos_Click(sender As Object, e As RoutedEventArgs) Handles adminPago.Click
        Dim winPago As New WinPagos
        winPago.Owner = Me
        Me.Hide()
        winPago.Show()
    End Sub

End Class
