Imports System.Data
Imports System.Data.OleDb

Public Class WinAddProducto

    Dim dsCategorias As DataSet
    Dim dsProductos As DataSet

    Private Sub AddProducto_Loaded(sender As Object, e As RoutedEventArgs) Handles AddProducto.Loaded

        Dim listProd As WinAdminProductos = Me.Owner
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
        End If


    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim users As WinAdminProductos
        users = Me.Owner
        users.Show()
        'Me.Hide()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim aux As Integer = 0
        Dim listProduct As WinAdminProductos = Me.Owner
        Using conexion As New OleDbConnection(listProduct.strConexion)

            Dim consulta As String = "Select * FROM producto;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsProductos = New DataSet("Tienda")
            adapter.Fill(dsProductos, "producto")
            Dim found = False

            For Each user As DataRow In dsProductos.Tables("producto").Rows
                If user("Id") = Me.txtId.Text Then
                    user("nombre") = Me.txtNombre.Text
                    user("precio") = Me.txtPrecio.Text
                    user("rating") = Me.txtRating.Text
                    user("consola") = Me.txtConsola.Text
                    user("stock") = Me.txtCantidad.Text
                    user("descripcion") = Me.txtDescripcion.Text

                    For Each cat As DataRow In dsCategorias.Tables("categoria").Rows
                        If cat(1) = Me.comboBox1.Text Then
                            user("id_categoria") = cat(0)
                        End If
                    Next

                    found = True
                    Exit For
                End If
            Next

            If Not found Then

                For Each cat As DataRow In dsCategorias.Tables("categoria").Rows
                    If cat(1) = Me.comboBox1.Text Then
                        aux = cat(0)
                    End If
                Next

                dsProductos.Tables("producto").Rows.Add(Me.txtId.Text, Me.txtNombre.Text, Me.txtPrecio.Text, Me.txtRating.Text, Me.txtConsola.Text, aux, txtCantidad, txtDescripcion)
            End If
            Try
                adapter.Update(dsProductos.Tables("producto"))
                If found Then
                    MessageBox.Show("Se actualizó el producto")
                Else
                    MessageBox.Show("Se agregó el producto")
                End If
            Catch es As Exception
                MessageBox.Show("Error al actualizar")
            End Try
            listProduct.UpdateDataGrid()

        End Using
        Me.Close()

    End Sub

End Class
