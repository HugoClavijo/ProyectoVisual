Imports System.Data
Imports System.Data.OleDb

Public Class WinAddUsuarios
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsUser As DataSet


    Private Sub AddUsuarios_Loaded(sender As Object, e As RoutedEventArgs) Handles AddUsuarios.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM usuario;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsUser = New DataSet("Tienda")
            adapter.Fill(dsUser, "usuario")
        End Using

        comboBox.Items.Add("administrador")
        comboBox.Items.Add("vendedor")

        Dim userr As Usuario = DirectCast(Me.DataContext, Usuario)
        If Not userr Is Nothing Then
            comboBox.SelectedValue = userr.Rol
        Else
            comboBox.SelectedValue = "administrador"
        End If

    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim users As WinAdminUsuarios
        users = Me.Owner
        users.Show()
        'Me.Hide()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click

        Dim listUser As WinAdminUsuarios = Me.Owner
        Using conexion As New OleDbConnection(listUser.strConexion)

            Dim consulta As String = "Select * FROM usuario;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsUser = New DataSet("Tienda")
            adapter.Fill(dsUser, "usuario")
            Dim found = False

            For Each user As DataRow In dsUser.Tables("usuario").Rows
                If user("Id") = Me.txtId.Text Then
                    user("Id") = Me.txtId.Text
                    user("user") = Me.txtUser.Text
                    user("pass") = Me.txtPassword.Text
                    user("nombre") = Me.txtName.Text
                    user("apellido") = Me.txtApellido.Text
                    user("contacto") = Me.txtContacto.Text
                    user("rol") = Me.comboBox.Text
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                dsUser.Tables("usuario").Rows.Add(Me.txtId.Text, Me.txtUser.Text, Me.txtPassword.Text, Me.txtName.Text, Me.txtApellido.Text, Me.txtContacto.Text, Me.comboBox.Text)
            End If

            Try
                adapter.Update(dsUser.Tables("usuario"))
                If found Then
                    MessageBox.Show("Se actualizó el usuario")
                Else
                    MessageBox.Show("Se agregó el usuario")
                End If
            Catch es As Exception
                MessageBox.Show("Error al actualizar")
            End Try

            listUser.UpdateDataGrid()

        End Using

        Me.Close()

    End Sub


End Class
