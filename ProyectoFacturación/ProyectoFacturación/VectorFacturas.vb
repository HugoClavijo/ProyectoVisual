Public Class VectorFacturas



    Private _ArrayFacturas As ArrayList

    Public Sub New()
        ArrayFacturas = New ArrayList()
    End Sub


    Public Property ArrayFacturas() As ArrayList
        Get
            Return _ArrayFacturas
        End Get
        Set(ByVal value As ArrayList)
            _ArrayFacturas = value
        End Set
    End Property


    Public Sub cargarFacturas()
        'Dim fact1 As New Factura() 
    End Sub










End Class
