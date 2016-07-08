Imports System.Xml

Public Class MenuPrincipal


    Protected vectorFacturas As VectorFacturas
    Protected arregloUsuarios As New ArrayList()
    Protected _empresa As Empresa
    Protected _ruta As String
    Dim rutaUsuarios As String
    Dim rutaCategorias As String
    Dim rutaProductos As String
    Dim auxImpuesto As Double = 0.14
    Dim auxEfectivo As Double = 0
    Dim auxTarjeta As Double = 0.01
    Dim auxElectronico As Double = 0.04
    Dim auxResta As Double = 0

    Dim detallesArray As New ArrayList

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


    Public Property Ruta() As String
        Get
            Return _ruta
        End Get
        Set(ByVal value As String)
            _ruta = value
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
            Console.WriteLine("6.- Guardar Cambios")
            Console.WriteLine("7.- Salir de la sesión")
            Console.WriteLine("8.- Salir del sistema")
            Console.WriteLine("9.- Agregar Usuario (sustentación):")
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

                            Dim rucString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(rucString) Then
                                Console.Clear()
                                Console.Write("Error, RUC: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxRuc = rucString

                            Console.WriteLine("Ingrese Razón Social:")

                            Dim razonString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(razonString) Then
                                Console.Clear()
                                Console.Write("Error, Razón Social: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxRazon = razonString

                            Console.WriteLine("Ingrese Nombre Empresa:")

                            Dim nameString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(nameString) Then
                                Console.Clear()
                                Console.Write("Error, Nombre Empresa: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            name = nameString

                            Console.WriteLine("Ingrese Dirección De La Empresa:")

                            Dim dirString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(dirString) Then
                                Console.Clear()
                                Console.Write("Error, Dirección De La Empresa: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            dir = dirString

                            Console.WriteLine("Ingrese Provincia De La Empresa:")

                            Dim provString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(provString) Then
                                Console.Clear()
                                Console.Write("Error, Provincia De La Empresa: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            prov = provString

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

                            Dim catString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(catString) Then
                                Console.Clear()
                                Console.Write("Error, Categoria (añadir): VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxCategoria = catString

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

                            Dim catString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(catString) Then
                                Console.Clear()
                                Console.Write("Error, Categoria (borrar): VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxCategoria = catString

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

                            Dim catString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(catString) Then
                                Console.Clear()
                                Console.Write("Error, Categoria: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxCategoria = catString

                            Console.WriteLine(vbNewLine & "Ingrese Cantidad que desea añadir: " & vbNewLine)

                            Dim canString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(canString) Then
                                Console.Clear()
                                Console.Write("Error, Cantidad: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxCantidad = canString

                            Console.WriteLine(vbNewLine & "Ingrese Nombre del producto: " & vbNewLine)

                            Dim nameString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(nameString) Then
                                Console.Clear()
                                Console.Write("Error, Nombre: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxNombre = nameString

                            Console.WriteLine(vbNewLine & "Ingrese Precio del producto: " & vbNewLine)

                            Dim precioString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(nameString) Then
                                Console.Clear()
                                Console.Write("Error, Precio: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxPrecio = CDbl(precioString)

                            Console.WriteLine(vbNewLine & "Ingrese Rating del producto: " & vbNewLine)

                            Dim ratString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(ratString) Then
                                Console.Clear()
                                Console.Write("Error, Precio: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxRating = ratString

                            Console.WriteLine(vbNewLine & "Ingrese Consola del producto: " & vbNewLine)

                            Dim conString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(conString) Then
                                Console.Clear()
                                Console.Write("Error, Consola: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxConsola = conString

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

                            Dim catString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(catString) Then
                                Console.Clear()
                                Console.Write("Error, Categoria: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If


                            auxCategoria = catString

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

                            Dim nameString As String = Console.ReadLine()

                            If String.IsNullOrEmpty(nameString) Then
                                Console.Clear()
                                Console.Write("Error, Nombre: VACIO")
                                Console.ReadLine()
                                MenuAdministrador(user, pass, idAux)
                            End If

                            auxNombre = nameString

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

                                    Dim ivaString As String = Console.ReadLine()

                                    If String.IsNullOrEmpty(ivaString) Or CInt(ivaString) < 0 Or CInt(ivaString) > 100 Then
                                        Console.Clear()
                                        Console.Write("Error, IVA: MAL")
                                        Console.ReadLine()
                                        MenuAdministrador(user, pass, idAux)
                                    End If

                                    opcionIv = CInt(ivaString)

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
                                    Console.WriteLine("Ingrese Nuevo % Valor Devuelto (Tarjeta De Credito): (1 - 100)")

                                    Dim tarString As String = Console.ReadLine()

                                    If String.IsNullOrEmpty(tarString) Or CInt(tarString) < 0 Or CInt(tarString) > 100 Then
                                        Console.Clear()
                                        Console.Write("Error, % Valor Devuelto (Tarjeta De Credito): MAL")
                                        Console.ReadLine()
                                        MenuAdministrador(user, pass, idAux)
                                    End If

                                    opcionCreditCard = CInt(tarString)

                                    If opcionCreditCard >= 0 And opcionCreditCard <= 100 Then
                                        auxTarjeta = opcionCreditCard / 100
                                    End If

                                    Console.WriteLine("Ingrese Nuevo % Valor Devuelto (Dinero Electronico): (1 - 100)")

                                    Dim elecString As String = Console.ReadLine()

                                    If String.IsNullOrEmpty(elecString) Or CInt(elecString) < 0 Or CInt(elecString) > 100 Then
                                        Console.Clear()
                                        Console.Write("Error, % Valor Devuelto (Dinero Electronico): MAL")
                                        Console.ReadLine()
                                        MenuAdministrador(user, pass, idAux)
                                    End If

                                    opcionElectronico = CInt(elecString)

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

                    Dim numString As String = Console.ReadLine()

                    If String.IsNullOrEmpty(numString) Then
                        Console.Clear()
                        Console.Write("Error, Número de Factura: MAL")
                        Console.ReadLine()
                        MenuAdministrador(user, pass, idAux)
                    End If

                    auxNumFact = CInt(numString)

                    buscarFactura(auxNumFact)
                    Console.ReadLine()
                    MenuAdministrador(user, pass, idAux)

                Case "6"

                    ''GuardarCategorias()
                    'GuardarProductos()
                    XmlCategorias()
                    XmlProductos()
                    Console.Clear()
                    Console.WriteLine("Los Datos se han guardado...")
                    Console.ReadLine()
                    MenuAdministrador(user, pass, idAux)

                Case "7"

                    Iniciar()

                Case "8"

                    Environment.Exit(0)

                Case "9"
                    Dim auxAdmin, auxVende As String

                    Console.Clear()
                    Console.WriteLine("Seleccione el tipo de usuario que desea crear..." & vbNewLine)
                    Console.WriteLine("1.- Administrador")
                    Console.WriteLine("2.- Vendedor")
                    Dim auxUsuario As String = Console.ReadLine()


                    'For Each admin As Administrador In Usuarios
                    '    auxAdmin = admin.Id
                    'Next

                    'For Each vendedor As Vendedor In Usuarios
                    '    auxVende = vendedor.Id
                    'Next

                    Select Case auxUsuario
                        Case "1"
                            Console.Clear()
                            Console.WriteLine("Ingrese Nombre:")
                            Dim auxName As String = Console.ReadLine()
                            Console.WriteLine("Nombre de Usuario:")
                            Dim auxUsua As String = Console.ReadLine()
                            Console.WriteLine("Contraseña:")
                            Dim auxcontra As String = Console.ReadLine()

                            Usuarios.Add(New Administrador(CStr(auxAdmin), auxName, auxUsua, auxcontra))
                            Console.ReadLine()
                            guardarUsuarios()
                            MenuAdministrador(user, pass, idAux)
                        Case "2"
                            Console.Clear()
                            Console.WriteLine("Ingrese Nombre:")
                            Dim auxName As String = Console.ReadLine()
                            Console.WriteLine("Nombre de Usuario:")
                            Dim auxUsua As String = Console.ReadLine()
                            Console.WriteLine("Contraseña:")
                            Dim auxcontra As String = Console.ReadLine()
                            Usuarios.Add(New Vendedor(CStr(auxVende), auxName, auxUsua, auxcontra))
                            Console.ReadLine()
                            guardarUsuarios()
                            MenuAdministrador(user, pass, idAux)
                    End Select


                    'If auxUsuario = "1" Then

                    '    Usuarios.Add(New Administrador(CStr(auxAdmin), "Hugo Clavijo", "hugo", "batman"))
                    'Else
                    '    Usuarios.Add(New Vendedor(CStr(auxVende), "Hugo Clavijo", "hugo", "batman"))
                    'End If


            End Select

        Loop Until (opcionAdmin = "9")

    End Sub


    Public Sub MenuVendedor(user As String, pass As String, idAux As String)

        Dim opcionVendedor As Integer

        Console.Clear()
        Console.WriteLine("Usuario Vendedor " & idAux & " Logeado... " & user & vbNewLine)
        Console.WriteLine("1.- Facturar")
        Console.WriteLine("2.- Guardar Facturas")
        Console.WriteLine("3.- Salir de la sesión")
        Console.WriteLine("4.- Salir del sistema")
        Console.Write("Ingrese una opción: ")
        opcionVendedor = Console.ReadLine()

        Select Case opcionVendedor

            Case "1"

                Facturar(user, pass, idAux)

            Case "2"

                'EstructurarXML()
                GuardarFacturas()
                Console.Clear()
                Console.WriteLine("Las Facturas se han guardado...")
                Console.ReadLine()
                MenuVendedor(user, pass, idAux)

            Case "3"

                Iniciar()

            Case "4"

                Environment.Exit(0)

        End Select

    End Sub


    Public Sub Facturar(user As String, pass As String, idAux As String)
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
        Dim iva As Double = auxImpuesto
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
                        Console.Write(" IVA: $" & iva)
                        posy += 1
                        Console.SetCursorPosition(posx, posy)
                        totalFactura = iva + subtotal
                        Console.Write("   TOTAL: $" & totalFactura)




                        posy += 1
                        Console.SetCursorPosition(posx, posy)
                        Console.Write("EFECTIVO: $")

                        Dim efectivoString As String = Console.ReadLine()

                        If String.IsNullOrEmpty(efectivoString) Then
                            Console.Clear()
                            Console.Write("Error, EFECTIVO: VACIO")
                            Console.ReadLine()
                            Facturar(user, pass, idAux)
                        End If

                        efectivo = CDbl(efectivoString)

                        posy += 1
                        Console.SetCursorPosition(posx, posy)
                        Console.Write("TCREDITO: $")

                        Dim tarjetaString As String = Console.ReadLine()

                        If String.IsNullOrEmpty(tarjetaString) Then
                            Console.Clear()
                            Console.Write("Error, TCREDITO: VACIO")
                            Console.ReadLine()
                            Facturar(user, pass, idAux)
                        End If

                        tarjeta = CDbl(tarjetaString)

                        Dim auxta As Double = 0
                        If tarjeta > 0 Then
                            auxta = auxTarjeta * totalFactura

                        End If
                        posy += 1
                        Console.SetCursorPosition(posx, posy)
                        Console.Write("D.ELECTR: $")

                        Dim elecString As String = Console.ReadLine()

                        If String.IsNullOrEmpty(elecString) Then
                            Console.Clear()
                            Console.Write("Error, D.ELECTR: VACIO")
                            Console.ReadLine()
                            Facturar(user, pass, idAux)
                        End If

                        dineroElect = CDbl(elecString)

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
                        Console.Write("Te ahorras: $" & auxResta)



                        Dim factura As New Factura(auxSecuencial, cliente, detallesArray, subtotal, iva, totalFactura, efectivo, tarjeta, dineroElect, cambio, auxResta)
                        vectorFacturas.ArrayFacturas.Add(factura)

                        For Each fact As Factura In vectorFacturas.ArrayFacturas
                            fact.mostrarFactura()
                        Next



                        'factura.mostrarFactura()
                        detallesArray.Clear()
                        Console.ReadLine()
                        'Iniciar()
                        MenuVendedor(user, pass, idAux)
                    End If

                Else
                    cantidad = CInt(cantidads)
                End If

                posx += 19


                Console.WriteLine("")


                Console.SetCursorPosition(posx, posy)
                descripcion = Console.ReadLine()
                Console.WriteLine("")

                'validación stock
                For Each cat As Categoria In arregloCategorias
                    For Each product As Producto In cat.Productos
                        If descripcion = product.Nombre And cantidad > product.CantidadStock Then
                            Console.Clear()
                            Console.WriteLine("Error, no se puede facturar " & cantidad & " Items de " & descripcion)
                            Console.WriteLine("El Stock de " & descripcion & " es " & product.CantidadStock & " Items ")
                            Console.ReadLine()
                            Facturar(user, pass, idAux)
                        End If
                    Next
                Next
                '------------------------
                producto = ValidarProducto(cantidad, descripcion)
                posx += 16


                If Not descripcion = producto.Nombre Then
                    vunitario = 0
                    vtotal = 0
                Else

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

                End If

            Loop






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

                'validación stock
                For Each cat As Categoria In arregloCategorias
                    For Each product As Producto In cat.Productos
                        If descripcion = product.Nombre And cantidad > product.CantidadStock Then
                            Console.Clear()
                            Console.WriteLine("Error, no se puede facturar " & cantidad & " Items de " & descripcion)
                            Console.WriteLine("El Stock de " & descripcion & " es " & product.CantidadStock & " Items ")
                            Console.ReadLine()
                            Facturar(user, pass, idAux)
                        End If
                    Next
                Next
                '------------------------

                producto = ValidarProducto(cantidad, descripcion)
                posx += 16


                If Not descripcion = producto.Nombre Then
                    vunitario = 0
                    vtotal = 0
                Else
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

                End If

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
                Console.Write(" IVA: $" & iva)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                totalFactura = iva + subtotal
                Console.Write("   TOTAL: $" & totalFactura)




                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("EFECTIVO: $")
                Dim efectivoString As String = Console.ReadLine()

                If String.IsNullOrEmpty(efectivoString) Then
                    Console.Clear()
                    Console.Write("Error, EFECTIVO: VACIO")
                    Console.ReadLine()
                    Facturar(user, pass, idAux)
                End If

                efectivo = CDbl(efectivoString)

                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("TCREDITO: $")

                Dim tarjetaString As String = Console.ReadLine()


                If String.IsNullOrEmpty(tarjetaString) Then
                    Console.Clear()
                    Console.Write("Error, TCREDITO: VACIO")
                    Console.ReadLine()
                    Facturar(user, pass, idAux)
                End If

                tarjeta = CDbl(tarjetaString)

                Dim auxta As Double = 0
                If tarjeta > 0 Then
                    auxta = auxTarjeta * totalFactura

                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("D.ELECTR: $")
                Dim dineroElectString As String = Console.ReadLine()

                If String.IsNullOrEmpty(dineroElectString) Then
                    Console.Clear()
                    Console.Write("Error, TCREDITO: VACIO")
                    Console.ReadLine()
                    Facturar(user, pass, idAux)
                End If

                dineroElect = CDbl(dineroElectString)


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
                Console.Write("Te ahorras: $" & auxResta)



                Dim factura As New Factura(auxSecuencial, cliente, detallesArray, subtotal, iva, totalFactura, efectivo, tarjeta, dineroElect, cambio, auxResta)
                vectorFacturas.ArrayFacturas.Add(factura)

                For Each fact As Factura In vectorFacturas.ArrayFacturas
                    fact.mostrarFactura()
                Next



                'factura.mostrarFactura()
                detallesArray.Clear()
                Console.ReadLine()
                'Iniciar()
                MenuVendedor(user, pass, idAux)
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


    'Public Sub CargarCategorias()
    '    Dim accion As Categoria = New Categoria("accion")
    '    Dim aventura As Categoria = New Categoria("aventura")
    '    Dim terror As Categoria = New Categoria("terror")
    '    Categorias.Add(accion)
    '    Categorias.Add(aventura)
    '    Categorias.Add(terror)
    'End Sub


    Public Sub AñadirCategoria(categoria As Categoria)
        Categorias.Add(categoria)
    End Sub


    Public Function ValidarProducto(cantidad As Integer, nombProd As String)
        Dim stock As Integer = 0
        Dim name As String = nombProd
        Dim prod As Producto = New Producto(" ", 0)
        Dim auxName As String = " "

        For Each cat As Categoria In arregloCategorias
            Dim aux As Integer = 0


            For Each producto As Producto In cat.Productos

                producto = cat.obtenerProducto(aux)
                If name = producto.Nombre And producto.CantidadStock > cantidad Then
                    auxName = producto.Nombre
                    prod = producto
                    producto.CantidadStock -= cantidad

                ElseIf (producto.CantidadStock < cantidad And nombProd = producto.Nombre) Then
                    'Console.WriteLine("*Lo sentimos*")
                    'Console.WriteLine("Tenemos un stock de: " & producto.CantidadStock)

                End If
                aux += 1
            Next
        Next

        Return prod

    End Function


    Public Sub buscarFactura(secuencial As Long) ' esto  va en el menu administrador 
        For Each f As Factura In vectorFacturas.ArrayFacturas
            If secuencial = f.Secuencial Then
                f.mostrarFactura()
            End If
        Next
    End Sub

    Public Sub CargarCategorias()
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(rutaCategorias)

        Dim nodoCategoria As XmlNodeList = xmlDoc.GetElementsByTagName("categoria")
        For Each categoria As XmlNode In nodoCategoria
            arregloCategorias.Add(New Categoria(categoria.ChildNodes(0).InnerText))
        Next
    End Sub

    Public Sub CargarProductos()

        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(rutaProductos)

        Dim nodoProduct As XmlNodeList = xmlDoc.GetElementsByTagName("producto")
        For Each product As XmlNode In nodoProduct
            For Each cat As Categoria In arregloCategorias
                If cat.Nombre = product.ChildNodes(3).InnerText Then
                    cat.Productos.Add(New Producto(product.ChildNodes(1).InnerText, product.ChildNodes(0).InnerText, product.ChildNodes(2).InnerText, product.ChildNodes(3).InnerText, product.ChildNodes(4).InnerText, product.ChildNodes(5).InnerText))
                End If
            Next
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


    Public Sub EstructurarXML()
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(_ruta, settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("facturas")

            For Each fact As Factura In vectorFacturas.ArrayFacturas
                writer.WriteStartElement("factura")
                writer.WriteStartElement("infoTributaria")
                writer.WriteElementString("razonSocial", fact.Empresa.Razonsocial.ToString)
                writer.WriteElementString("nombreComercial", fact.Empresa.NombreComercial.ToString)
                writer.WriteElementString("ruc", fact.Empresa.Ruc.ToString)
                'writer.WriteElementString("provEmpresa", fact.Empresa.Provincia.ToString)
                writer.WriteElementString("dirMatriz", fact.Empresa.DireccionEmpresa.ToString)
                writer.WriteEndElement()

                writer.WriteStartElement("infoFactura")
                writer.WriteElementString("fechaEmision", fact.FechaEmision.ToString)
                writer.WriteElementString("numeroFactura", fact.Secuencial.ToString)
                writer.WriteElementString("provEstablecimiento", fact.Empresa.Provincia.ToString)
                writer.WriteElementString("dirEstablecimiento", fact.Empresa.DireccionEmpresa.ToString)
                writer.WriteElementString("cliente", fact.Cliente.Nombre.ToString)
                writer.WriteElementString("totalSinImpuestos", fact.Subtotal.ToString)
                writer.WriteElementString("impuesto", fact.Impuesto.ToString)
                writer.WriteElementString("totalConImpuestos", fact.TotalFactura.ToString)
                writer.WriteElementString("efectivo", fact.Efectivo.ToString)
                writer.WriteElementString("tarjetaCredito", fact.TarjetaCredito.ToString)
                writer.WriteElementString("dineroElectronico", fact.DineroElectronico.ToString)
                writer.WriteElementString("cambio", fact.Cambio.ToString)
                writer.WriteElementString("valorDevuelto", fact.AhorroFactura.ToString)
                writer.WriteEndElement()


                For Each detalle As Detalle In fact.DetalleArray
                    writer.WriteStartElement("detalle")
                    writer.WriteElementString("descripcion", detalle.Descripcion.ToString)
                    writer.WriteElementString("cantidad", detalle.Cantidad.ToString)
                    writer.WriteElementString("precioUnitario", detalle.PrecioUnitario.ToString)
                    writer.WriteElementString("precioTotalSinImpuesto", detalle.PrecioTotal.ToString)
                    writer.WriteEndElement()
                Next

            Next

        End Using

    End Sub


    Public Sub GuardarFacturas()
        Dim xmlDoc As XmlDocument = New XmlDocument()
        xmlDoc.Load(_ruta)

        'Dim newXMLNode As XmlNode = xmlDoc.SelectSingleNode("factura")
        With xmlDoc.SelectSingleNode("facturas").CreateNavigator().AppendChild()
            .WriteStartElement("factura")
            For Each fact As Factura In vectorFacturas.ArrayFacturas
                .WriteStartElement("infoTributaria")
                .WriteElementString("razonSocial", fact.Empresa.Razonsocial.ToString)
                .WriteElementString("nombreComercial", fact.Empresa.NombreComercial.ToString)
                .WriteElementString("ruc", fact.Empresa.Ruc.ToString)
                .WriteElementString("dirMatriz", fact.Empresa.DireccionEmpresa.ToString)
                .WriteEndElement()


                .WriteStartElement("infoFactura")
                .WriteElementString("fechaEmision", fact.FechaEmision.ToString)
                .WriteElementString("provEstablecimiento", fact.Empresa.Provincia.ToString)
                .WriteElementString("dirEstablecimiento", fact.Empresa.DireccionEmpresa.ToString)
                .WriteElementString("cliente", fact.Cliente.Nombre.ToString)
                .WriteElementString("totalSinImpuestos", fact.Subtotal.ToString)
                .WriteElementString("impuesto", fact.Impuesto.ToString)
                .WriteElementString("totalConImpuestos", fact.TotalFactura.ToString)
                .WriteElementString("efectivo", fact.Efectivo.ToString)
                .WriteElementString("tarjetaCredito", fact.TarjetaCredito.ToString)
                .WriteElementString("dineroElectronico", fact.DineroElectronico.ToString)
                .WriteElementString("cambio", fact.Cambio.ToString)
                .WriteElementString("valorDevuelto", fact.AhorroFactura.ToString)
                .WriteEndElement()

                For Each detalle As Detalle In fact.DetalleArray
                    .WriteStartElement("detalle")
                    .WriteElementString("descripcion", detalle.Descripcion.ToString)
                    .WriteElementString("cantidad", detalle.Cantidad.ToString)
                    .WriteElementString("precioUnitario", detalle.PrecioUnitario.ToString)
                    .WriteElementString("precioTotalSinImpuesto", detalle.PrecioTotal.ToString)
                    .WriteEndElement()
                Next
            Next
            .Close()
        End With

        xmlDoc.Save(_ruta)

    End Sub

    Public Sub XmlProductos()
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(rutaProductos, settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("productos")

            For Each cat As Categoria In Categorias
                For Each pro As Producto In cat.Productos
                    writer.WriteStartElement("producto")
                    writer.WriteElementString("nombre", pro.Nombre.ToString)
                    writer.WriteElementString("stock", pro.CantidadStock.ToString)
                    writer.WriteElementString("precio", pro.Precio.ToString)
                    writer.WriteElementString("categoria", pro.Categoria.ToString)
                    writer.WriteElementString("rating", pro.Rating.ToString)
                    writer.WriteElementString("consola", pro.Consola.ToString)
                    writer.WriteEndElement()
                Next
            Next
        End Using

    End Sub


    'Public Sub GuardarProductos()
    '    Dim xmlDoc As XmlDocument = New XmlDocument()
    '    xmlDoc.Load(rutaProductos)

    '    'Dim newXMLNode As XmlNode = xmlDoc.SelectSingleNode("factura")
    '    With xmlDoc.SelectSingleNode("productos").CreateNavigator().AppendChild()
    '        .WriteStartElement("producto")
    '        For Each cat As Categoria In Categorias
    '            For Each pro As Producto In cat.Productos
    '                .WriteElementString("nombre", pro.Nombre.ToString)
    '                .WriteElementString("stock", pro.CantidadStock.ToString)
    '                .WriteElementString("precio", pro.Precio.ToString)
    '                .WriteElementString("categoria", pro.Categoria.ToString)
    '                .WriteElementString("rating", pro.Rating.ToString)
    '                .WriteElementString("consola", pro.Consola.ToString)
    '                '.WriteEndElement()
    '            Next
    '        Next
    '        .Close()
    '    End With

    '    xmlDoc.Save(rutaProductos)
    'End Sub


    Public Sub XmlCategorias()
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(rutaCategorias, settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("categorias")

            For Each cat As Categoria In Categorias
                writer.WriteStartElement("categoria")
                writer.WriteElementString("nombre", cat.Nombre.ToString)
                'For Each pro As Producto In cat.Productos
                '    writer.WriteStartElement("producto", pro.Nombre.ToString)
                '    writer.WriteEndElement()
                'Next
                writer.WriteEndElement()
            Next
        End Using
    End Sub


    'Public Sub GuardarCategorias()
    '    Dim xmlDoc As XmlDocument = New XmlDocument()
    '    xmlDoc.Load(rutaCategorias)

    '    'Dim newXMLNode As XmlNode = xmlDoc.SelectSingleNode("factura")
    '    With xmlDoc.SelectSingleNode("categorias").CreateNavigator().AppendChild()
    '        .WriteStartElement("categoria")
    '        For Each cat As Categoria In Categorias
    '            .WriteElementString("nombre", cat.Nombre.ToString)
    '            'For Each pro As Producto In cat.Productos
    '            '    .WriteElementString("nombre", pro.Nombre.ToString)
    '            '    .WriteElementString("stock", pro.CantidadStock.ToString)
    '            '    .WriteElementString("precio", pro.Precio.ToString)
    '            '    .WriteElementString("categoria", pro.Categoria.ToString)
    '            '    .WriteElementString("rating", pro.Rating.ToString)
    '            '    .WriteElementString("consola", pro.Consola.ToString)

    '            'Next
    '            '.WriteEndElement()
    '        Next
    '        .Close()
    '    End With

    '    xmlDoc.Save(rutaCategorias)
    'End Sub

    Public Sub cargarUsuarios()
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(rutaUsuarios)

        Dim nodoUsuario As XmlNodeList = xmlDoc.GetElementsByTagName("usuario")
        For Each usuar As XmlNode In nodoUsuario
            If usuar.ChildNodes(2).InnerText = "administrador" Then
                Usuarios.Add(New Administrador("0", usuar.ChildNodes(0).InnerText, usuar.ChildNodes(0).InnerText, usuar.ChildNodes(2).InnerText))
            End If

            If usuar.ChildNodes(2).InnerText = "vendedor" Then
                Usuarios.Add(New Administrador("0", usuar.ChildNodes(0).InnerText, usuar.ChildNodes(0).InnerText, usuar.ChildNodes(2).InnerText))
            End If

            arregloCategorias.Add(New Categoria(usuar.ChildNodes(0).InnerText))
        Next
    End Sub


    Public Sub guardarUsuarios()
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(rutaUsuarios, settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("usuarios")

            For Each user As Usuario In Usuarios
                writer.WriteStartElement("usuario")
                writer.WriteElementString("nombre", user.Usuario.ToString)
                writer.WriteElementString("contraseña", user.Password.ToString)
                writer.WriteElementString("tipo", user.TipoUser.ToString)
                writer.WriteEndElement()
            Next
        End Using
    End Sub


    Public Sub New(arreglo As ArrayList, path As String, pathcategorias As String, pathProductos As String, pathUsuarios As String)
        Me.Usuarios = arreglo
        Me.Categorias = New ArrayList
        Me.Ruta = path
        rutaCategorias = pathcategorias
        rutaProductos = pathProductos
        rutaUsuarios = pathUsuarios
        CargarEmpresa()
        ValidarImpuesto()
        CargarCategorias()
        CargarProductos()
        Me.vectorFacturas = New VectorFacturas
        'cargarUsuarios()
        'guardarUsuarios()
        'EstructurarXML()
        'XmlCategorias()
        'XmlProductos()
    End Sub

End Class
