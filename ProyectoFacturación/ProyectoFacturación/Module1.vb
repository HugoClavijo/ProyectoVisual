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
        '------------------------------------------
        'PRODUCTOS---------------------------------
















        Console.ReadLine()


    End Sub

End Module
