Public Class MenuPrincipal


    Protected vectorFacturas As VectorFacturas
    Protected arregloUsuarios As New ArrayList()
    Protected _empresa As Empresa
    Dim auxImpuesto As Double = 0.14
    Dim auxEfectivo As Double = 0
    Dim auxTarjeta As Double = 0.01
    Dim auxElectronico As Double = 0.04
    Dim auxResta As Double = 0
    Dim detallesArray As ArrayList

    Protected arregloCategorias As ArrayList


    Public Property Usuarios() As ArrayList
        Get
            Return arregloUsuarios
        End Get
        Set(ByVal value As ArrayList)
            arregloUsuarios = value
        End Set
    End Property


    Public Property Categorias() As ArrayList
        Get
            Return arregloCategorias
        End Get
        Set(ByVal value As ArrayList)
            arregloCategorias = value
        End Set
    End Property


    Public Property Empresa() As Empresa
        Get
            Return _empresa
        End Get
        Set(ByVal value As Empresa)
            _empresa = value
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
        Dim opcionCategorias As Integer
        Dim opcionIva As Integer
        Dim opcionEmpresa, opcionNuevaEmpresa As Integer
        Dim opcionValorDevuelto As Integer
        Dim auxCategoria As String
        Dim auxCantidad As Integer
        Dim auxNombre As String
        Dim auxPrecio As Double
        Dim auxRating As String
        Dim auxConsola As String
        Dim indexArreglo As Integer
        Dim auxNumFact As Long

        Do
            Console.Clear()
            Console.WriteLine("Usuario Administrador " & idAux & " Logeado... " & user & vbNewLine)
            Console.WriteLine("1.- Datos Empresa")
            Console.WriteLine("2.- Categorías")
            Console.WriteLine("3.- Productos")
            Console.WriteLine("4.- IVA")
            Console.WriteLine("5.- Buscar Factura")
            Console.WriteLine("6.- Salir de la sesión")
            Console.WriteLine("7.- Salir del sistema")
            Console.Write("Ingrese una opción: ")
            opcionAdmin = Console.ReadLine()

            Select Case opcionAdmin

                Case "1"
                    Dim auxRuc As Long
                    Dim auxRazon, name, dir, prov As String

                    MostrarEmpresa()
                    Console.WriteLine("Realizar...")
                    Console.WriteLine("1.- Cambiar Datos Empresa")
                    Console.WriteLine("2.- Salir")
                    opcionNuevaEmpresa = Console.ReadLine()

                    Select Case opcionNuevaEmpresa
                        Case "1"
                            Console.WriteLine("Ingrese RUC:")
                            auxRuc = Console.ReadLine()
                            Console.WriteLine("Ingrese Razón Social:")
                            auxRazon = Console.ReadLine()
                            Console.WriteLine("Ingrese Nombre Empresa:")
                            name = Console.ReadLine()
                            Console.WriteLine("Ingrese Dirección De La Empresa:")
                            dir = Console.ReadLine()
                            Console.WriteLine("Ingrese Provincia De La Empresa:")
                            prov = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Nuevos Datos Empresa...")
                            InfoEmpresa(auxRuc, auxRazon, name, dir, prov)
                            MostrarEmpresa()
                            Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "2"
                            MenuAdministrador(user, pass, idAux)

                    End Select

                Case "2"
                    'Administrador de categorias
                    Console.Clear()
                    Console.WriteLine("1.- Añadir Categoria")
                    Console.WriteLine("2.- Borrar Categoria")
                    Console.WriteLine("3.- Borrar Todas Las Categorias")
                    Console.WriteLine("4.- Regresar")
                    Console.WriteLine("5.- Salir Del Sistema")
                    Console.Write("Ingrese una opción: ")
                    opcionCategorias = Console.ReadLine()

                    Select Case opcionCategorias
                        Case "1"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria (añadir):  ")
                            auxCategoria = Console.ReadLine()
                            Categorias.Add(New Categoria(auxCategoria))

                            For Each cat As Categoria In Categorias
                                Console.WriteLine(cat.Nombre)
                            Next

                            Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "2"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria (borrar): ")
                            For Each cat As Categoria In Categorias
                                Console.WriteLine(cat.Nombre)
                            Next

                            auxCategoria = Console.ReadLine()

                            Console.Clear()
                            Console.WriteLine("La categoria " & auxCategoria & " ha sido borrada")
                            Console.WriteLine(" ")

                            For Each cate As Categoria In arregloCategorias
                                If cate.Nombre = auxCategoria Then
                                    indexArreglo = arregloCategorias.IndexOf(cate)
                                End If
                            Next

                            arregloCategorias.RemoveAt(indexArreglo)

                            For Each cat As Categoria In Categorias
                                Console.WriteLine(cat.Nombre)
                            Next

                            Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "3"

                            Categorias.Clear()
                            Console.Clear()
                            Console.WriteLine("Todas las categorias han sido borradas")
                            Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "4"

                            MenuAdministrador(user, pass, idAux)

                        Case "5"

                            Environment.Exit(0)

                    End Select


                Case "3"
                    'Administrador de productos
                    Console.Clear()
                    Console.WriteLine("1.- Añadir Productos")
                    Console.WriteLine("2.- Borrar Productos")
                    Console.WriteLine("3.- Borrar Todos Los Productos")
                    Console.WriteLine("4.- Regresar")
                    Console.WriteLine("5.- Salir Del Sistema")
                    Console.Write("Ingrese una opción: ")
                    opcionProductos = Console.ReadLine()

                    Select Case opcionProductos
                        Case "1"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria del producto: ")

                            For Each cat As Categoria In Categorias
                                Console.WriteLine(cat.Nombre)
                            Next

                            Console.WriteLine()
                            auxCategoria = Console.ReadLine()

                            Console.WriteLine(vbNewLine & "Ingrese Cantidad que desea añadir: " & vbNewLine)
                            auxCantidad = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese Nombre del producto: " & vbNewLine)
                            auxNombre = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese Precio del producto: " & vbNewLine)
                            auxPrecio = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese Rating del producto: " & vbNewLine)
                            auxRating = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese Consola del producto: " & vbNewLine)
                            auxConsola = Console.ReadLine()

                            For Each cat As Categoria In Categorias
                                If auxCategoria = cat.Nombre Then
                                    cat.AñadirProducto(auxCantidad, auxNombre, auxPrecio, auxCategoria, auxRating, auxConsola)
                                    Console.WriteLine(vbNewLine & "El producto " & auxNombre & " se ha agregado en " & auxCategoria & "...")
                                End If
                            Next

                            For Each cate As Categoria In Categorias
                                If auxCategoria = cate.Nombre Then
                                    cate.MostrarProductos()
                                End If
                            Next

                            Console.ReadLine()
                            'vectorProductos.AñadirProducto(auxCantidad, auxNombre, auxPrecio)
                            MenuAdministrador(user, pass, idAux)

                        Case "2"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria del producto: ")

                            For Each cat As Categoria In Categorias
                                Console.WriteLine(cat.Nombre)
                            Next

                            Console.WriteLine()
                            auxCategoria = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese cantidad que desea Borrar: " & vbNewLine)
                            auxCantidad = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Productos con categoria " & auxCategoria)

                            For Each cat1 As Categoria In Categorias
                                If auxCategoria = cat1.Nombre Then
                                    cat1.MostrarProductos()
                                End If
                            Next

                            Console.WriteLine(vbNewLine)
                            Console.WriteLine(vbNewLine & "Ingrese Nombre del producto: " & vbNewLine)
                            auxNombre = Console.ReadLine()

                            For Each cat As Categoria In Categorias
                                If auxCategoria = cat.Nombre Then
                                    cat.BorrarProducto(auxCantidad, auxNombre)
                                End If
                            Next

                            Console.Clear()

                            For Each cate As Categoria In Categorias
                                If auxCategoria = cate.Nombre Then
                                    cate.MostrarProductos()
                                End If
                            Next

                            Console.WriteLine(vbNewLine)
                            Console.WriteLine("El producto " & auxNombre & " ha sido borrado")
                            'vectorProductos.BorrarProducto(auxCantidad, auxNombre)
                            Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "3"

                            Dim auxx As Integer = 0
                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria de los productos que seran borrados...")
                            auxCategoria = Console.ReadLine()

                            For Each cat As Categoria In Categorias
                                If auxCategoria = cat.Nombre Then
                                    auxx = Categorias.IndexOf(cat)
                                End If
                            Next

                            If Not auxx = 0 Then
                                Categorias.RemoveAt(auxx)
                            End If

                            Console.WriteLine(vbNewLine & "Los productos de " & auxCategoria & " han sido borrados")
                            Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "4"

                            MenuAdministrador(user, pass, idAux)

                        Case "5"

                            Environment.Exit(0)

                    End Select


                Case "4"

                    'Iva diferenciado
                    Console.Clear()
                    Console.WriteLine("1.- IVA")
                    Console.WriteLine("2.- Tipo De Pago")
                    Console.WriteLine("3.- Regresar")
                    Console.WriteLine("4.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcionIva = Console.ReadLine()

                    Select Case opcionIva

                        Case "1"
                            Dim opcionIv As Integer
                            MostrarEmpresa()
                            Console.WriteLine("Realizar...")
                            Console.WriteLine("1.- Cambiar IVA")
                            Console.WriteLine("2.- Salir")
                            opcionEmpresa = Console.ReadLine()

                            Select Case opcionEmpresa
                                Case "1"
                                    Console.Clear()
                                    Console.WriteLine("Ingrese Nuevo % IVA: (1 - 100)")
                                    opcionIv = Console.ReadLine()

                                    If opcionIv >= 0 And opcionIv <= 100 Then
                                        auxImpuesto = opcionIv / 100
                                    End If

                                    Console.Clear()
                                    Console.WriteLine("El Nuevo IVA es: " & auxImpuesto)
                                    Console.ReadLine()
                                    MenuAdministrador(user, pass, idAux)

                                Case "2"
                                    MenuAdministrador(user, pass, idAux)
                            End Select

                        Case "2"

                            Dim opcionCreditCard, opcionElectronico As Integer
                            MostrarEmpresa()
                            Console.WriteLine("Realizar...")
                            Console.WriteLine("1.- Cambiar Valores")
                            Console.WriteLine("2.- Salir")
                            opcionValorDevuelto = Console.ReadLine()

                            Select Case opcionValorDevuelto
                                Case "1"
                                    Console.Clear()
                                    Console.WriteLine("Ingrese Nuevo % Valor Devuelto (Tarjeta De Credito) : (1 - 100)")
                                    opcionCreditCard = Console.ReadLine()

                                    If opcionCreditCard >= 0 And opcionCreditCard <= 100 Then
                                        auxTarjeta = opcionCreditCard / 100
                                    End If

                                    Console.WriteLine("Ingrese Nuevo Valor Devuelto (Dinero Electronico): (1 - 100)")
                                    opcionElectronico = Console.ReadLine()

                                    If opcionElectronico >= 0 And opcionElectronico <= 100 Then
                                        auxElectronico = opcionElectronico / 100
                                    End If

                                    Console.Clear()
                                    Console.WriteLine("Nuevo Valor Devuelto (Efectivo): " & auxEfectivo)
                                    Console.WriteLine("Nuevo Valor Devuelto (Tarjeta De Credito): " & auxTarjeta)
                                    Console.WriteLine("Nuevo Valor Devuelto (Dinero Electronico): " & auxElectronico & vbNewLine & vbNewLine)
                                    Console.ReadLine()
                                    MenuAdministrador(user, pass, idAux)

                            End Select


                        Case "3"

                            MenuAdministrador(user, pass, idAux)

                        Case "4"

                            Environment.Exit(0)

                    End Select


                Case "5"

                    Console.Clear()
                    Console.WriteLine("Ingrese Número de Factura: ")
                    auxNumFact = Console.ReadLine()
                    buscarFactura(auxNumFact)
                    Console.ReadLine()
                    MenuAdministrador(user, pass, idAux)

                Case "6"

                    Iniciar()

                Case "7"

                    Environment.Exit(0)

            End Select

        Loop Until (opcionAdmin = "7")

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

                Facturar()

            Case "2"

                Iniciar()

            Case "3"

                Environment.Exit(0)

        End Select

    End Sub


    Public Sub Facturar()
        Dim siono As String
        Dim nombre As String
        Dim ruc_ci As String
        Dim cantidads As String = ""
        Dim cantidad As Integer
        Dim auxSecuencial As Long = 1001
        Dim descripcion As String
        Dim vunitario As Double = 0
        Dim vtotal As Double = 0
        Dim subtotal As Double = 0
        Dim iva As Double = 0.14
        Dim totalFactura As Double = 0
        Dim efectivo As Double = 0
        Dim tarjeta As Double = 0
        Dim dineroElect As Double = 0
        Dim cambio As Double = 0

        Dim formaPago As Integer = 0

        Dim cliente As Cliente
        Dim producto As Producto
        Dim posx As Integer = 0
        Dim posy As Integer = 0

        detallesArray = New ArrayList()


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

            For Each f As Factura In vectorFacturas.ArrayFacturas
                auxSecuencial = f.Secuencial + 1

            Next


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
                iva = auxImpuesto * subtotal
                Console.Write(" IVA " & auxImpuesto & "%: $" & iva)
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
                Console.Write("TCREDITO: $")
                tarjeta = Console.ReadLine()
                Dim auxta As Double = 0
                If tarjeta > 0 Then
                    auxta = auxTarjeta * totalFactura

                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("D.ELECTR: $")
                dineroElect = Console.ReadLine()
                Dim auxel As Double = 0
                If dineroElect > 0 Then
                    auxel = auxElectronico * subtotal
                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                'operacion(14%      -   4%    -      1%)
                cambio = ((efectivo + tarjeta + dineroElect) - totalFactura)
                'cambiar formato de cambio
                Console.Write("CAMBIO  : $" & cambio)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("--------------------")
                posy += 1

                auxResta = ((efectivo + tarjeta + dineroElect) - totalFactura) - auxel - auxta
                Console.SetCursorPosition(posx, posy)
                If efectivo > totalFactura Then
                    auxResta = 0
                End If
                Console.Write("Valor devuelto: $" & auxResta)



                Dim factura As New Factura(auxImpuesto, Empresa, auxSecuencial, cliente, detallesArray, subtotal, iva, totalFactura, efectivo, tarjeta, dineroElect, cambio, auxResta)
                vectorFacturas.ArrayFacturas.Add(factura)

                For Each fact As Factura In vectorFacturas.ArrayFacturas
                    fact.mostrarFactura()
                Next



                'factura.mostrarFactura()

                Console.ReadLine()
                Iniciar()
            End If




            Console.ReadLine()


        ElseIf siono = "n" Or siono = "N" Then
            'Console.WriteLine("Sr(es): Usuario final")

            Console.Clear()
            Console.WriteLine("Sr(es):  Usuario final")
            nombre = "Usuario final"


            cliente = New Cliente(nombre)

            For Each f As Factura In vectorFacturas.ArrayFacturas
                auxSecuencial = f.Secuencial + 1

            Next


            Console.WriteLine("CANTIDAD           PRODUCTO      ValorUnit     ValorTotal     ")
            posy = 2
            Do While siono = "n" Or siono = "N"
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
                Console.Write(" IVA " & auxImpuesto & "%: $" & iva)
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
                Console.Write("TCREDITO: $")
                tarjeta = Console.ReadLine()
                Dim auxta As Double = 0
                If tarjeta > 0 Then
                    auxta = auxTarjeta * totalFactura

                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("D.ELECTR: $")
                dineroElect = Console.ReadLine()
                Dim auxel As Double = 0
                If dineroElect > 0 Then
                    auxel = auxElectronico * subtotal
                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                'operacion(14%      -   4%    -      1%)
                cambio = ((efectivo + tarjeta + dineroElect) - totalFactura)
                'cambiar formato de cambio
                Console.Write("CAMBIO  : $" & cambio)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("--------------------")
                posy += 1

                auxResta = ((efectivo + tarjeta + dineroElect) - totalFactura) - auxel - auxta
                Console.SetCursorPosition(posx, posy)
                If efectivo > totalFactura Then
                    auxResta = 0
                End If
                Console.Write("Valor devuelto: $" & auxResta)



                Dim factura As New Factura(auxImpuesto, Empresa, auxSecuencial, cliente, detallesArray, subtotal, iva, totalFactura, efectivo, tarjeta, dineroElect, cambio, auxResta)
                vectorFacturas.ArrayFacturas.Add(factura)

                For Each fact As Factura In vectorFacturas.ArrayFacturas
                    fact.mostrarFactura()
                Next



                'factura.mostrarFactura()

                Console.ReadLine()
                Iniciar()
            End If




            Console.ReadLine()


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


    Public Sub CargarCategorias()
        Dim accion As Categoria = New Categoria("accion")
        Dim aventura As Categoria = New Categoria("aventura")
        Dim terror As Categoria = New Categoria("terror")
        Categorias.Add(accion)
        Categorias.Add(aventura)
        Categorias.Add(terror)
    End Sub


    Public Sub AñadirCategoria(categoria As Categoria)
        Categorias.Add(categoria)
    End Sub


    Public Function ValidarProducto(cantidad As Integer, nombProd As String)
        Dim stock As Integer = 0
        Dim name As String = nombProd
        Dim prod As Producto


        For Each cat As Categoria In arregloCategorias
            Dim aux As Integer = 0


            For Each producto As Producto In cat.Productos

                producto = cat.obtenerProducto(aux)
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
                aux += 1
            Next

        Next





        'For Each producto As Producto In vectorProductos.ArrayProductos
        '    If name = producto.Nombre And producto.CantidadStock > cantidad Then

        '        prod = producto
        '        producto.CantidadStock -= cantidad
        '        'Console.WriteLine("Ahora tenemos:  " & producto.CantidadStock)

        '    ElseIf (producto.CantidadStock < cantidad And nombProd = producto.Nombre) Then
        '        'Console.WriteLine("*Lo sentimos*")
        '        'Console.WriteLine("Tenemos un stock de: " & producto.CantidadStock)

        '    ElseIf nombProd IsNot producto.Nombre Then
        '        'Console.WriteLine(vectorProductos.ArrayProductos.Count)'obtengo la cantidad de  productos


        '    End If
        'Next

        Return prod
    End Function


    Public Sub buscarFactura(secuencial As Long) ' esto  va en el menu administrador 
        For Each f As Factura In vectorFacturas.ArrayFacturas
            If secuencial = f.Secuencial Then
                f.mostrarFactura()
            End If
        Next
    End Sub


    Public Sub CargarProductos()
        Dim prod1 As Producto = New Producto(100, "Counter Strike", 40.0, "accion", "pg", "playstation 4")
        Dim prod2 As Producto = New Producto(200, "Call of duty 4 Modern Warfare", 35.5, "accion", "pg", "playstation 4")
        Dim prod3 As Producto = New Producto(300, "Call of duty 3", 25.5, "accion", "pg", "Xbox One")

        For Each cat As Categoria In arregloCategorias
            If cat.Nombre = "accion" Then
                cat.Productos.Add(prod1)
                cat.Productos.Add(prod2)
                cat.Productos.Add(prod3)
            End If
        Next

        Dim prod4 As Producto = New Producto(400, "Pokemon Gold", 20.5, "aventura", "pg", "game boy")
        Dim prod5 As Producto = New Producto(500, "Pokemon Silver", 20.6, "aventura", "pg", "game boy")
        Dim prod6 As Producto = New Producto(600, "Pokemon GO", 30.5, "aventura", "pg", "pc")

        For Each cat As Categoria In arregloCategorias
            If cat.Nombre = "aventura" Then
                cat.Productos.Add(prod4)
                cat.Productos.Add(prod5)
                cat.Productos.Add(prod6)
            End If
        Next

        Dim prod7 As Producto = New Producto(700, "Silent hill", 32.3, "terror", "pg", "playstation 3")
        Dim prod8 As Producto = New Producto(800, "Silent hill: 2", 42.3, "terror", "r", "playstation 4")
        Dim prod9 As Producto = New Producto(900, "Silent hill: 3", 120.0, "terror", "r", "playstation 4")

        For Each cat As Categoria In arregloCategorias
            If cat.Nombre = "terror" Then
                cat.Productos.Add(prod7)
                cat.Productos.Add(prod8)
                cat.Productos.Add(prod9)
            End If
        Next

    End Sub


    Public Sub InfoEmpresa(ruc As Long, razonS As String, nameEmpresa As String, dir As String, prov As String)
        Empresa = New Empresa(ruc, razonS, nameEmpresa, dir, prov)
    End Sub


    Public Sub CargarEmpresa()
        Empresa = New Empresa(1235846958001, "Proyecto Visual S.A.", "Proyecto", "Campus Espol, EDCOM - Guayaquil,Ecuador", "Guayas")
    End Sub


    Public Sub MostrarEmpresa()
        Console.Clear()
        Console.WriteLine("Empresa: " & Empresa.NombreComercial)
        Console.WriteLine("Dirección (Sucursal): " & Empresa.DireccionEmpresa)
        Console.WriteLine("Provincia: " & Empresa.Provincia)
        Console.WriteLine("IVA: " & auxImpuesto & vbNewLine & vbNewLine)
    End Sub


    Public Sub ValidarImpuesto()
        If Empresa.Provincia = "Manabí" Or Empresa.Provincia = "Esmeraldas" Or Empresa.Provincia = "esmeraldas" Or Empresa.Provincia = "manabí" Then
            auxImpuesto = 0.12
        Else
            auxImpuesto = 0.14
        End If
    End Sub


    Public Sub New(arreglo As ArrayList)
        Me.Usuarios = arreglo
        Me.Categorias = New ArrayList
        CargarEmpresa()
        ValidarImpuesto()
        CargarCategorias()
        CargarProductos()

        Me.vectorFacturas = New VectorFacturas
    End Sub

End Class
