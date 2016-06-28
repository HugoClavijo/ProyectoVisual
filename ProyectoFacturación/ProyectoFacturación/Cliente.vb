Public Class Cliente
    Protected _nombre As String
    Protected _ruc_Cedula As String
    Private _direccion As String


    Public Sub New(Nombre As String)
        Me._nombre = Nombre

    End Sub


    Public Sub New(Nombre As String, ruc_Cedula As String)
        Me._nombre = Nombre
        Me._ruc_Cedula = ruc_Cedula
    End Sub


    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property



    Public Property Ruc_Cedula() As String
        Get
            Return _ruc_Cedula
        End Get
        Set(ByVal value As String)
            _ruc_Cedula = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

End Class
