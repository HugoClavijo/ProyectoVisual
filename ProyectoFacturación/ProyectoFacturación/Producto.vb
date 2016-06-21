Public Class Producto

    Protected _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property


    Protected _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property


    Protected _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property


    Protected _categoria As Categoria
    Public Property Categoria() As Categoria
        Get
            Return _categoria
        End Get
        Set(ByVal value As Categoria)
            _categoria = value
        End Set
    End Property


    Protected _precio As Double
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property


    Public Sub New(id As String, nombre As String, descripcion As String, categoria As Categoria)
        Me._id = id
        Me._nombre = nombre
        Me._descripcion = descripcion
        Me._categoria = categoria
    End Sub

End Class
