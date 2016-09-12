Imports System.Data
Imports System.Data.OleDb

Public Class WinUserViewFactura
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsDetalles As DataSet
    Dim dsClientes As DataSet
    Dim dsEmpresa As DataSet
    Dim dsUsers As DataSet

    Private Sub ViewFactura_Loaded(sender As Object, e As RoutedEventArgs) Handles viewUserFactura.Loaded

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM detalle WHERE id_factura =" & lblNumeroFactura.Content
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsDetalles = New DataSet("Tienda")
            adapter.Fill(dsDetalles, "detalle")

            dataGrid.DataContext = dsDetalles


            Dim consulta2 As String = "Select * FROM cliente;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
            Me.dsClientes = New DataSet("Tienda")
            adapter2.Fill(dsClientes, "cliente")

            Dim consulta3 As String = "Select * FROM empresa;"
            Dim adapter3 As New OleDbDataAdapter(New OleDbCommand(consulta3, conexion))
            Me.dsEmpresa = New DataSet("Tienda")
            adapter3.Fill(dsEmpresa, "empresa")


            Dim consulta4 As String = "Select * FROM usuario;"
            Dim adapter4 As New OleDbDataAdapter(New OleDbCommand(consulta4, conexion))
            Me.dsUsers = New DataSet("Tienda")
            adapter4.Fill(dsUsers, "usuario")

        End Using


        For Each user As DataRow In dsClientes.Tables(0).Rows
            If user("cedulaRuc") = Me.txtCedulaRuc.Text Then
                Me.txtCliente.Text = user("nombre")
                Me.txtDireccion.Text = user("direccion")
            End If
        Next

        lblRuc.Content = dsEmpresa.Tables(0).Rows(0).Item(4)
        lblProvincia.Content = dsUsers.Tables(0).Rows(0).Item(7)
    End Sub

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim user As WinUserBuscarFacturas
        user = Me.Owner
        user.Show()
    End Sub
End Class
