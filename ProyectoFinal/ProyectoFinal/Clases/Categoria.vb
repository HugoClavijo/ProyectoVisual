Public Class Categoria
    Protected _id As Integer
    Protected _nombre As String
    Protected _descripcion As String
    'Protected _productos As ArrayList

    Public Sub New(id As Integer, nombre As String, descrp As String)
        Me._id = id
        Me._nombre = nombre
        Me._descripcion = descrp
        'Me._productos = New ArrayList
    End Sub


    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
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

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property



    'Public Sub AñadirProducto(cantidad As Integer, nombre As String, precio As Double, categoria As String, rating As String, console As String)
    '    Dim auxProducto As String = Nothing
    '    If cantidad > 0 Then
    '        For Each producto As Producto In Productos
    '            If producto.Nombre = nombre Then
    '                producto.CantidadStock += cantidad
    '                auxProducto = producto.Nombre
    '            End If
    '        Next

    '        If auxProducto = Nothing Then
    '            Productos.Add(New Producto(cantidad, nombre, precio, categoria, rating, console))
    '        End If
    '    End If

    'End Sub


    'Public Sub BorrarProducto(cantidad As Integer, nombre As String)
    '    'Dim contador = 0
    '    Dim indexProducto As Integer = 0

    '    If cantidad > 0 Then
    '        For Each producto As Producto In Productos
    '            If producto.Nombre = nombre Then
    '                If producto.CantidadStock < cantidad Then
    '                    producto.CantidadStock = 0
    '                    indexProducto = Productos.IndexOf(producto)
    '                Else
    '                    producto.CantidadStock -= cantidad
    '                End If
    '            End If
    '        Next

    '        If Not indexProducto = 0 Then
    '            Productos.RemoveAt(indexProducto)
    '        End If
    '    End If
    'End Sub

    'Public Sub BorrarTodosProductos()
    '    Productos.Clear()
    'End Sub
End Class
