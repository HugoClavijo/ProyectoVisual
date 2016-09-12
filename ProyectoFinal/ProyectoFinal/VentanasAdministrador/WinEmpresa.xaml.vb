Imports System.Data
Imports System.Data.OleDb

Public Class WinEmpresa

    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Private dsEmpresa As DataSet
    Private dsProducto As DataSet


    Private Sub DataEmpresa_Loaded(sender As Object, e As RoutedEventArgs) Handles DataEmpresa.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM empresa;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsEmpresa = New DataSet("Tienda")
            adapter.Fill(dsEmpresa, "empresa")

            txtNombre.Text = dsEmpresa.Tables(0).Rows(0).Item(1)
            txtProvincia.Text = dsEmpresa.Tables(0).Rows(0).Item(2)
            txtCiudad.Text = dsEmpresa.Tables(0).Rows(0).Item(3)
            txtRuc.Text = dsEmpresa.Tables(0).Rows(0).Item(4)
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
            id = dsEmpresa.Tables(0).Rows(0).Item(0)
        Catch ex As Exception

        End Try

        For Each empresa As DataRow In Me.dsEmpresa.Tables("empresa").Rows
            If empresa("id") = id Then
                dsEmpresa.Tables(0).Rows(0).Item(1) = txtNombre.Text
                dsEmpresa.Tables(0).Rows(0).Item(2) = txtProvincia.Text
                dsEmpresa.Tables(0).Rows(0).Item(3) = txtCiudad.Text
                dsEmpresa.Tables(0).Rows(0).Item(4) = txtRuc.Text
            End If
        Next


        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM empresa;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsEmpresa.Tables("empresa"))
                MessageBox.Show("Se han guardado los datos...")
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using

    End Sub

End Class
