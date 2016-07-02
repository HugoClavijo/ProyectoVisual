Public Class MenuPrincipal
    Protected vectorProductos As VectorProductos
    Protected vectorFacturas As VectorFacturas
    Protected arregloUsuarios As New ArrayList()
    Dim detallesArray As New ArrayList
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
                MenuAdministrador(user, pass, idAux)

            Case "vendedor"
                MenuVendedor(user, pass, idAux)

        End Select

    End Sub


    Public Sub MenuAdministrador(user As String, pass As String, idAux As String)
        Dim opcionAdmin As Integer
        Dim opcionProductos As Integer
        Dim auxCantidad As Integer
        Dim auxNombre As String
        Dim auxPrecio As Double


        Do
            Console.Clear()
            Console.WriteLine("Usuario Administrador " & idAux & " Logeado... " & user & vbNewLine)
            Console.WriteLine("1.- Categorías")
            Console.WriteLine("2.- Productos")
            Console.WriteLine("3.- IVA diferenciado")
            Console.WriteLine("4.- Provincia")
            Console.WriteLine("5.- Salir de la sesión")
            Console.WriteLine("6.- Salir del sistema")
            Console.Write("Ingrese una opción: ")
            opcionAdmin = Console.ReadLine()

            Select Case opcionAdmin
                Case "1"
                            'Administrador de categorias
                Case "2"
                    Console.Clear()
                    Console.WriteLine("1.- Añadir producto")
                    Console.WriteLine("2.- Borrar producto")
                    Console.WriteLine("3.- Regresar")
                    Console.WriteLine("4.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcionProductos = Console.ReadLine()

                    Select Case opcionProductos
                        Case "1"
                            Console.Clear()
                            Console.WriteLine("Ingrese cantidad que desea añadir: ")
                            auxCantidad = Console.ReadLine()
                            Console.WriteLine("Ingrese Nombre del producto: ")
                            auxNombre = Console.ReadLine()
                            Console.WriteLine("Ingrese precio del producto: ")
                            auxPrecio = Console.ReadLine()

                            vectorProductos.AñadirProducto(auxCantidad, auxNombre, auxPrecio)
                            MenuAdministrador(user, pass, idAux)
                        Case "2"
                            Console.Clear()
                            Console.WriteLine("Ingrese cantidad que desea Borrar: ")
                            auxCantidad = Console.ReadLine()
                            Console.WriteLine("Ingrese Nombre del producto: ")
                            auxNombre = Console.ReadLine()
                            Console.WriteLine("Ingrese precio del producto: ")
                            auxPrecio = Console.ReadLine()

                            vectorProductos.BorrarProducto(auxCantidad, auxNombre)
                            MenuAdministrador(user, pass, idAux)
                        Case "3"
                            MenuAdministrador(user, pass, idAux)
                        Case "4"
                            Environment.Exit(0)
                    End Select

                Case "3"
                    'Iva diferenciado
                Case "5"
                    Iniciar()
                    'Case "6"
                    '    Environment.Exit(0)
            End Select
        Loop Until (opcionAdmin = "6")

    End Sub

    Public Sub MenuVendedor(user As String, pass As String, idAux As String)
        Dim opcionVendedor As Integer
        Console.Clear()
        Console.WriteLine("Usuario Vendedor " & idAux & " Logeado... " & user & vbNewLine)
        Console.WriteLine("1.- Facturar")
        Console.WriteLine("2.- Salir de la sesión")
        Console.WriteLine("3.- Salir del sistema")
        Console.Write("Ingrese una opción: ")
        opcionVendedor = Console.ReadLine()

        Select Case opcionVendedor
            Case "1"
                facturar()
            Case "2"
                Iniciar()
            Case "3"
                Environment.Exit(0)
        End Select

        'If opcionVendedor = "1" Then

        '        facturar()



        '    ElseIf opcionVendedor = "2" Then
        '        'Console.Clear()
        '        'Console.WriteLine("3.- Salir del sistema")
        '        Iniciar()

        '    ElseIf opcionVendedor = "3" Then

        'End If
    End Sub


    Public Sub facturar()
        Dim siono As String
        Dim nombre As String
        Dim ruc_ci As String
        Dim cantidads As String = ""
        Dim cantidad As Integer
        Dim descripcion As String
        Dim vunitario As Double = 0
        Dim vtotal As Double = 0
        Dim subtotal As Double = 0
        Dim iva As Double = 0.14
        Dim totalFactura As Double = 0
        Dim efectivo As Double = 0
        Dim cambio As Double = 0

        Dim cliente As Cliente
        Dim producto As Producto
        Dim posx As Integer = 0
        Dim posy As Integer = 0




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



            Console.WriteLine("CANTIDAD           PRODUCTO      ValorUnit     ValorTotal     ")
            posy = 2
            Do While siono = "S" Or siono = "s"
                posx = 2
                posy += 1
                Console.SetCursorPosition(posx, posy)


                cantidads = Console.ReadLine()
                If cantidads = "" Then
                    Exit Do

                Else
                    cantidad = CInt(cantidads)
                End If

                posx += 19




                Console.WriteLine("")

                Console.SetCursorPosition(posx, posy)
                descripcion = Console.ReadLine()
                Console.WriteLine("")



                producto = ValidarProducto(cantidad, descripcion)
                posx += 16
                Console.SetCursorPosition(posx, posy)
                vunitario = producto.Precio
                Console.WriteLine(vunitario)
                Console.WriteLine("")
                posx += 14
                Console.SetCursorPosition(posx, posy)
                vtotal = producto.Precio * cantidad
                Console.WriteLine("$" & vtotal)

                Dim detalle As New Detalle(cantidad, descripcion, vunitario, vtotal) 'esto debe ir a factura
                detallesArray.Add(detalle)



                Console.WriteLine("")
                Console.Write("")





            Loop

            If cantidads = "" Then
                posx = 40
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("-----------------------")
                posy += 1
                Console.SetCursorPosition(posx, posy)
                For Each d As Detalle In detallesArray
                    subtotal += d.PrecioTotal
                Next

                Console.Write("SUBTOTAL: $" & subtotal)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                iva = iva * subtotal
                Console.Write(" IVA 14%: $" & iva)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                totalFactura = iva + subtotal
                Console.Write("   TOTAL: $" & totalFactura)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("EFECTIVO: $")
                efectivo = Console.ReadLine()
                posy += 1
                Console.SetCursorPosition(posx, posy)
                cambio = (efectivo - totalFactura)
                Format(cambio, “##,##0.00”)
                Console.Write("CAMBIO  : $" & cambio)

                Dim factura As New Factura(cliente, detallesArray, subtotal, iva, totalFactura, efectivo, cambio)
                factura.mostrarFactura()
                Console.ReadLine()
                Iniciar()
            End If




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
        Me.vectorProductos = New VectorProductos
        Me.vectorFacturas = New VectorFacturas
    End Sub



    Public Function ValidarProducto(cantidad As Integer, nombProd As String)
        Dim stock As Integer = 0
        Dim name As String = nombProd
        Dim prod As Producto
        For Each producto As Producto In vectorProductos.ArrayProductos
            If name = producto.Nombre And producto.CantidadStock > cantidad Then

                prod = producto
                producto.CantidadStock -= cantidad
                'Console.WriteLine("Ahora tenemos:  " & producto.CantidadStock)

            ElseIf (producto.CantidadStock < cantidad And nombProd = producto.Nombre) Then
                'Console.WriteLine("*Lo sentimos*")
                'Console.WriteLine("Tenemos un stock de: " & producto.CantidadStock)

            ElseIf nombProd IsNot producto.Nombre Then
                'Console.WriteLine(vectorProductos.ArrayProductos.Count)'obtengo la cantidad de  productos


            End If
        Next




        Return prod
    End Function

End Class
