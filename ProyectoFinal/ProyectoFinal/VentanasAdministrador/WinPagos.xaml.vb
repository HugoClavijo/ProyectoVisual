Imports System.Data
Imports System.Data.OleDb

Public Class WinPagos
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsPagos As DataSet

    Private Sub DataPagos_Loaded(sender As Object, e As RoutedEventArgs) Handles DataPagos.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM pagos;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsPagos = New DataSet("Tienda")
            adapter.Fill(dsPagos, "pagos")

            dataGrid.DataContext = dsPagos
        End Using
    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim admin As WinAdmin
        admin = Me.Owner
        admin.Show()
    End Sub


    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim id = 0
        Try
            'id = Me.DataContext.Id()
            id = dsPagos.Tables(0).Rows(0).Item(0)
        Catch ex As Exception

        End Try

        For Each pago As DataRow In Me.dsPagos.Tables("pagos").Rows
            If pago("id") = id Then
                dsPagos.Tables(0).Rows(0).Item(1) = txtIva.Text / 100
                dsPagos.Tables(0).Rows(0).Item(2) = txtTarjeta.Text / 100
                dsPagos.Tables(0).Rows(0).Item(3) = txtElectronico.Text / 100
            End If
        Next


        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM pagos;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsPagos.Tables("pagos"))
                MessageBox.Show("Se han guardado los datos...")
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub
End Class
