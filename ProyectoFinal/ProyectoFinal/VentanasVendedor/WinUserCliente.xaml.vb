Imports System.Data
Imports System.Data.OleDb

Public Class WinUserCliente
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsCliente As DataSet
    Dim dsProvincia As DataSet

    Private Sub AddUsuarios_Loaded(sender As Object, e As RoutedEventArgs) Handles UserClientes.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM cliente;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsCliente = New DataSet("Tienda")
            adapter.Fill(dsCliente, "cliente")
        End Using

    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim clientes As WinUserClientes
        clientes = Me.Owner
        clientes.Show()
        'Me.Hide()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click

        'Dim intValue As Integer

        If Me.txtId.Text = Nothing Or Me.txtNombre.Text = Nothing Or Me.txtDirec.Text = Nothing Then
            MessageBox.Show("Error, campos vacios.")
            Exit Sub
        End If

        Dim listClients As WinUserClientes = Me.Owner
        Using conexion As New OleDbConnection(listClients.strConexion)

            Dim consulta As String = "Select * FROM cliente;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsCliente = New DataSet("Tienda")
            adapter.Fill(dsCliente, "cliente")
            Dim found = False

            For Each client As DataRow In dsCliente.Tables("cliente").Rows
                If client("cedulaRuc") = Me.txtId.Text Then
                    client("cedulaRuc") = Me.txtId.Text
                    client("nombre") = Me.txtNombre.Text
                    client("direccion") = Me.txtDirec.Text
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                Me.dsCliente.Tables(0).Rows.Add(Me.txtId.Text, Me.txtNombre.Text, Me.txtDirec.Text)
            End If

            'Try
            adapter.Update(dsCliente.Tables("cliente"))
            If found Then
                MessageBox.Show("Se actualizó el cliente")
            Else
                MessageBox.Show("Se agregó el cliente")
            End If
            'Catch es As Exception
            '    MessageBox.Show("Error al actualizar")
            'End Try
            listClients.UpdateDataGrid()
        End Using
        Me.Close()

    End Sub
End Class
