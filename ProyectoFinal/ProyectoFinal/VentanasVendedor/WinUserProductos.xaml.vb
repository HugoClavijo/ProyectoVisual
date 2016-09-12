Imports System.Data
Imports System.Data.OleDb

Public Class WinUserProductos

    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsProductos As DataSet
    Dim dsCategoria As DataSet

    Private Sub DataProductos_Loaded(sender As Object, e As RoutedEventArgs) Handles userProductos.Loaded

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM producto;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsProductos = New DataSet("Tienda")
            adapter.Fill(dsProductos, "producto")

            dataGrid.DataContext = dsProductos

        End Using

        CargarCategorias()

    End Sub

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim user As WinUser
        user = Me.Owner
        user.Show()
    End Sub


    Private Sub dtgProductos_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid.SelectionChanged
        Dim aux As String = ""
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim nuevoProducto As New Producto(fila(0), fila(1), fila(2), fila(3), fila(4), fila(5), fila(6), fila(7))
            Dim winProduct As New WinViewProducto
            winProduct.Owner = Me
            winProduct.DataContext = nuevoProducto
            winProduct.Show()
            Me.Hide()
        End If
    End Sub


    Private Sub CargarCategorias()
        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "Select * FROM categoria;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsCategoria = New DataSet("Tienda")
            adapter.Fill(dsCategoria, "categoria")
        End Using
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As RoutedEventArgs) Handles btnBuscar.Click

        Dim intValue As Integer

        If Integer.TryParse(txtNombre.Text, intValue) Then
            MessageBox.Show("Error, Ingrese letras en producto")
            Exit Sub
        End If

        Using conexion As New OleDbConnection(strConexion)

            If txtNombre.Text = Nothing Then
                Dim consulta2 As String = "Select * FROM producto"
                Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
                Me.dsProductos = New DataSet("Tienda")
                adapter2.Fill(dsProductos, "producto")

                dataGrid.DataContext = dsProductos
                Exit Sub
            End If

            'Dim consulta As String = "Select * FROM producto WHERE nombre ='" & txtNombre.Text & "';"
            Dim consulta As String = "Select * FROM producto WHERE nombre LIKE '%" & txtNombre.Text & "%';"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsProductos = New DataSet("Tienda")
            adapter.Fill(dsProductos, "producto")

            dataGrid.DataContext = dsProductos
        End Using
    End Sub

    Public Sub UpdateDataGrid()
        Me.DataProductos_Loaded(Nothing, Nothing)
    End Sub

End Class
