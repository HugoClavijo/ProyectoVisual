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
        Dim activo As Usuario
        Dim opcion As Integer

        Do
            Console.Clear()
            Console.WriteLine("Aplicación en VB.Net para facturación..." & vbNewLine)
            Console.Write("Nombre de usuario:  ")
            user = Console.ReadLine()
            Console.Write("Contraseña:  ")
            pass = Console.ReadLine()
            idAux = ValidarUsuario(user, pass)
        Loop While idAux = "No existe"

        activo = ObtenerIdUsuario(idAux)

        Select Case activo.TipoUser

            Case "administrador"
                Do
                    Console.Clear()
                    Console.WriteLine("Usuario Administrador " & idAux & " Logeado... " & user & vbNewLine)
                    Console.WriteLine("1.- Categorías")
                    Console.WriteLine("2.- Artículos")
                    Console.WriteLine("3.- IVA diferenciado")
                    Console.WriteLine("4.- Provincia")
                    Console.WriteLine("5.- Salir de la sesión")
                    Console.WriteLine("6.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcion = Console.ReadLine()

                    If opcion = "5" Then
                        Iniciar()
                    End If

                Loop Until (opcion = "6")


            Case "vendedor"

                Do
                    Console.Clear()
                    Console.WriteLine("Usuario Vendedor " & idAux & " Logeado... " & user & vbNewLine)
                    Console.WriteLine("1.- Facturar")
                    Console.WriteLine("2.- Salir de la sesión")
                    Console.WriteLine("3.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcion = Console.ReadLine()

                    If opcion = "2" Then
                        Iniciar()
                    End If

                Loop Until (opcion = "3")

        End Select

    End Sub


    Public Function ValidarUsuario(usuario As String, pass As String)
        Dim id As String = "No existe"
        Dim tipo As String = "Ninguno"
        Dim nombre As String = "Sin nombre"
        For Each user As Usuario In arregloUsuarios
            If user.Usuario = usuario And user.Password = pass Then
                id = user.Id
                tipo = user.TipoUser
                nombre = user.Nombre
            End If
        Next

        If id = "No existe" Then
            Console.WriteLine("Usuario y/o contraseña incorrectos, presione ENTER para volver a intentar.")
            Console.ReadLine()
        End If

        'If id <> "No existe" Then
        '    Console.WriteLine("Usuario Logeado... " & nombre & " - " & tipo)
        'End If


        Return id

    End Function


    Public Function ObtenerIdUsuario(id As String) As Usuario
        For Each user As Usuario In arregloUsuarios
            If user.Id = id Then
                Return user
            End If
        Next
        Return Nothing
    End Function



    Public Sub New(arreglo As ArrayList)
        Me.Usuarios = arreglo
    End Sub

End Class
