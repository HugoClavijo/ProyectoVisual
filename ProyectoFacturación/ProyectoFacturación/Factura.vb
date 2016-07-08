Imports ProyectoFacturación

Public Class Factura
    Private _stab As String = "001"
    Private _ptoEmi As String = "001"
    Private _secuencial As Long = 1

    Private _empresa As Empresa
    Private _cliente As Cliente
    Private _subtotal As Double
    Private _totalFactura As Double
    Private _efectivo As Double
    Private _tarjetaCredito As Double

    Private _dineroElectronico As Double



    Private _cambio As Double

    Private _ivaIngresado As Double


    Private _impuesto As Double
    Private _formaDePago As String
    Private _detalleArray As ArrayList
    Private _autSRI As String = "1234567890123456789012345678901234567890123456789"
    Private _fechaEmision As String

    Private _ahorroFactura As Double



    'falta poner detalle de la factura

    Public Sub New(ivaUsado As Double, empresa As Empresa, numSecuencial As Long, Cliente As Cliente, arraydetalles As ArrayList, subtotal As Double, iva As Double, totalFactura As Double,
                   efectivo As Double, tarjeta As Double, dineroElectronico As Double, cambio As Double, ahorro As Double)
        informacionEmpresa()

        Me._empresa = empresa
        Me._ivaIngresado = ivaUsado
        Me._secuencial = numSecuencial
        Me._cliente = Cliente
        _detalleArray = New ArrayList
        _detalleArray = arraydetalles
        Me._subtotal = subtotal
        Me._impuesto = iva
        Me._totalFactura = totalFactura
        Me._efectivo = efectivo
        Me._tarjetaCredito = tarjeta
        Me._dineroElectronico = dineroElectronico
        Me._cambio = cambio
        Me._ahorroFactura = ahorro

        '_fechaEmision = DateTime.Now().ToShortDateString()
        _fechaEmision = Format(Now(), "Long Date")
    End Sub

    Public Sub New(numSecuencial As Long, Cliente As Cliente, arraydetalles As ArrayList, subtotal As Double, iva As Double, totalFactura As Double,
                   efectivo As Double, tarjeta As Double, dineroElectronico As Double, cambio As Double, ahorro As Double)
        informacionEmpresa()

        Me._empresa = Empresa
        'Me._ivaIngresado = ivaUsado
        Me._secuencial = numSecuencial
        Me._cliente = Cliente
        _detalleArray = New ArrayList
        _detalleArray = arraydetalles
        Me._subtotal = subtotal
        Me._impuesto = iva
        Me._totalFactura = totalFactura
        Me._efectivo = efectivo
        Me._tarjetaCredito = tarjeta
        Me._dineroElectronico = dineroElectronico
        Me._cambio = cambio
        Me._ahorroFactura = ahorro

        '_fechaEmision = DateTime.Now().ToShortDateString()
        _fechaEmision = Format(Now(), "Long Date")
    End Sub




    Public Property IvaIngresado() As Double
        Get
            Return _ivaIngresado
        End Get
        Set(ByVal value As Double)
            _ivaIngresado = value
        End Set
    End Property

    Public Property AhorroFactura() As Double
        Get
            Return _ahorroFactura
        End Get
        Set(ByVal value As Double)
            _ahorroFactura = value
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


    Public Property Efectivo() As Double
        Get
            Return _efectivo
        End Get
        Set(ByVal value As Double)
            _efectivo = value
        End Set
    End Property
    Public Property TarjetaCredito() As Double
        Get
            Return _tarjetaCredito
        End Get
        Set(ByVal value As Double)
            _tarjetaCredito = value
        End Set
    End Property





    Public Property DineroElectronico() As Double
        Get
            Return _dineroElectronico
        End Get
        Set(ByVal value As Double)
            _dineroElectronico = value
        End Set
    End Property


    Public Property TotalFactura() As Double
        Get
            Return _totalFactura
        End Get
        Set(ByVal value As Double)
            _totalFactura = value
        End Set
    End Property


    Public Property FechaEmision() As String
        Get
            Return _fechaEmision
        End Get
        Set(ByVal value As String)
            _fechaEmision = value
        End Set
    End Property




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


    Public Property Secuencial() As Long
        Get
            Return _secuencial
        End Get
        Set(ByVal value As Long)
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



    Public Function detalleProd(NumProd As Integer)
        Dim lineaDetalle As String = ""
        For Each prod As Producto In DetalleArray
            If NumProd = DetalleArray(NumProd) Then


            End If


        Next



        Return lineaDetalle
    End Function


    Public Sub mostrarFactura()
        Console.WriteLine("")
        Console.WriteLine("-------------------------------------------------------------------------------------")
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

        Console.WriteLine("")

        Console.WriteLine("CANTIDAD       PRODUCTO      ValorUnit     ValorTotal      ")

        For Each d As Detalle In DetalleArray
            Console.WriteLine("  " & d.Cantidad & vbTab & "        " & d.Descripcion & vbTab & "        " & d.PrecioUnitario & "      " & vbTab & d.PrecioTotal & "")
        Next





        Console.WriteLine("")

        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "-----------------------")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "SUBTOTAL " & IvaIngresado & "%: $" & _subtotal)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & " SUBTOTAL 0%: $0.00")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "   DESCUENTO: $0.00")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "         IVA: $" & _impuesto)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & " VALOR TOTAL: $" & _totalFactura)

        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "    EFECTIVO: $" & _efectivo)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "    TCREDITO: $" & _tarjetaCredito)
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "  D.ELECTRON: $" & _dineroElectronico)
        Console.WriteLine("")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & "      CAMBIO: $" & _cambio)
        Console.WriteLine("")
        Console.WriteLine(vbTab & vbTab & vbTab & vbTab & " V. DEVUELTO: $" & _ahorroFactura)
        Console.WriteLine("-------------------------------------------------------------------------------------")


    End Sub




    Public Sub informacionEmpresa() 'informacion de la empresa por default
        Empresa = New Empresa(1235846958001, "Proyecto Visual S.A.", "Proyecto", "Campus Espol, EDCOM - Guayaquil,Ecuador", "Guayas")
    End Sub



End Class
