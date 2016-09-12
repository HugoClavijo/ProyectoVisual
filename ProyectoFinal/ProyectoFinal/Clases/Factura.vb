Public Class Factura

    Protected _secuencial As Integer
    Protected _cedulaRuc As Integer
    Protected _subtotal As Double
    Protected _total As Double
    Protected _iva As Double
    Protected _efectivo As Double
    Protected _cambio As Double
    Protected _formaDePago As String
    Protected _fecha As String
    Protected _descuento As Double
    Protected _vendedor As String

    Public Property Secuencial() As Integer
        Get
            Return _secuencial
        End Get
        Set(ByVal value As Integer)
            _secuencial = value
        End Set
    End Property

    Public Property Ruc() As Integer
        Get
            Return _cedulaRuc
        End Get
        Set(ByVal value As Integer)
            _cedulaRuc = value
        End Set
    End Property

    Public Property Subtotal() As Double
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Double)
            _subtotal = value
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return _total
        End Get
        Set(ByVal value As Double)
            _total = value
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


    Public Property Efectivo() As Double
        Get
            Return _efectivo
        End Get
        Set(ByVal value As Double)
            _efectivo = value
        End Set
    End Property

    Public Property Cambio() As Double
        Get
            Return _cambio
        End Get
        Set(ByVal value As Double)
            _cambio = value
        End Set
    End Property


    Public Property FormaDePago() As String
        Get
            Return _formaDePago
        End Get
        Set(ByVal value As String)
            _formaDePago = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property

    Public Property Descuento() As Double
        Get
            Return _descuento
        End Get
        Set(ByVal value As Double)
            _descuento = value
        End Set
    End Property

    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
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



    Public Sub New(id As Integer, cedRuc As String, subt As Double, tot As Double, imp As Double, pago As String, fech As String, desc As Double, user As String, pro As String, efec As Double, camb As Double)
        Me.Secuencial = id
        Me.Ruc = cedRuc
        Me.Subtotal = subt
        Me.Total = tot
        Me.Iva = imp
        Me.FormaDePago = pago
        Me.Fecha = fech
        Me.Descuento = desc
        Me.Vendedor = user
        Me.Provincia = pro
        Me.Efectivo = efec
        Me.Cambio = camb
    End Sub

End Class
