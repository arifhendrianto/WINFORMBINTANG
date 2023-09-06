<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PROFILE
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbinput = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUserInput = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsInputDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbUpdated = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUserUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUpdateDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbstmst = New System.Windows.Forms.ToolStrip()
        Me.ADD = New System.Windows.Forms.ToolStripButton()
        Me.EDIT = New System.Windows.Forms.ToolStripButton()
        Me.CANCEL = New System.Windows.Forms.ToolStripButton()
        Me.SAVE = New System.Windows.Forms.ToolStripButton()
        Me.UPDATEE = New System.Windows.Forms.ToolStripButton()
        Me.DEL = New System.Windows.Forms.ToolStripButton()
        Me.PRINT = New System.Windows.Forms.ToolStripButton()
        Me.LISTING = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DELETEROW = New System.Windows.Forms.ToolStripButton()
        Me.EXPORTXLS = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EXITT = New System.Windows.Forms.ToolStripButton()
        Me.MENU_PROFILE = New DevExpress.XtraTab.XtraTabControl()
        Me.XTabInfo = New DevExpress.XtraTab.XtraTabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.txtMulaiData = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtpicture_back = New System.Windows.Forms.TextBox()
        Me.btnBrowsePhoto = New System.Windows.Forms.Button()
        Me.PictureBox_back = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.txtCompanyID = New System.Windows.Forms.TextBox()
        Me.XTabPajak = New DevExpress.XtraTab.XtraTabPage()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cbKategoriUsaha = New System.Windows.Forms.ComboBox()
        Me.cbBidangUsaha = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1.SuspendLayout()
        Me.tbstmst.SuspendLayout()
        CType(Me.MENU_PROFILE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MENU_PROFILE.SuspendLayout()
        Me.XTabInfo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox_back, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbinput, Me.tsUserInput, Me.tsInputDate, Me.lbUpdated, Me.tsUserUpdate, Me.tsUpdateDate, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 455)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(965, 22)
        Me.StatusStrip1.TabIndex = 78
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbinput
        '
        Me.lbinput.Name = "lbinput"
        Me.lbinput.Size = New System.Drawing.Size(57, 17)
        Me.lbinput.Text = "Input by :"
        '
        'tsUserInput
        '
        Me.tsUserInput.Name = "tsUserInput"
        Me.tsUserInput.Size = New System.Drawing.Size(67, 17)
        Me.tsUserInput.Text = "tsUserInput"
        '
        'tsInputDate
        '
        Me.tsInputDate.Name = "tsInputDate"
        Me.tsInputDate.Size = New System.Drawing.Size(71, 17)
        Me.tsInputDate.Text = "txtinputdate"
        '
        'lbUpdated
        '
        Me.lbUpdated.Name = "lbUpdated"
        Me.lbUpdated.Size = New System.Drawing.Size(74, 17)
        Me.lbUpdated.Text = "Updated by :"
        '
        'tsUserUpdate
        '
        Me.tsUserUpdate.Name = "tsUserUpdate"
        Me.tsUserUpdate.Size = New System.Drawing.Size(79, 17)
        Me.tsUserUpdate.Text = "txtuserupdate"
        '
        'tsUpdateDate
        '
        Me.tsUpdateDate.Name = "tsUpdateDate"
        Me.tsUpdateDate.Size = New System.Drawing.Size(80, 17)
        Me.tsUpdateDate.Text = "txtupdatedate"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'tbstmst
        '
        Me.tbstmst.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbstmst.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADD, Me.EDIT, Me.CANCEL, Me.SAVE, Me.UPDATEE, Me.DEL, Me.PRINT, Me.LISTING, Me.DELETEROW, Me.EXPORTXLS, Me.EXITT})
        Me.tbstmst.Location = New System.Drawing.Point(0, 0)
        Me.tbstmst.Name = "tbstmst"
        Me.tbstmst.Size = New System.Drawing.Size(965, 37)
        Me.tbstmst.TabIndex = 79
        Me.tbstmst.Text = "ToolStrip1"
        '
        'ADD
        '
        Me.ADD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ADD.ForeColor = System.Drawing.Color.White
        Me.ADD.Image = Global.Symbios.My.Resources.Resources.Add
        Me.ADD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ADD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ADD.Name = "ADD"
        Me.ADD.Size = New System.Drawing.Size(34, 34)
        Me.ADD.Text = "Add"
        Me.ADD.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'EDIT
        '
        Me.EDIT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EDIT.ForeColor = System.Drawing.Color.White
        Me.EDIT.Image = Global.Symbios.My.Resources.Resources.edit
        Me.EDIT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EDIT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EDIT.Name = "EDIT"
        Me.EDIT.Size = New System.Drawing.Size(34, 34)
        Me.EDIT.Text = "Edit"
        Me.EDIT.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.EDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.EDIT.ToolTipText = "Edit"
        '
        'CANCEL
        '
        Me.CANCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CANCEL.ForeColor = System.Drawing.Color.White
        Me.CANCEL.Image = Global.Symbios.My.Resources.Resources.undo
        Me.CANCEL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CANCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CANCEL.Name = "CANCEL"
        Me.CANCEL.Size = New System.Drawing.Size(29, 34)
        Me.CANCEL.Text = "Cancel"
        Me.CANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CANCEL.ToolTipText = "Cancel"
        '
        'SAVE
        '
        Me.SAVE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SAVE.ForeColor = System.Drawing.Color.White
        Me.SAVE.Image = Global.Symbios.My.Resources.Resources.save
        Me.SAVE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SAVE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SAVE.Name = "SAVE"
        Me.SAVE.Size = New System.Drawing.Size(34, 34)
        Me.SAVE.Text = "Save"
        Me.SAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.SAVE.ToolTipText = "Save"
        '
        'UPDATEE
        '
        Me.UPDATEE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UPDATEE.ForeColor = System.Drawing.Color.White
        Me.UPDATEE.Image = Global.Symbios.My.Resources.Resources.update
        Me.UPDATEE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.UPDATEE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UPDATEE.Name = "UPDATEE"
        Me.UPDATEE.Size = New System.Drawing.Size(34, 34)
        Me.UPDATEE.Text = "Update"
        Me.UPDATEE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.UPDATEE.ToolTipText = "Update"
        '
        'DEL
        '
        Me.DEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DEL.ForeColor = System.Drawing.Color.White
        Me.DEL.Image = Global.Symbios.My.Resources.Resources.delete
        Me.DEL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DEL.Name = "DEL"
        Me.DEL.Size = New System.Drawing.Size(34, 34)
        Me.DEL.Text = "Delete"
        Me.DEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.DEL.ToolTipText = "Delete"
        '
        'PRINT
        '
        Me.PRINT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PRINT.ForeColor = System.Drawing.Color.White
        Me.PRINT.Image = Global.Symbios.My.Resources.Resources.print
        Me.PRINT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PRINT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PRINT.Name = "PRINT"
        Me.PRINT.Size = New System.Drawing.Size(34, 34)
        Me.PRINT.Text = "Print"
        Me.PRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.PRINT.ToolTipText = "Print"
        '
        'LISTING
        '
        Me.LISTING.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LISTING.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1})
        Me.LISTING.ForeColor = System.Drawing.Color.White
        Me.LISTING.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LISTING.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LISTING.Name = "LISTING"
        Me.LISTING.Size = New System.Drawing.Size(13, 34)
        Me.LISTING.Text = "REKAP"
        Me.LISTING.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(192, 6)
        '
        'DELETEROW
        '
        Me.DELETEROW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DELETEROW.Image = Global.Symbios.My.Resources.Resources.delete_row
        Me.DELETEROW.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DELETEROW.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DELETEROW.Name = "DELETEROW"
        Me.DELETEROW.Size = New System.Drawing.Size(34, 34)
        Me.DELETEROW.Text = "DELETE ROW"
        '
        'EXPORTXLS
        '
        Me.EXPORTXLS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXPORTXLS.Image = Global.Symbios.My.Resources.Resources.excel
        Me.EXPORTXLS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EXPORTXLS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXPORTXLS.Name = "EXPORTXLS"
        Me.EXPORTXLS.Size = New System.Drawing.Size(43, 34)
        Me.EXPORTXLS.Text = "ToolStripDropDownButton1"
        '
        'EXITT
        '
        Me.EXITT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXITT.ForeColor = System.Drawing.Color.White
        Me.EXITT.Image = Global.Symbios.My.Resources.Resources._exit
        Me.EXITT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EXITT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXITT.Name = "EXITT"
        Me.EXITT.Size = New System.Drawing.Size(34, 34)
        Me.EXITT.Text = "Close"
        Me.EXITT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.EXITT.ToolTipText = "Close"
        '
        'MENU_PROFILE
        '
        Me.MENU_PROFILE.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.MENU_PROFILE.Appearance.BackColor2 = System.Drawing.Color.White
        Me.MENU_PROFILE.Appearance.Options.UseBackColor = True
        Me.MENU_PROFILE.AppearancePage.Header.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.MENU_PROFILE.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Transparent
        Me.MENU_PROFILE.AppearancePage.HeaderActive.BackColor2 = System.Drawing.Color.Transparent
        Me.MENU_PROFILE.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.Black
        Me.MENU_PROFILE.AppearancePage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MENU_PROFILE.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.MENU_PROFILE.AppearancePage.HeaderActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.MENU_PROFILE.AppearancePage.HeaderActive.Options.UseBackColor = True
        Me.MENU_PROFILE.AppearancePage.HeaderActive.Options.UseBorderColor = True
        Me.MENU_PROFILE.AppearancePage.HeaderActive.Options.UseFont = True
        Me.MENU_PROFILE.AppearancePage.HeaderActive.Options.UseForeColor = True
        Me.MENU_PROFILE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MENU_PROFILE.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MENU_PROFILE.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MENU_PROFILE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MENU_PROFILE.Location = New System.Drawing.Point(0, 37)
        Me.MENU_PROFILE.LookAndFeel.SkinName = "Blue"
        Me.MENU_PROFILE.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MENU_PROFILE.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.MENU_PROFILE.Name = "MENU_PROFILE"
        Me.MENU_PROFILE.SelectedTabPage = Me.XTabInfo
        Me.MENU_PROFILE.Size = New System.Drawing.Size(965, 418)
        Me.MENU_PROFILE.TabIndex = 372
        Me.MENU_PROFILE.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTabInfo, Me.XTabPajak})
        '
        'XTabInfo
        '
        Me.XTabInfo.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control
        Me.XTabInfo.Appearance.PageClient.Options.UseBackColor = True
        Me.XTabInfo.Controls.Add(Me.Panel1)
        Me.XTabInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTabInfo.Name = "XTabInfo"
        Me.XTabInfo.Size = New System.Drawing.Size(958, 389)
        Me.XTabInfo.Text = "Info Perusahaan"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.cbBidangUsaha)
        Me.Panel1.Controls.Add(Me.cbKategoriUsaha)
        Me.Panel1.Controls.Add(Me.cbCurrency)
        Me.Panel1.Controls.Add(Me.txtMulaiData)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtpicture_back)
        Me.Panel1.Controls.Add(Me.btnBrowsePhoto)
        Me.Panel1.Controls.Add(Me.PictureBox_back)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtFax)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtPhone)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtAddress2)
        Me.Panel1.Controls.Add(Me.txtAddress1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtCompanyName)
        Me.Panel1.Controls.Add(Me.txtCompanyID)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(958, 389)
        Me.Panel1.TabIndex = 406
        '
        'cbCurrency
        '
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Location = New System.Drawing.Point(136, 304)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(95, 21)
        Me.cbCurrency.TabIndex = 529
        '
        'txtMulaiData
        '
        Me.txtMulaiData.CustomFormat = "dd MMM yy"
        Me.txtMulaiData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtMulaiData.Location = New System.Drawing.Point(136, 283)
        Me.txtMulaiData.Name = "txtMulaiData"
        Me.txtMulaiData.Size = New System.Drawing.Size(195, 20)
        Me.txtMulaiData.TabIndex = 528
        Me.txtMulaiData.Value = New Date(2023, 8, 26, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 312)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 407
        Me.Label10.Text = "Currency"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 288)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 405
        Me.Label9.Text = "Tgl Mulai Data"
        '
        'txtpicture_back
        '
        Me.txtpicture_back.BackColor = System.Drawing.Color.White
        Me.txtpicture_back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpicture_back.Location = New System.Drawing.Point(705, 216)
        Me.txtpicture_back.Name = "txtpicture_back"
        Me.txtpicture_back.ReadOnly = True
        Me.txtpicture_back.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtpicture_back.Size = New System.Drawing.Size(55, 20)
        Me.txtpicture_back.TabIndex = 402
        Me.txtpicture_back.Visible = False
        '
        'btnBrowsePhoto
        '
        Me.btnBrowsePhoto.Location = New System.Drawing.Point(614, 215)
        Me.btnBrowsePhoto.Name = "btnBrowsePhoto"
        Me.btnBrowsePhoto.Size = New System.Drawing.Size(91, 23)
        Me.btnBrowsePhoto.TabIndex = 401
        Me.btnBrowsePhoto.Text = "Company Logo"
        Me.btnBrowsePhoto.UseVisualStyleBackColor = True
        '
        'PictureBox_back
        '
        Me.PictureBox_back.BackColor = System.Drawing.Color.White
        Me.PictureBox_back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox_back.Location = New System.Drawing.Point(614, 20)
        Me.PictureBox_back.Name = "PictureBox_back"
        Me.PictureBox_back.Size = New System.Drawing.Size(149, 192)
        Me.PictureBox_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_back.TabIndex = 400
        Me.PictureBox_back.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 399
        Me.Label8.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(136, 260)
        Me.txtEmail.MaxLength = 0
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(258, 20)
        Me.txtEmail.TabIndex = 398
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 397
        Me.Label7.Text = "Fax"
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.Color.White
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFax.Location = New System.Drawing.Point(136, 237)
        Me.txtFax.MaxLength = 0
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.Size = New System.Drawing.Size(258, 20)
        Me.txtFax.TabIndex = 396
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 395
        Me.Label6.Text = "Phone"
        '
        'txtPhone
        '
        Me.txtPhone.BackColor = System.Drawing.Color.White
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(136, 215)
        Me.txtPhone.MaxLength = 0
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReadOnly = True
        Me.txtPhone.Size = New System.Drawing.Size(258, 20)
        Me.txtPhone.TabIndex = 394
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 393
        Me.Label5.Text = "Alamat-1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 392
        Me.Label4.Text = "Alamat-1"
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.Color.White
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress2.Location = New System.Drawing.Point(136, 145)
        Me.txtAddress2.MaxLength = 0
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(424, 67)
        Me.txtAddress2.TabIndex = 391
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.Color.White
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress1.Location = New System.Drawing.Point(136, 89)
        Me.txtAddress1.MaxLength = 0
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(424, 53)
        Me.txtAddress1.TabIndex = 390
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "Bidang Usaha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 387
        Me.Label2.Text = "Kategori Usaha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 374
        Me.Label1.Text = "Nama"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BackColor = System.Drawing.Color.White
        Me.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompanyName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyName.Location = New System.Drawing.Point(136, 20)
        Me.txtCompanyName.MaxLength = 0
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.ReadOnly = True
        Me.txtCompanyName.Size = New System.Drawing.Size(424, 20)
        Me.txtCompanyName.TabIndex = 373
        '
        'txtCompanyID
        '
        Me.txtCompanyID.BackColor = System.Drawing.Color.White
        Me.txtCompanyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompanyID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyID.Location = New System.Drawing.Point(113, 20)
        Me.txtCompanyID.MaxLength = 9
        Me.txtCompanyID.Name = "txtCompanyID"
        Me.txtCompanyID.ReadOnly = True
        Me.txtCompanyID.Size = New System.Drawing.Size(80, 20)
        Me.txtCompanyID.TabIndex = 406
        Me.txtCompanyID.Visible = False
        '
        'XTabPajak
        '
        Me.XTabPajak.Name = "XTabPajak"
        Me.XTabPajak.Size = New System.Drawing.Size(958, 389)
        Me.XTabPajak.Text = "Pajak"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cbKategoriUsaha
        '
        Me.cbKategoriUsaha.FormattingEnabled = True
        Me.cbKategoriUsaha.Location = New System.Drawing.Point(136, 41)
        Me.cbKategoriUsaha.Name = "cbKategoriUsaha"
        Me.cbKategoriUsaha.Size = New System.Drawing.Size(424, 21)
        Me.cbKategoriUsaha.TabIndex = 530
        '
        'cbBidangUsaha
        '
        Me.cbBidangUsaha.FormattingEnabled = True
        Me.cbBidangUsaha.Location = New System.Drawing.Point(136, 65)
        Me.cbBidangUsaha.Name = "cbBidangUsaha"
        Me.cbBidangUsaha.Size = New System.Drawing.Size(424, 21)
        Me.cbBidangUsaha.TabIndex = 531
        '
        'PROFILE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 477)
        Me.Controls.Add(Me.MENU_PROFILE)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tbstmst)
        Me.Name = "PROFILE"
        Me.Text = "PROFILE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tbstmst.ResumeLayout(False)
        Me.tbstmst.PerformLayout()
        CType(Me.MENU_PROFILE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MENU_PROFILE.ResumeLayout(False)
        Me.XTabInfo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox_back, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbinput As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsUserInput As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsInputDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbUpdated As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsUserUpdate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsUpdateDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbstmst As System.Windows.Forms.ToolStrip
    Friend WithEvents ADD As System.Windows.Forms.ToolStripButton
    Friend WithEvents EDIT As System.Windows.Forms.ToolStripButton
    Friend WithEvents CANCEL As System.Windows.Forms.ToolStripButton
    Friend WithEvents SAVE As System.Windows.Forms.ToolStripButton
    Friend WithEvents UPDATEE As System.Windows.Forms.ToolStripButton
    Friend WithEvents DEL As System.Windows.Forms.ToolStripButton
    Friend WithEvents PRINT As System.Windows.Forms.ToolStripButton
    Friend WithEvents LISTING As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DELETEROW As System.Windows.Forms.ToolStripButton
    Friend WithEvents EXPORTXLS As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents EXITT As System.Windows.Forms.ToolStripButton
    Friend WithEvents MENU_PROFILE As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTabInfo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTabPajak As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBrowsePhoto As System.Windows.Forms.Button
    Friend WithEvents PictureBox_back As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtpicture_back As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCompanyID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMulaiData As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents cbKategoriUsaha As System.Windows.Forms.ComboBox
    Friend WithEvents cbBidangUsaha As System.Windows.Forms.ComboBox
End Class
