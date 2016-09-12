Imports System.Data
Imports System.Data.OleDb

Public Class WinAdminClientes

    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsClientes As DataSet

    Private Sub DataClientes_Loaded(sender As Object, e As RoutedEventArgs) Handles DataClientes.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM cliente;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsClientes = New DataSet("Tienda")
            adapter.Fill(dsClientes, "cliente")

            dataGrid.DataContext = dsClientes

        End Using
    End Sub

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim admin As WinAdmin
        admin = Me.Owner
        admin.Show()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim winClientes As New WinAddCliente
        winClientes.Owner = Me
        winClientes.btnBorrar.Visibility = 1
        Me.Hide()
        winClientes.Show()
    End Sub

    Public Sub UpdateDataGrid()
        Me.DataClientes_Loaded(Nothing, Nothing)
    End Sub

    Private Sub dtgCategorias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem

        If fila Is Nothing Then
            Exit Sub
        End If

        If Not (fila Is Nothing) Then
            Dim nuevoCliente As New Cliente(fila(0), fila(1), fila(2))
            Dim winClient As New WinAddCliente
            winClient.Owner = Me
            winClient.DataContext = nuevoCliente
            winClient.Show()
            Me.Hide()
        End If

    End Sub

End Class
