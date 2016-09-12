Imports System.Data
Imports System.Data.OleDb

Public Class WinViewProducto
    Dim dsCategorias As DataSet
    Dim dsProductos As DataSet
    Dim aux As String

    Private Sub AddProducto_Loaded(sender As Object, e As RoutedEventArgs) Handles viewProducto.Loaded

        Dim listProd As WinUserProductos = Me.Owner
        Using conexion As New OleDbConnection(listProd.strConexion)
            Dim consulta As String = "Select * FROM categoria;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsCategorias = New DataSet("Tienda")
            adapter.Fill(dsCategorias, "categoria")
            For Each cat As DataRow In dsCategorias.Tables("categoria").Rows
                comboBox1.Items.Add(cat(1))
            Next
        End Using


        Dim unProducto As Producto = TryCast(Me.DataContext, Producto)

        If Not (unProducto Is Nothing) Then
            comboBox1.SelectedValue = unProducto.Categoria
        Else
            comboBox1.SelectedIndex = 0
        End If


    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim user As WinUserProductos
        user = Me.Owner
        user.Show()
        'Me.Hide()
    End Sub
End Class
