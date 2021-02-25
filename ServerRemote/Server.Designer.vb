<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Server
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RText = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_send = New System.Windows.Forms.Button()
        Me.List2 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_koneksi = New System.Windows.Forms.Button()
        Me.List1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_decrypt = New System.Windows.Forms.Button()
        Me.btn_mouselock = New System.Windows.Forms.Button()
        Me.btn_mouserel = New System.Windows.Forms.Button()
        Me.btn_restart = New System.Windows.Forms.Button()
        Me.btn_shutdown = New System.Windows.Forms.Button()
        Me.btn_logoff = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_capturing = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 291)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RText)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btn_send)
        Me.Panel2.Controls.Add(Me.List2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(23, 134)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(422, 134)
        Me.Panel2.TabIndex = 3
        '
        'RText
        '
        Me.RText.Location = New System.Drawing.Point(139, 91)
        Me.RText.Name = "RText"
        Me.RText.Size = New System.Drawing.Size(175, 30)
        Me.RText.TabIndex = 11
        Me.RText.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        '
        'btn_send
        '
        Me.btn_send.Location = New System.Drawing.Point(328, 91)
        Me.btn_send.Name = "btn_send"
        Me.btn_send.Size = New System.Drawing.Size(75, 23)
        Me.btn_send.TabIndex = 2
        Me.btn_send.Text = "Send"
        Me.btn_send.UseVisualStyleBackColor = True
        '
        'List2
        '
        Me.List2.FormattingEnabled = True
        Me.List2.Location = New System.Drawing.Point(139, 16)
        Me.List2.Name = "List2"
        Me.List2.Size = New System.Drawing.Size(264, 69)
        Me.List2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Label2"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_koneksi)
        Me.Panel1.Controls.Add(Me.List1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(23, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 100)
        Me.Panel1.TabIndex = 1
        '
        'btn_koneksi
        '
        Me.btn_koneksi.Location = New System.Drawing.Point(24, 62)
        Me.btn_koneksi.Name = "btn_koneksi"
        Me.btn_koneksi.Size = New System.Drawing.Size(75, 23)
        Me.btn_koneksi.TabIndex = 2
        Me.btn_koneksi.Text = "Connect"
        Me.btn_koneksi.UseVisualStyleBackColor = True
        '
        'List1
        '
        Me.List1.FormattingEnabled = True
        Me.List1.Location = New System.Drawing.Point(139, 16)
        Me.List1.Name = "List1"
        Me.List1.Size = New System.Drawing.Size(264, 69)
        Me.List1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btn_decrypt)
        Me.Panel3.Controls.Add(Me.btn_mouselock)
        Me.Panel3.Controls.Add(Me.btn_mouserel)
        Me.Panel3.Controls.Add(Me.btn_restart)
        Me.Panel3.Controls.Add(Me.btn_shutdown)
        Me.Panel3.Controls.Add(Me.btn_logoff)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(35, 375)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(422, 125)
        Me.Panel3.TabIndex = 1
        '
        'btn_decrypt
        '
        Me.btn_decrypt.Location = New System.Drawing.Point(254, 84)
        Me.btn_decrypt.Name = "btn_decrypt"
        Me.btn_decrypt.Size = New System.Drawing.Size(75, 23)
        Me.btn_decrypt.TabIndex = 9
        Me.btn_decrypt.Text = "Decrypt File"
        Me.btn_decrypt.UseVisualStyleBackColor = True
        '
        'btn_mouselock
        '
        Me.btn_mouselock.Location = New System.Drawing.Point(173, 84)
        Me.btn_mouselock.Name = "btn_mouselock"
        Me.btn_mouselock.Size = New System.Drawing.Size(75, 23)
        Me.btn_mouselock.TabIndex = 8
        Me.btn_mouselock.Text = "Mouse Lock"
        Me.btn_mouselock.UseVisualStyleBackColor = True
        '
        'btn_mouserel
        '
        Me.btn_mouserel.Location = New System.Drawing.Point(56, 84)
        Me.btn_mouserel.Name = "btn_mouserel"
        Me.btn_mouserel.Size = New System.Drawing.Size(111, 23)
        Me.btn_mouserel.TabIndex = 7
        Me.btn_mouserel.Text = "Mouse Release"
        Me.btn_mouserel.UseVisualStyleBackColor = True
        '
        'btn_restart
        '
        Me.btn_restart.Location = New System.Drawing.Point(254, 55)
        Me.btn_restart.Name = "btn_restart"
        Me.btn_restart.Size = New System.Drawing.Size(75, 23)
        Me.btn_restart.TabIndex = 6
        Me.btn_restart.Text = "Restart"
        Me.btn_restart.UseVisualStyleBackColor = True
        '
        'btn_shutdown
        '
        Me.btn_shutdown.Location = New System.Drawing.Point(173, 55)
        Me.btn_shutdown.Name = "btn_shutdown"
        Me.btn_shutdown.Size = New System.Drawing.Size(75, 23)
        Me.btn_shutdown.TabIndex = 5
        Me.btn_shutdown.Text = "Shutdown"
        Me.btn_shutdown.UseVisualStyleBackColor = True
        '
        'btn_logoff
        '
        Me.btn_logoff.Location = New System.Drawing.Point(92, 55)
        Me.btn_logoff.Name = "btn_logoff"
        Me.btn_logoff.Size = New System.Drawing.Size(75, 23)
        Me.btn_logoff.TabIndex = 3
        Me.btn_logoff.Text = "LogOff"
        Me.btn_logoff.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Label4"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Location = New System.Drawing.Point(485, 78)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(572, 376)
        Me.Panel4.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(566, 370)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btn_capturing
        '
        Me.btn_capturing.Location = New System.Drawing.Point(755, 477)
        Me.btn_capturing.Name = "btn_capturing"
        Me.btn_capturing.Size = New System.Drawing.Size(75, 23)
        Me.btn_capturing.TabIndex = 10
        Me.btn_capturing.Text = "Capturing"
        Me.btn_capturing.UseVisualStyleBackColor = True
        '
        'btn_exit
        '
        Me.btn_exit.Location = New System.Drawing.Point(485, 477)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 23)
        Me.btn_exit.TabIndex = 11
        Me.btn_exit.Text = "EXIT"
        Me.btn_exit.UseVisualStyleBackColor = True
        '
        'Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 512)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_capturing)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Server"
        Me.Text = "Server"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_send As Button
    Friend WithEvents List2 As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_koneksi As Button
    Friend WithEvents List1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn_decrypt As Button
    Friend WithEvents btn_mouselock As Button
    Friend WithEvents btn_mouserel As Button
    Friend WithEvents btn_restart As Button
    Friend WithEvents btn_shutdown As Button
    Friend WithEvents btn_logoff As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_capturing As Button
    Friend WithEvents RText As RichTextBox
    Friend WithEvents btn_exit As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
