<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_desktop = New System.Windows.Forms.Button()
        Me.btn_mediaplayer = New System.Windows.Forms.Button()
        Me.btn_pesan = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MENU MASTER SERVER REMOTE"
        '
        'btn_desktop
        '
        Me.btn_desktop.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btn_desktop.FlatAppearance.BorderSize = 0
        Me.btn_desktop.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_desktop.ForeColor = System.Drawing.Color.White
        Me.btn_desktop.Location = New System.Drawing.Point(55, 82)
        Me.btn_desktop.Name = "btn_desktop"
        Me.btn_desktop.Size = New System.Drawing.Size(113, 71)
        Me.btn_desktop.TabIndex = 1
        Me.btn_desktop.Text = "Desktop Viewer"
        Me.btn_desktop.UseVisualStyleBackColor = False
        '
        'btn_mediaplayer
        '
        Me.btn_mediaplayer.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btn_mediaplayer.FlatAppearance.BorderSize = 0
        Me.btn_mediaplayer.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mediaplayer.ForeColor = System.Drawing.Color.White
        Me.btn_mediaplayer.Location = New System.Drawing.Point(191, 82)
        Me.btn_mediaplayer.Name = "btn_mediaplayer"
        Me.btn_mediaplayer.Size = New System.Drawing.Size(113, 71)
        Me.btn_mediaplayer.TabIndex = 2
        Me.btn_mediaplayer.Text = "Media Player Remote"
        Me.btn_mediaplayer.UseVisualStyleBackColor = False
        '
        'btn_pesan
        '
        Me.btn_pesan.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btn_pesan.FlatAppearance.BorderSize = 0
        Me.btn_pesan.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pesan.ForeColor = System.Drawing.Color.White
        Me.btn_pesan.Location = New System.Drawing.Point(326, 82)
        Me.btn_pesan.Name = "btn_pesan"
        Me.btn_pesan.Size = New System.Drawing.Size(113, 71)
        Me.btn_pesan.TabIndex = 3
        Me.btn_pesan.Text = "Pesan Remote"
        Me.btn_pesan.UseVisualStyleBackColor = False
        '
        'MenuMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(491, 193)
        Me.Controls.Add(Me.btn_pesan)
        Me.Controls.Add(Me.btn_mediaplayer)
        Me.Controls.Add(Me.btn_desktop)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "MenuMaster"
        Me.Text = "MenuMaster"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btn_desktop As Button
    Friend WithEvents btn_mediaplayer As Button
    Friend WithEvents btn_pesan As Button
End Class
