Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms
Imports DevExpress.XtraTab
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.ReportAppServer
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel

Public Class SALES_ORDER
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

    Private Sub PURCHASE_ORDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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



        sqlstr = " Exec [spMenu_Access] '" & siduser & "','SALES_ORDER' "
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

        ChangeModeControl(True)
        GridControl(False)

        Isi_Currency()
        Isi_PaymentTerm()
        Isi_FOB()
        Isi_ShipVia()

        isi_data("", "", "")
        LastTransaction()
        select_cell = ""
        widthchange = True

        Me.txtSODate.Text = FormatTanggal_View(Date.Now)
        Me.txtDeliveryDate.Text = FormatTanggal_View(Date.Now)
        Me.KeyPreview = True

        biasa_arrow()
    End Sub

    Private Sub Isi_Currency()
        Try
            sqlstr = "Select  Curr From Currency order By CurrID"
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(dtRead)
            cbCurrency.DataSource = dt
            cbCurrency.ValueMember = dt.Columns(0).ToString()
            cbCurrency.DisplayMember = dt.Columns(0).ToString()

            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Isi_FOB()
        Try
            sqlstr = "Select  FOBID, FOB From FOB order By FOBID"
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(dtRead)
            cbFOB.DataSource = dt
            cbFOB.ValueMember = dt.Columns(0).ToString()
            cbFOB.DisplayMember = dt.Columns(1).ToString()

            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Isi_ShipVia()
        Try
            sqlstr = "Select  ShipID, ShipVia From ShipVia order By ShipID"
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(dtRead)
            cbShipVia.DataSource = dt
            cbShipVia.ValueMember = dt.Columns(0).ToString()
            cbShipVia.DisplayMember = dt.Columns(1).ToString()

            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Isi_PaymentTerm()
        Try
            sqlstr = "Select paymentID, Payment From PaymentTerms order By Payment"
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(dtRead)
            cbPayment.DataSource = dt
            cbPayment.ValueMember = dt.Columns(0).ToString()
            cbPayment.DisplayMember = dt.Columns(1).ToString()

            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LastTransaction()

        Dim sqlstr As String = "[spSO_LastTrx]"
        Dim cmdGenerate As New SqlCommand(sqlstr)
        Dim dtGenerate As DataTable = ax.GetDataTable(cmdGenerate)
        If dtGenerate.Rows.Count > 0 Then
            pID = dtGenerate.Rows(0).Item("SOID")
            sketproses = "FIND"
            select_cell = "CELLSELECT"

            Search_Data(pID)
        End If
    End Sub

    Public Sub Search_Data(ByVal SOID As String)
        tunggu_arrow()

        tutup_tb_dan_field()
        buka_tb_ada_record()


        Dim SqlHeader As String = "[spSO_Header] '" & Trim(SOID) & "'"
        Dim cmdHeader As New SqlCommand(SqlHeader)
        Dim dtHeader As DataTable = ax.GetDataTable(cmdHeader)
        If dtHeader.Rows.Count > 0 Then
            'BersihkanField()
            'GridControl(False)
            ChangeModeControl(True)
            GridControl(False)

            Me.txtSOID.Text = Trim(SOID)
            Me.txtSONo.Text = dtHeader.Rows(0).Item("SONo")
            Me.txtSODate.Text = dtHeader.Rows(0).Item("SoDate")
            Me.txtCustomerID.Text = dtHeader.Rows(0).Item("CustomerID")
            Me.txtCustomer.Text = dtHeader.Rows(0).Item("CustName")
            Me.cbCurrency.SelectedValue = dtHeader.Rows(0).Item("Currency")
            Me.txtKurs.Text = dtHeader.Rows(0).Item("NIlaiKurs")
            Me.txtDeliveryDate.Text = FormatTanggal_View(dtHeader.Rows(0).Item("DeliveryDate"))
            Me.txtAddress.Text = dtHeader.Rows(0).Item("DeliveryTo")
            Me.cbPayment.SelectedValue = dtHeader.Rows(0).Item("PaymentTerms")
            Me.cbFOB.SelectedValue = dtHeader.Rows(0).Item("FOBID")
            Me.cbShipVia.SelectedValue = dtHeader.Rows(0).Item("ShipID")
            Me.txtShipDate.text = dtHeader.Rows(0).Item("ShipDate")
            Me.txtRemarks.Text = dtHeader.Rows(0).Item("Remarks")
            Me.tsUserInput.Text = dtHeader.Rows(0).Item("userInput")
            Me.tsInputDate.Text = FormatTanggal_View(dtHeader.Rows(0).Item("InputDate"))
            Me.tsUserUpdate.Text = dtHeader.Rows(0).Item("UserUpdate")
            Me.tsUpdateDate.Text = FormatTanggal_View(dtHeader.Rows(0).Item("UpdateDate"))


            Bind_Detail(Me.txtSOID.Text)
        End If

        biasa_arrow()

    End Sub

    Private Sub Bind_Detail(ByVal SOID As String)
        If cn5.State = ConnectionState.Open Then cn5.Close()
        cn5 = ax.cntsvr
        cmd5.Connection = cn5
        sqlstr = "[spSO_Detail] '" & SOID & "'"
        cmd5.CommandText = sqlstr
        dtRead5 = cmd5.ExecuteReader
        row = 0

        Me.dgDetail.Rows.Clear()
        Me.dgDetail.Refresh()

        Do Until dtRead5.Read = False
            Me.dgDetail.Rows.Add()
            Me.dgDetail.Item("NO", row).Value = dtRead5!No
            Me.dgDetail.Item("ITEMID", row).Value = dtRead5!ItemID
            Me.dgDetail.Item("ITEM", row).Value = dtRead5!ItemName
            Me.dgDetail.Item("QTYORDER", row).Value = dtRead5!QtyOrder
            Me.dgDetail.Item("UNIT", row).Value = dtRead5!Unit
            Me.dgDetail.Item("UNITPRICE", row).Value = dtRead5!UnitPrice
            Me.dgDetail.Item("DISC", row).Value = dtRead5!DiscAmount
            Me.dgDetail.Item("TOTALPRICE", row).Value = dtRead5!TotalPrice
            Me.dgDetail.Item("ROWID", row).Value = dtRead5!ID
            row += 1
        Loop
        dtRead5.Close()
        dtRead5 = Nothing

        dgDetail.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Bind_Summary()

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

    Private Sub SetDefaultValue()
        Me.txtSODate.Text = FormatTanggal_View(Date.Now)
        Me.txtDeliveryDate.Text = FormatTanggal_View(Date.Now)
        Me.txtPODate.Text = FormatTanggal_View(Date.Now)
        Me.txtShipDate.Text = FormatTanggal_View(Date.Now)

        Me.txtSONo.BackColor = Color.FromArgb(235, 235, 224)
        Me.cbCurrency.SelectedIndex = 0
        Me.cbPayment.SelectedIndex = 0
        Me.cbShipVia.SelectedIndex = 0
        Me.cbFOB.SelectedIndex = 0
        Me.txtKurs.Text = 0

        Me.txtDiscPct.Text = 0
        Me.txtDiscAmount.Text = 0
        Me.txtPpnPct.Text = 11
        Me.txtPphPct.Text = 0
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

        Me.dgDetail.Rows.Clear()
        Me.dgDetail.Refresh()

        SetDefaultValue()

        chkPenomoran.Checked = True
        Me.txtSONo.ReadOnly = True

        HighlightControl(Me.txtSODate)
        Me.txtSODate.Focus()

    End Sub


    Private Sub proc_edit()
        bbenar = True

        If bbenar Then
            'If sFinish = 1 Then
            '    MsgBox("Can Not Update Finish Spreading", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            sketproses = "EDIT"
            beditan = True
            tutup_tb_dan_field()
            Me.tbstmst.Items.Item("CANCEL").Enabled = True
            Me.tbstmst.Items.Item("UPDATEE").Enabled = True
            Me.tbstmst.Items.Item("DEL").Enabled = True
            Me.tbstmst.Items.Item("DELETEROW").Enabled = True
            buka_field_txt()

        Else
            sresponse = CStr(MsgBox(pesan, MsgBoxStyle.Critical))
            System.Windows.Forms.SendKeys.Send("{Home}+{End}")
        End If
    End Sub

    Private Sub proc_cancel()
        sresponse = CStr(MsgBox("Cancel Changes ( Y/N ) : ", MsgBoxStyle.YesNo))
        Try
            If sresponse = CStr(MsgBoxResult.Yes) Then
                If pID Is Nothing Then
                    Exit Sub
                End If
                biasa_arrow()
                sketproses = "FIND"
                Search_Data(pID)
            End If
        Catch ex As Exception
            biasa_arrow()
            MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DELETEROW_Click(sender As Object, e As EventArgs) Handles DELETEROW.Click
        If Me.dgDetail.RowCount > 0 Then
            If Me.dgDetail.Rows(Me.dgDetail.CurrentRow.Index).Selected = True Then
                Dim RowNo As String = dgDetail.Item(5, dgDetail.CurrentRow.Index).Value.ToString
                If Me.dgDetail.Focused = True Then
                    sresponse = CStr(MsgBox("Delete Item : " & dgDetail.Item(2, dgDetail.CurrentRow.Index).Value.ToString & "( Y/N ) : ", MsgBoxStyle.YesNo))
                    If sresponse = CStr(MsgBoxResult.Yes) Then
                        Try
                            Dim SqlDelItem As String = "spPR_DeleteItem '" & Me.txtSONo.Text & "','" & RowNo & "'"
                            Dim cmdDelItem = New SqlCommand(SqlDelItem, cn)
                            cmdDelItem.ExecuteNonQuery()

                            Me.dgDetail.Rows.RemoveAt(Me.dgDetail.CurrentRow.Index)

                            Bind_Detail(Me.txtSONo.Text)
                        Catch ex As Exception
                        End Try
                    End If

                End If
            End If
        End If


    End Sub


    Private Sub proc_save()
        bbenar = True
        Me.txtSONo.Focus()

        If Me.txtSODate.Text = "" Then
            bbenar = False
            pesan = "Isikan Tgl SO"
            Me.txtSODate.Focus()
            MsgBox(pesan)
            Exit Sub
        End If
        If Me.txtCustomer.Text = "" Then
            bbenar = False
            pesan = "Pilih Customer"
            Me.txtCustomer.Focus()
            MsgBox(pesan)
            Exit Sub
        End If
        If Me.txtDeliveryDate.Text = "" Then
            bbenar = False
            pesan = "Isikan Nomor PO Customer"
            Me.txtPONo.Focus()
            MsgBox(pesan)
            Exit Sub
        End If

        If Me.cbCurrency.Text = "" Then
            bbenar = False
            pesan = "Pilih Currency"
            Me.cbCurrency.Focus()
            MsgBox(pesan)
            Exit Sub
        End If

        If Me.cbPayment.Text = "" Then
            bbenar = False
            pesan = "Pilih Payment"
            Me.cbPayment.Focus()
            MsgBox(pesan)
            Exit Sub
        End If



        If bbenar Then
            tunggu_arrow()
            Save_Header()
            Save_Detail()

            isi_data(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text)
            select_cell = "CELLSELECT"

            sketproses = "FIND"
            Search_Data(Me.txtSOID.Text)
            Me.txtSONo.Focus()
            biasa_arrow()
        End If
    End Sub

    Private Sub Save_Header()
        If Me.txtKurs.Text = "" Then Me.txtKurs.Text = 0
        If txtDiscPct.Text = "" Then txtDiscPct.Text = 0
        If txtDiscAmount.Text = "" Then txtDiscAmount.Text = 0
        If txtPpnPct.Text = "" Then txtPpnPct.Text = 0
        If txtPpn.Text = "" Then txtPpn.Text = 0
        If txtPphPct.Text = "" Then txtPphPct.Text = 0
        If txtPph.Text = "" Then txtPph.Text = 0

        Dim cmdSave As New SqlCommand()
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "spSO_Save"
        cmdSave.Parameters.Add("@mode", SqlDbType.VarChar).Value = sketproses
        cmdSave.Parameters.Add("@SOID", SqlDbType.VarChar).Value = Me.txtSOID.Text
        cmdSave.Parameters.Add("@SoNo", SqlDbType.VarChar).Value = Me.txtSONo.Text
        cmdSave.Parameters.Add("@SODate", SqlDbType.Date).Value = FormatTanggal_Save(Me.txtSODate.Text)
        cmdSave.Parameters.Add("@PoNo", SqlDbType.VarChar).Value = Me.txtPONo.Text
        cmdSave.Parameters.Add("@PoDate", SqlDbType.Date).Value = FormatTanggal_Save(Me.txtPODate.Text)
        cmdSave.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = Me.txtCustomerID.Text
        cmdSave.Parameters.Add("@DeliveryDate", SqlDbType.Date).Value = FormatTanggal_Save(Me.txtDeliveryDate.Text)
        cmdSave.Parameters.Add("@DeliveryAddress", SqlDbType.VarChar).Value = Me.txtAddress.Text
        cmdSave.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Me.cbCurrency.SelectedValue
        cmdSave.Parameters.Add("@NilaiKurs", SqlDbType.Money).Value = Me.txtKurs.Text
        cmdSave.Parameters.Add("@Paymentterms", SqlDbType.VarChar).Value = Me.cbPayment.SelectedValue
        cmdSave.Parameters.Add("@FOB", SqlDbType.VarChar).Value = Me.cbFOB.SelectedValue
        cmdSave.Parameters.Add("@ShipVia", SqlDbType.VarChar).Value = Me.cbShipVia.SelectedValue
        cmdSave.Parameters.Add("@ShipDate", SqlDbType.Date).Value = Me.txtShipDate.Text
        cmdSave.Parameters.Add("@SubTotal", SqlDbType.Money).Value = CDbl(txtSubTotal.Text)
        cmdSave.Parameters.Add("@DiscPct", SqlDbType.Real).Value = CDbl(txtDiscPct.Text)
        cmdSave.Parameters.Add("@DiscAmount", SqlDbType.Money).Value = CDbl(txtDiscAmount.Text)
        cmdSave.Parameters.Add("@PpnPct", SqlDbType.Real).Value = CDbl(txtPpnPct.Text)
        cmdSave.Parameters.Add("@Ppn", SqlDbType.Money).Value = CDbl(txtPpn.Text)
        cmdSave.Parameters.Add("@PphPct", SqlDbType.Real).Value = CDbl(txtPphPct.Text)
        cmdSave.Parameters.Add("@Pph", SqlDbType.Money).Value = CDbl(txtPph.Text)
        cmdSave.Parameters.Add("@Total", SqlDbType.Money).Value = CDbl(Me.txtTotal.Text)
        cmdSave.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Me.txtRemarks.Text
        cmdSave.Parameters.Add("@UserID", SqlDbType.VarChar).Value = siduser.Trim
        cmdSave.Parameters.Add("@DocID_New", SqlDbType.VarChar, 10)
        cmdSave.Parameters("@DocID_New").Direction = ParameterDirection.Output
        cmdSave.Connection = cn
        Try
            cmdSave.ExecuteNonQuery()
            If sketproses = "ADD" Then
                pID = cmdSave.Parameters("@DocID_New").Value.ToString
                Me.txtSOID.Text = pID
            Else
                pID = Me.txtSOID.Text
            End If
        Catch ex As Exception
            bbenar = False
        Finally
        End Try
    End Sub

    Private Sub Save_Detail()
        For Each row As DataGridViewRow In dgDetail.Rows
            Dim bSave As Boolean = True

            If row.Cells("ITEM").Value <> "" Then
                If row.Cells("QTYORDER").Value Is Nothing Then row.Cells("QTYORDER").Value = 0
                If row.Cells("DISC").Value Is Nothing Then row.Cells("DISC").Value = 0
                If row.Cells("UNITPRICE").Value Is Nothing Then row.Cells("UNITPRICE").Value = 0
                If row.Cells("TOTALPRICE").Value Is Nothing Then row.Cells("TOTALPRICE").Value = 0
                If row.Cells("ROWID").Value Is Nothing Then row.Cells("ROWID").Value = 0
                If row.Cells("UNIT").Value Is Nothing Then row.Cells("UNIT").Value = "PC"
                If row.Cells("NOTES").Value Is Nothing Then row.Cells("NOTES").Value = ""


                Dim cmdSaveDetail As New SqlCommand()
                cmdSaveDetail.CommandType = CommandType.StoredProcedure
                cmdSaveDetail.CommandText = "[spSO_Save_Detail]"
                cmdSaveDetail.Parameters.Add("@mode", SqlDbType.VarChar).Value = sketproses
                cmdSaveDetail.Parameters.Add("@SOID", SqlDbType.VarChar).Value = Me.txtSOID.Text
                cmdSaveDetail.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = row.Cells("ITEMID").Value
                cmdSaveDetail.Parameters.Add("@QtyOrder", SqlDbType.Money).Value = IIf(IsDBNull(row.Cells("QTYORDER").Value), 0, row.Cells("QTYORDER").Value)
                cmdSaveDetail.Parameters.Add("@Unit", SqlDbType.VarChar).Value = IIf(IsDBNull(row.Cells("UNIT").Value), "", row.Cells("UNIT").Value.ToString)
                cmdSaveDetail.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = IIf(IsDBNull(row.Cells("UNITPRICE").Value), 0, row.Cells("UNITPRICE").Value)
                cmdSaveDetail.Parameters.Add("@Disc", SqlDbType.Money).Value = IIf(IsDBNull(row.Cells("DISC").Value), 0, row.Cells("DISC").Value)
                cmdSaveDetail.Parameters.Add("@TotalPrice", SqlDbType.Money).Value = IIf(IsDBNull(row.Cells("TOTALPRICE").Value), 0, row.Cells("TOTALPRICE").Value)
                cmdSaveDetail.Parameters.Add("@Notes", SqlDbType.VarChar).Value = row.Cells("NOTES").Value
                cmdSaveDetail.Parameters.Add("@ID", SqlDbType.BigInt).Value = row.Cells("ROWID").Value
                cmdSaveDetail.Connection = cn
                Try
                    cmdSaveDetail.ExecuteNonQuery()
                Catch ex As Exception
                    bSave = False
                    MsgBox("Save Detail Error", MsgBoxStyle.Critical, "E R R O R")
                    biasa_arrow()
                Finally
                End Try

            End If
        Next
    End Sub

    Private Sub isi_data(ByVal SOID As String, ByVal SONo As String, ByVal SODate As String)

        Dim ds As New DataSet
        pesan = "GRID LIST"
        Try
            Dim SqlStrEmp As String = "[spSO_List] '" & SOID & "', '" & SONo & "','" & SODate & "'"

            Dim adapter = New SqlDataAdapter(SqlStrEmp, cn)
            adapter.Fill(ds)
            Me.dgfind.DataSource = ds.Tables(0)

            widthchange = False

            Me.dgfind.Columns(0).Width = Me.split_find1.Panel1.Width
            Me.dgfind.Columns(1).Width = Me.split_find2.Panel1.Width
            Me.dgfind.Columns(2).Width = Me.split_find2.Panel2.Width
            Me.dgfind.ReadOnly = True
            widthchange = True
            Me.dgfind.AllowUserToAddRows = False
            Me.dgfind.AllowUserToDeleteRows = False

            dgfind_ColumnWidthChanged(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub


    Private Sub dgfind_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgfind.ColumnWidthChanged
        Try
            If widthchange Then
                Me.split_find1.SplitterDistance = Me.dgfind.Columns(0).Width
                Me.split_find2.SplitterDistance = Me.dgfind.Columns(1).Width
                Me.dgfind.Columns(2).Width = Me.split_find2.Panel2.Width
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If widthchange Then
            widthchange = False
            Me.dgfind.Columns(0).Width = Me.split_find1.Panel1.Width
            Me.dgfind.Columns(1).Width = Me.split_find2.Panel1.Width
            Me.dgfind.Columns(2).Width = Me.split_find2.Panel2.Width
            widthchange = True
        End If
    End Sub

    Private Sub dgfind_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgfind.CurrentCellChanged, dgfind.CellClick
        If dgfind.SelectedCells.Count = 0 Then
        Else
            If (sketproses = "COPY" Or sketproses = "ADD" Or sketproses = "EDIT" Or sketproses = "UPDATEE" Or sketproses = "SAVE") Then
            Else
                pID = IIf(IsDBNull(dgfind.Item("SOID", dgfind.CurrentRow.Index).Value), "", dgfind.Item("SOID", dgfind.CurrentRow.Index).Value)
                sketproses = "FIND"
                select_cell = "CELLSELECT"
                Search_Data(pID)
            End If
        End If
    End Sub


    Private Sub HighlightControl(ByVal ctl As Control)
        ctl.BackColor = Color.FromArgb(255, 255, 128)
    End Sub

    Private Sub tutup_tb_dan_field()
        For urut = 0 To Me.tbstmst.Items.Count - 1
            Me.tbstmst.Items.Item(urut).Enabled = False
        Next urut
        Me.tbstmst.Items.Item("EXITT").Enabled = True

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
        GridControl(True)
    End Sub

    Private Sub GridControl(ByVal mode As Boolean)
        Me.dgDetail.AllowUserToAddRows = mode
        Me.dgDetail.AllowUserToDeleteRows = mode

        For Each dgC As DataGridViewColumn In dgDetail.Columns
            If (dgC.Index = 0 Or dgC.Index = 1 Or dgC.Index = 2 Or dgC.Index = 4 Or dgC.Index = 7 Or dgC.Index = 8 Or dgC.Index = 9) Then
                dgC.ReadOnly = True
            Else
                dgC.ReadOnly = IIf(mode = True, False, True)
            End If

        Next
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
                DirectCast(ctl, ComboBox).SelectedIndex = -1

            ElseIf TypeOf (ctl) Is DateTimePicker Then
                DirectCast(ctl, DateTimePicker).Value = "1/1/1900"
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    ClearControl(ctl.Controls)
                End If
            End If
        Next
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


    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        stxtgetfromgrid = "N"
        spasscari = "FIND_CUSTOMER"
        titleformcari = "Find Customer "
        Dim frm As New GridCari
        Dim x As Integer = 0
        frm.ShowDialog()
        If stxtgetfromgrid = "Y" Then
            Me.txtCustomerID.Text = getgridcari(0, 1)
            Me.txtCustomer.Text = getgridcari(0, 2)
            Me.txtAddress.Text = getgridcari(0, 3)

            Me.txtAddress.Focus()
        End If
    End Sub


    Private Sub dgDetail_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellDoubleClick
        Dim kolom As Integer
        Dim namakolom As String
        nmkolom = ""
        kolom = e.ColumnIndex
        If kolom >= 0 And (sketproses = "ADD" Or sketproses = "EDIT" Or sketproses = "UPDATEE" Or sketproses = "SAVE") Then
            namakolom = Me.dgDetail.Columns(e.ColumnIndex).Name
            Select Case UCase(namakolom)
                Case "ITEMID", "ITEM"
                    stxtgetfromgrid = "N"
                    titleformcari = "FIND MATERIAL"
                    spasscari = "FIND_MATERIAL_ITEM"
                    gridcaricode1 = ""
                    GridCari.ShowDialog()
                    If stxtgetfromgrid = "Y" Then
                        Dim x As Integer = e.RowIndex
                        Dim isi As Boolean = False
                        For iarray As Integer = 0 To UBound(getgridcari) - 1

                            If IIf(IsDBNull(getgridcari(iarray, 1)), "", getgridcari(iarray, 1)) <> "" Then

                                Dim i As Integer = 0
                                Dim NotExist As Boolean = True
                                For i = 0 To dgDetail.Rows.Count - 1
                                    If getgridcari(iarray, 1) = Me.dgDetail.Item("ITEMID", i).Value Then
                                        NotExist = False
                                    End If
                                Next

                                If Me.dgDetail.RowCount - 1 <= x And NotExist = True Then
                                    Me.dgDetail.Rows.Add()
                                End If

                                If x <= -1 Then
                                    x += 1
                                    Me.dgDetail.Rows.Insert(x)
                                Else
                                    If IIf(IsDBNull(Me.dgDetail.Item("ITEMID", x).Value), "", Me.dgDetail.Item("ITEMID", x).Value) <> "" And isi = True Then
                                        x += 1
                                        Me.dgDetail.Rows.Insert(x)

                                    End If
                                End If
                                If NotExist Then
                                    Me.dgDetail.Item("ITEMID", x).Value = getgridcari(iarray, 1)
                                    Me.dgDetail.Item("ITEM", x).Value = getgridcari(iarray, 2)
                                    dgDetail.CurrentCell = dgDetail.Rows(e.RowIndex).Cells(3)
                                    dgDetail.BeginEdit(False)


                                    dgDetail.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                    dgDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                                End If

                                isi = True
                            End If
                        Next iarray

                    End If

                Case "UNIT"
                    Dim iarray As Short
                    stxtgetfromgrid = "N"
                    titleformcari = "FIND UNIT"
                    spasscari = "FIND_UNIT"

                    GridCari.ShowDialog()
                    If stxtgetfromgrid = "Y" Then
                        Me.dgDetail.Item("UNIT", e.RowIndex).Value = getgridcari(iarray, 1)

                    End If

                Case "QTY", "UNITPRICE"
                    Bind_Summary()
            End Select
        End If
    End Sub


    Private Sub dgDetail_GetSummary(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEndEdit, dgDetail.CellLeave
        Dim kolom As Integer
        Dim namakolom As String
        nmkolom = ""
        kolom = e.ColumnIndex
        If kolom >= 0 And (sketproses = "ADD" Or sketproses = "EDIT" Or sketproses = "UPDATEE" Or sketproses = "SAVE") Then
            namakolom = Me.dgDetail.Columns(e.ColumnIndex).Name
            Select Case UCase(namakolom)
                Case "QTYORDER", "UNITPRICE", "DISC"
                    Dim Qty As Double = Val(Me.dgDetail.Item("QTYORDER", e.RowIndex).Value)
                    Dim UnitPrice As Double = Val(Me.dgDetail.Item("UNITPRICE", e.RowIndex).Value)
                    Dim Disc As Double = Val(Me.dgDetail.Item("DISC", e.RowIndex).Value)
                    Dim TotalPrice As Double = (Qty * UnitPrice) - Disc

                    Me.dgDetail.Item("TOTALPRICE", e.RowIndex).Value() = TotalPrice
                    Bind_Summary()
            End Select
        End If
    End Sub
    Private Sub TextboxFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged
        isi_data(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text)
    End Sub

    Private Sub TexboxNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKurs.KeyPress, txtSubTotal.KeyPress, txtDiscAmount.KeyPress, txtPpn.KeyPress, txtTotal.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub TexboxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscPct.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub Dropdown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbCurrency.KeyPress, cbPayment.KeyPress
        e.Handled = True
    End Sub



    Private Sub Bind_Summary()
        If Me.txtDiscAmount.Text = "" Then Me.txtDiscAmount.Text = 0
        If Me.txtPpnPct.Text = "" Then Me.txtPpnPct.Text = 0
        If Me.txtPphPct.Text = "" Then Me.txtPphPct.Text = 0

        If Me.dgDetail.Rows.Count > 0 Then

            Dim TotalPrice As Double = 0,
                Disc As Double = 0,
                Ppn As Double = 0,
                Pph As Double = 0,
                Total As Double = 0

            For i As Integer = 0 To dgDetail.Rows.Count() - 1 Step +1
                TotalPrice = TotalPrice + dgDetail.Rows(i).Cells(7).Value
            Next

            Disc = CDbl(Me.txtDiscAmount.Text)
            Me.txtSubTotal.Text = FormatNumber(TotalPrice, 0)

            Ppn = (Me.txtPpnPct.Text / 100) * TotalPrice
            Me.txtPpn.Text = FormatNumber(Ppn, 0)

            Pph = (Me.txtPphPct.Text / 100) * TotalPrice
            Me.txtPph.Text = Pph

            Total = TotalPrice - Disc + Ppn + Pph
            Me.txtTotal.Text = FormatNumber(Total, 0)
        End If
    End Sub



    Private Sub DGV_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgDetail.EditingControlShowing
        '       '*************Allow only Numbers in DataGridView*************
        Dim txtEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtEdit.KeyPress, AddressOf TextEdit_Keypress
        AddHandler txtEdit.KeyPress, AddressOf TextEdit_Keypress
    End Sub

    Private Sub TextEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        If (dgDetail.CurrentCell.ColumnIndex = 3 Or dgDetail.CurrentCell.ColumnIndex = 5 Or dgDetail.CurrentCell.ColumnIndex = 6 Or dgDetail.CurrentCell.ColumnIndex = 7) Then
            If IsNumeric(e.KeyChar.ToString()) Or e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False 'if numeric display
            Else
                e.Handled = True  'if non numeric don't display
            End If
        End If
    End Sub


    Private Sub btnPpn_Click(sender As Object, e As EventArgs) Handles btnPpn.Click
        stxtgetfromgrid = "N"
        spasscari = "FIND_TAX"
        titleformcari = "Find Ppn"
        gridcaricode1 = "PPN"
        Dim frm As New GridCari
        Dim x As Integer = 0
        frm.ShowDialog()


        If stxtgetfromgrid = "Y" Then
            Me.txtPpnPct.Text = getgridcari(0, 1)
            Bind_Summary()
        End If
    End Sub


    Private Sub btnPph_Click(sender As Object, e As EventArgs) Handles btnPph.Click
        stxtgetfromgrid = "N"
        spasscari = "FIND_TAX"
        titleformcari = "Find Pph"
        gridcaricode1 = "PPH"
        Dim frm As New GridCari
        Dim x As Integer = 0
        frm.ShowDialog()


        If stxtgetfromgrid = "Y" Then
            Me.txtPphPct.Text = getgridcari(0, 1)
            Bind_Summary()
        End If
    End Sub

    Private Sub chkPenomoran_CheckedChanged(sender As Object, e As EventArgs) Handles chkPenomoran.CheckedChanged
        If Me.chkPenomoran.Checked = True Then
            Me.txtSONo.ReadOnly = True
        Else
            Me.txtSONo.ReadOnly = False
        End If
    End Sub

    Private Sub PRINT_PO_Click(sender As Object, e As EventArgs) Handles PRINT_PO.Click
        Try

            pesan = "PurchaseOrder"
            Dim cryRpt As New ReportDocument

            ReportViewerSQL.CrystalReportViewer1.ReportSource = Nothing
            cryRpt.Load(pdir & "\" & "SalesOrder.rpt")
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table

            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterValues As ParameterValues
            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim crParameterFieldLocation As ParameterFieldDefinition

            With crConnectionInfo
                .ServerName = sserver
                .DatabaseName = sdbs
                .UserID = suid
                .Password = spwd
            End With

            CrTables = cryRpt.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            'Me.CR_View.ToolPanelView = False
            ReportViewerSQL.CrystalReportViewer1.ToolPanelView = False
            'cryRpt.DataDefinition.FormulaFields(1).Text = LoginForm.get_date_server

            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields

            crParameterFieldLocation = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            crParameterDiscreteValue.Value = Me.txtSOID.Text.Trim
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            ReportViewerSQL.CrystalReportViewer1.ReportSource = cryRpt
            ReportViewerSQL.Show()

        Catch ex As Exception
            biasa_arrow()
            MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class