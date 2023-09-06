<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenuChangePassword
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
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOLDpassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNEWpassword = New System.Windows.Forms.TextBox()
        Me.txtReNEWpassword = New System.Windows.Forms.TextBox()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtuserid = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Btn_OK
        '
        Me.Btn_OK.Enabled = False
        Me.Btn_OK.Location = New System.Drawing.Point(146, 179)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.Btn_OK.TabIndex = 0
        Me.Btn_OK.Text = "&OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Change Your Password"
        '
        'txtOLDpassword
        '
        Me.txtOLDpassword.Location = New System.Drawing.Point(121, 59)
        Me.txtOLDpassword.Name = "txtOLDpassword"
        Me.txtOLDpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOLDpassword.Size = New System.Drawing.Size(100, 20)
        Me.txtOLDpassword.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Re Type Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "New Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Enter Old Password"
        '
        'txtNEWpassword
        '
        Me.txtNEWpassword.Enabled = False
        Me.txtNEWpassword.Location = New System.Drawing.Point(121, 113)
        Me.txtNEWpassword.Name = "txtNEWpassword"
        Me.txtNEWpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNEWpassword.Size = New System.Drawing.Size(100, 20)
        Me.txtNEWpassword.TabIndex = 6
        '
        'txtReNEWpassword
        '
        Me.txtReNEWpassword.Enabled = False
        Me.txtReNEWpassword.Location = New System.Drawing.Point(121, 139)
        Me.txtReNEWpassword.Name = "txtReNEWpassword"
        Me.txtReNEWpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtReNEWpassword.Size = New System.Drawing.Size(100, 20)
        Me.txtReNEWpassword.TabIndex = 7
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(65, 179)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 8
        Me.btn_Cancel.Text = "&Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "User ID"
        '
        'txtuserid
        '
        Me.txtuserid.BackColor = System.Drawing.Color.White
        Me.txtuserid.Location = New System.Drawing.Point(121, 31)
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.ReadOnly = True
        Me.txtuserid.Size = New System.Drawing.Size(100, 20)
        Me.txtuserid.TabIndex = 10
        '
        'MainMenuChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 227)
        Me.Controls.Add(Me.txtuserid)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.txtReNEWpassword)
        Me.Controls.Add(Me.txtNEWpassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOLDpassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_OK)
        Me.Name = "MainMenuChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintenance Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_OK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOLDpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNEWpassword As System.Windows.Forms.TextBox
    Friend WithEvents txtReNEWpassword As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtuserid As System.Windows.Forms.TextBox
End Class
