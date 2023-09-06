<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About_Form
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbPT = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lbversion = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTNOK = New System.Windows.Forms.Button()
        Me.BTNSySINFO = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lbAlamat = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 286)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(375, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbPT
        '
        Me.lbPT.AutoSize = True
        Me.lbPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPT.Location = New System.Drawing.Point(13, 195)
        Me.lbPT.Name = "lbPT"
        Me.lbPT.Size = New System.Drawing.Size(45, 13)
        Me.lbPT.TabIndex = 2
        Me.lbPT.Text = "Label1"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(7, 70)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(45, 13)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "Label1"
        '
        'lbversion
        '
        Me.lbversion.AutoSize = True
        Me.lbversion.Location = New System.Drawing.Point(7, 33)
        Me.lbversion.Name = "lbversion"
        Me.lbversion.Size = New System.Drawing.Size(0, 13)
        Me.lbversion.TabIndex = 4
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(7, 11)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(83, 13)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Symbios System"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.lblDescription)
        Me.Panel1.Controls.Add(Me.lbversion)
        Me.Panel1.Location = New System.Drawing.Point(5, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(365, 122)
        Me.Panel1.TabIndex = 6
        '
        'BTNOK
        '
        Me.BTNOK.Location = New System.Drawing.Point(260, 195)
        Me.BTNOK.Name = "BTNOK"
        Me.BTNOK.Size = New System.Drawing.Size(110, 23)
        Me.BTNOK.TabIndex = 7
        Me.BTNOK.Text = "&OK"
        Me.BTNOK.UseVisualStyleBackColor = True
        '
        'BTNSySINFO
        '
        Me.BTNSySINFO.Location = New System.Drawing.Point(260, 224)
        Me.BTNSySINFO.Name = "BTNSySINFO"
        Me.BTNSySINFO.Size = New System.Drawing.Size(110, 23)
        Me.BTNSySINFO.TabIndex = 8
        Me.BTNSySINFO.Text = "&System Info..."
        Me.BTNSySINFO.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(260, 253)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "&Additional Info..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lbAlamat
        '
        Me.lbAlamat.AutoSize = True
        Me.lbAlamat.Location = New System.Drawing.Point(13, 229)
        Me.lbAlamat.Name = "lbAlamat"
        Me.lbAlamat.Size = New System.Drawing.Size(39, 13)
        Me.lbAlamat.TabIndex = 10
        Me.lbAlamat.Text = "Label1"
        '
        'About_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(375, 308)
        Me.Controls.Add(Me.lbAlamat)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lbPT)
        Me.Controls.Add(Me.BTNSySINFO)
        Me.Controls.Add(Me.BTNOK)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Application"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbPT As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lbversion As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BTNOK As System.Windows.Forms.Button
    Friend WithEvents BTNSySINFO As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lbAlamat As System.Windows.Forms.Label
End Class
