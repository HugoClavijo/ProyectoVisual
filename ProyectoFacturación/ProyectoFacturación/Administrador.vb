Public Class Administrador
    Inherits Usuario

    Sub New(id As String, nombre As String, user As String, pass As String)

        MyBase.New("administrador", id, nombre, user, pass)
    End Sub

End Class
