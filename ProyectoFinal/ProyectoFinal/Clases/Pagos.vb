Public Class Pagos
    Protected _id As Integer
    Protected _iva As Double
    Protected _tarjeta As Double
    Protected _Electronico As Double

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Iva() As Double
        Get
            Return _iva
        End Get
        Set(ByVal value As Double)
            _iva = value
        End Set
    End Property

    Public Property Tarjeta() As Double
        Get
            Return _tarjeta
        End Get
        Set(ByVal value As Double)
            _tarjeta = value
        End Set
    End Property


    Public Property Electro() As Double
        Get
            Return _Electronico
        End Get
        Set(ByVal value As Double)
            _Electronico = value
        End Set
    End Property


    Public Sub New(id As Integer, iva As Double, tarj As Double, elec As Double)
        Me._id = id
        Me.Iva = iva
        Me.Tarjeta = tarj
        Me.Electro = elec
    End Sub


End Class
