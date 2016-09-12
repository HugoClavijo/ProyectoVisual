Imports System.Data
Imports System.Data.OleDb

Public Class Login
    Public loggedIn As Boolean
    Public usuarios As ArrayList
    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim usuario As String


    Private Sub winLogin_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded, MyBase.Loaded

        Me.usuarios = New ArrayList

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM usuario;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim dsUsuarios = New DataSet("Tienda")
            adapter.Fill(dsUsuarios, "usuario")

            Me.loggedIn = False
            For Each u As DataRow In dsUsuarios.Tables("usuario").Rows
                Me.usuarios.Add(New Usuario(u))
            Next

        End Using
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As RoutedEventArgs) Handles btnLogin.Click

        Dim nuevoUsuario As New Usuario(txtUser.Text, txtPass.Password)
        Me.loggedIn = nuevoUsuario.Login(usuarios)
        If Me.loggedIn Then
            MessageBox.Show("Bienvenido")
            Me.usuario = nuevoUsuario.User
        Else
            MessageBox.Show("Usuario o contraseña no coinciden")
            'Me.usuario = nuevoUsuario.Name
        End If

        If nuevoUsuario.Roles(usuarios) = "administrador" Then
            Dim winAdministrador As New WinAdmin
            winAdministrador.Owner = Me
            Me.Hide()
            winAdministrador.Show()
        ElseIf nuevoUsuario.Roles(usuarios) = "vendedor" Then
            Dim winVendedor As New WinUser
            winVendedor.Owner = Me
            winVendedor.CargarUsuario(Me.usuario)
            Me.Hide()
            winVendedor.Show()
        End If

    End Sub
End Class
