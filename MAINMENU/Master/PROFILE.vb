Imports System.Data
Imports System.Configuration
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlTransaction
Imports System.Data.OleDb.OleDbTransaction
Imports System.DBNull
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Forms.Control
Imports Excel = Microsoft.Office.Interop.Excel
Imports DevExpress.XtraTab


Public Class PROFILE

    Dim ax As New MyGlobal
    Dim cn As New SqlConnection '  SqlConnection
    Dim cmd As New SqlCommand
    Dim dtRead As SqlDataReader

    Dim cn1 As New SqlConnection 'SqlConnection
    Dim cmd1 As New SqlCommand
    Dim dtRead1 As SqlDataReader

    Dim cn5 As New SqlConnection 'SqlConnection
    Dim cmd5 As New SqlCommand
    Dim dtRead5 As SqlDataReader


    Dim nmkolom As String
    Dim sketproses As String
    Dim select_cell As String
    Dim findChange As Boolean = False
    Dim widthchange As Boolean = False

    Public pID As String
    Public pSketproses As String
    Public row As Integer
    Dim SPanel1Width As Integer



    Private Sub PROFILE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tunggu_arrow()

        If cn.State = ConnectionState.Open Then cn.Close()
        If cn1.State = ConnectionState.Open Then cn1.Close()
        If cn5.State = ConnectionState.Open Then cn5.Close()

        cn = ax.cntsvr
        cn1 = ax.cntsvr
        cn5 = ax.cntsvr

        cmd.Connection = cn
        cmd1.Connection = cn1
        cmd5.Connection = cn5



        sqlstr = " Exec [spMenu_Access] '" & siduser & "','PROFILE' "
        cmd.CommandText = sqlstr
        dtRead = cmd.ExecuteReader
        If dtRead.Read = True Then
            Me.tbstmst.Items("ADD").Visible = IIf(dtRead!insert_tbl Is DBNull.Value, False, dtRead!insert_tbl)
            Me.tbstmst.Items("SAVE").Visible = IIf(dtRead!insert_tbl Is DBNull.Value, False, dtRead!insert_tbl)
            Me.tbstmst.Items("EDIT").Visible = IIf(dtRead!update_tbl Is DBNull.Value, False, dtRead!update_tbl)
            Me.tbstmst.Items("UPDATEE").Visible = IIf(dtRead!update_tbl Is DBNull.Value, False, dtRead!update_tbl)
            If IIf(dtRead!insert_tbl Is DBNull.Value, False, dtRead!insert_tbl) = False And IIf(dtRead!update_tbl Is DBNull.Value, False, dtRead!update_tbl) = False Then
                Me.tbstmst.Items("CANCEL").Visible = False
            End If
            Me.tbstmst.Items("DEL").Visible = IIf(dtRead!delete_tbl Is DBNull.Value, False, dtRead!delete_tbl)
            Me.tbstmst.Items("PRINT").Visible = IIf(dtRead!print_tbl Is DBNull.Value, False, dtRead!print_tbl)
            Me.tbstmst.Items("EXPORTXLS").Visible = IIf(dtRead!print_tbl Is DBNull.Value, False, dtRead!print_tbl)

        End If
        dtRead.Close()
        dtRead = Nothing

        Isi_KategoriUsaha()
        Isi_BidangUsaha()
        Isi_Currency()
         
        Bind_Header()
    End Sub

    Private Sub Isi_KategoriUsaha()
        Try
            sqlstr = "SELECT CatID, Category FROM KategoriUsaha Order By CatID "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(dtRead)

            cbKategoriUsaha.DataSource = dt
            cbKategoriUsaha.ValueMember = dt.Columns(0).ToString()
            cbKategoriUsaha.DisplayMember = dt.Columns(1).ToString()

            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Isi_BidangUsaha()
        Try

            sqlstr = "SELECT UsahaID, Usaha FROM BidangUsaha Order By UsahaID "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(dtRead)

            cbBidangUsaha.DataSource = dt
            cbBidangUsaha.ValueMember = dt.Columns(0).ToString()
            cbBidangUsaha.DisplayMember = dt.Columns(1).ToString()

            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Isi_Currency()
        Try
            sqlstr = "Select  CurrID, Curr From Currency order By CurrID"
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(dtRead)
            cbCurrency.DataSource = dt
            cbCurrency.ValueMember = dt.Columns(0).ToString()
            cbCurrency.DisplayMember = dt.Columns(1).ToString()

            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Bind_Header()
        tunggu_arrow()

        tutup_tb_dan_field()
        buka_tb_ada_record()



        Dim SqlHeader As String = "[spProfile_Header]"
        Dim cmdHeader As New SqlCommand(SqlHeader)
        Dim dtHeader As DataTable = ax.GetDataTable(cmdHeader)
        If dtHeader.Rows.Count > 0 Then
            Me.tbstmst.Items.Item("ADD").Enabled = False
            BersihkanField()
            Me.txtCompanyID.Text = dtHeader.Rows(0).Item("CompanyID")
            Me.txtCompanyName.Text = dtHeader.Rows(0).Item("CompanyName")
            Me.cbKategoriUsaha.SelectedValue = dtHeader.Rows(0).Item("KategoriUsaha")
            Me.cbBidangUsaha.SelectedValue = dtHeader.Rows(0).Item("BidangUsaha")
            Me.txtAddress1.Text = dtHeader.Rows(0).Item("Address1")
            Me.txtAddress2.Text = dtHeader.Rows(0).Item("Address2")
            Me.txtPhone.Text = dtHeader.Rows(0).Item("Phone")
            Me.txtFax.Text = dtHeader.Rows(0).Item("Fax")
            Me.txtEmail.Text = dtHeader.Rows(0).Item("Email")
            Me.cbCurrency.SelectedValue = dtHeader.Rows(0).Item("Currency")
            Me.txtMulaiData.Text = dtHeader.Rows(0).Item("TglMulaiData")
            Me.tsUserInput.Text = dtHeader.Rows(0).Item("userInput")
            Me.tsInputDate.Text = FormatTanggal_View(dtHeader.Rows(0).Item("InputDate"))
            Me.tsUserUpdate.Text = dtHeader.Rows(0).Item("UserUpdate")
            Me.tsUpdateDate.Text = FormatTanggal_View(dtHeader.Rows(0).Item("UpdateDate"))
             
            PictureBoxClear(Me.PictureBox_back)
            If Not IsDBNull(dtHeader.Rows(0).Item("Logo")) Then
                Dim data As Byte() = DirectCast(dtHeader.Rows(0).Item("Logo"), Byte())
                Dim ms As New MemoryStream(data)
                PictureBox_back.Image = Image.FromStream(ms)
                'PictureBox_Contract.Image = Image.FromStream(ms)
            End If
        End If
 
        biasa_arrow()

    End Sub
    Public Sub PictureBoxClear(ByRef pb As PictureBox)
        pb.Image = Nothing
    End Sub
  


    Private Sub tbstmst_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbstmst.ItemClicked
        ToolStripStatusLabel1.Visible = True
        Select Case e.ClickedItem.Name
            Case "ADD"
                ToolStripStatusLabel1.Text = "Add New data ..."
                proc_add()
            Case "EDIT"
                ToolStripStatusLabel1.Text = "Edit data ..."
                proc_edit()
            Case "CANCEL"
                ToolStripStatusLabel1.Text = "Cancel ..."
                proc_cancel()
            Case "SAVE"
                ToolStripStatusLabel1.Text = "Saving Data ..."
                proc_save()
            Case "UPDATEE"
                ToolStripStatusLabel1.Text = "Update Data ..."
                proc_save()
            Case "DEL"
                ToolStripStatusLabel1.Text = "Delete User Data ..."
                'proc_delete()
            Case "PRINT"
                ToolStripStatusLabel1.Text = "Print Data ..."
            Case "EXITT"
                ToolStripStatusLabel1.Text = "Exit Menu ..."
                proc_exit()
        End Select

        Select Case e.ClickedItem.Name
            Case "CANCEL", "SAVE", "UPDATEE", "DEL", "PRINT", "PREV", "NEXTT"
                ToolStripStatusLabel1.Visible = True
                ToolStripStatusLabel1.Text = ""
        End Select
    End Sub
     
    Private Sub proc_add()
        beditan = True
        ClearControl()
        sketproses = "ADD"
        select_cell = ""
        tutup_tb_dan_field()
        Me.tbstmst.Items.Item("CANCEL").Enabled = True
        Me.tbstmst.Items.Item("SAVE").Enabled = True
        buka_field_txt()

        Me.cbKategoriUsaha.SelectedIndex = 0
        Me.cbBidangUsaha.SelectedIndex = 0

        Me.txtMulaiData.Text = FormatTanggal_View(Date.Now)

        HighlightControl(Me.txtCompanyName)
        Me.txtCompanyName.Focus()

    End Sub


    Private Sub proc_edit()
        bbenar = True

        If bbenar Then
            sketproses = "EDIT"
            beditan = True
            tutup_tb_dan_field()
            Me.tbstmst.Items.Item("CANCEL").Enabled = True
            Me.tbstmst.Items.Item("UPDATEE").Enabled = True
            buka_field_txt()
            ChangeModeControl(False)

            HighlightControl(Me.txtCompanyName)
            Me.txtCompanyName.Focus()
        End If
    End Sub


    Private Sub proc_cancel()
        sresponse = CStr(MsgBox("Cancel Changes ( Y/N ) : ", MsgBoxStyle.YesNo))
        Try
            If sresponse = CStr(MsgBoxResult.Yes) Then
                biasa_arrow()
                sketproses = "FIND"

                Bind_Header()

            End If
        Catch ex As Exception
            biasa_arrow()
            MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub proc_save()
        bbenar = True
        Me.txtCompanyName.Focus()

        If Me.txtCompanyName.Text = "" Then
            bbenar = False
            pesan = "Isikan Nama Perusahaan"
            txtCompanyName.Focus()
            MsgBox(pesan)
            Exit Sub
        End If
        If Me.txtAddress1.Text = "" Then
            bbenar = False
            pesan = "Isikan Alamat Perusahaan"
            txtCompanyName.Focus()
            MsgBox(pesan)
            Exit Sub
        End If


        If bbenar Then
            tunggu_arrow()
            Save_Header()

            sketproses = "FIND"
            Bind_Header()

            biasa_arrow()
        End If
    End Sub

    Private Sub Save_Header()
        If Me.txtMulaiData.Text Is Nothing Then Me.txtMulaiData.Text = "1/1/1900"
        If Me.txtMulaiData.Text = "" Then Me.txtMulaiData.Text = "1/1/1900"

        Dim cmdSave As New SqlCommand()
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "spProfile_Save"
        cmdSave.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = Me.txtCompanyID.Text
        cmdSave.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = Me.txtCompanyName.Text
        cmdSave.Parameters.Add("@KategoriUsaha", SqlDbType.Int).Value = Me.cbKategoriUsaha.SelectedValue
        cmdSave.Parameters.Add("@BidangUsaha", SqlDbType.Int).Value = Me.cbBidangUsaha.SelectedValue
        cmdSave.Parameters.Add("@Address1", SqlDbType.VarChar).Value = Me.txtAddress1.Text
        cmdSave.Parameters.Add("@Address2", SqlDbType.VarChar).Value = Me.txtAddress2.Text
        cmdSave.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Me.txtPhone.Text
        cmdSave.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Me.txtFax.Text
        cmdSave.Parameters.Add("@Email", SqlDbType.VarChar).Value = Me.txtEmail.Text
        cmdSave.Parameters.Add("@TglMulaiData", SqlDbType.Date).Value = Me.txtMulaiData.Text
        cmdSave.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Me.cbCurrency.SelectedValue
        cmdSave.Parameters.Add("@UserName", SqlDbType.VarChar).Value = siduser.Trim
        cmdSave.Parameters.Add("@CompanyID_New", SqlDbType.VarChar, 2)
        cmdSave.Parameters("@CompanyID_New").Direction = ParameterDirection.Output
        cmdSave.Connection = cn
        Try
            cmdSave.ExecuteNonQuery()
            If sketproses = "ADD" Then
                pID = cmdSave.Parameters("@CompanyID_New").Value.ToString
                Me.txtCompanyID.Text = pID
            Else
                pID = Me.txtCompanyID.Text
            End If

            If Me.txtCompanyID.Text <> "" Then
                SaveLogo()
            End If
 
        Catch ex As Exception
            bbenar = False
        Finally
        End Try
    End Sub


    Private Sub SaveLogo()
        Dim bUpload As Boolean = True

        'UPLOAD PHOTO
        '---------------------------------------------------------
        Try
            If IsNothing(Me.PictureBox_back.Image) = False Then

                Dim cmdPhoto As New SqlCommand("spProfile_SavePhoto @CompanyID,@photo ", cn)
                cmdPhoto.Parameters.AddWithValue("CompanyID", Me.txtCompanyID.Text.ToString.Trim)

                Dim sbytes() As Byte = ax.ImageToByte(Me.PictureBox_back.Image)
                Dim iom As IO.MemoryStream = ax.ConvertBytesToMemoryStream(sbytes)
                Dim FileByteArray(iom.Length - 1) As Byte
                iom.Read(FileByteArray, 0, iom.Length)
                cmdPhoto.Parameters.Add("@photo", SqlDbType.Binary, iom.Length).Value = FileByteArray
                cmdPhoto.ExecuteNonQuery()
            End If
        Catch ex As Exception
            bUpload = False
            MsgBox("Upload Pict Failed !", MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub


    Private Sub tutup_tb_dan_field()
        For urut = 0 To Me.tbstmst.Items.Count - 1
            Me.tbstmst.Items.Item(urut).Enabled = False
        Next urut
        Me.tbstmst.Items.Item("EXITT").Enabled = True

        'Me.txtCompanyName.ReadOnly = True
        ChangeModeControl(True)
    End Sub

    Private Sub buka_tb_ada_record()
        Me.tbstmst.Items.Item("ADD").Enabled = True
        Me.tbstmst.Items.Item("EDIT").Enabled = True
        Me.tbstmst.Items.Item("EXPORTXLS").Enabled = True
        Me.tbstmst.Items.Item("DELETEROW").Enabled = False
        Me.tbstmst.Items.Item("DEL").Enabled = False
        Me.tbstmst.Items.Item("PRINT").Enabled = True
        Me.tbstmst.Items.Item("LISTING").Enabled = True
    End Sub


    Private Sub buka_field_txt()
        ChangeModeControl(False)
    End Sub

    Private Sub HighlightControl(ByVal ctl As Control)
        ctl.BackColor = Color.FromArgb(255, 255, 128)
    End Sub
    Private Sub BersihkanField()
        sketproses = ""
        ClearControl()
    End Sub


    Public Sub ChangeModeControl(ByVal mode As Boolean, Optional ByVal ctlcolx As Control.ControlCollection = Nothing)
        If ctlcolx Is Nothing Then ctlcolx = Me.Controls
        For Each ctlx As Control In ctlcolx
            If TypeOf (ctlx) Is TextBox Then
                If ctlx.Name <> "lbfnd1" Then
                    If ctlx.Name <> "lbfnd2" Then
                        If ctlx.Name <> "lbfnd3" Then
                            If ctlx.Name <> "TextBox3" Then
                                If ctlx.Name <> "TextBox2" Then
                                    If ctlx.Name <> "TextBox1" Then
                                        DirectCast(ctlx, TextBox).ReadOnly = mode
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            ElseIf TypeOf (ctlx) Is ComboBox Then
                DirectCast(ctlx, ComboBox).Enabled = IIf(mode = True, False, True)
            ElseIf TypeOf (ctlx) Is RadioButton Then
                DirectCast(ctlx, RadioButton).Enabled = IIf(mode = True, False, True)
            ElseIf TypeOf (ctlx) Is CheckBox Then
                DirectCast(ctlx, CheckBox).Enabled = IIf(mode = True, False, True)
            ElseIf TypeOf (ctlx) Is DateTimePicker Then
                DirectCast(ctlx, DateTimePicker).Enabled = IIf(mode = True, False, True)
            ElseIf TypeOf (ctlx) Is Button Then
                If ctlx.Name <> "Btn_Min" Then
                    If ctlx.Name <> "Btn_Max" Then
                        DirectCast(ctlx, Button).Enabled = IIf(mode = True, False, True)
                    End If
                End If

            ElseIf TypeOf (ctlx) Is Label Then
                DirectCast(ctlx, Label).Enabled = True
            Else
                If Not ctlx.Controls Is Nothing OrElse ctlx.Controls.Count <> 0 Then
                    ChangeModeControl(mode, ctlx.Controls)
                End If
            End If
        Next
    End Sub

    Public Sub ClearControl(Optional ByVal ctlcol As Control.ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = Me.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is TextBox Then
                If ctl.Name <> "lbfind" Then
                    If ctl.Name <> "lbfnd1" Then
                        If ctl.Name <> "lbfnd2" Then
                            If ctl.Name <> "lbfnd3" Then
                                If ctl.Name <> "TextBox3" Then
                                    If ctl.Name <> "TextBox2" Then
                                        If ctl.Name <> "TextBox1" Then
                                            DirectCast(ctl, TextBox).Clear()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If


            ElseIf TypeOf (ctl) Is ComboBox Then
                DirectCast(ctl, ComboBox).SelectedIndex = 0

            ElseIf TypeOf (ctl) Is DateTimePicker Then
                DirectCast(ctl, DateTimePicker).Value = "1/1/1900"
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    ClearControl(ctl.Controls)
                End If
            End If
        Next
    End Sub

    Private Sub btnBrowsePhoto_Click(sender As Object, e As EventArgs) Handles btnBrowsePhoto.Click
        With OpenFileDialog1
            .Title = "Pilih Picture"
            .Filter = "JPG Files|*.jpg|JPEG Files|*.jpeg|Bitmap Files|*.bmp|Gif Files|*.gif"
            .FilterIndex = 1
            '.InitialDirectory = Application.StartupPath
            If .ShowDialog = vbOK Then
                Me.txtpicture_back.Text = OpenFileDialog1.FileName
                Dim sbytes() As Byte = ax.ConvertImageFiletoBytes(OpenFileDialog1.FileName)

                If sbytes.Length > 2000000 Then
                    MsgBox("Maximum Picture Size 2 Mb !")
                Else
                    ' 
                    PictureBox_back.Image = ax.byteArrayToImage(sbytes)
                    'Me.PictureBox_back.SizeMode = PictureBoxSizeMode.CenterImage
                    Me.PictureBox_back.SizeMode = PictureBoxSizeMode.StretchImage

                End If
            End If
        End With
    End Sub



    Private Sub proc_exit()
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub tunggu_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    End Sub

    Private Sub biasa_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Dropdown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbCurrency.KeyPress, cbKategoriUsaha.KeyPress, cbBidangUsaha.KeyPress
        e.Handled = True
    End Sub
End Class