Imports System.Data
Imports System.Data.OleDb

Public Class WinAddUsuarios
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsUser As DataSet
    Dim dsProvincia As DataSet

    Private Sub AddUsuarios_Loaded(sender As Object, e As RoutedEventArgs) Handles AddUsuarios.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM usuario;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsUser = New DataSet("Tienda")
            adapter.Fill(dsUser, "usuario")

            Dim consulta2 As String = "Select * FROM provincia;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
            Me.dsProvincia = New DataSet("Tienda")
            adapter2.Fill(dsProvincia, "provincia")

        End Using

        comboBox.Items.Add("administrador")
        comboBox.Items.Add("vendedor")

        For Each pro As DataRow In dsProvincia.Tables("provincia").Rows
            comboBox_Provincia.Items.Add(pro("provincia"))
        Next

        Dim userr As Usuario = DirectCast(Me.DataContext, Usuario)
        If Not userr Is Nothing Then
            comboBox.SelectedValue = userr.Rol
            comboBox_Provincia.SelectedValue = userr.Provincia
        Else
            comboBox.SelectedValue = "administrador"
            comboBox_Provincia.SelectedValue = "esmeraldas"
        End If

    End Sub


    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim users As WinAdminUsuarios
        users = Me.Owner
        users.Show()
        'Me.Hide()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click

        Dim intValue As Integer

        If Me.txtId.Text = Nothing Or Me.txtUser.Text = Nothing Or Me.txtPassword.Text = Nothing Or Me.txtName.Text = Nothing Or Me.txtApellido.Text = Nothing Or Me.txtContacto.Text = Nothing Then
            MessageBox.Show("Error, campos vacios.")
            Exit Sub
        End If

        If Not Integer.TryParse(Me.txtId.Text, intValue) Then
            MessageBox.Show("Error, ingrese número en Id ")
            Exit Sub
        End If

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
                    user("provincia") = Me.comboBox_Provincia.Text
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                'dsUser.Tables("usuario").Rows.Add(Me.txtId.Text, Me.txtUser.Text, Me.txtPassword.Text, Me.txtName.Text, Me.txtApellido.Text, Me.txtContacto.Text, Me.comboBox.Text, Me.comboBox_Provincia.Text)
                Dim cb As New OleDb.OleDbCommandBuilder(adapter)
                cb.QuotePrefix = "["
                cb.QuoteSuffix = "]"
                Dim dsNewRow As DataRow

                dsNewRow = dsUser.Tables("usuario").NewRow()

                dsNewRow.Item("Id") = Me.txtId.Text
                dsNewRow.Item("user") = Me.txtUser.Text
                dsNewRow.Item("pass") = Me.txtPassword.Text
                dsNewRow.Item("nombre") = Me.txtName.Text
                dsNewRow.Item("apellido") = Me.txtApellido.Text
                dsNewRow.Item("contacto") = Me.txtContacto.Text
                dsNewRow.Item("rol") = Me.comboBox.Text
                dsNewRow.Item("provincia") = Me.comboBox_Provincia.Text
                dsUser.Tables("usuario").Rows.Add(dsNewRow)
                'da.Update(ds, "snack")
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


    Private Sub BtnBorrar_Click(sender As Object, e As RoutedEventArgs) Handles btnBorrar.Click

        Dim listUser As WinAdminUsuarios = Me.Owner
        Using conexion As New OleDbConnection(listUser.strConexion)

            Dim consulta As String = "Delete * FROM usuario WHERE id =" & txtId.Text & ";"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsUser = New DataSet("Tienda")
            adapter.Fill(dsUser, "usuario")
            Dim found = False

            If Not found Then
                MessageBox.Show("Se borró el usuario")
            End If
            'Try
            adapter.Update(dsUser.Tables("usuario"))
            If found Then
                MessageBox.Show("No se borró el usuario")
            End If
            'Catch es As Exception
            '    MessageBox.Show("Error al actualizar")
            'End Try
            listUser.UpdateDataGrid()

        End Using
        Me.Close()

    End Sub



End Class
