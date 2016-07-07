Public Class Empresa

    Private _ruc As Long
    Private _nombreComercial As String
    Private _razonsocial As String
    Private _direccionEmpresa As String
    Protected _provincia As String


    Public Sub New(ruc As Long, razonSocial As String, nombreEmpresa As String, direccion As String)
        Me._ruc = ruc
        Me._razonsocial = razonSocial
        Me._nombreComercial = nombreEmpresa
        Me._direccionEmpresa = direccion
    End Sub


    Public Sub New(ruc As Long, razonSocial As String, nombreEmpresa As String, direccion As String, provincia As String)
        Me._ruc = ruc
        Me._razonsocial = razonSocial
        Me._nombreComercial = nombreEmpresa
        Me._direccionEmpresa = direccion
        Me._provincia = provincia
    End Sub


    Public Property Provincia() As String
        Get
            Return _provincia
        End Get
        Set(ByVal value As String)
            _provincia = value
        End Set
    End Property


    Public Property Ruc() As Long
        Get
            Return _ruc
        End Get
        Set(ByVal value As Long)
            _ruc = value
        End Set
    End Property



    Public Property NombreComercial() As String
        Get
            Return _nombreComercial
        End Get
        Set(ByVal value As String)
            _nombreComercial = value
        End Set
    End Property



    Public Property Razonsocial() As String
        Get
            Return _razonsocial
        End Get
        Set(ByVal value As String)
            _razonsocial = value
        End Set
    End Property

    Public Property DireccionEmpresa() As String
        Get
            Return _direccionEmpresa
        End Get
        Set(ByVal value As String)
            _direccionEmpresa = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return "Empresa: " + Me.Razonsocial & vbTab &
         " Ruc :" + Me.Ruc
    End Function
End Class
