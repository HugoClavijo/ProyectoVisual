Imports System.Data
Imports System.Data.OleDb

Public Class WinFacturar
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsUsers As DataSet
    Dim dsFactura As DataSet
    Dim dsCliente As DataSet
    Dim dsDetalle As DataSet
    Dim dsPagos As DataSet
    Dim dsEmpresa As DataSet
    Dim dsProductos As DataSet
    'Dim dsProducts As DataSet
    Dim dsProvincias As DataSet
    Dim dsAux As DataSet
    Dim auxFormaDePago As String
    'Dim aux As Integer = 0
    Dim auxCliente As String
    Dim auxProvincia As String
    Dim auxFact As Integer = 0
    Dim usuario As String

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim winuser As WinUser
        winuser = Me.Owner
        winuser.Show()
    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "SELECT * FROM factura ;"


            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))

            Me.dsFactura = New DataSet("Tienda")

            Me.dsDetalle = New DataSet("info")

            adapter.Fill(dsFactura, "factura")


            For Each fact As DataRow In dsFactura.Tables("factura").Rows
                lblNumeroFactura.Content = fact(0) + 1
            Next

            Dim consulta2 As String = "Select * FROM producto;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
            Me.dsProductos = New DataSet("Tienda")
            adapter2.Fill(dsProductos, "producto")


            Dim consulta3 As String = "Select * FROM detalle WHERE id_factura =" & lblNumeroFactura.Content & ";"
            Dim adapter3 As New OleDbDataAdapter(New OleDbCommand(consulta3, conexion))
            adapter3.Fill(dsDetalle, "detalle")

            Dim consulta4 As String = "Select * FROM pagos;"
            Dim adapter4 As New OleDbDataAdapter(New OleDbCommand(consulta4, conexion))
            Me.dsPagos = New DataSet("Tienda")
            adapter4.Fill(dsPagos, "pagos")


            dataGrid.DataContext = dsDetalle


            Dim consulta5 As String = "Select * FROM empresa;"
            Dim adapter5 As New OleDbDataAdapter(New OleDbCommand(consulta5, conexion))
            Me.dsEmpresa = New DataSet("Tienda")
            adapter5.Fill(dsEmpresa, "empresa")


            Dim consulta6 As String = "Select * FROM usuario;"
            Dim adapter6 As New OleDbDataAdapter(New OleDbCommand(consulta6, conexion))
            Me.dsUsers = New DataSet("Tienda")
            adapter6.Fill(dsUsers, "usuario")

            Dim consulta7 As String = "Select * FROM provincia;"
            Dim adapter7 As New OleDbDataAdapter(New OleDbCommand(consulta7, conexion))
            Me.dsProvincias = New DataSet("Tienda")
            adapter7.Fill(dsProvincias, "provincia")

        End Using

        For Each usua As DataRow In dsUsers.Tables(0).Rows
            If usua("user") = usuario Then
                auxProvincia = usua("provincia")
            End If
        Next

        lblRuc.Content = dsEmpresa.Tables(0).Rows(0).Item(4)
        lblProvincia.Content = auxProvincia
        'lblCiudad.Content = dsEmpresa.Tables(0).Rows(0).Item(3)

        lblVendedor.Content = usuario
        'lblIva.Content = dsPagos.Tables(0).Rows(0).Item(1)
        Me.lblTotal.Content = 0
        Me.lblSubtotal.Content = 0
        Me.lblDescuento.Content = 0

        For Each prov As DataRow In dsProvincias.Tables(0).Rows
            If auxProvincia = prov("provincia") Then
                lblIva.Content = prov("iva_provincia")
            End If
        Next

    End Sub

    Private Sub addDetalle_Click(sender As Object, e As RoutedEventArgs) Handles addDetalle.Click
        Dim winDet As New WinAddDetalle
        winDet.Owner = Me
        winDet.GuardarFactura(lblNumeroFactura.Content)
        'Me.Hide()
        winDet.Show()
    End Sub

    Private Sub guardar_Click(sender As Object, e As RoutedEventArgs) Handles guardar.Click

        If Me.txtEfectivo.Text = Nothing Or Me.txtCliente.Text = Nothing Or Me.txtDireccion.Text = Nothing Or Me.txtCedulaRuc.Text = Nothing Or lblTotal.Content = Nothing Or Me.lblDescuento.Content = Nothing Or Me.lblTotal.Content = Nothing Or Me.lblSubtotal.Content = Nothing Or Me.lblIva.Content = Nothing Then
            MessageBox.Show("Error, campos vacios...")
            Exit Sub
        End If


        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "Select * FROM cliente;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsCliente = New DataSet("Tienda")
            adapter.Fill(dsCliente, "cliente")
            Dim found = False

            For Each user As DataRow In dsCliente.Tables("cliente").Rows
                If user("cedulaRuc") = Me.txtCedulaRuc.Text Then
                    user("cedulaRuc") = Me.txtCedulaRuc.Text
                    user("nombre") = Me.txtCliente.Text
                    user("direccion") = Me.txtDireccion.Text
                    found = True
                    Exit For
                End If
            Next

            For Each c1 As DataRow In dsCliente.Tables(0).Rows
                auxCliente = c1("cedulaRuc")
            Next

            'auxCliente = auxCliente + 1

            'If CStr(txtCedulaRuc.Text) = dsCliente.Tables(0).Rows("cedulaRuc").Item(0) Then
            '    auxCliente = 1
            'End If


            If Not found Then
                Me.dsCliente.Tables(0).Rows.Add(Me.txtCedulaRuc.Text, Me.txtCliente.Text, Me.txtDireccion.Text)
            End If

            Try
                adapter.Update(dsCliente.Tables("cliente"))
                If found Then
                    MessageBox.Show("Se actualizó el cliente")
                Else
                    MessageBox.Show("Se agregó el cliente")
                End If
            Catch es As Exception
                MessageBox.Show("Error al actualizar")
            End Try



            Dim dd As New DateTime
            dd = DateTime.Now
            Dim auxFecha As String = dd.ToShortDateString()
            Dim auxIdUser As String

            Dim consulta2 As String = "Select * FROM factura;"

            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
            Dim facturaCmdBuilder = New OleDbCommandBuilder(adapter2)
            Me.dsFactura = New DataSet("Tienda")
            adapter2.Fill(dsFactura, "factura")
            Dim found1 = False

            For Each user As DataRow In dsFactura.Tables("factura").Rows
                If user("secuencial") = Me.lblNumeroFactura.Content Then
                    user("subtotal") = Me.lblSubtotal.Content
                    user("total") = Me.lblTotal.Content
                    user("iva") = Me.lblIva.Content
                    user("descuento") = Me.lblDescuento.Content
                    user("forma_pago") = Me.auxFormaDePago
                    user("fecha_emision") = auxFecha
                    user("efectivo") = Me.txtEfectivo.Text
                    user("cambio") = Me.lblCambio.Content
                    found1 = True
                    Exit For
                End If
            Next


            For Each userr As DataRow In dsUsers.Tables("usuario").Rows
                If userr("user") = Me.usuario Then
                    auxIdUser = userr("user")
                End If
            Next

            'auxIdUser = Me.lblVendedor.Content

            For Each f1 As DataRow In dsFactura.Tables(0).Rows
                auxFact = f1(0)
            Next

            auxFact = auxFact + 1


            If Not found1 Then
                Me.dsFactura.Tables("factura").Rows.Add(auxFact, Me.dsEmpresa.Tables(0).Rows(0).Item(0), auxCliente, Me.lblSubtotal.Content, Me.lblTotal.Content, Me.lblIva.Content, auxFormaDePago, auxFecha, Me.lblDescuento.Content, auxIdUser, auxProvincia, txtEfectivo.Text, lblCambio.Content)
            End If

            Try
                adapter2.Update(dsFactura.Tables("factura"))
                If found1 Then
                    MessageBox.Show("Se actualizó La factura")
                Else
                    MessageBox.Show("Se agregó la factura")
                End If
            Catch es As Exception
                MessageBox.Show("Error al actualizar")
            End Try

        End Using

        Me.Close()

    End Sub

    Public Sub UpdateDataGrid()
        Me.Window_Loaded(Nothing, Nothing)
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As RoutedEventArgs) Handles btnCalcular.Click
        Dim aux As Double = 0

        For Each dat1 As DataRow In dsDetalle.Tables("detalle").Rows
            aux += dat1("precio_total")
        Next

        lblSubtotal.Content = aux

        'If aux = 0 Then
        '    Me.lblSubtotal.Content = "0,0"
        '    Me.lblTotal.Content = "0,0"
        '    Me.txtEfectivo.Text = "0,0"

        'Else
        lblTotal.Content = CDbl(lblSubtotal.Content) + (CDbl(lblSubtotal.Content) * CDbl(lblIva.Content)) - (CDbl(lblSubtotal.Content) * CDbl(lblDescuento.Content))
        'End If

    End Sub

    Private Sub btnVisa_Click(sender As Object, e As RoutedEventArgs) Handles btnVisa.Click
        lblDescuento.Content = dsPagos.Tables(0).Rows(0).Item(2)
        lblTotal.Content = CDbl(lblSubtotal.Content) + (CDbl(lblSubtotal.Content) * CDbl(lblIva.Content)) - (CDbl(lblSubtotal.Content) * CDbl(lblDescuento.Content))

        If lblTotal.Content = Nothing Then
            Me.lblTotal.Content = "0,0"
        End If

        Me.auxFormaDePago = "tarjeta"

    End Sub

    Private Sub btnDineroElectronico_Click(sender As Object, e As RoutedEventArgs) Handles btnDineroElectronico.Click
        lblDescuento.Content = dsPagos.Tables(0).Rows(0).Item(3)
        lblTotal.Content = CDbl(lblSubtotal.Content) + (CDbl(lblSubtotal.Content) * CDbl(lblIva.Content)) - (CDbl(lblSubtotal.Content) * CDbl(lblDescuento.Content))

        'If lblTotal.Content = Nothing Then
        '    Me.lblTotal.Content = "0,0"
        'End If

        Me.auxFormaDePago = "Electronico"

    End Sub

    Private Sub btnEfectivo_Click(sender As Object, e As RoutedEventArgs) Handles btnEfectivo.Click
        lblDescuento.Content = "0"
        lblTotal.Content = CDbl(lblSubtotal.Content) + (CDbl(lblSubtotal.Content) * CDbl(lblIva.Content)) - (CDbl(lblSubtotal.Content) * CDbl(lblDescuento.Content))

        If lblTotal.Content = Nothing Then
            Me.lblTotal.Content = "0,0"
        End If

        Me.auxFormaDePago = "Efectivo"

    End Sub


    Private Sub btnCambio_Click(sender As Object, e As RoutedEventArgs) Handles btnCambio.Click
        Dim dblValue As Double

        If Me.txtEfectivo.Text = Nothing Or lblTotal.Content = Nothing Or Me.lblDescuento.Content = Nothing Or Me.lblTotal.Content = Nothing Or Me.lblSubtotal.Content = Nothing Or Me.lblIva.Content = Nothing Then
            MessageBox.Show("Error, campos vacios...")
            Exit Sub
        End If


        If Not Double.TryParse(txtEfectivo.Text, dblValue) Then
            MessageBox.Show("Error, Ingrese números decimales con ','")
            Exit Sub
        Else
            Me.lblCambio.Content = CDbl(Me.txtEfectivo.Text) - CDbl(lblTotal.Content)
        End If

    End Sub

    Public Sub CargarUsuario(user As String)
        Me.usuario = user
    End Sub


    Private Sub BtnBorrar_Click(sender As Object, e As RoutedEventArgs) Handles btnBorrar.Click
        For Each detail As DataRow In dsDetalle.Tables(0).Rows
            If detail(0) = Me.lblNumeroFactura.Content Then
                For Each produc As DataRow In dsProductos.Tables(0).Rows
                    If detail("nombre_producto") = produc("nombre") Then
                        produc("stock") = produc("stock") + detail("cantidad")
                    End If
                Next
            End If
        Next

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM producto;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsProductos.Tables("producto"))
                'MessageBox.Show("Se han guardado los datos...")
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

            'If dataGrid.DataContext IsNot Nothing Then
            '    Exit Sub
            'End If

            Dim consulta2 As String = "Delete * FROM detalle WHERE id_factura =" & lblNumeroFactura.Content & ";"

                Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
                Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
                Me.dsDetalle = New DataSet("Tienda")
                adapter2.Fill(dsDetalle, "detalle")
                Dim found = False

                If Not found Then
                    MessageBox.Show("Se borró el detalle")
                End If
            'Try
            'adapter.Update(dsDetalle.Tables("detalle"))
            If found Then
                    MessageBox.Show("No se borró el detalle")
                End If
                'Catch es As Exception
                '    MessageBox.Show("Error al actualizar")
                'End Try
                Me.UpdateDataGrid()



        End Using

        'Me.Close()
    End Sub

End Class
