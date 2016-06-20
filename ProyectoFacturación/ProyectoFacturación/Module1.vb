Module Module1

    Sub Main()
        Dim arregloUsers As New ArrayList()
        Dim admin As Usuario = New Usuario("administrador", "01", "Hugo clavijo", "hugo", "batman")
        Dim vendedor As Usuario = New Usuario("vendedor", "02", "Juan Carlos Carrera", "juank", "spiderman")

        arregloUsers.Add(admin)
        arregloUsers.Add(vendedor)

        Dim menu As MenuPrincipal = New MenuPrincipal(arregloUsers)
        menu.Iniciar()

        Console.ReadLine()

    End Sub

End Module
