Public Class Cliente
    Protected _nombre As String
    Protected _cedula As Integer

    Public Sub New(Nombre As String)
        Me._nombre = Nombre

    End Sub


    Public Sub New(Nombre As String, cedula As Integer)
        Me._nombre = Nombre
        Me._cedula = cedula
    End Sub


    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property



    Public Property Cedula() As Integer
        Get
            Return _cedula
        End Get
        Set(ByVal value As Integer)
            _cedula = value
        End Set
    End Property

End Class
