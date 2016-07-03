Public Class VectorProductos
    Protected prod1 As Producto
    Protected prod2 As Producto
    Protected prod3 As Producto
    Protected prod4 As Producto
    Protected prod5 As Producto
    Protected prod6 As Producto
    Protected prod7 As Producto
    Protected prod8 As Producto
    Protected prod9 As Producto
    Private _arrayProductos As  ArrayList

    Public Sub New()
        cargarProductos()
    End Sub

    Public Sub cargarProductos()
        prod1 = New Producto(100, "a", 40.0)
        prod2 = New Producto(200, "b", 50.0)
        prod3 = New Producto(300, "c", 60.0)
        prod4 = New Producto(400, "d", 70.0)
        prod5 = New Producto(500, "e", 80.0)
        prod6 = New Producto(600, "f", 90.0)
        prod7 = New Producto(700, "g", 100.0)
        prod8 = New Producto(800, "h", 110.0)
        prod9 = New Producto(900, "i", 120.0)


        ArrayProductos = New ArrayList

        ArrayProductos.Add(prod1)
        ArrayProductos.Add(prod2)
        ArrayProductos.Add(prod3)
        ArrayProductos.Add(prod4)
        ArrayProductos.Add(prod5)
        ArrayProductos.Add(prod6)
        ArrayProductos.Add(prod7)
        ArrayProductos.Add(prod8)
        ArrayProductos.Add(prod9)

    End Sub

    'Public Sub AñadirProducto(cantidad As Integer, nombre As String, precio As Double)
    '    ArrayProductos.Add(New Producto(cantidad, nombre, precio))
    'End Sub

    'Public Sub BorrarProducto(cantidad As Integer, nombre As String)
    '    'Dim contador = 0
    '    If cantidad > 0 Then
    '        For Each producto As Producto In ArrayProductos
    '            If producto.Nombre = nombre Then
    '                producto.CantidadStock -= cantidad
    '                If cantidad < 0 Then
    '                    producto.CantidadStock = 0
    '                End If
    '                'ArrayProductos.Remove(producto)
    '                'contador += 1
    '                'If contador = cantidad Then
    '                '    Exit For
    '                'End If
    '            End If
    '        Next
    '    End If

    'End Sub


    Public Property ArrayProductos() As ArrayList
        Get
            Return _arrayProductos
        End Get
        Set(ByVal value As ArrayList)
            _arrayProductos = value
        End Set
    End Property
End Class
