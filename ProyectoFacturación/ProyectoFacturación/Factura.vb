Imports ProyectoFacturación

Public Class Factura
    Private _stab As String
    Private _ptoEmi As String
    Private _secuencial As String

    Private _empresa As Empresa
    Private _cliente As Cliente
    Private _subtotal As Double
    Private _impuesto As Double
    Private _formaDePago As String
    Private _detalleArray As ArrayList
    Private _autSRI As String
    Private _fechaEmision As String



    Public Property FechaEmision() As String
        Get
            Return _fechaEmision
        End Get
        Set(ByVal value As String)
            _fechaEmision = value
        End Set
    End Property


    'falta poner detalle de la factura

    Public Sub New(stab As String, PtoEmi As String, Secuencial As String, autorizacionSri As String, Empresa As Empresa, Cliente As Cliente)
        Me._stab = stab
        Me._ptoEmi = PtoEmi
        Me._secuencial = Secuencial
        Me._autSRI = autorizacionSri
        Me._empresa = Empresa
        Me._cliente = Cliente
        _detalleArray = New ArrayList
        '_fechaEmision = DateTime.Now().ToShortDateString()
        _fechaEmision = Format(Now(), "Long Date")
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



    Public Property Subtotal() As Double
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Double)
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



    Public Property DetalleArray() As ArrayList
        Get
            Return _detalleArray
        End Get
        Set(ByVal value As ArrayList)
            _detalleArray = value
        End Set
    End Property

    Public Property AutSRI() As String
        Get
            Return _autSRI
        End Get
        Set(ByVal value As String)
            _autSRI = value
        End Set
    End Property

    Public Sub agregarProducto(producto As Producto)
        DetalleArray.Add(producto)
    End Sub

    Public Function detalleProd(NumProd As Integer)
        Dim lineaDetalle As String = ""
        For Each prod As Producto In DetalleArray
            If NumProd = DetalleArray(NumProd) Then


            End If


        Next



        Return lineaDetalle
    End Function


    Public Sub mostrarFactura()
        Console.WriteLine("Ruc: " & Empresa.Ruc)
        Console.WriteLine("" & Empresa.Razonsocial)
        Console.WriteLine("" & Empresa.NombreComercial)
        Console.WriteLine("" & Empresa.DireccionEmpresa & vbNewLine)
        Console.WriteLine("FACTURA" & vbTab)
        Console.WriteLine("No. " & _stab & "-" & _ptoEmi & "-" & _secuencial)
        Console.WriteLine("Clave de acceso/Autorzacion: " & AutSRI & vbNewLine)

        Console.WriteLine("Sr(es): " & Cliente.Nombre)
        Console.WriteLine("R.U.C./C.I: " & Cliente.Ruc_Cedula)
        Console.WriteLine("FECHA EMISION: " & FechaEmision)



        Console.WriteLine("CANTIDAD" & vbTab & " DESCRIPCION     " & vbTab & "P.UNITARIO" & vbTab & " P.TOTAL ")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "SUBTOTAL 14%:")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & " SUBTOTAL 0%:")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "   DESCUENTO:")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "     IVA 14%:")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & " VALOR TOTAL:")
        Console.WriteLine("Empresa: " & _empresa.Razonsocial)



        Console.WriteLine("Cliente: " & _cliente.Nombre & vbNewLine)


    End Sub






End Class
