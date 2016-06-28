Public Class Detalle
    Private _cantidad As Integer
    Private _descripcion As String
    Private _precioUnitario As Double
    Private _precioTotal As Double
    Private _producto As Producto


    Public Sub New(cantidad As Integer, descripcion As String, precioUnit As Double, precioTotal As Double)
        Me._cantidad = cantidad
        Me._descripcion = descripcion
        Me._precioUnitario = precioUnit
        Me._precioTotal = precioTotal
    End Sub


    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property



    Public Property PrecioUnitario As Double
        Get
            Return _precioUnitario
        End Get
        Set(value As Double)
            _precioUnitario = value
        End Set
    End Property


    Public ReadOnly Property PrecioTotal As Double
        Get
            Return _precioTotal
        End Get

    End Property


    Public Property Producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property




    Public Function CalcularValorTotal(cantidadDeProductos As Integer, precioUnitario As Double)
        Dim valtotal As Double
        valtotal = cantidadDeProductos * precioUnitario
        Return valtotal
    End Function


    Public Overrides Function ToString() As String
        Return "   " & Cantidad & vbTab & "          " & Descripcion & "  " & vbTab &
            "           " & PrecioUnitario & "       " & vbTab & PrecioTotal
    End Function





End Class
