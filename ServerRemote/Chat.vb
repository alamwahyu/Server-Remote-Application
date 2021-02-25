Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary
Public Class Chat
    Dim clientNetSocket As New System.Net.Sockets.TcpClient()
    Dim chatStream As NetworkStream
    'Dim userStream As NetworkStream 
    Dim readChat As String
    Dim chatCounter As Integer

    'akan mengirimkan pesan dari txtBox chat saat button Send di klik. 
    Private Sub btn_send_Click(sender As Object, e As EventArgs) Handles btn_send.Click
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(tb_pesangrup.Text + "$")
        chatStream.Write(outStream, 0, outStream.Length)
        chatStream.Flush()
        'mengosongkan textBox chat 
        tb_pesangrup.Text = ""
    End Sub
    'text box untuk input new chat 
    ' isi chat dari textboxchat akan dilempar ke richboxtextchat 

    Private Sub msg()
        ''AcceptButton = btn_send 'menerima inputkan keyboard 
        If InvokeRequired Then
            Invoke(New MethodInvoker(AddressOf msg))
        Else
            Dim userList As Byte() = System.Text.Encoding.ASCII.GetBytes(tb_pesangrup.Text)
            'rich text Box yg menampilkan pesan dari client 
            rb_isipesangrup.Text = rb_isipesangrup.Text + Environment.NewLine + " ^^ " + readChat
        End If
    End Sub

    'button untuk connect ke server 
    Private Sub btn_connect_Click(sender As Object, e As EventArgs) Handles btn_connect.Click

        'exception, jika server belum jalan 
        Try
            readChat = "Conected to Chat Server ..."
            'ip address & port number dari server chat 
            clientNetSocket.Connect("127.0.0.1", 8888)
            gb_chat.Text = "Chat Room - ONLINE..!"

            'button hanya aktif jika login berhasil 
            btn_color.Enabled = True
            btn_font.Enabled = True
            btn_send.Enabled = True
            ll_software.Enabled = True
            ll_hardware.Enabled = True
            ll_notepad.Enabled = True
            ll_cpanel.Enabled = True
            ll_shutdown.Enabled = True
            ll_restart.Enabled = True
            ll_abort.Enabled = True

            'setelah login sukses, form username akan disable 
            tb_connect.Enabled = False
            btn_connect.Enabled = False
            chatStream = clientNetSocket.GetStream()
            Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(tb_connect.Text + "$")
            rb_join.Text = tb_connect.Text
            chatStream.Write(outStream, 0, outStream.Length)
            chatStream.Flush()
            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMessage)
            ctThread.Start()
        Catch ex As Exception
            'jika serverConsole belum berjalan, maka muncul message : 
            MessageBox.Show("Silakan Hidupkan Server Dahulu .....!")
        End Try
    End Sub

    'perulangan untuk menangkap dan mengkonversi pesan yang dikirimkan 
    Private Sub getMessage()
        Try
            For chatCounter = 1 To 2
                chatCounter = 1
                chatStream = clientNetSocket.GetStream()

                Dim bufferSize As Integer
                Dim chatMasuk(10024) As Byte
                bufferSize = clientNetSocket.ReceiveBufferSize
                chatStream.Read(chatMasuk, 0, bufferSize)
                Dim returnData As String = System.Text.Encoding.ASCII.GetString(chatMasuk)
                readChat = "" + returnData
                msg()
            Next
        Catch ex As Exception
        End Try
    End Sub

    'counter untuk menjalankan ProgressBar 
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Show()
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 100 Then
            ProgressBar1.Hide()
            lbl_username.Visible = True
            tb_connect.Visible = True
            btn_connect.Visible = True
        End If
    End Sub
    'merubah warna background 
    Private Sub btnCustomize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_font.Click
        'perulangan untuk menampilkan FontDialog 
        'jika null akan menampilkan messageBox 
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbl_username.Font = FontDialog1.Font
            tb_pesangrup.Font = FontDialog1.Font
            lbl_customize.Font = FontDialog1.Font
            btn_send.Font = FontDialog1.Font
            gb_font.Font = FontDialog1.Font
            gb_background.Font = FontDialog1.Font
            gb_chat.Font = FontDialog1.Font
            rb_isipesangrup.Font = FontDialog1.Font
            gb_fitur.Font = FontDialog1.Font
        Else
            MessageBox.Show("Belum ada font yang dipilih")
        End If
    End Sub

    'button yg menampilkan color dialog untuk merubah background color dari form 
    'tidak memperbolehkan warna yang dipilih = hitam dan atau blank 
    Private Sub btnChangeColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_color.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ColorDialog1.Color = Color.Black Then
                MessageBox.Show("Ga boleh Item")
            Else
                BackColor = Me.ColorDialog1.Color
            End If
        Else
            MessageBox.Show("Pilih warna donk bro, biar seru")
        End If
    End Sub

    'saat aplikasi pertama kali dijalankan, akan menjalankan sub class From1_load berikut : 
    Private Sub RemoteComputer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'timer untuk men-trigger jalannya ProgressBar 
        Timer1.Start()

        'button inactive 
        btn_color.Enabled = False
        btn_font.Enabled = False
        btn_send.Enabled = False
        ll_software.Enabled = False
        ll_hardware.Enabled = False
        ll_notepad.Enabled = False
        ll_cpanel.Enabled = False
        ll_shutdown.Enabled = False
        ll_restart.Enabled = False
        ll_abort.Enabled = False

        'tombol "Enter" akan men-trigger login button 
        ''AcceptButton = btn_connect
    End Sub

    'hiperlink untuk menampilkan keyword khusus di textboxchat,untuk menampilkan informasi OS 
    Private Sub LinkLabelSoftware_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ll_software.LinkClicked
        tb_pesangrup.Text = "Software Spec"
    End Sub
    'hiperlink untuk menampilkan spec hardware, processor dan RAM 
    Private Sub LinkLabelHardware_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ll_hardware.LinkClicked
        tb_pesangrup.Text = "Hardware Spec"
    End Sub
    'hiperlink untuk menjalankan Control Panel 
    Private Sub LinkLabelCPanel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ll_cpanel.LinkClicked
        tb_pesangrup.Text = "Control Panel"
    End Sub
    'hiperlink untuk menjalankan aplikasi Notepad 
    Private Sub LinkLabelNotepad_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ll_notepad.LinkClicked
        tb_pesangrup.Text = "Notepad"
    End Sub
    'hiperlink untuk countdown shutdown dalam waktu 10 menit 
    Private Sub LinkLabelShutdown_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ll_shutdown.LinkClicked
        tb_pesangrup.Text = "Shutdown"
    End Sub
    'hiperlink untuk countdown restart dalam waktu 10 menit 
    Private Sub LinkLabelRestart_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ll_restart.LinkClicked
        tb_pesangrup.Text = "Restart"
    End Sub
    'hiperlink untuk cancel / abort shutdown atau restart 
    Private Sub LinkLabelAbort_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ll_abort.LinkClicked
        tb_pesangrup.Text = "Abort"
    End Sub

    'menggunakan tooxbox SaveFileDialogChat untuk memilih 
    'folder penyimpanan history chat ke file txt 
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_savechat.Click
        Try

            SaveFileDialogChat.Filter = "Text Files (*.txt)|*.txt"
            If SaveFileDialogChat.ShowDialog = Windows.Forms.DialogResult.OK Then
                rb_isipesangrup.SaveFile(SaveFileDialogChat.FileName, RichTextBoxStreamType.PlainText)
                MessageBox.Show("File berhasil tersimpan")
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
