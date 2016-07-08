Module Module1

    Sub Main()
        Dim arregloUsers As New ArrayList()
        Dim path As String = "C:\Users\ESTUDIANTE.GGEDCLABWRK065\Documents\Visual Studio 2015\Projects\ProyectoVisual\ProyectoFacturación\facturas.xml"
        Dim pathProductos As String = "C:\Users\ESTUDIANTE.GGEDCLABWRK065\Documents\Visual Studio 2015\Projects\ProyectoVisual\ProyectoFacturación\productos.xml"
        Dim pathCategorias As String = "C:\Users\ESTUDIANTE.GGEDCLABWRK065\Documents\Visual Studio 2015\Projects\ProyectoVisual\ProyectoFacturación\categorias.xml"
        'Dim admin As Usuario = New Usuario("administrador", "01", "Hugo Clavijo", "hugo", "batman")
        'Dim vendedor As Usuario = New Usuario("vendedor", "02", "Juan Carlos Carrera", "juank", "spiderman")

        Dim admin As Administrador = New Administrador("01", "Hugo Clavijo", "hugo", "batman")
        Dim vendedor As Vendedor = New Vendedor("02", "Juan Carlos Carrera", "juank", "spiderman")

        arregloUsers.Add(admin)


        arregloUsers.Add(vendedor)

        Dim menu As MenuPrincipal = New MenuPrincipal(arregloUsers, path, pathCategorias, pathProductos)
        menu.Iniciar()

        Console.ReadLine()


    End Sub

End Module
