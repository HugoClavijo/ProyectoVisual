Public Class Vendedor
    Inherits Usuario

    Sub New(id As String, nombre As String, user As String, pass As String)

        MyBase.New("vendedor", id, nombre, user, pass)
    End Sub

End Class
