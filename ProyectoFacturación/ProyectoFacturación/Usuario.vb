Public Class Usuario

    Protected _tipoUser As String
    Public Property TipoUser() As String
        Get
            Return _tipoUser
        End Get
        Set(ByVal value As String)
            _tipoUser = value
        End Set
    End Property


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

    Protected _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Protected _password As String

    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property


    Public Sub New(tipo As String, id As String, nombre As String, usuario As String, pass As String)
        Me.TipoUser = tipo
        Me._id = id
        Me._nombre = nombre
        Me._usuario = usuario
        Me._password = pass
    End Sub

    Public Sub New()

    End Sub

End Class
