Public Class MenuMaster
    Private Sub btn_desktop_Click(sender As Object, e As EventArgs) Handles btn_desktop.Click
        ''Me.Hide()
        RemoteDesktopServer.Show()
    End Sub

    Private Sub btn_mediaplayer_Click(sender As Object, e As EventArgs) Handles btn_mediaplayer.Click
        ''Me.Hide()
        MediaPlayerRemote.Show()
    End Sub

    Private Sub btn_pesan_Click(sender As Object, e As EventArgs) Handles btn_pesan.Click
        ''Me.Hide()
        PesanRemote.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 
        Server.Show()
    End Sub
End Class