Public Class Producto


    Private _cantidadStock As Integer
    Protected _id As String
    Protected _nombre As String
    Protected _precio As Double
    Protected _categoria As String



    Public Property CantidadStock() As Integer
        Get
            Return _cantidadStock
        End Get
        Set(ByVal value As Integer)
            _cantidadStock = value
        End Set
    End Property


    Public Property Categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property




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



    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property


    Public Sub New(codigo As String, cantidad As Integer, nombre As String, precio As Double, categoria As String)
        Me._id = codigo
        Me._cantidadStock = cantidad
        Me._nombre = nombre
        Me._precio = precio
        Me.Categoria = categoria
    End Sub

    'Public Sub New(cantidad As Integer, nombre As String, precio As Double)
    '    Me._cantidadStock = cantidad
    '    Me._nombre = nombre
    '    Me._precio = precio

    'End Sub

    Public Sub New(cantidad As Integer, nombre As String, precio As Double, categoria As String)
        Me._cantidadStock = cantidad
        Me._nombre = nombre
        Me._precio = precio
        Me.Categoria = categoria
    End Sub


    Public Sub New(nombre As String, precio As Double)
        Me._nombre = nombre
        Me._precio = precio

    End Sub


    Public Overrides Function ToString() As String
        Return "Producto: " & Me._nombre & vbTab &
         " Costo :" & Me._precio
    End Function

End Class
