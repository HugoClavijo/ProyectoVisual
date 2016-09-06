Imports System.Data
Imports System.Data.OleDb

Public Class WinFacturar
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsFactura As DataSet
    Dim dsCliente As DataSet
    Dim dsDetalle As DataSet

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim winuser As WinUser
        winuser = Me.Owner
        winuser.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "SELECT * FROM factura ;" 'SELECT * FROM factura ORDER BY secuencial DESC LIMIT 1;
            Dim consulta2 As String = "SELECT * FROM cliente ;" 'SELECT * FROM factura ORDER BY secuencial DESC LIMIT 1; 
            'SELECT OrderID, C.CustomerID, CompanyName, OrderDate
            'From Customers C INNER Join Orders O ON C.CustomerID = O.CustomerID 
            Dim consulta3 As String = "Select * FROM detalle WHERE id_factura =1"
            ' Dim consulta3 As String = "SELECT * FROM secuencial factura INNER Join id_factura detalle ON factura.secuencial = detalle.id_factura "

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim adapter3 As New OleDbDataAdapter(New OleDbCommand(consulta3, conexion))


            Me.dsFactura = New DataSet("fact")
            Me.dsCliente = New DataSet("client")
            Me.dsDetalle = New DataSet("info")

            adapter.Fill(dsFactura, "factura")
            adapter2.Fill(dsCliente, "cliente")
            adapter3.Fill(dsDetalle, "detalle")
            For Each fact As DataRow In dsFactura.Tables("factura").Rows
                lblNumeroFactura.Content = (fact(0).ToString) + 1
            Next


            dataGrid.DataContext = dsDetalle













                End Using






        'lblNumeroFactura.Content = "yaaa"

    End Sub

    Private Sub addDetalle_Click(sender As Object, e As RoutedEventArgs) Handles addDetalle.Click
        Dim winDet As New WinAddDetalle
        winDet.Owner = Me
        Me.Hide()
        winDet.Show()
    End Sub

    Private Sub guardar_Click(sender As Object, e As RoutedEventArgs) Handles guardar.Click





        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "SELECT * FROM cliente ;" 'SELECT * FROM factura ORDER BY secuencial DESC LIMIT 1;
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsCliente = New DataSet("client")
            adapter.Fill(dsCliente, "cliente")

            Dim found = False
            For Each cliente As DataRow In dsCliente.Tables("cliente").Rows
                If cliente("cedulaRuc") = Me.txtCedulaRuc.Text Then
                    cliente("nombre") = Me.txtCliente.Text
                    cliente("direccion") = Me.txtDireccion.Text

                    found = True
                    Exit For
                End If
            Next




            If Not found Then
                dsCliente.Tables("cliente").Rows.Add(Me.txtCedulaRuc.Text, Me.txtCliente.Text, Me.txtDireccion.Text)
            End If



            'Try

            'adapter.Update(dsCliente.Tables("cliente"))
            If found Then
                    MessageBox.Show("Se actualizó el cliente")
                Else
                    MessageBox.Show("Se agregó el cliente")
                End If
            'Catch es As Exception
            '    MessageBox.Show("Error al actualizar")
            'End Try

        End Using
        Me.Close()
    End Sub
End Class
