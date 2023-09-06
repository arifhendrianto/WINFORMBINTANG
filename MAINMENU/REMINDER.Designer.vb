<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REMINDER
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
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabUnActive = New System.Windows.Forms.TabPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dgUnActive = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Btn_Close1 = New System.Windows.Forms.Button()
        Me.Btn_Email1 = New System.Windows.Forms.Button()
        Me.txtTotalUnActive = New System.Windows.Forms.TextBox()
        Me.btnExcelUnActive = New System.Windows.Forms.Button()
        Me.TabContract = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dgContract = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.Btn_Email = New System.Windows.Forms.Button()
        Me.txtTotalContract = New System.Windows.Forms.TextBox()
        Me.btnExcelContract = New System.Windows.Forms.Button()
        Me.TabActing = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.dgActing = New System.Windows.Forms.DataGridView()
        Me.txtTotalActing = New System.Windows.Forms.TextBox()
        Me.ExcelActing = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabUnActive.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.dgUnActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.TabContract.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgContract, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.TabActing.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.dgActing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1020, 26)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 479)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1020, 16)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1020, 453)
        Me.Panel3.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabUnActive)
        Me.TabControl1.Controls.Add(Me.TabContract)
        Me.TabControl1.Controls.Add(Me.TabActing)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1020, 453)
        Me.TabControl1.TabIndex = 0
        '
        'TabUnActive
        '
        Me.TabUnActive.Controls.Add(Me.Panel7)
        Me.TabUnActive.Controls.Add(Me.Panel6)
        Me.TabUnActive.Location = New System.Drawing.Point(4, 22)
        Me.TabUnActive.Name = "TabUnActive"
        Me.TabUnActive.Size = New System.Drawing.Size(1012, 427)
        Me.TabUnActive.TabIndex = 1
        Me.TabUnActive.Text = "  Habis Kontrak Status Masih Aktif     "
        Me.TabUnActive.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.dgUnActive)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1012, 393)
        Me.Panel7.TabIndex = 109
        '
        'dgUnActive
        '
        Me.dgUnActive.AllowUserToAddRows = False
        Me.dgUnActive.AllowUserToDeleteRows = False
        Me.dgUnActive.AllowUserToResizeColumns = False
        Me.dgUnActive.AllowUserToResizeRows = False
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnActive.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle37
        Me.dgUnActive.BackgroundColor = System.Drawing.Color.White
        Me.dgUnActive.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgUnActive.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle38.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnActive.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle38
        Me.dgUnActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnActive.DefaultCellStyle = DataGridViewCellStyle39
        Me.dgUnActive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUnActive.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgUnActive.EnableHeadersVisualStyles = False
        Me.dgUnActive.GridColor = System.Drawing.Color.White
        Me.dgUnActive.Location = New System.Drawing.Point(0, 0)
        Me.dgUnActive.Name = "dgUnActive"
        DataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle40.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnActive.RowHeadersDefaultCellStyle = DataGridViewCellStyle40
        Me.dgUnActive.RowHeadersWidth = 10
        Me.dgUnActive.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgUnActive.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnActive.RowTemplate.Height = 21
        Me.dgUnActive.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnActive.Size = New System.Drawing.Size(1012, 393)
        Me.dgUnActive.TabIndex = 107
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Btn_Close1)
        Me.Panel6.Controls.Add(Me.Btn_Email1)
        Me.Panel6.Controls.Add(Me.txtTotalUnActive)
        Me.Panel6.Controls.Add(Me.btnExcelUnActive)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 393)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1012, 34)
        Me.Panel6.TabIndex = 108
        '
        'Btn_Close1
        '
        Me.Btn_Close1.Location = New System.Drawing.Point(140, 2)
        Me.Btn_Close1.Name = "Btn_Close1"
        Me.Btn_Close1.Size = New System.Drawing.Size(59, 30)
        Me.Btn_Close1.TabIndex = 115
        Me.Btn_Close1.Text = "Close"
        Me.Btn_Close1.UseVisualStyleBackColor = True
        '
        'Btn_Email1
        '
        Me.Btn_Email1.Image = Global.Symbios.My.Resources.Resources.email
        Me.Btn_Email1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Email1.Location = New System.Drawing.Point(60, 2)
        Me.Btn_Email1.Name = "Btn_Email1"
        Me.Btn_Email1.Size = New System.Drawing.Size(65, 33)
        Me.Btn_Email1.TabIndex = 114
        Me.Btn_Email1.Text = " Email"
        Me.Btn_Email1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Email1.UseVisualStyleBackColor = True
        '
        'txtTotalUnActive
        '
        Me.txtTotalUnActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalUnActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUnActive.Location = New System.Drawing.Point(901, 4)
        Me.txtTotalUnActive.Name = "txtTotalUnActive"
        Me.txtTotalUnActive.Size = New System.Drawing.Size(61, 26)
        Me.txtTotalUnActive.TabIndex = 113
        Me.txtTotalUnActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnExcelUnActive
        '
        Me.btnExcelUnActive.Image = Global.Symbios.My.Resources.Resources.excel
        Me.btnExcelUnActive.Location = New System.Drawing.Point(3, 1)
        Me.btnExcelUnActive.Name = "btnExcelUnActive"
        Me.btnExcelUnActive.Size = New System.Drawing.Size(51, 33)
        Me.btnExcelUnActive.TabIndex = 112
        Me.btnExcelUnActive.UseVisualStyleBackColor = True
        '
        'TabContract
        '
        Me.TabContract.Controls.Add(Me.Panel5)
        Me.TabContract.Controls.Add(Me.Panel4)
        Me.TabContract.Location = New System.Drawing.Point(4, 22)
        Me.TabContract.Name = "TabContract"
        Me.TabContract.Padding = New System.Windows.Forms.Padding(3)
        Me.TabContract.Size = New System.Drawing.Size(1012, 427)
        Me.TabContract.TabIndex = 0
        Me.TabContract.Text = "  Daftar Karyawan Habis Kontrak       "
        Me.TabContract.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgContract)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1006, 383)
        Me.Panel5.TabIndex = 108
        '
        'dgContract
        '
        Me.dgContract.AllowUserToAddRows = False
        Me.dgContract.AllowUserToDeleteRows = False
        Me.dgContract.AllowUserToResizeColumns = False
        Me.dgContract.AllowUserToResizeRows = False
        DataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContract.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle41
        Me.dgContract.BackgroundColor = System.Drawing.Color.White
        Me.dgContract.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgContract.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle42.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle42.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContract.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle42
        Me.dgContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle43.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContract.DefaultCellStyle = DataGridViewCellStyle43
        Me.dgContract.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgContract.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgContract.EnableHeadersVisualStyles = False
        Me.dgContract.GridColor = System.Drawing.Color.White
        Me.dgContract.Location = New System.Drawing.Point(0, 0)
        Me.dgContract.Name = "dgContract"
        DataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle44.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContract.RowHeadersDefaultCellStyle = DataGridViewCellStyle44
        Me.dgContract.RowHeadersWidth = 10
        Me.dgContract.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgContract.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContract.RowTemplate.Height = 21
        Me.dgContract.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContract.Size = New System.Drawing.Size(1006, 383)
        Me.dgContract.TabIndex = 106
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Btn_Close)
        Me.Panel4.Controls.Add(Me.Btn_Email)
        Me.Panel4.Controls.Add(Me.txtTotalContract)
        Me.Panel4.Controls.Add(Me.btnExcelContract)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 386)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1006, 38)
        Me.Panel4.TabIndex = 107
        '
        'Btn_Close
        '
        Me.Btn_Close.Location = New System.Drawing.Point(144, 4)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(59, 30)
        Me.Btn_Close.TabIndex = 114
        Me.Btn_Close.Text = "Close"
        Me.Btn_Close.UseVisualStyleBackColor = True
        '
        'Btn_Email
        '
        Me.Btn_Email.Image = Global.Symbios.My.Resources.Resources.email
        Me.Btn_Email.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Email.Location = New System.Drawing.Point(60, 2)
        Me.Btn_Email.Name = "Btn_Email"
        Me.Btn_Email.Size = New System.Drawing.Size(65, 33)
        Me.Btn_Email.TabIndex = 113
        Me.Btn_Email.Text = " Email"
        Me.Btn_Email.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Email.UseVisualStyleBackColor = True
        '
        'txtTotalContract
        '
        Me.txtTotalContract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalContract.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalContract.Location = New System.Drawing.Point(895, 6)
        Me.txtTotalContract.Name = "txtTotalContract"
        Me.txtTotalContract.Size = New System.Drawing.Size(61, 26)
        Me.txtTotalContract.TabIndex = 112
        Me.txtTotalContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnExcelContract
        '
        Me.btnExcelContract.Image = Global.Symbios.My.Resources.Resources.excel
        Me.btnExcelContract.Location = New System.Drawing.Point(3, 2)
        Me.btnExcelContract.Name = "btnExcelContract"
        Me.btnExcelContract.Size = New System.Drawing.Size(51, 33)
        Me.btnExcelContract.TabIndex = 111
        Me.btnExcelContract.UseVisualStyleBackColor = True
        '
        'TabActing
        '
        Me.TabActing.Controls.Add(Me.Panel9)
        Me.TabActing.Controls.Add(Me.Panel8)
        Me.TabActing.Location = New System.Drawing.Point(4, 22)
        Me.TabActing.Name = "TabActing"
        Me.TabActing.Size = New System.Drawing.Size(1012, 427)
        Me.TabActing.TabIndex = 2
        Me.TabActing.Text = "Acting Histories"
        Me.TabActing.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.ExcelActing)
        Me.Panel8.Controls.Add(Me.txtTotalActing)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 382)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1012, 45)
        Me.Panel8.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.dgActing)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1012, 382)
        Me.Panel9.TabIndex = 1
        '
        'dgActing
        '
        Me.dgActing.AllowUserToAddRows = False
        Me.dgActing.AllowUserToDeleteRows = False
        Me.dgActing.AllowUserToResizeColumns = False
        Me.dgActing.AllowUserToResizeRows = False
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgActing.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle45
        Me.dgActing.BackgroundColor = System.Drawing.Color.White
        Me.dgActing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgActing.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle46.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle46.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle46.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgActing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle46
        Me.dgActing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle47.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgActing.DefaultCellStyle = DataGridViewCellStyle47
        Me.dgActing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgActing.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgActing.EnableHeadersVisualStyles = False
        Me.dgActing.GridColor = System.Drawing.Color.White
        Me.dgActing.Location = New System.Drawing.Point(0, 0)
        Me.dgActing.Name = "dgActing"
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgActing.RowHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.dgActing.RowHeadersWidth = 10
        Me.dgActing.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgActing.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgActing.RowTemplate.Height = 21
        Me.dgActing.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgActing.Size = New System.Drawing.Size(1012, 382)
        Me.dgActing.TabIndex = 108
        '
        'txtTotalActing
        '
        Me.txtTotalActing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalActing.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalActing.Location = New System.Drawing.Point(921, 6)
        Me.txtTotalActing.Name = "txtTotalActing"
        Me.txtTotalActing.Size = New System.Drawing.Size(61, 26)
        Me.txtTotalActing.TabIndex = 113
        Me.txtTotalActing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ExcelActing
        '
        Me.ExcelActing.Image = Global.Symbios.My.Resources.Resources.excel
        Me.ExcelActing.Location = New System.Drawing.Point(5, 4)
        Me.ExcelActing.Name = "ExcelActing"
        Me.ExcelActing.Size = New System.Drawing.Size(51, 33)
        Me.ExcelActing.TabIndex = 115
        Me.ExcelActing.UseVisualStyleBackColor = True
        '
        'REMINDER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 495)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "REMINDER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REMINDER"
        Me.Panel3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabUnActive.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.dgUnActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.TabContract.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgContract, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabActing.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        CType(Me.dgActing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabContract As System.Windows.Forms.TabPage
    Friend WithEvents dgContract As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnExcelContract As System.Windows.Forms.Button
    Friend WithEvents txtTotalContract As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Email As System.Windows.Forms.Button
    Friend WithEvents TabUnActive As System.Windows.Forms.TabPage
    Friend WithEvents dgUnActive As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents txtTotalUnActive As System.Windows.Forms.TextBox
    Friend WithEvents btnExcelUnActive As System.Windows.Forms.Button
    Friend WithEvents Btn_Email1 As System.Windows.Forms.Button
    Friend WithEvents Btn_Close As System.Windows.Forms.Button
    Friend WithEvents Btn_Close1 As System.Windows.Forms.Button
    Friend WithEvents TabActing As System.Windows.Forms.TabPage
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents dgActing As System.Windows.Forms.DataGridView
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtTotalActing As System.Windows.Forms.TextBox
    Friend WithEvents ExcelActing As System.Windows.Forms.Button
End Class
