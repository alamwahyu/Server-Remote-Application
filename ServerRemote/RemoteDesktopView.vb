
Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary
Public Class RemoteDesktopView

    Dim client As New TcpClient
    Dim port As Integer
    Dim server As TcpListener
    Dim ns As NetworkStream
    Dim listening As New Thread(AddressOf Listen)
    Dim GetImage As New Thread(AddressOf ReceiveImage)

    Private Sub ReceiveImage()
        Dim bf As New BinaryFormatter
        While client.Connected = True
            ns = client.GetStream
            PictureBox1.Image = bf.Deserialize(ns)
        End While
    End Sub

    Private Sub Listen()
        While client.Connected = False
            server.Start()
            client = server.AcceptTcpClient
        End While
        GetImage.Start()
    End Sub

    Private Sub RemoteDesktopView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        port = Integer.Parse(RemoteDesktopServer.tb_port.Text)
        server = New TcpListener(port)
        listening.Start()
    End Sub
End Class