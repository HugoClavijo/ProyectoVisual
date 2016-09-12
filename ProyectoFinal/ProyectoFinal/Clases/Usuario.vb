Public Class Usuario
    Private _isLogged As Boolean

    Sub New(usuario As String, clave As String)
        Me.User = usuario
        Me.Pass = clave
    End Sub

    Sub New(usuario As String, clave As String, roll As String)
        Me.User = usuario
        Me.Pass = clave
        Me.Rol = roll
    End Sub

    Sub New(usuario As String, clave As String, nombre As String, apellido As String, contactox As String, rr As String)
        _user = usuario
        _pass = clave
        _name = nombre
        _contacto = contactox
        _rol = rr
        _lastName = apellido
    End Sub

    Sub New(di As Integer, usuario As String, clave As String, nombre As String, apellido As String, contactox As String, rr As String, provin As String)
        _id = di
        _user = usuario
        _pass = clave
        _name = nombre
        _contacto = contactox
        _rol = rr
        _lastName = apellido
        _provincia = provin
    End Sub



    Public ReadOnly Property isLogged() As Boolean
        Get
            Return _isLogged
        End Get
    End Property

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property




    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _lastName As String
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property


    Private _user As String
    Property User() As String
        Get
            Return Me._user
        End Get
        Set(value As String)
            Me._user = value
        End Set
    End Property

    Private _pass As String
    Public Property Pass() As String
        Get
            Return _pass
        End Get
        Set(ByVal value As String)
            _pass = value
        End Set
    End Property

    Private _contacto As String
    Public Property Contact() As String
        Get
            Return _contacto
        End Get
        Set(ByVal value As String)
            _contacto = value
        End Set
    End Property

    Private _rol As String
    Public Property Rol() As String
        Get
            Return _rol
        End Get
        Set(ByVal value As String)
            _rol = value
        End Set
    End Property


    Private _provincia As String
    Public Property Provincia() As String
        Get
            Return _provincia
        End Get
        Set(ByVal value As String)
            _provincia = value
        End Set
    End Property


    Public Function Login(usuarios As ArrayList)

        For Each u As Usuario In usuarios
            If Me.User = u.User And Me.Pass = u.Pass Then
                Me._isLogged = True
                Me.Name = u.Name
                Exit For
            End If
        Next
        Return isLogged
    End Function

    Public Function Logout()
        Me._isLogged = False
        Me.Name = ""
        Me.Contact = ""
        Me.Pass = ""
        Me.Rol = ""
        Me.User = ""
        Me.LastName = ""
        Return True
    End Function


    Public Function Roles(usuarios As ArrayList)
        Dim aux As String = ""
        For Each u As Usuario In usuarios
            If Me.User = u.User And Me.Pass = u.Pass Then
                Me._isLogged = True
                Me.Name = u.Name
                aux = u.Rol
                Exit For
            End If
        Next
        Return aux
    End Function


    Sub New(usuario As System.Data.DataRow)
        Me.ID = usuario("id")
        Me.User = usuario("user")
        Me.Pass = usuario("pass")
        Me.Name = usuario("nombre")
        Me.LastName = usuario("apellido")
        Me.Contact = usuario("contacto")
        Me.Rol = usuario("rol")
        Me.Provincia = usuario("provincia")
    End Sub



End Class
