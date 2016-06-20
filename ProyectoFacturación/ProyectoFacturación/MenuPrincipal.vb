Public Class MenuPrincipal


    Dim arregloUsuarios As New ArrayList()
    Public Property Usuarios() As ArrayList
        Get
            Return arregloUsuarios
        End Get
        Set(ByVal value As ArrayList)
            arregloUsuarios = value
        End Set
    End Property

    'Dim empleado As Vendedor
    'Dim admin As Administrador


    Public Sub Iniciar()

        Dim user, pass, idAux As String

        Do
            Console.Clear()
            Console.WriteLine("Aplicación en VB.Net para facturación..." & vbNewLine)
            Console.Write("Nombre de usuario:  ")
            user = Console.ReadLine()
            Console.Write("Contraseña:  ")
            pass = Console.ReadLine()
            idAux = ValidarUsuario(user, pass)
        Loop While idAux = "No existe"


    End Sub


    Public Function ValidarUsuario(usuario As String, pass As String)
        Dim id As String = "No existe"

        For Each user As Usuario In arregloUsuarios
            If user.Usuario = usuario And user.Password = pass Then
                id = user.Id
            End If
        Next

        If id = "No existe" Then
            Console.WriteLine("Usuario y/o contraseña incorrectos, presione ENTER para volver a intentar.")
            Console.ReadLine()
        End If

        If id <> "No Existe" Then
            Console.WriteLine("Usuario Logeado...")
        End If


        Return id
    End Function


    Public Sub New(arreglo As ArrayList)
        Me.Usuarios = arreglo
    End Sub

End Class
