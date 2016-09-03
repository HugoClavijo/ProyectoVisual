Imports System.Data
Imports System.Data.OleDb

Public Class WinAdminUsuarios
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsUsuarios As DataSet

    Private Sub DataUsuarios_Loaded(sender As Object, e As RoutedEventArgs) Handles DataUsuarios.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM usuario;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsUsuarios = New DataSet("Tienda")
            adapter.Fill(dsUsuarios, "usuarios")

            dataGrid.DataContext = dsUsuarios

        End Using
    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim admin As WinAdmin
        admin = Me.Owner
        admin.Show()
    End Sub


    Private Sub BtnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim winUser As New WinAddUsuarios
        winUser.Owner = Me
        Me.Hide()
        winUser.Show()
    End Sub

    Private Sub dtgUsuarios_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim nuevoUsuario As New Usuario(fila(0), fila(1), fila(2), fila(3), fila(4), fila(5), fila(6))
            Dim winUser As New WinAddUsuarios
            winUser.Owner = Me
            winUser.DataContext = nuevoUsuario
            winUser.Show()
            Me.Hide()
        End If
    End Sub

    Public Sub UpdateDataGrid()
        Me.DataUsuarios_Loaded(Nothing, Nothing)
    End Sub

End Class
