Imports System.Data
Imports System.Data.OleDb

Public Class WinAdminFacturas

    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsFacturas As DataSet

    Private Sub DataFacturas_Loaded(sender As Object, e As RoutedEventArgs) Handles DataFacturas.Loaded

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM factura;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsFacturas = New DataSet("Tienda")
            adapter.Fill(dsFacturas, "factura")

            dataGrid.DataContext = dsFacturas

        End Using

    End Sub

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim admin As WinAdmin
        admin = Me.Owner
        admin.Show()
    End Sub

    Private Sub dtgFacturas_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid.SelectionChanged
        Dim aux As String = ""
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim nuevaFactura As New Factura(fila(0), fila(2), fila(3), fila(4), fila(5), fila(6), fila(7), fila(8), fila(9), fila(10), fila(11), fila(12))
            Dim winFact As New WinViewFactura
            winFact.Owner = Me
            winFact.DataContext = nuevaFactura
            winFact.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As RoutedEventArgs) Handles btnBuscar.Click
        Dim intValue As Integer

        If Not Integer.TryParse(txtNum.Text, intValue) Then
            MessageBox.Show("Error, Ingrese números en # Factura")
            Exit Sub
        End If

        Using conexion As New OleDbConnection(strConexion)

            If txtNum.Text = Nothing Then
                Dim consulta2 As String = "Select * FROM factura"
                Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
                Me.dsFacturas = New DataSet("Tienda")
                adapter2.Fill(dsFacturas, "factura")

                dataGrid.DataContext = dsFacturas
            Else
                Dim consulta As String = "Select * FROM factura WHERE secuencial =" & txtNum.Text & ";"
                Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
                Me.dsFacturas = New DataSet("Tienda")
                adapter.Fill(dsFacturas, "factura")

                dataGrid.DataContext = dsFacturas
            End If

        End Using
    End Sub

End Class
