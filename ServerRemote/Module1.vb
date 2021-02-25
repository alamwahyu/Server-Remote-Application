'memasukkan library 
Imports System.Net.Sockets
Imports System.Text
'library system info HW dan SW 
Imports System.IO
Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Environment

Module Module1
    Dim userList As New Hashtable
    Dim txtIn As String 'inputan dari reserved word 
    'badan program yang menangani connection client server 
    'dan dapat memanggil sub class lain 
    Sub Main()
        Dim serverChatSocket As New TcpListener(8888)
        Dim clientChatSocket As TcpClient
        Dim counter As Integer

        'serverChatSocket.Start() 
        msg("Server Chat Started ..")
        counter = 0

        While (True)
            Try
                serverChatSocket.Start()
                counter += 1
                clientChatSocket = serverChatSocket.AcceptTcpClient()
                Dim bytes(10024) As Byte
                Dim chatFromClient As String
                Dim chatStream As NetworkStream = clientChatSocket.GetStream()
                chatStream.Read(bytes, 0, CInt(clientChatSocket.ReceiveBufferSize))
                chatFromClient = System.Text.Encoding.ASCII.GetString(bytes)
                chatFromClient = chatFromClient.Substring(0, chatFromClient.IndexOf("$"))
                userList(chatFromClient) = clientChatSocket
                broadcast(chatFromClient + " Bergabung ", chatFromClient, False)
                msg(chatFromClient) ' + " Joined Chat room") 

                'menyapa user yang login 
                msg("Hi Broo.. " + chatFromClient)

                Dim client As New handleClient
                client.startClient(clientChatSocket, chatFromClient, userList)
            Catch ex As Exception
                'exception 
            End Try
        End While

        serverChatSocket.Stop()
        msg("bye..")
        Console.ReadLine()
    End Sub
    'menampilkan nama user yang login 
    Sub msg(ByVal message As String)
        message.Trim()
        Console.WriteLine("^^" + message)
    End Sub
    'mengirim dan menampilkan chat client ke layar console 
    Private Sub broadcast(ByVal msg As String, ByVal username As String, ByVal flag As Boolean)
        Dim Item As DictionaryEntry
        For Each Item In userList
            Dim broadcastSocket As TcpClient
            broadcastSocket = CType(Item.Value, TcpClient)

            Try
                Dim chatStream As NetworkStream = broadcastSocket.GetStream()
                Dim broadcastBytes As [Byte]()
                If flag = True Then
                    broadcastBytes = Encoding.ASCII.GetBytes(username + " says : " + msg)
                Else
                    broadcastBytes = Encoding.ASCII.GetBytes(msg)
                End If
                chatStream.Write(broadcastBytes, 0, broadcastBytes.Length)
                chatStream.Flush()
            Catch ex As Exception
            End Try
        Next
    End Sub
    'code dan decode ke ASCII dari isi chat client 
    Public Class handleClient
        Dim clientSocket As TcpClient
        Dim clientNumber As String
        Dim userList As Hashtable

        Public Sub startClient(ByVal inClientSocket As TcpClient, ByVal clientNo As String, ByVal cList As Hashtable)
            clientSocket = inClientSocket
            clientNumber = clientNo
            userList = cList
            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf letsChat)
            ctThread.Start()
        End Sub

        'sub class yang menangani transfer info antara client server 
        Private Sub letsChat()
            Dim requestCount As Integer
            Dim bytesFrom(10024) As Byte
            Dim dataFromClient As String
            Dim iCount As String
            requestCount = 0

            While (True)
                Try
                    requestCount = requestCount + 1
                    Dim chatStream As NetworkStream = clientSocket.GetStream()
                    chatStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"))
                    msg("From client - " + clientNumber + " : " + dataFromClient)
                    iCount = Convert.ToString(requestCount)
                    txtIn = dataFromClient 'aliasing 

                    'reseverd word, yg akan menjalankan program / comand 
                    If txtIn = "Notepad" Then
                        Process.Start("Notepad.exe")
                    ElseIf txtIn = "Control Panel" Then
                        Process.Start("Control.exe")
                    ElseIf txtIn = "Software Spec" Then
                        'variable yg menyimpan spesifikasi OS 
                        Dim OSVer As String = My.Computer.Info.OSVersion.ToString
                        Dim OSPlatform As String = My.Computer.Info.OSPlatform.ToString
                        Dim OSName As String = My.Computer.Info.OSFullName.ToString

                        'isi spesifikasi komputer yg akan ditampilkan 
                        dataFromClient =
                            ControlChars.NewLine + "--- Software Infromation ---" +
                        ControlChars.NewLine + "OS Version: " + OSVer +
                        ControlChars.NewLine + "OS Platform: " + OSPlatform +
                        ControlChars.NewLine + "OS Name: " + OSName +
                        ControlChars.NewLine + "Username: " + System.Environment.UserName

                        'menampilkan Spesifikasi Komputer 
                        broadcast(dataFromClient, clientNumber, True)

                    ElseIf txtIn = "Hardware Spec" Then
                        'variable untuk info processor 
                        Dim m_LM, m_HW, m_Des, m_System, m_CPU, m_Info As RegistryKey
                        m_LM = Registry.LocalMachine
                        m_HW = m_LM.OpenSubKey("HARDWARE")
                        m_Des = m_HW.OpenSubKey("DESCRIPTION")
                        m_System = m_Des.OpenSubKey("SYSTEM")
                        m_CPU = m_System.OpenSubKey("CentralProcessor")
                        m_Info = m_CPU.OpenSubKey("0")

                        'variable RAM 
                        Dim ram As New RAM

                        'isi spesifikasi komputer yg akan ditampilkan 
                        dataFromClient =
                        ControlChars.NewLine + "--- Hardware Infromation ---" +
                        ControlChars.NewLine + "Vendor: " + m_Info.GetValue("VendorIdentifier") +
                        ControlChars.NewLine + "Prosesor: " + m_Info.GetValue("ProcessorNameString") +
                        ControlChars.NewLine + "Bit: " + m_Info.GetValue("Identifier") +
                        ControlChars.NewLine + "RAM: " + ram.GetMemory
                        broadcast(dataFromClient, clientNumber, True)

                    ElseIf txtIn = "Shutdown" Then
                        Shell("shutdown -s -t 600") 'menjalankan CMD dengan command shutdown 

                    ElseIf txtIn = "Restart" Then
                        Shell("shutdown -r -t 600") 'menjalankan CMD dengan command restart 
                        broadcast(dataFromClient, clientNumber, True)

                    ElseIf txtIn = "Abort" Then
                        Shell("shutdown -a") 'cancel shutdown / restart 

                    ElseIf txtIn = "test" Then
                        MsgBox("Coba2 ya? ^_^")
                    Else
                        broadcast(dataFromClient, clientNumber, True)
                    End If
                Catch ex As Exception
                    ' MsgBox(ex.ToString)
                End Try
            End While
        End Sub
    End Class
    'Class yang menyimpan perulangan untuk type2 RAM. 
    'dibagi2 kedalam beberapa kriteria berapa Bit RAM yg terinstall dan akan dibagi 1024 (1Mb) 
    Public Class RAM
        Public Function GetMemory() As String
            Dim RAMBitSize As String = CStr(My.Computer.Info.TotalPhysicalMemory)
            Select Case CDec(RAMBitSize)
                Case 0 To CDec(999.999)
                    RAMBitSize = Format(CInt(CDec(RAMBitSize)), "###,###,###,###,##0 bytes")
                Case 1000 To CDec(999999.999)
                    RAMBitSize = Format(CInt(CDec(RAMBitSize) / 1024), "###,###,###,##0 KB")
                Case 1000000 To CDec(999999999.999)
                    RAMBitSize = Format(CInt(CDec(RAMBitSize) / 1024 / 1024), "###,###,##0 MB")
                Case Is >= 1000000000
                    RAMBitSize = Format(CInt(CDec(RAMBitSize) / 1024 / 1024 / 1024), "#,###.00 GB")
            End Select
            Return RAMBitSize
        End Function
    End Class
End Module
