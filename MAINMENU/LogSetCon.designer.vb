<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogSetCon
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.FrPswd = New System.Windows.Forms.TextBox()
        Me.FrUser = New System.Windows.Forms.TextBox()
        Me.FrDtbs = New System.Windows.Forms.TextBox()
        Me.Frsvr = New System.Windows.Forms.TextBox()
        Me._Label1_5 = New System.Windows.Forms.Label()
        Me._Label1_4 = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me._Label1_0 = New System.Windows.Forms.Label()
        Me.txtmdb = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(213, 166)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(92, 27)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "Apply"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Transparent
        Me.Frame1.Controls.Add(Me.FrPswd)
        Me.Frame1.Controls.Add(Me.FrUser)
        Me.Frame1.Controls.Add(Me.FrDtbs)
        Me.Frame1.Controls.Add(Me.Frsvr)
        Me.Frame1.Controls.Add(Me._Label1_5)
        Me.Frame1.Controls.Add(Me._Label1_4)
        Me.Frame1.Controls.Add(Me._Label1_2)
        Me.Frame1.Controls.Add(Me._Label1_0)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.Color.Black
        Me.Frame1.Location = New System.Drawing.Point(-4, 1)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(324, 147)
        Me.Frame1.TabIndex = 6
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "SQL Database"
        '
        'FrPswd
        '
        Me.FrPswd.AcceptsReturn = True
        Me.FrPswd.BackColor = System.Drawing.SystemColors.Window
        Me.FrPswd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FrPswd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrPswd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FrPswd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.FrPswd.Location = New System.Drawing.Point(104, 96)
        Me.FrPswd.MaxLength = 0
        Me.FrPswd.Name = "FrPswd"
        Me.FrPswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.FrPswd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrPswd.Size = New System.Drawing.Size(205, 20)
        Me.FrPswd.TabIndex = 3
        '
        'FrUser
        '
        Me.FrUser.AcceptsReturn = True
        Me.FrUser.BackColor = System.Drawing.SystemColors.Window
        Me.FrUser.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FrUser.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrUser.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FrUser.Location = New System.Drawing.Point(104, 72)
        Me.FrUser.MaxLength = 0
        Me.FrUser.Name = "FrUser"
        Me.FrUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrUser.Size = New System.Drawing.Size(205, 20)
        Me.FrUser.TabIndex = 2
        '
        'FrDtbs
        '
        Me.FrDtbs.AcceptsReturn = True
        Me.FrDtbs.BackColor = System.Drawing.SystemColors.Window
        Me.FrDtbs.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FrDtbs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrDtbs.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FrDtbs.Location = New System.Drawing.Point(104, 48)
        Me.FrDtbs.MaxLength = 0
        Me.FrDtbs.Name = "FrDtbs"
        Me.FrDtbs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrDtbs.Size = New System.Drawing.Size(205, 20)
        Me.FrDtbs.TabIndex = 1
        '
        'Frsvr
        '
        Me.Frsvr.AcceptsReturn = True
        Me.Frsvr.BackColor = System.Drawing.SystemColors.Window
        Me.Frsvr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Frsvr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frsvr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frsvr.Location = New System.Drawing.Point(104, 24)
        Me.Frsvr.MaxLength = 0
        Me.Frsvr.Name = "Frsvr"
        Me.Frsvr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frsvr.Size = New System.Drawing.Size(205, 20)
        Me.Frsvr.TabIndex = 0
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.Color.Transparent
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(16, 98)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(84, 17)
        Me._Label1_5.TabIndex = 9
        Me._Label1_5.Text = "Password"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.Color.Transparent
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(16, 74)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(84, 17)
        Me._Label1_4.TabIndex = 8
        Me._Label1_4.Text = "User"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.Color.Transparent
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(16, 50)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(84, 17)
        Me._Label1_2.TabIndex = 7
        Me._Label1_2.Text = "Database"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.Color.Transparent
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(16, 26)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(84, 17)
        Me._Label1_0.TabIndex = 6
        Me._Label1_0.Text = "Server name"
        '
        'txtmdb
        '
        Me.txtmdb.AcceptsReturn = True
        Me.txtmdb.BackColor = System.Drawing.SystemColors.Window
        Me.txtmdb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtmdb.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmdb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtmdb.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtmdb.Location = New System.Drawing.Point(100, 159)
        Me.txtmdb.MaxLength = 0
        Me.txtmdb.Name = "txtmdb"
        Me.txtmdb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtmdb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtmdb.Size = New System.Drawing.Size(107, 20)
        Me.txtmdb.TabIndex = 10
        Me.txtmdb.Text = "HRDDATA"
        Me.txtmdb.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "HRDDATA"
        Me.Label1.Visible = False
        '
        'LogSetCon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Symbios.My.Resources.Resources.wind
        Me.ClientSize = New System.Drawing.Size(317, 205)
        Me.Controls.Add(Me.txtmdb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LogSetCon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Connection Seting "
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents FrPswd As System.Windows.Forms.TextBox
    Public WithEvents FrUser As System.Windows.Forms.TextBox
    Public WithEvents FrDtbs As System.Windows.Forms.TextBox
    Public WithEvents Frsvr As System.Windows.Forms.TextBox
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents txtmdb As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
End Class
