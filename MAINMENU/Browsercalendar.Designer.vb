<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Browsercalendar
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdclose = New System.Windows.Forms.Button()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.cmdclose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(227, 29)
        Me.Panel1.TabIndex = 2
        '
        'cmdclose
        '
        Me.cmdclose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdclose.Location = New System.Drawing.Point(551, 5)
        Me.cmdclose.Name = "cmdclose"
        Me.cmdclose.Size = New System.Drawing.Size(146, 23)
        Me.cmdclose.TabIndex = 0
        Me.cmdclose.Text = "Close"
        Me.cmdclose.UseVisualStyleBackColor = False
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonthCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 3
        '
        'btnclose
        '
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Location = New System.Drawing.Point(149, 2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(75, 23)
        Me.btnclose.TabIndex = 4
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'Browsercalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Browsercalendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdclose As System.Windows.Forms.Button
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnclose As System.Windows.Forms.Button
End Class
