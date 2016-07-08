Public Class VectorFacturas



    Private _ArrayFacturas As ArrayList

    Public Sub New()
        ArrayFacturas = New ArrayList()
        cargarFacturas()
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
        Dim c1 As New Cliente("Juan", "095885252001")


        Dim arraydetalle As New ArrayList()
        Dim detalle As New Detalle(2, "Counter Strike", 40.0, 80.0)
        arraydetalle.Add(detalle)

        Dim Empresa As New Empresa(1235846958001, "Proyecto Visual S.A.", "Proyecto", "Campus Espol, EDCOM - Guayaquil,Ecuador", "Guayas")


        Dim factura1 As New Factura(0.14, Empresa, 1000, c1, arraydetalle, 80.0, 11.2, 91.2, 91.2, 0, 0, 0, 0)
        ArrayFacturas.Add(factura1)



    End Sub










End Class
