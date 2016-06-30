Module Module1

    Sub Main()
        Dim arregloUsers As New ArrayList()
        'Dim admin As Usuario = New Usuario("administrador", "01", "Hugo Clavijo", "hugo", "batman")
        'Dim vendedor As Usuario = New Usuario("vendedor", "02", "Juan Carlos Carrera", "juank", "spiderman")

        Dim admin As Administrador = New Administrador("01", "Hugo Clavijo", "hugo", "batman")
        Dim vendedor As Vendedor = New Vendedor("02", "Juan Carlos Carrera", "juank", "spiderman")

        arregloUsers.Add(admin)

        arregloUsers.Add(vendedor)

        Dim menu As MenuPrincipal = New MenuPrincipal(arregloUsers)
        menu.Iniciar()







        '------------------------------------------
        'CATEGORIA---------------------------------
        Dim hogar As New Categoria("hogar")
        Dim deporte As New Categoria("deporte")
        Dim cocina As New Categoria("cocina")
        Dim comedia As New Categoria("comedia")
        Dim terror As New Categoria("terror")
        '------------------------------------------
        'PRODUCTOS---------------------------------

        Dim vectorProductos As New VectorProductos() 'carga 9 archivos
        ' Console.WriteLine(vectorProductos.ArrayProductos(0).ToString)



        terror.Productos.Add(vectorProductos.ArrayProductos(0))
        terror.Productos.Add(vectorProductos.ArrayProductos(1))


        'Console.WriteLine(terror.obtenerProducto(0))
        'Console.WriteLine(terror.obtenerProducto(1))



        'Console.WriteLine("-------------------------")


        'Vamos a hacer la factura---------------------------------
        '1)Empresa
        Dim empresa1 As New Empresa(1235846958001, "Huan S.A", "Batderman", "Cdla La Joya")
        Dim cliente1 As New Cliente("Armando Paredes", "1234567891001")


        Dim factura1 As New Factura("001", "001", "0012", "1234567890123456789012345678901234567890123456789", empresa1, cliente1)
        Dim total1 As Double
        Dim total2 As Double
        'total1 = factura1.Cliente.comprar(2, prod1)
        'total2 = factura1.Cliente.comprar(1, prod1)

        'factura1.agregarProducto(prod1)
        'factura1.agregarProducto(prod2)
        'factura1.mostrarFactura()








        Console.ReadLine()


    End Sub

End Module
