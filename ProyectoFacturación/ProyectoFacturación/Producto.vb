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




    Protected _precio As Double
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property


    Public Sub New(nombre As String, precio As Double)
        Me._nombre = nombre
        Me._precio = precio

    End Sub


    Public Overrides Function ToString() As String
        Return "Producto: " & Me._nombre & vbTab &
         " Costo :" & Me._precio
    End Function

End Class
