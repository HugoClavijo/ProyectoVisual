Public Class Cliente
    Protected _cedula As String
    Protected _nombre As String
    Protected _direccion As String


    Public Sub New(idruc As String, nombre As String, direccion As String)
        Me.Id = idruc
        Me.Nombre = nombre
        Me.Direccion = direccion
    End Sub

    Public Sub New(idruc As String, nombre As String)
        Me.Id = idruc
        Me.Nombre = nombre
    End Sub


    Public Property Id() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
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


    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property


End Class
