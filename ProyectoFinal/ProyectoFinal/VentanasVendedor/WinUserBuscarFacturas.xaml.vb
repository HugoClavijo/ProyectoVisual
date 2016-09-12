Imports System.Data
Imports System.Data.OleDb

Public Class WinUserBuscarFacturas

    Private dbPath As String = "..\..\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Dim dsFacturas As DataSet
    Dim dsUsuarios As DataSet
    Dim usuario As String
    Dim auxId As String

    Private Sub DataUserFacturas_Loaded(sender As Object, e As RoutedEventArgs) Handles DataUserFacturas.Loaded

        Using conexion As New OleDbConnection(strConexion)

            Dim consulta0 As String = "Select * FROM usuario;"
            Dim adapter0 As New OleDbDataAdapter(New OleDbCommand(consulta0, conexion))
            Me.dsUsuarios = New DataSet("Tienda")
            adapter0.Fill(dsUsuarios, "usuario")

            'For Each data1 As DataRow In dsUsuarios.Tables(0).Rows
            '    If data1("user") = usuario Then
            '        auxId = data1("user")
            '    End If
            'Next

            Dim consulta As String = "Select * FROM factura WHERE vendedor ='" & usuario & "';"
            'Dim consulta As String = "Select * FROM factura;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Me.dsFacturas = New DataSet("Tienda")
            adapter.Fill(dsFacturas, "factura")

            dataGrid.DataContext = dsFacturas

        End Using

    End Sub

    Private Sub DataWindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'Me.Hide()
        Dim admin As WinUser
        admin = Me.Owner
        admin.Show()
    End Sub

    Public Sub CargarUsuario(user As String)
        Me.usuario = user
    End Sub

    Private Sub dtgFacturas_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid.SelectionChanged
        Dim aux As String = ""
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim nuevaFactura As New Factura(fila(0), fila(2), fila(3), fila(4), fila(5), fila(6), fila(7), fila(8), fila(9), fila(10), fila(11), fila(12))
            Dim winFact As New WinUserViewFactura
            winFact.Owner = Me
            winFact.DataContext = nuevaFactura
            winFact.Show()
            Me.Hide()
        End If
    End Sub



End Class
