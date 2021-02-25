Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System
Imports System.Drawing
Imports Microsoft.Win32
Imports System.Diagnostic


Public Class PesanRemote
    Dim ServerStatus As Boolean = False
    Dim ServerTrying As Boolean = False
    Dim Server As TcpListener
    Dim Clients As New List(Of TcpClient)
    Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))

    Private Delegate Sub updateLblStatus_dlgt(ByVal tempStr As String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        StartServer()
    End Sub

    Function StartServer()
        If ServerStatus = False Then
            ServerTrying = True
            Try
                thdUDPServer.Start()
                Server = New TcpListener(IPAddress.Any, 4305)
                Server.Start()
                ServerStatus = True
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
            Catch ex As Exception
                ServerStatus = False
            End Try
            ServerTrying = False
        End If
        Return True
    End Function

    Private Sub btn_Stop_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        StopServer()
    End Sub
    Function StopServer()
        If ServerStatus = True Then
            ServerTrying = True
            Try
                For Each Client As TcpClient In Clients
                    Client.Close()
                Next
                Server.Stop()
                ServerStatus = False
            Catch ex As Exception
                StopServer()
            End Try
            ServerTrying = False
        End If
        Return True
    End Function
    Function Handler_Client(ByVal state As Object)
        Dim TempClient As TcpClient

        Try
            Using Client As TcpClient = Server.AcceptTcpClient
                ''     Console.Beep()

                If ServerTrying = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If

                Clients.Add(Client)
                TempClient = Client

                Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                Try
                    If RX.BaseStream.CanRead = True Then
                        While RX.BaseStream.CanRead = True
                            Dim RawData As String = RX.ReadLine
                            If Client.Client.Connected = True AndAlso Client.Connected = True AndAlso Client.GetStream.CanRead = True Then
                                REM For some reason this seems to stop the comon tcp connection bug vvv
                                Dim RawDataLength As String = RawData.Length.ToString
                                REM ^^^^ Comment it out and test it in your own projects. Mine might be the only stupid one.
                                RichTextBox1.Text += Client.Client.RemoteEndPoint.ToString + ">> " + RawData + vbNewLine
                            Else Exit While
                            End If
                        End While
                    End If
                Catch ex As Exception
                    If Clients.Contains(Client) Then
                        Clients.Remove(Client)
                        Client.Close()
                    End If

                End Try


                ''   If RX.BaseStream.CanRead = False Then
                ''   Client.Close()
                ''   Clients.Remove(Client)
                ''   End If
                ''   Console.Beep()
            End Using
            If Clients.Contains(TempClient) Then
                Clients.Remove(TempClient)
                TempClient.Close()
            End If
        Catch ex As Exception
            If Clients.Contains(TempClient) Then
                Clients.Remove(TempClient)
                TempClient.Close()
            End If
        End Try

        Return True
    End Function

    Private Sub btn_sent_Click(sender As Object, e As EventArgs) Handles btn_sent.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, TextBox1.Text)
        RichTextBox1.Text += "Server>> " + TextBox1.Text + vbNewLine
        TextBox1.Text = ""
    End Sub
    Function SendToClients(ByVal Data As String)
        If ServerStatus = True Then
            If Clients.Count > 0 Then
                Try
                    REM  Broadcast data to all clients
                    REM To target one client,
                    REM USAGE: If client.client.remoteendpoint.tostring.contains(IP As String) Then
                    REM I am sorry for the lack of preparation for this project and in the video.
                    REM I wrote 99% of this from the top of my head,  no one is perfect, bound to make mistakes.
                    For Each Client As TcpClient In Clients
                        Dim TX1 As New StreamWriter(Client.GetStream)
                        ''   Dim RX1 As New StreamReader(Client.GetStream)
                        TX1.WriteLine(Data)
                        TX1.Flush()
                    Next
                Catch ex As Exception
                    SendToClients(Data)
                End Try
            End If
        End If
        Return True
    End Function
    REM   Timer1 enabled = true
    REM Just if you want to always have a count of connected clients.
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Clients.Count.ToString
    End Sub

    '=====================================================UDP SERVER==============================================================
    Public Sub serverThread()
        Dim udpClient100 As New UdpClient(8080)
        Dim a, banding, c As String
        Dim bnds As Rectangle = My.Computer.Screen.Bounds
        Dim m_LM As RegistryKey
        Dim m_HW As RegistryKey
        Dim m_Des As RegistryKey
        Dim m_System As RegistryKey
        Dim m_CPU As RegistryKey
        Dim m_Info As RegistryKey
        m_LM = Registry.LocalMachine
        m_HW = m_LM.OpenSubKey("HARDWARE")
        m_Des = m_HW.OpenSubKey("DESCRIPTION")
        m_System = m_Des.OpenSubKey("SYSTEM")
        m_CPU = m_System.OpenSubKey("CentralProcessor")
        m_Info = m_CPU.OpenSubKey("0")

        Dim OSVer As String = My.Computer.Info.OSVersion.ToString
        Dim OSPlatform As String = My.Computer.Info.OSPlatform.ToString
        Dim OSName As String = My.Computer.Info.OSFullName.ToString

        While True
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
            Dim receiveBytes As Byte()
            receiveBytes = udpClient100.Receive(RemoteIpEndPoint)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
            a = RemoteIpEndPoint.Address.ToString() + "=" + returnData.ToString
            banding = returnData.ToString
            UpdateLblStatusThreadSafe(a)

            If (banding = "User") Then
                c = System.Environment.UserName
                UpdateLblStatusThreadSafe(c)
            End If

            If (banding = "Memori") Then
                c = GC.GetTotalMemory(True)
                UpdateLblStatusThreadSafe(c)
            End If

            If (banding = "Resolusi Layar") Then
                c = "Resolusi Layar: " & bnds.Width & " by " & bnds.Height
                UpdateLblStatusThreadSafe(c)
            End If
            If (banding = "Software") Then
                c = "--- Software Infromation ---"
                UpdateLblStatusThreadSafe(c)
                c = "OS Version: " + OSVer
                UpdateLblStatusThreadSafe(c)
                c = "OS Platform: " + OSPlatform
                UpdateLblStatusThreadSafe(c)
                c = "OS Name: " + OSName
                UpdateLblStatusThreadSafe(c)
            End If
            Dim ram As New RAM
            If (banding = "Hardware") Then
                c = "--- Hardware Infromation ---"
                UpdateLblStatusThreadSafe(c)
                c = "Prosesor =" + m_Info.GetValue("VendorIdentifier")
                UpdateLblStatusThreadSafe(c)
                c = "Prosesor Name =" + m_Info.GetValue("ProcessorNameString")
                UpdateLblStatusThreadSafe(c)
                c = "Identifier    = " + m_Info.GetValue("Identifier")
                UpdateLblStatusThreadSafe(c)
                c = m_Info.GetValue("~Mhz") & "MHz"
                UpdateLblStatusThreadSafe(c)
                'c = "RAM: " + ram.GetMemory
                'UpdateLblStatusThreadSafe(c)
            End If
            If (banding = "Shutdown") Then
                c = Shell("shutdown -s -t 600")
                UpdateLblStatusThreadSafe(c)
            End If
            If (banding = "Abort") Then
                c = Shell("shutdown -a")
                UpdateLblStatusThreadSafe(c)
            End If
            If (banding = "Restart") Then
                c = Shell("shutdown -r -t 600")
                UpdateLblStatusThreadSafe(c)
            End If
            If (banding = "Notepad") Then
                Process.Start("Notepad.exe")
                ''UpdateLblStatusThreadSafe(c)
            End If
            If (banding = "CMD") Then
                System.Diagnostics.Process.Start("cmd")
                ''UpdateLblStatusThreadSafe(c)
            End If
        End While
    End Sub
    Private Sub UpdateLblStatusThreadSafe(ByVal tempStr As String)

        Dim updateLblStatus_obj As updateLblStatus_dlgt
        If RichTextBox1.InvokeRequired Then

            updateLblStatus_obj = New updateLblStatus_dlgt(AddressOf UpdateLblStatusThreadSafe)
            If Not updateLblStatus_obj Is Nothing Then
                RichTextBox1.Invoke(updateLblStatus_obj, tempStr)
            End If
        Else
            Call UpdateLblStatus(tempStr)
        End If
    End Sub
    Private Sub UpdateLblStatus(ByVal tempStr As String)

        RichTextBox1.Text += tempStr + vbNewLine
    End Sub
End Class
