Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Drawing
Imports System.IO

Public Class Server
    'Deklarasi variabel
    Dim handler As Socket
    Public th As Thread
    Public th1 As Thread
    Public Data As String
    Public fname As String
    Public ext As String
    Dim i As Integer
    Public msg As Byte()
    Dim apppath As String
    Dim cap As Integer
    Public f As Integer
    'deklaraasi variabel _crypto (digunakan untuk enkripsi file) 
    ' Public _crypto As CryptoLib.Crypto
    Public ipHostinfo As System.Net.IPHostEntry
    Public ipAdd As System.Net.IPAddress
    Public localEndPoint As System.Net.IPEndPoint
    Public listner As System.Net.Sockets.Socket
    Delegate Sub SetDisplay(ByVal [Text] As String)
    Public Sub Connect()
        Try
            ipHostinfo = Dns.Resolve(Dns.GetHostName())
            ipAdd = ipHostinfo.AddressList(0)
            'Port 11000 adalah port yang dibuka untuk melakukan koneksi 
            localEndPoint = New IPEndPoint(ipAdd, 11000)
            listner.Bind(localEndPoint)
            listner.Listen(10)
            th = New System.Threading.Thread(AddressOf Acceptstart)
            th.Start()
            i = 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Server_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If i = 1 Then
            th.Abort()
        End If
        If i = 2 Then
            th.Abort()
            th1.Abort()
        End If
        If handler IsNot Nothing Then
            handler.Shutdown(SocketShutdown.Both)
            handler.Close()
        End If
        Dim p1 As Process = Process.GetCurrentProcess()
        p1.Kill()
    End Sub

    Private Sub Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Pesan pada listbox ketika tidak ada koneksi ke server     
        List1.Items.Add("Menunggu Koneksi")
        Me.listner = New System.Net.Sockets.Socket(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
        apppath = System.Windows.Forms.Application.StartupPath.ToString()
        RText.Text = apppath
        f = 2
    End Sub

    Private Sub btn_koneksi_Click(sender As Object, e As EventArgs) Handles btn_koneksi.Click
        'Memanggil fungsi connect    
        Connect()
    End Sub
    Public Sub Acceptstart()
        'jika Koneksi berhasil dilakukan maka port dalam kondisi listening   
        handler = listner.Accept()
        th1 = New System.Threading.Thread(AddressOf Receive)
        th1.Start()
        i = 2
        'KOneksi dengan server berhasil   
        MessageBox.Show("Connected")
    End Sub
    Public Sub Proccessdata(ByVal str As String)
        If Me.List2.InvokeRequired Then
            Dim d As New SetDisplay(AddressOf Proccessdata)
            Me.Invoke(d, New Object() {str})
        Else
            Me.List2.Items.Add(str)
            If (cap = 0) Then
                btn_shutdown.Enabled = True
            End If
            If str = "ok" Then
                Me.btn_koneksi.Visible = True
                Label1.Visible = True
                List1.Visible = True
                Label4.Visible = False
                btn_logoff.Visible = False
                RText.Visible = False
                RText.Text = apppath
                Me.Size = New System.Drawing.Size(919, 489)
            End If
            If f = 0 Then
                btn_koneksi.Visible = True
                Label1.Visible = True
                List1.Visible = True
                Label4.Visible = False
                btn_logoff.Visible = False
                RText.Visible = False
                RText.Text = apppath
                Me.Size = New System.Drawing.Size(919, 489)
            End If
            If str.Length > 12 Then
                If str.Substring(0, 12).ToString() = "FileTransfer" Then
                    Dim i As Integer
                    Dim j As Integer
                    j = str.IndexOf(".") + 1
                    i = str.IndexOf(":") + 1
                    ext = str.Substring(j, str.Length - j)
                    fname = str.Substring(i, str.Length - i)

                    If (MessageBox.Show("Pilih Tempat Penyimpanan File-->" + fname + " Format", "File Received Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
                        Me.btn_koneksi.Visible = False
                        Label1.Visible = False
                        List1.Visible = False
                        Label4.Visible = True
                        btn_logoff.Visible = True
                        RText.Visible = True
                        RText.Text = RText.Text + "\" + fname
                        Me.Size = New System.Drawing.Size(410, 138)
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub Receive()
        Try
            Dim bytes(100000) As Byte
            Dim bytesRec As Integer
            bytes = New Byte(100000) {}
A:          While True
                bytesRec = handler.Receive(bytes)
            If bytesRec > 0 Then
                Data = Encoding.ASCII.GetString(bytes, 0, bytesRec)
                Exit While
            End If
            End While
            If cap = 1 Then
                cap = 0
                Try
                    Dim path As String
                    path = System.Windows.Forms.Application.StartupPath.ToString() + "\T1.Bmp"
                    Dim fli As New FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)
                    fli.Write(bytes, 0, bytesRec)
                    fli.Close()
                    Dim s As New FileStream(path, FileMode.Open, FileAccess.Read)
                    PictureBox1.Image = Image.FromStream(s)
                    s.Close()
                Catch ex As Exception
                    msg = Encoding.ASCII.GetBytes("stop")
                    cap = 0
                    handler.Send(msg)
                    GoTo C
                End Try
            End If
            If f = 1 Then
                Dim fl As New FileStream(RText.Text, FileMode.Create, FileAccess.Write)
                fl.Write(bytes, 0, bytesRec)
                fl.Close()
                Try
                    msg = Encoding.ASCII.GetBytes("Done")
                    handler.Send(msg)
                    f = 0

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
C:          Proccessdata(Data)
            'Proccessdata(bytesRec.ToString())   
            ActionData(Data)
            GoTo A
        Catch ex As Exception
            MessageBox.Show("Server Problem:" + ex.Message.ToString())
        End Try
    End Sub
    Public Sub ActionData(ByVal str As String)
        Select Case str
            'Pesan str pada listbox akan dieksekusi unutk open Notepad  
            Case "Notepad"
                Process.Start("Notepad.exe")
                'Pesan Mspaint pada listbox akan dieksekusi unutk open Paint 
            Case "Mspaint"
                Process.Start("Mspaint.exe")
                'Pesan calc pada listbox akan dieksekusi unutk open Apliaksi Kalkulator     
            Case "Calc"
                Process.Start("calc.exe")
        End Select
    End Sub

    'Private Sub btn_send_Click(sender As Object, e As EventArgs) Handles btn_send.Click
    'Try
    ' msg = Encoding.ASCII.GetBytes(Txtmsg.Text)
    '  handler.Send(msg)
    '   Txtmsg.Text = ""
    'Catch ex As Exception
    '      MessageBox.Show(ex.Message)
    ' End Try
    '    End Sub

    Private Sub btn_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send.Click
        If RText.Text = "" Then
            MessageBox.Show("Fill Receive Path")
        Else
            Dim i As Integer
            i = RText.Text.IndexOf(".") + 1
            If RText.Text.Substring(i, RText.Text.Length - i) <> ext Then
                MessageBox.Show("Invalid File Extension,Receive File in " + ext)
            Else
                Try
                    msg = Encoding.ASCII.GetBytes("Ack")
                    f = 1
                    handler.Send(msg)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub btn_capturing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_capturing.Click
        Try
            msg = Encoding.ASCII.GetBytes("ICapturing")
            handler.Send(msg)
            cap = 1
            btn_shutdown.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_logoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_logoff.Click
        Try
            'pesan yang diterima akan di terjemahkan dalam ASCII untuk Logoff        
            msg = Encoding.ASCII.GetBytes("LogOff")
            handler.Send(msg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_shutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_shutdown.Click
        Try
            'pesan yang diterima akan di terjemahkan dalam ASCII untuk Shutdown     
            msg = Encoding.ASCII.GetBytes("ShutDown")
            handler.Send(msg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_restart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restart.Click
        Try
            'pesan yang diterima akan di terjemahkan dalam ASCII untuk Restart           
            msg = Encoding.ASCII.GetBytes("Restart")
            handler.Send(msg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_mouselock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mouselock.Click
        Try
            'pesan yang diterima akan di terjemahkan dalam ASCII untuk Lock Mouse          
            msg = Encoding.ASCII.GetBytes("Mlock")
            handler.Send(msg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_mouserel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mouserel.Click
        Try
            'pesan yang diterima akan di terjemahkan dalam ASCII untuk Release Mouse   
            msg = Encoding.ASCII.GetBytes("MRel")
            handler.Send(msg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub btn_decrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_decrypt.Click
    'Deklarasi variabel filename dan ofd     
    'Dim fileName As String
    'Dim ofd As OpenFileDialog
    'Try
    'Mencari file yang akan di kirim dengan OpenFileDialog       
    '  ofd = New OpenFileDialog

    'With ofd
    '.Filter = "xxx Files (*.xxx)|*.xxx"
    '.Multiselect = False
    '.Title = "File to decrypt:"
    'If .ShowDialog = DialogResult.OK Then
    '           fileName = .FileName
    'Else
    'Return
    'End If
    'End With

    '     _crypto = New CryptoLib.Crypto
    '     _crypto.DecryptFile(fileName, fileName.Substring(0, fileName.Length - 4), "hitesh")
    'Catch ex As Exception
    '      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    'Finally
    'If Not ofd Is Nothing Then ofd.Dispose()
    'If Not _crypto Is Nothing Then _crypto.Dispose()
    'End Try
    ' End Sub
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Hide()
    End Sub
End Class