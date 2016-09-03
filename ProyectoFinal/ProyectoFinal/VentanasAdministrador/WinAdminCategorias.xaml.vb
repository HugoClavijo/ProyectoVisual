Imports System.Data
Imports System.Data.OleDb

Public Class WinAdminCategorias
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsCategorias As DataSet

    Private Sub DataCategorias_Loaded(sender As Object, e As RoutedEventArgs) Handles DataCategorias.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM categoria;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsCategorias = New DataSet("Tienda")
            adapter.Fill(dsCategorias, "categoria")

            dataGrid.DataContext = dsCategorias

        End Using
    End Sub

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim admin As WinAdmin
        admin = Me.Owner
        admin.Show()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim winCat As New WinAddCategoria
        winCat.Owner = Me
        Me.Hide()
        winCat.Show()
    End Sub

    Private Sub dtgCategorias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem

        If fila Is Nothing Then
            Exit Sub
        End If

        If Not (fila Is Nothing) Then
            Dim nuevaCategoria As New Categoria(fila(0), fila(1), fila(2))
            Dim winCate As New WinAddCategoria
            winCate.Owner = Me
            winCate.DataContext = nuevaCategoria
            winCate.Show()
            Me.Hide()
        End If

    End Sub

    Public Sub UpdateDataGrid()
        Me.DataCategorias_Loaded(Nothing, Nothing)
    End Sub

End Class
