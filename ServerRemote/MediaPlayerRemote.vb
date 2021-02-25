
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text 'Buat Encoding' 
Imports System
Imports System.IO
Imports AxWMPLib
Imports WMPLib
Public Class MediaPlayerRemote
    Private Delegate Sub updateLBlStatus_dlgt(ByVal tempStr As String)

    Private Sub MediaPlayerRemote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))
        thdUDPServer.Start()
    End Sub
    Public Sub serverThread()
        Dim udpClient100 As New UdpClient(8080)
        Dim a, banding, c, status As String
        Dim bnds As Rectangle = My.Computer.Screen.Bounds
        Me.AxWindowsMediaPlayer1.enableContextMenu = False

        While True
            Me.AxWindowsMediaPlayer1.enableContextMenu = False
            Dim remoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
            Dim receiveBytes As Byte()
            Dim item_obj As updateLBlStatus_dlgt
            receiveBytes = udpClient100.Receive(remoteIpEndPoint)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
            a = remoteIpEndPoint.Address.ToString() + "Pesan: " + returnData.ToString
            'Mendapatkan Flag shuffle atau tidak             
            banding = (returnData.ToString).ToLower
            'status = status apakah musik dijalankan shuffle atau tidak             
            status = banding.Substring(4)
            'menjalankan command yang harus dilakukan             
            banding = banding.Substring(0, 4)
            If (banding = "play") Then
                Using sr As New StreamReader("E:\PlayList.txt")
                    Dim item As String = sr.ReadLine
                    While item <> Nothing
                        If ListBox1.InvokeRequired Then
                            item_obj = New updateLBlStatus_dlgt(AddressOf UpdateLblStatusThreadSafe)

                            If Not item_obj Is Nothing Then
                                ListBox1.Invoke(item_obj, item)
                            End If
                        End If
                        item = sr.ReadLine
                    End While

                    'menjalankan shuffle                      
                    If (status = 1) Then
                        AxWindowsMediaPlayer1.settings.setMode("shuffle", True)
                    End If
                End Using

                ' Buat Playlist                  
                Dim Playlist As IWMPPlaylist = AxWindowsMediaPlayer1.playlistCollection.newPlaylist("thePlaylist")
                For Each FilePath As String In ListBox1.Items
                    Dim VideoFile As WMPLib.IWMPMedia3 = AxWindowsMediaPlayer1.newMedia(FilePath)
                    Playlist.appendItem(VideoFile)
                Next

                AxWindowsMediaPlayer1.currentPlaylist = Playlist

                'c = "Play Music"                 
                'UpdateLblStatusThreadSafe(c)             
            End If

            If (banding = "stop") Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
                c = "Stop Music"
                'UpdateLblStatusThreadSafe(c)             
            End If

            If (banding = "next") Then
                AxWindowsMediaPlayer1.Ctlcontrols.next()
                c = "Next Music"
                'UpdateLblStatusThreadSafe(c)             
            End If

            If (banding = "prev") Then
                AxWindowsMediaPlayer1.Ctlcontrols.previous()
                c = "Previous Music"
                'UpdateLblStatusThreadSafe(c)             
            End If
            If (banding = "volume up") Then
                If AxWindowsMediaPlayer1.settings.volume < 100 Then
                    AxWindowsMediaPlayer1.settings.volume += 1
                End If
            End If

            If (banding = "volume down") Then
                If AxWindowsMediaPlayer1.settings.volume > 0 Then
                    AxWindowsMediaPlayer1.settings.volume -= 1
                End If
            End If

            If (banding = "mute") Then
                AxWindowsMediaPlayer1.settings.mute = Not AxWindowsMediaPlayer1.settings.mute
            End If
        End While
    End Sub

    Private Sub UpdateLblStatusThreadSafe(ByVal tempStr As String)
        Dim updateLBlStatus_obj As updateLBlStatus_dlgt

        If ListBox1.InvokeRequired Then
            updateLBlStatus_obj = New updateLBlStatus_dlgt(AddressOf UpdateLblStatusThreadSafe)
            If Not updateLBlStatus_obj Is Nothing Then
                ListBox1.Invoke(updateLBlStatus_obj, tempStr)
            End If
        Else
            Call UpdateLblStatus(tempStr)
        End If

    End Sub

    Private Sub UpdateLblStatus(ByVal tempStr As String)
        ListBox1.Items.Add(tempStr)
    End Sub

    Private Sub AxWindowsMediaPlayer1_CurrentItemChange(ByVal sender As System.Object, ByVal e As AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent) Handles AxWindowsMediaPlayer1.CurrentItemChange
        For i As Integer = 0 To ListBox1.Items.Count - 1
            ListBox1.SelectedIndex = i
        Next
    End Sub

    Private Sub player_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsMediaEnded Or
                Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            Me.AxWindowsMediaPlayer1.currentMedia = Nothing
        End If
    End Sub
    'Minimize Window dan menjadikan icon tran     
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
        nfi.Visible = True
    End Sub
    'Jika Icon tray diklik akan kembali ke mode normal     
    Private Sub nfi_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nfi.MouseDoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        nfi.Visible = False
    End Sub
End Class