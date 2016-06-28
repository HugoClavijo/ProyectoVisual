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
        '  menu.Iniciar()







        '------------------------------------------
        'CATEGORIA---------------------------------
        Dim hogar As New Categoria("hogar")
        Dim deporte As New Categoria("deporte")
        Dim cocina As New Categoria("cocina")
        Dim comedia As New Categoria("comedia")
        Dim terror As New Categoria("terror")
        '------------------------------------------
        'PRODUCTOS---------------------------------


        Dim prod1 As New Producto("Silent hill", 35.55)
        Dim prod2 As New Producto("resident evil", 40.1)

        terror.Productos.Add(prod1)
        terror.Productos.Add(prod2)



        Console.WriteLine(terror.obtenerProducto(0))
        Console.WriteLine(terror.obtenerProducto(1))










        Console.ReadLine()


    End Sub

End Module
