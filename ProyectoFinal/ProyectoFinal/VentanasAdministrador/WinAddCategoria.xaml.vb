Imports System.Data
Imports System.Data.OleDb

Public Class WinAddCategoria
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsCategorias As DataSet

    Private Sub AddCategorias_Loaded(sender As Object, e As RoutedEventArgs) Handles AddCategorias.Loaded
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM categoria;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsCategorias = New DataSet("Tienda")
            adapter.Fill(dsCategorias, "categoria")
        End Using
    End Sub

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim cate As WinAdminCategorias
        cate = Me.Owner
        'cate.actualizar()
        cate.Show()
        'Me.Hide()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click

        Dim intValue As Integer

        If Me.txtId.Text = Nothing Or Me.txtNombre.Text = Nothing Or Me.txtDescripcion.Text = Nothing Then
            MessageBox.Show("Error, campos vacios.")
            Exit Sub
        End If

        If Not Integer.TryParse(Me.txtId.Text, intValue) Then
            MessageBox.Show("Error, ingrese número en Id ")
            Exit Sub
        End If


        Dim listCate As WinAdminCategorias = Me.Owner
        Using conexion As New OleDbConnection(listCate.strConexion)

            Dim consulta As String = "Select * FROM categoria;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsCategorias = New DataSet("Tienda")
            adapter.Fill(dsCategorias, "categoria")
            Dim found = False

            For Each cate As DataRow In dsCategorias.Tables("categoria").Rows
                If cate("Id") = Me.txtId.Text Then
                    cate("nombre") = Me.txtNombre.Text
                    cate("descripcion") = Me.txtDescripcion.Text
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                dsCategorias.Tables("categoria").Rows.Add(Me.txtId.Text, Me.txtNombre.Text, Me.txtDescripcion.Text)
            End If
            Try
                adapter.Update(dsCategorias.Tables("categoria"))
                If found Then
                    MessageBox.Show("Se actualizó la categoria")
                Else
                    MessageBox.Show("Se agregó la categoria")
                End If
            Catch es As Exception
                MessageBox.Show("Error al actualizar")
            End Try
            listCate.UpdateDataGrid()

        End Using
        Me.Close()

    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As RoutedEventArgs) Handles btnBorrar.Click

        Dim listCate As WinAdminCategorias = Me.Owner
        Using conexion As New OleDbConnection(listCate.strConexion)

            Dim consulta As String = "Delete * FROM categoria WHERE id =" & txtId.Text & ";"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Me.dsCategorias = New DataSet("Tienda")
            adapter.Fill(dsCategorias, "categoria")
            Dim found = False

            If Not found Then
                MessageBox.Show("Se borró la categoria")
            End If
            'Try
            adapter.Update(dsCategorias.Tables("categoria"))
                If found Then
                MessageBox.Show("No se borró la categoria")
            End If
            'Catch es As Exception
            '    MessageBox.Show("Error al actualizar")
            'End Try
            listCate.UpdateDataGrid()

        End Using
        Me.Close()

    End Sub
End Class
