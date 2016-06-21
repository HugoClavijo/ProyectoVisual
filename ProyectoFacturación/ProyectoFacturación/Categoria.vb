Public Class Categoria

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

    Protected _productos As ArrayList
    Public Property Productos() As ArrayList
        Get
            Return _productos
        End Get
        Set(ByVal value As ArrayList)
            _productos = value
        End Set
    End Property



    Public Sub New(id As String, nombre As String)
        Me._id = id
        Me._nombre = nombre
        Me._productos = New ArrayList
    End Sub


    Public Sub New(id As String, nombre As String, products As ArrayList)
        Me._id = id
        Me._nombre = nombre
        Me._productos = products
    End Sub

End Class
