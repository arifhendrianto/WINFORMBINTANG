<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendEmail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgfind = New System.Windows.Forms.DataGridView()
        Me.CheckEmailAfter = New System.Windows.Forms.CheckedListBox()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgfind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgfind)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckEmailAfter)
        Me.SplitContainer1.Size = New System.Drawing.Size(601, 266)
        Me.SplitContainer1.SplitterDistance = 378
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'dgfind
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dgfind.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgfind.BackgroundColor = System.Drawing.Color.White
        Me.dgfind.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgfind.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgfind.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgfind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgfind.ColumnHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgfind.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgfind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgfind.Location = New System.Drawing.Point(0, 0)
        Me.dgfind.MultiSelect = False
        Me.dgfind.Name = "dgfind"
        Me.dgfind.RowHeadersVisible = False
        Me.dgfind.Size = New System.Drawing.Size(378, 266)
        Me.dgfind.TabIndex = 1
        '
        'CheckEmailAfter
        '
        Me.CheckEmailAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckEmailAfter.FormattingEnabled = True
        Me.CheckEmailAfter.Location = New System.Drawing.Point(0, 0)
        Me.CheckEmailAfter.Name = "CheckEmailAfter"
        Me.CheckEmailAfter.Size = New System.Drawing.Size(222, 266)
        Me.CheckEmailAfter.TabIndex = 1
        '
        'SendEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 266)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "SendEmail"
        Me.Text = "Email Address"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgfind, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents CheckEmailAfter As System.Windows.Forms.CheckedListBox
    Friend WithEvents dgfind As System.Windows.Forms.DataGridView
End Class
