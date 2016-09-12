Imports System.Data
Imports System.Data.OleDb

Public Class WinAddDetalle
    Dim dsDetalle As DataSet
    Dim dsProducto As DataSet
    Dim idFactura As Integer

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Dim winFac As New WinFacturar
        'winFac = Me.Owner
        'winFac.Show()
        Me.Hide()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim listDetalle As WinFacturar = Me.Owner
        Using conexion As New OleDbConnection(listDetalle.strConexion)
            Dim consulta As String = "Select * FROM producto;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsProducto = New DataSet("Tienda")
            adapter.Fill(dsProducto, "producto")

            For Each prod As DataRow In dsProducto.Tables("producto").Rows
                comboBox.Items.Add(prod(1))
            Next

        End Using

        Me.txtPrecioUnitario.Text = Nothing
        Me.txtCantidad.Text = Nothing
        Me.txtPrecioTotal.Text = Nothing
        Me.txtStock.IsEnabled = False
        Me.txtPrecioUnitario.IsEnabled = False
    End Sub


    Private Sub ClaveComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBox.SelectionChanged
        txtPrecioUnitario.Text = dsProducto.Tables(0).Rows(comboBox.SelectedIndex).Item(2)
        txtStock.Text = dsProducto.Tables(0).Rows(comboBox.SelectedIndex).Item(6)
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim aux As Integer = 0
        Dim listDetalle As WinFacturar = Me.Owner
        Dim dblValue As Double
        Dim intValue As Integer

        If Me.txtPrecioUnitario.Text = Nothing Or Me.txtStock.Text = Nothing Or Me.txtCantidad.Text = Nothing Then
            MessageBox.Show("Error, campos vacios...")
            Exit Sub
        End If


        If Not Double.TryParse(txtPrecioUnitario.Text, dblValue) Then
            MessageBox.Show("Error, Ingrese números y/o números decimales con ',' en V. Unitario")
            Exit Sub
        ElseIf Not Integer.TryParse(txtCantidad.Text, intValue) Then
            MessageBox.Show("Error, Ingrese números enteros en Cantidad")
            Exit Sub
        ElseIf Not Integer.TryParse(txtStock.Text, intValue) Then
            MessageBox.Show("Error, Ingrese números enteros en Stock")
            Exit Sub
        Else
            txtPrecioTotal.Text = CDbl(txtPrecioUnitario.Text) * CDbl(txtCantidad.Text)
        End If


        If Me.txtStock.Text < Me.txtCantidad.Text Then
            MessageBox.Show("Error, no hay esa cantidad en el stock" & "(" & Me.txtCantidad.Text & ")")
            Exit Sub
        End If


        Using conexion As New OleDbConnection(listDetalle.strConexion)

            Dim consulta As String = "Select * FROM detalle;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsDetalle = New DataSet("Tienda")
            adapter.Fill(dsDetalle, "detalle")
            Dim found = False

            'For Each prod As DataRow In dsProducto.Tables("producto").Rows
            '    If prod(1) = Me.comboBox.Text Then
            '        aux = CInt(prod(0))
            '    End If
            'Next

            dsDetalle.Tables("detalle").Rows.Add(idFactura, Me.comboBox.Text, Me.txtCantidad.Text, Me.txtPrecioUnitario.Text, Me.txtPrecioTotal.Text)


            For Each produc As DataRow In dsProducto.Tables(0).Rows
                If Me.comboBox.Text = produc("nombre") Then
                    produc("stock") -= Me.txtCantidad.Text
                    Me.txtStock.Text = produc("stock")
                End If
            Next


            Dim consulta2 As String = "Select * FROM producto;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
            Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
            Try
                adapter2.Update(dsProducto.Tables("producto"))
                'MessageBox.Show("Se han guardado los datos...")
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

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

    Private Sub btnCalcular_Click(sender As Object, e As RoutedEventArgs) Handles btnCalcular.Click
        Dim dblValue As Double
        Dim intValue As Integer

        If Me.txtPrecioUnitario.Text = Nothing Or Me.txtStock.Text = Nothing Or Me.txtCantidad.Text = Nothing Then
            MessageBox.Show("Error, campos vacios...")
            Exit Sub
        End If


        If Not Double.TryParse(txtPrecioUnitario.Text, dblValue) Then
            MessageBox.Show("Error, Ingrese números y/o números decimales con ',' en V. Unitario")
            Exit Sub
        ElseIf Not Integer.TryParse(txtCantidad.Text, intValue) Then
            MessageBox.Show("Error, Ingrese números enteros en Cantidad")
            Exit Sub
        ElseIf Not Integer.TryParse(txtStock.Text, intValue) Then
            MessageBox.Show("Error, Ingrese números enteros en Stock")
            Exit Sub
        Else
            txtPrecioTotal.Text = CDbl(txtPrecioUnitario.Text) * CDbl(txtCantidad.Text)
        End If

    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As RoutedEventArgs) Handles btnBuscar.Click

        If txtId.Text = Nothing Then
            MessageBox.Show("Error, Ingrese el id del producto")
            Exit Sub
        End If

        For Each pro As DataRow In dsProducto.Tables(0).Rows
            If pro("id") = txtId.Text Then

                comboBox.SelectedValue = pro("nombre")
            End If
        Next

    End Sub

    Public Sub GuardarFactura(numero As Integer)
        idFactura = numero
    End Sub
End Class
