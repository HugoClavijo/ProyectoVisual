Imports System.Data
Imports System.Data.OleDb

Public Class WinAddDetalle
    Dim dsDetalle As DataSet
    Dim dsProducto As DataSet

    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winFac As New WinFacturar
        winFac = Me.Owner
        winFac.Show()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)




    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim aux As Integer = 0
        Dim listDetalle As WinAdminProductos = Me.Owner
        Using conexion As New OleDbConnection(listDetalle.strConexion)

            Dim consulta As String = "Select * FROM detalle;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsDetalle = New DataSet("Tienda")
            adapter.Fill(dsDetalle, "detalle")
            Dim found = False

            For Each det As DataRow In dsDetalle.Tables("detalle").Rows
                If det("cantidad") = Me.txtCantidad.Text Then
                    det("id_producto") = Me.txtCodigo.Text
                    det("id_producto") = Me.txtProducto.Text
                    det("precio_unitario") = Me.txtPrecioUnitario.Text
                    det("precio_total") = Me.txtPrecioTotal.Text
                    det("stock") = Me.txtStock.Text



                    found = True
                    Exit For
                End If
            Next


            Try
                adapter.Update(dsDetalle.Tables("detalle"))
                If found Then
                    MessageBox.Show("Se actualizó el detalle")
                Else
                    MessageBox.Show("Se agregó el detalle")
                End If
            Catch es As Exception
                MessageBox.Show("Error al actualizar")
            End Try
            listDetalle.UpdateDataGrid()

        End Using
        Me.Close()
    End Sub
End Class
