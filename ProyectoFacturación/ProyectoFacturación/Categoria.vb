Public Class Categoria

    Protected _id As String
    Protected _nombre As String
    Protected _productos As ArrayList


    Public Sub New(id As String, nombre As String)
        Me._id = id
        Me._nombre = nombre
        Me._productos = New ArrayList
    End Sub


    Public Sub New(nombre As String)
        Me._nombre = nombre
        Me._productos = New ArrayList
    End Sub


    Public Sub New(id As String, nombre As String, products As ArrayList)
        Me._id = id
        Me._nombre = nombre
        Me._productos = products
    End Sub






    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property


    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property


    Public Property Productos() As ArrayList
        Get
            Return _productos
        End Get
        Set(ByVal value As ArrayList)
            _productos = value
        End Set
    End Property


    Public Function obtenerProducto(num As Integer)

        Return Productos(num).ToString
    End Function


    Public Sub AñadirProducto(cantidad As Integer, nombre As String, precio As Double, categoria As String)
        Productos.Add(New Producto(cantidad, nombre, precio, categoria))
    End Sub


    Public Sub BorrarProducto(cantidad As Integer, nombre As String)
        'Dim contador = 0
        If cantidad > 0 Then
            For Each producto As Producto In Productos
                If producto.Nombre = nombre Then
                    If producto.CantidadStock < cantidad Then
                        producto.CantidadStock = 0
                    Else
                        producto.CantidadStock -= cantidad
                    End If
                    'ArrayProductos.Remove(producto)
                    'contador += 1
                    'If contador = cantidad Then
                    '    Exit For
                    'End If
                End If
            Next
        End If

    End Sub

End Class
