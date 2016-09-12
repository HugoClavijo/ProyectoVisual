Imports System.Data
Imports System.Data.OleDb

Public Class WinAddProducto

    Dim dsCategorias As DataSet
    Dim dsProductos As DataSet
    Dim aux As String

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
        Else
            comboBox1.SelectedIndex = 0
        End If


    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim users As WinAdminProductos
        users = Me.Owner
        users.Show()
        'Me.Hide()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim dblValue As Double
        Dim intValue As Integer


        If Me.txtId.Text = Nothing Or Me.txtCantidad.Text = Nothing Or Me.txtConsola.Text = Nothing Or Me.txtRating.Text = Nothing Or Me.txtDescripcion.Text = Nothing Or Me.txtNombre.Text = Nothing Or Me.txtPrecio.Text = Nothing Then
            MessageBox.Show("Error, campos vacios.")
            Exit Sub
        End If

        If Not Integer.TryParse(Me.txtId.Text, intValue) Then
            MessageBox.Show("Error, ingrese número en Id")
            Exit Sub
        End If

        If Not Double.TryParse(txtPrecio.Text, dblValue) Then
            MessageBox.Show("Error, Ingrese números decimales con ',' en precio")
            Exit Sub
        End If

        If Not Integer.TryParse(Me.txtCantidad.Text, intValue) Then
            MessageBox.Show("Error, ingrese números en Stock")
            Exit Sub
        End If

        If Not Double.TryParse(txtRating.Text, dblValue) Then
            MessageBox.Show("Error, Ingrese números decimales con ',' en rating")
            Exit Sub
        End If


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
                    user("precio_unitario") = Me.txtPrecio.Text
                    user("rating") = Me.txtRating.Text
                    user("consola") = Me.txtConsola.Text
                    user("stock") = Me.txtCantidad.Text
                    user("descripcion") = Me.txtDescripcion.Text

                    For Each cat As DataRow In dsCategorias.Tables("categoria").Rows
                        If cat("nombre") = Me.comboBox1.Text Then
                            user("nombre_categoria") = cat("nombre")
                        End If
                    Next

                    found = True
                    Exit For
                End If
            Next

            If Not found Then

                For Each cat As DataRow In dsCategorias.Tables("categoria").Rows
                    If cat("nombre") = Me.comboBox1.Text Then
                        aux = cat("nombre")
                    End If
                Next

                dsProductos.Tables("producto").Rows.Add(Me.txtId.Text, Me.txtNombre.Text, Me.txtPrecio.Text, Me.txtRating.Text, Me.txtConsola.Text, Me.aux, Me.txtCantidad.Text, Me.txtDescripcion.Text)
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
        'Me.Close()

    End Sub


    Private Sub BtnBorrar_Click(sender As Object, e As RoutedEventArgs) Handles btnBorrar.Click
        'Dim aux As Integer = 0
        'For Each data1 As DataRow In dsProductos.Tables("producto").Rows
        '    If Me.txtId.Text = data1(0) Then
        '        aux = data1(0)
        '    End If
        'Next

        'If aux = 0 Then
        '    MessageBox.Show("El Id del producto no se encuentra")
        '    Exit Sub
        'End If

        Dim listProd As WinAdminProductos = Me.Owner
        Using conexion As New OleDbConnection(listProd.strConexion)

            Dim consulta As String = "Delete * FROM producto WHERE id =" & txtId.Text & ";"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsProductos = New DataSet("Tienda")
            adapter.Fill(dsProductos, "producto")
            Dim found = False

            If Not found Then
                MessageBox.Show("Se borró el producto")
            End If

            Try
                adapter.Update(dsProductos.Tables("producto"))
                If found Then
                    MessageBox.Show("No se borró el producto")
                End If
            Catch es As Exception
                'MessageBox.Show("Error al actualizar")
            End Try
            listProd.UpdateDataGrid()

        End Using
        Me.Close()

    End Sub

End Class
