<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chat
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_send = New System.Windows.Forms.Button()
        Me.tb_pesangrup = New System.Windows.Forms.TextBox()
        Me.btn_savechat = New System.Windows.Forms.Button()
        Me.rb_join = New System.Windows.Forms.RichTextBox()
        Me.gb_fitur = New System.Windows.Forms.GroupBox()
        Me.ll_abort = New System.Windows.Forms.LinkLabel()
        Me.ll_restart = New System.Windows.Forms.LinkLabel()
        Me.ll_shutdown = New System.Windows.Forms.LinkLabel()
        Me.ll_cpanel = New System.Windows.Forms.LinkLabel()
        Me.ll_notepad = New System.Windows.Forms.LinkLabel()
        Me.ll_hardware = New System.Windows.Forms.LinkLabel()
        Me.ll_software = New System.Windows.Forms.LinkLabel()
        Me.gb_chat = New System.Windows.Forms.GroupBox()
        Me.rb_isipesangrup = New System.Windows.Forms.RichTextBox()
        Me.gb_background = New System.Windows.Forms.GroupBox()
        Me.btn_color = New System.Windows.Forms.Button()
        Me.lbl_customize = New System.Windows.Forms.Label()
        Me.btn_connect = New System.Windows.Forms.Button()
        Me.tb_connect = New System.Windows.Forms.TextBox()
        Me.lbl_username = New System.Windows.Forms.Label()
        Me.gb_font = New System.Windows.Forms.GroupBox()
        Me.btn_font = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveFileDialogChat = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox4.SuspendLayout()
        Me.gb_fitur.SuspendLayout()
        Me.gb_chat.SuspendLayout()
        Me.gb_background.SuspendLayout()
        Me.gb_font.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.btn_send)
        Me.GroupBox4.Controls.Add(Me.tb_pesangrup)
        Me.GroupBox4.Controls.Add(Me.btn_savechat)
        Me.GroupBox4.Controls.Add(Me.rb_join)
        Me.GroupBox4.Controls.Add(Me.gb_fitur)
        Me.GroupBox4.Controls.Add(Me.gb_chat)
        Me.GroupBox4.Controls.Add(Me.gb_background)
        Me.GroupBox4.Controls.Add(Me.lbl_customize)
        Me.GroupBox4.Controls.Add(Me.btn_connect)
        Me.GroupBox4.Controls.Add(Me.tb_connect)
        Me.GroupBox4.Controls.Add(Me.lbl_username)
        Me.GroupBox4.Controls.Add(Me.gb_font)
        Me.GroupBox4.Controls.Add(Me.ProgressBar1)
        Me.GroupBox4.Location = New System.Drawing.Point(38, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(918, 371)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Group Chat Remote"
        '
        'btn_send
        '
        Me.btn_send.Location = New System.Drawing.Point(618, 286)
        Me.btn_send.Name = "btn_send"
        Me.btn_send.Size = New System.Drawing.Size(95, 37)
        Me.btn_send.TabIndex = 21
        Me.btn_send.Text = "SEND"
        Me.btn_send.UseVisualStyleBackColor = True
        '
        'tb_pesangrup
        '
        Me.tb_pesangrup.Location = New System.Drawing.Point(323, 291)
        Me.tb_pesangrup.Name = "tb_pesangrup"
        Me.tb_pesangrup.Size = New System.Drawing.Size(278, 20)
        Me.tb_pesangrup.TabIndex = 20
        '
        'btn_savechat
        '
        Me.btn_savechat.Location = New System.Drawing.Point(748, 280)
        Me.btn_savechat.Name = "btn_savechat"
        Me.btn_savechat.Size = New System.Drawing.Size(117, 44)
        Me.btn_savechat.TabIndex = 19
        Me.btn_savechat.Text = "Save Chat"
        Me.btn_savechat.UseVisualStyleBackColor = True
        '
        'rb_join
        '
        Me.rb_join.Location = New System.Drawing.Point(719, 113)
        Me.rb_join.Name = "rb_join"
        Me.rb_join.Size = New System.Drawing.Size(170, 143)
        Me.rb_join.TabIndex = 14
        Me.rb_join.Text = ""
        '
        'gb_fitur
        '
        Me.gb_fitur.Controls.Add(Me.ll_abort)
        Me.gb_fitur.Controls.Add(Me.ll_restart)
        Me.gb_fitur.Controls.Add(Me.ll_shutdown)
        Me.gb_fitur.Controls.Add(Me.ll_cpanel)
        Me.gb_fitur.Controls.Add(Me.ll_notepad)
        Me.gb_fitur.Controls.Add(Me.ll_hardware)
        Me.gb_fitur.Controls.Add(Me.ll_software)
        Me.gb_fitur.Location = New System.Drawing.Point(43, 210)
        Me.gb_fitur.Name = "gb_fitur"
        Me.gb_fitur.Size = New System.Drawing.Size(254, 140)
        Me.gb_fitur.TabIndex = 17
        Me.gb_fitur.TabStop = False
        Me.gb_fitur.Text = "FITUR"
        '
        'll_abort
        '
        Me.ll_abort.AutoSize = True
        Me.ll_abort.Location = New System.Drawing.Point(26, 105)
        Me.ll_abort.Name = "ll_abort"
        Me.ll_abort.Size = New System.Drawing.Size(32, 13)
        Me.ll_abort.TabIndex = 11
        Me.ll_abort.TabStop = True
        Me.ll_abort.Text = "Abort"
        '
        'll_restart
        '
        Me.ll_restart.AutoSize = True
        Me.ll_restart.Location = New System.Drawing.Point(149, 81)
        Me.ll_restart.Name = "ll_restart"
        Me.ll_restart.Size = New System.Drawing.Size(41, 13)
        Me.ll_restart.TabIndex = 10
        Me.ll_restart.TabStop = True
        Me.ll_restart.Text = "Restart"
        '
        'll_shutdown
        '
        Me.ll_shutdown.AutoSize = True
        Me.ll_shutdown.Location = New System.Drawing.Point(25, 81)
        Me.ll_shutdown.Name = "ll_shutdown"
        Me.ll_shutdown.Size = New System.Drawing.Size(55, 13)
        Me.ll_shutdown.TabIndex = 9
        Me.ll_shutdown.TabStop = True
        Me.ll_shutdown.Text = "Shutdown"
        '
        'll_cpanel
        '
        Me.ll_cpanel.AutoSize = True
        Me.ll_cpanel.Location = New System.Drawing.Point(149, 53)
        Me.ll_cpanel.Name = "ll_cpanel"
        Me.ll_cpanel.Size = New System.Drawing.Size(40, 13)
        Me.ll_cpanel.TabIndex = 8
        Me.ll_cpanel.TabStop = True
        Me.ll_cpanel.Text = "Cpanel"
        '
        'll_notepad
        '
        Me.ll_notepad.AutoSize = True
        Me.ll_notepad.Location = New System.Drawing.Point(25, 53)
        Me.ll_notepad.Name = "ll_notepad"
        Me.ll_notepad.Size = New System.Drawing.Size(48, 13)
        Me.ll_notepad.TabIndex = 7
        Me.ll_notepad.TabStop = True
        Me.ll_notepad.Text = "Notepad"
        '
        'll_hardware
        '
        Me.ll_hardware.AutoSize = True
        Me.ll_hardware.Location = New System.Drawing.Point(149, 25)
        Me.ll_hardware.Name = "ll_hardware"
        Me.ll_hardware.Size = New System.Drawing.Size(53, 13)
        Me.ll_hardware.TabIndex = 6
        Me.ll_hardware.TabStop = True
        Me.ll_hardware.Text = "Hardware"
        '
        'll_software
        '
        Me.ll_software.AutoSize = True
        Me.ll_software.Location = New System.Drawing.Point(25, 25)
        Me.ll_software.Name = "ll_software"
        Me.ll_software.Size = New System.Drawing.Size(49, 13)
        Me.ll_software.TabIndex = 5
        Me.ll_software.TabStop = True
        Me.ll_software.Text = "Software"
        '
        'gb_chat
        '
        Me.gb_chat.Controls.Add(Me.rb_isipesangrup)
        Me.gb_chat.Location = New System.Drawing.Point(303, 76)
        Me.gb_chat.Name = "gb_chat"
        Me.gb_chat.Size = New System.Drawing.Size(410, 204)
        Me.gb_chat.TabIndex = 18
        Me.gb_chat.TabStop = False
        Me.gb_chat.Text = "Chat Room - OFFLINE"
        '
        'rb_isipesangrup
        '
        Me.rb_isipesangrup.Location = New System.Drawing.Point(20, 37)
        Me.rb_isipesangrup.Name = "rb_isipesangrup"
        Me.rb_isipesangrup.Size = New System.Drawing.Size(370, 150)
        Me.rb_isipesangrup.TabIndex = 0
        Me.rb_isipesangrup.Text = ""
        '
        'gb_background
        '
        Me.gb_background.Controls.Add(Me.btn_color)
        Me.gb_background.Location = New System.Drawing.Point(43, 145)
        Me.gb_background.Name = "gb_background"
        Me.gb_background.Size = New System.Drawing.Size(254, 59)
        Me.gb_background.TabIndex = 16
        Me.gb_background.TabStop = False
        Me.gb_background.Text = "BACKGROUND"
        '
        'btn_color
        '
        Me.btn_color.Location = New System.Drawing.Point(65, 20)
        Me.btn_color.Name = "btn_color"
        Me.btn_color.Size = New System.Drawing.Size(179, 31)
        Me.btn_color.TabIndex = 2
        Me.btn_color.Text = "Change Color"
        Me.btn_color.UseVisualStyleBackColor = True
        '
        'lbl_customize
        '
        Me.lbl_customize.AutoSize = True
        Me.lbl_customize.Location = New System.Drawing.Point(141, 39)
        Me.lbl_customize.Name = "lbl_customize"
        Me.lbl_customize.Size = New System.Drawing.Size(78, 13)
        Me.lbl_customize.TabIndex = 25
        Me.lbl_customize.Text = "GROUP CHAT"
        '
        'btn_connect
        '
        Me.btn_connect.Location = New System.Drawing.Point(674, 30)
        Me.btn_connect.Name = "btn_connect"
        Me.btn_connect.Size = New System.Drawing.Size(90, 33)
        Me.btn_connect.TabIndex = 24
        Me.btn_connect.Text = "Connect"
        Me.btn_connect.UseVisualStyleBackColor = True
        Me.btn_connect.Visible = False
        '
        'tb_connect
        '
        Me.tb_connect.Location = New System.Drawing.Point(461, 33)
        Me.tb_connect.Name = "tb_connect"
        Me.tb_connect.Size = New System.Drawing.Size(195, 20)
        Me.tb_connect.TabIndex = 23
        Me.tb_connect.Visible = False
        '
        'lbl_username
        '
        Me.lbl_username.AutoSize = True
        Me.lbl_username.Location = New System.Drawing.Point(339, 36)
        Me.lbl_username.Name = "lbl_username"
        Me.lbl_username.Size = New System.Drawing.Size(55, 13)
        Me.lbl_username.TabIndex = 22
        Me.lbl_username.Text = "Username"
        Me.lbl_username.Visible = False
        '
        'gb_font
        '
        Me.gb_font.Controls.Add(Me.btn_font)
        Me.gb_font.Location = New System.Drawing.Point(43, 77)
        Me.gb_font.Name = "gb_font"
        Me.gb_font.Size = New System.Drawing.Size(254, 62)
        Me.gb_font.TabIndex = 15
        Me.gb_font.TabStop = False
        Me.gb_font.Text = "FONT"
        '
        'btn_font
        '
        Me.btn_font.Location = New System.Drawing.Point(65, 21)
        Me.btn_font.Name = "btn_font"
        Me.btn_font.Size = New System.Drawing.Size(179, 31)
        Me.btn_font.TabIndex = 2
        Me.btn_font.Text = "Change Font"
        Me.btn_font.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(303, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(514, 40)
        Me.ProgressBar1.TabIndex = 13
        '
        'Chat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 425)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "Chat"
        Me.Text = "Chat"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gb_fitur.ResumeLayout(False)
        Me.gb_fitur.PerformLayout()
        Me.gb_chat.ResumeLayout(False)
        Me.gb_background.ResumeLayout(False)
        Me.gb_font.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_send As Button
    Friend WithEvents tb_pesangrup As TextBox
    Friend WithEvents btn_savechat As Button
    Friend WithEvents rb_join As RichTextBox
    Friend WithEvents gb_fitur As GroupBox
    Friend WithEvents ll_abort As LinkLabel
    Friend WithEvents ll_restart As LinkLabel
    Friend WithEvents ll_shutdown As LinkLabel
    Friend WithEvents ll_cpanel As LinkLabel
    Friend WithEvents ll_notepad As LinkLabel
    Friend WithEvents ll_hardware As LinkLabel
    Friend WithEvents ll_software As LinkLabel
    Friend WithEvents gb_chat As GroupBox
    Friend WithEvents rb_isipesangrup As RichTextBox
    Friend WithEvents gb_background As GroupBox
    Friend WithEvents btn_color As Button
    Friend WithEvents lbl_customize As Label
    Friend WithEvents btn_connect As Button
    Friend WithEvents tb_connect As TextBox
    Friend WithEvents lbl_username As Label
    Friend WithEvents gb_font As GroupBox
    Friend WithEvents btn_font As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents SaveFileDialogChat As SaveFileDialog
End Class
