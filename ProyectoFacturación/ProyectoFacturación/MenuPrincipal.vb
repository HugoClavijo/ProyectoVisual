Public Class MenuPrincipal
    Protected vectorProductos As VectorProductos
    Protected vectorFacturas As VectorFacturas
    Protected arregloUsuarios As New ArrayList()
    Public Property Usuarios() As ArrayList
        Get
            Return arregloUsuarios
        End Get
        Set(ByVal value As ArrayList)
            arregloUsuarios = value
        End Set
    End Property


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


                Console.Clear()
                    Console.WriteLine("Usuario Vendedor " & idAux & " Logeado... " & user & vbNewLine)
                    Console.WriteLine("1.- Facturar")
                    Console.WriteLine("2.- Salir de la sesión")
                    Console.WriteLine("3.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcion = Console.ReadLine()


                If opcion = "1" Then

                    facturar()



                ElseIf opcion = "2" Then
                    'Console.Clear()
                    'Console.WriteLine("3.- Salir del sistema")
                    Iniciar()



                ElseIf opcion = "3" Then




                End If


        End Select

    End Sub

    Public Sub facturar()
        Dim siono As String
        Dim nombre As String
        Dim ruc_ci As String
        Dim cantidad As Integer
        Dim descripcion As String
        Dim cliente As Cliente
        Dim producto As Producto



        Console.Clear()
        Console.Write("¿Desea su factura con datos?s/n: ")


        siono = Console.ReadLine

        If siono = "s" Or siono = "S" Then

            Console.Clear()
            Console.Write("Sr(es): ")
            nombre = Console.ReadLine()
            Console.Write("R.U.C./C.I: ")
            ruc_ci = Console.ReadLine()

            cliente = New Cliente(nombre, ruc_ci)


            Do While siono = "s" Or siono = "S"
                Console.Clear()

                Console.WriteLine("CANTIDAD           PRODUCTO      ValorUnit     ValorTotal     ")
                cantidad = Console.ReadLine()

                'Console.Write("CANTIDAD: ")
                Console.WriteLine("")
                Console.SetCursorPosition(19, 1)
                descripcion = Console.ReadLine()
                Console.WriteLine("")


                'Console.Write("PRODUCTO: ")
                'descripcion = Console.ReadLine()
                'Console.SetCursorPosition(35, 2)

                producto = ValidarProducto(cantidad, descripcion)
                Console.SetCursorPosition(35, 1)
                Console.WriteLine(producto.Precio)
                Console.WriteLine("")
                Console.SetCursorPosition(49, 1)
                Console.WriteLine("$" & producto.Precio * cantidad)
                Console.Write("DESEA INGRESAR UN NUEVO PRODUCTO? S/N:  ")
                siono = Console.ReadLine()




            Loop



            If siono = "f" Or siono = "F" Then
                Console.Clear()
                Console.Write("Ya nos vamos")
            End If

            'Console.SetCursorPosition(35, 2)
            'Console.Write(" V.Unitario: ")

            'Console.Write(" $10.00")
            'Console.Write("    V.Total: ")
            'Console.Write(" $10.00 ")

            Console.ReadLine()


        ElseIf siono = "n" Or siono = "N" Then
            'Console.WriteLine("Sr(es): Usuario final")
            Console.Write("CANTIDAD: ")
            cantidad = Console.ReadLine()
            Console.Write("PRODUCTO: ")
            descripcion = Console.ReadLine()
            ValidarProducto(cantidad, descripcion)

        End If




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
            Console.WriteLine("Usuario y/o contraseña incorrectos, vuelva a intentarlo.")
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
        vectorProductos = New VectorProductos
        vectorFacturas = New VectorFacturas
    End Sub



    Public Function ValidarProducto(cantidad As Integer, nombProd As String)
        Dim stock As Integer = 0
        Dim name As String = "no existe"
        Dim prod As Producto
        For Each producto As Producto In vectorProductos.ArrayProductos
            If producto.CantidadStock > cantidad And nombProd = producto.Nombre Then
                Console.WriteLine("Producto Comprado con exito :)")
                Console.WriteLine("Teniamos en stock: " & producto.CantidadStock)
                prod = producto
                producto.CantidadStock -= cantidad
                Console.WriteLine("Ahora tenemos:  " & producto.CantidadStock)
                Exit For
            ElseIf (producto.CantidadStock < cantidad And nombProd = producto.Nombre) Then
                Console.WriteLine("*Lo sentimos*")
                Console.WriteLine("Tenemos un stock de: " & producto.CantidadStock)
                Exit For
            ElseIf nombProd IsNot producto.Nombre Then
                Console.WriteLine("No tenemos ese producto")
                Exit For
            End If
        Next




        Return prod
    End Function

End Class
