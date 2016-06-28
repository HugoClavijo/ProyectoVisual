Public Class Detalle
    Private _cantidad As Integer
    Private _descripcion As String
    Private _precioUnitario As Double
    Private _precioTotal As Double




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





    Public Function ValorTotal(cantidadDeProductos As Integer, precioUnitario As Double)
        Dim valtotal As Double
        valtotal = cantidadDeProductos * precioUnitario
        Return valtotal
    End Function








End Class
