Public Class Factura
    Private _stab As String
    Private _ptoEmi As String
    Private _secuencial As String
    Private _empresa As Empresa
    Private _cliente As Cliente
    Private _subtotal As String
    Private _impuesto As Double
    Private _formaDePago As String
    'falta poner detalle de la factura

    Public Sub New(stab As String, PtoEmi As String, Secuencial As String, Empresa As Empresa, Cliente As Cliente)
        Me._stab = stab
        Me._ptoEmi = PtoEmi
        Me._secuencial = Secuencial
        Me._empresa = Empresa
        Me._cliente = Cliente

    End Sub








    Public Property Stab() As String
        Get
            Return _stab
        End Get
        Set(ByVal value As String)
            _stab = value
        End Set
    End Property

    Public Property PtoEmi() As String
        Get
            Return _ptoEmi
        End Get
        Set(ByVal value As String)
            _ptoEmi = value
        End Set
    End Property


    Public Property Secuencial() As String
        Get
            Return _secuencial
        End Get
        Set(ByVal value As String)
            _secuencial = value
        End Set
    End Property



    Public Property Empresa() As Empresa
        Get
            Return _empresa
        End Get
        Set(ByVal value As Empresa)
            _empresa = value
        End Set
    End Property




    Public Property Cliente As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property



    Public Property Subtotal() As String
        Get
            Return _subtotal
        End Get
        Set(ByVal value As String)
            _subtotal = value
        End Set
    End Property



    Public Property Impuesto() As Double
        Get
            Return _impuesto
        End Get
        Set(ByVal value As Double)
            _impuesto = value
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



    Public Sub mostrarFactura()
        Console.WriteLine("Factura: " & _stab & "-" & _ptoEmi & "-" & _secuencial)
        Console.WriteLine("Empresa: " & _empresa.Razonsocial)
        Console.WriteLine("Cliente: " & _cliente.Nombre & vbNewLine)


    End Sub






End Class
