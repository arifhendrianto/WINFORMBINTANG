Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlTransaction
Imports System.Data.OleDb.OleDbTransaction
Imports System.Data.Odbc.OdbcConnection
Imports System.DBNull

Public Class GridCari
    Dim strtampung1, strtampung As String
    Dim jumrow As Integer = 0 

    Dim ax As New MyGlobal
    Dim axtemp As New MyGlobal
    Dim tmprptcn As New OleDb.OleDbConnection
    Dim cn As New SqlConnection
    Dim cmdsql1 As New SqlCommand
    Dim dtReadsql1 As SqlDataReader

    Dim cn2 As New SqlConnection
    Dim cmdsql2 As New SqlCommand
    Dim dtReadsql2 As SqlDataReader

    Dim cmdtmp As New OleDb.OleDbCommand
    Dim dtReadtmp As OleDb.OleDbDataReader
    Dim Fnd As Boolean = True
    Dim widthchange As Boolean = False
    Dim centerscreen As Boolean = False
    Dim jmlkolomfind As Integer = 0 ' jumlah kolom yg akan di tampilkan yg bisa di find. hitung 1 dari field pertama, jika ada check , hitung mulai dari 2 dari field pertama
    Dim jmlttlkolomfindhide As Integer = 0 ' jumlah total field ya di query hitung dari 0 field pertama. jika ada check hitung 1 dari field pertama (di isi jika ada kolom yang akan di hidden)
    Dim isiGrid As String = ""

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Clear_gridcari()
        Dim col As Integer
        For jumrow = 0 To UBound(getgridcari) Step 1
            For col = 0 To 25
                getgridcari(jumrow, col) = ""
            Next
        Next

        For row As Integer = 0 To Me.ssdgcari.ColumnCount - 1
            Me.ssdgcari.Columns(row).ReadOnly = True
            Me.ssdgcari.Columns(row).HeaderText = ""
        Next
        Me.ssdgcari.AllowUserToAddRows = False
        Me.ssdgcari.AllowUserToDeleteRows = False
        stxtgetfromgrid = "N"
        strtampung = ""
        sqlstr1 = ""
        Me.lbcolomfnd1.Text = ""
        Me.lbcolomfnd2.Text = ""
        Me.lbcolomfnd3.Text = ""
        Me.lbcolomfnd4.Text = ""
        Me.lbcolomfnd5.Text = ""
        Me.lbcolomfnd6.Text = ""
        Me.lbcolomfnd7.Text = ""
        Me.lbcolomfnd8.Text = ""
        Me.lbcolomfnd9.Text = ""
        Me.lbcolomfnd10.Text = ""
        Me.lbcolomfnd11.Text = ""
        Me.lbcolomfnd12.Text = ""
        Me.lbcolomfnd13.Text = ""
        Me.lbcolomfnd14.Text = ""
        Me.lbcolomfnd15.Text = ""
        Me.lbcolomfnd16.Text = ""
        Me.lbcolomfnd17.Text = ""
        Me.lbcolomfnd18.Text = ""
        Me.lbcolomfnd19.Text = ""
        Me.lbcolomfnd20.Text = ""
        Me.lbcolomfnd21.Text = ""

        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.TextBox4.Text = ""
        Me.TextBox5.Text = ""
        Me.TextBox6.Text = ""
        Me.TextBox7.Text = ""
        Me.TextBox8.Text = ""
        Me.TextBox9.Text = ""
        Me.TextBox10.Text = ""
        Me.TextBox11.Text = ""
        Me.TextBox12.Text = ""
        Me.TextBox13.Text = ""
        Me.TextBox14.Text = ""
        Me.TextBox15.Text = ""
        Me.TextBox16.Text = ""
        Me.TextBox17.Text = ""
        Me.TextBox18.Text = ""
        Me.TextBox19.Text = ""
        Me.TextBox20.Text = ""
        Me.TextBox21.Text = ""
        All_Item.Visible = True
        All_Item.Checked = False
    End Sub

    Private Sub GridCari_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            centerscreen = True
            Me.txtspasscari.Visible = False
            Me.txtisiGrid.Visible = False
            Me.txtisiQuery.Visible = False
            tunggu_arrow()
            Clear_gridcari()
            ssdgcari.ColumnHeadersVisible = False
            Me.Title1.Text = titleformcari
            Select Case spasscari
                Case "FIND_SECTION"
                    isi_data_find_Section()

                Case "FIND_MATERIAL_ITEM"
                    isi_data_find_Material()

                Case "FIND_UNIT"
                    isi_data_find_Unit()

                Case "FIND_CUSTOMER"
                    isi_data_find_Customer()

                Case "FIND_SUPPLIER"
                    isi_data_find_Supplier()

                Case "FIND_PR"
                    isi_data_find_PR()
                   
                Case "FIND_TAX"
                    isi_data_find_Tax()


             
                Case Else
                    Exit Sub
            End Select
            widthchange = True
            GridCari_ResizeEnd(eventSender, eventArgs)
            ResizeForm()
            biasa_arrow()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridCari_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        biasa_arrow()
    End Sub
   
    Private Sub ssdgcari_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ssdgcari.CellClick
        Dim kolom As Integer
        Dim namakolom As String 
        kolom = e.ColumnIndex
        If kolom >= 0 Then
            namakolom = ssdgcari.Columns(e.ColumnIndex).Name
            Select Case UCase(namakolom)
                Case "CHK"
                    'Select Case spasscari
                    '    Case "FIND_EMPLOYEE_SPL"
                    '        stxtgetfromgrid = "Y"
                    '        getgridcari(0, 1) = Trim(ssdgcari.Item("EMPLOYEENO", e.RowIndex).Value)
                    '        getgridcari(0, 2) = Trim(ssdgcari.Item("FIRSTNAME", e.RowIndex).Value)
                    '        getgridcari(0, 3) = ssdgcari.Item("PHOTO", e.RowIndex).Value
                    '        getgridcari(0, 4) = Trim(ssdgcari.Item("DIVISIONID", e.RowIndex).Value)
                    '        getgridcari(0, 5) = Trim(ssdgcari.Item("DESCRIPTIONDIVISION", e.RowIndex).Value)
                    '        getgridcari(0, 6) = Trim(ssdgcari.Item("SECTIONID", e.RowIndex).Value)
                    '        getgridcari(0, 7) = Trim(ssdgcari.Item("DESCRIPTIONSECTION", e.RowIndex).Value)
                    '        getgridcari(0, 8) = ssdgcari.Item("HASOVERTIME", e.RowIndex).Value

                    '        Dim isi As Boolean = False
                    '        For x As Integer = 0 To HRD_DE_SPL.dgdetail_01.RowCount - 1

                    '            If getgridcari(0, 1) <> "" Then
                    '                If HRD_DE_SPL.dgdetail_01.RowCount - 1 <= x Then
                    '                    HRD_DE_SPL.dgdetail_01.Rows.Add()
                    '                End If
                    '                If x <= -1 Then
                    '                    x += 1
                    '                    HRD_DE_SPL.dgdetail_01.Rows.Insert(x)
                    '                Else
                    '                    If HRD_DE_SPL.dgdetail_01.Item("NIK_01", x).Value <> "" And isi = True Then
                    '                        x += 1
                    '                        HRD_DE_SPL.dgdetail_01.Rows.Insert(x)
                    '                    End If
                    '                End If

                    '                HRD_DE_SPL.dgdetail_01.Item("NIK_01", x).Value = getgridcari(0, 1)
                    '                HRD_DE_SPL.dgdetail_01.Item("NAMA_01", x).Value = getgridcari(0, 2)
                    '                HRD_DE_SPL.dgdetail_01.Item("PHOTO_01", x).Value = getgridcari(0, 3)
                    '                HRD_DE_SPL.dgdetail_01.Item("DIVISIONID_01", x).Value = getgridcari(0, 4)
                    '                HRD_DE_SPL.dgdetail_01.Item("SECTIONID_01", x).Value = getgridcari(0, 6)
                    '                HRD_DE_SPL.dgdetail_01.Item("DESCRIPTIONSECTION_01", x).Value = getgridcari(0, 7)
                    '                HRD_DE_SPL.dgdetail_01.Item("HASOT_01", x).Value = getgridcari(0, 4)
                    '                HRD_DE_SPL.dgdetail_01.Item("START_01", x).Value = HRD_DE_SPL.txtStartOT.Text
                    '                HRD_DE_SPL.dgdetail_01.Item("END_01", x).Value = HRD_DE_SPL.txtEndOT.Text
                    '                HRD_DE_SPL.dgdetail_01.Item("HOUROT_01", x).Value = HRD_DE_SPL.txtHourOT.Text
                    '                isi = True
                    '            End If
                    '        Next iarray
                    'End Select
               
            End Select

        End If
    End Sub
 
    Private Sub ssdgcari_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ssdgcari.CellDoubleClick ', Btn_Enter.Click
        ssdgcari_KLIK(e.ColumnIndex, e.RowIndex)
    End Sub
    Private Sub ssdgcari_KLIK(kolom As Integer, row As Integer)
        tunggu_arrow()
        bbenar = True

        Select Case spasscari
           
            Case "FIND_SECTION"
                stxtgetfromgrid = "Y"
                getgridcari(0, 1) = Trim(ssdgcari.Item("SECTIONID", row).Value)
                getgridcari(0, 2) = Trim(ssdgcari.Item("SECTION", row).Value)

            Case "FIND_MATERIAL_ITEM"
                stxtgetfromgrid = "Y"
                getgridcari(0, 1) = Trim(ssdgcari.Item("ITEMID", row).Value)
                getgridcari(0, 2) = Trim(ssdgcari.Item("ITEMNAME", row).Value)
                getgridcari(0, 3) = Trim(ssdgcari.Item("ITEMCATEGORY", row).Value)
                getgridcari(0, 4) = Trim(ssdgcari.Item("COMPOSITION", row).Value)
                getgridcari(0, 5) = Trim(ssdgcari.Item("UNIT", row).Value)


            Case "FIND_CUSTOMER"
                stxtgetfromgrid = "Y"
                getgridcari(0, 1) = Trim(ssdgcari.Item("CustomerID", row).Value)
                getgridcari(0, 2) = Trim(ssdgcari.Item("CustName", row).Value)
                getgridcari(0, 3) = Trim(ssdgcari.Item("Address1", row).Value)
                getgridcari(0, 4) = Trim(ssdgcari.Item("Address2", row).Value)
                getgridcari(0, 5) = Trim(ssdgcari.Item("Phone1", row).Value)
                getgridcari(0, 6) = Trim(ssdgcari.Item("Fax", row).Value)


            Case "FIND_SUPPLIER"
                stxtgetfromgrid = "Y"
                getgridcari(0, 1) = Trim(ssdgcari.Item("SuppID", row).Value)
                getgridcari(0, 2) = Trim(ssdgcari.Item("SuppName", row).Value)
                getgridcari(0, 3) = Trim(ssdgcari.Item("Address1", row).Value)
                getgridcari(0, 4) = Trim(ssdgcari.Item("Address2", row).Value)
                getgridcari(0, 5) = Trim(ssdgcari.Item("Phone1", row).Value)
                getgridcari(0, 6) = Trim(ssdgcari.Item("Fax", row).Value)


            Case "FIND_UNIT"
                stxtgetfromgrid = "Y"
                getgridcari(0, 1) = Trim(ssdgcari.Item("UNIT", row).Value)

            Case "FIND_TAX"
                stxtgetfromgrid = "Y"
                getgridcari(0, 1) = Trim(ssdgcari.Item("TAX", row).Value)

 
            Case "FIND_PR"
                Dim Y As Integer = 0
                For x As Integer = 0 To ssdgcari.RowCount - 1
                    If ssdgcari.Item("CHK", x).Value = True Then

                        stxtgetfromgrid = "Y"
                        getgridcari(Y, 1) = ssdgcari.Item("PRNo", x).Value
                        getgridcari(Y, 2) = ssdgcari.Item("PRDate", x).Value
                        getgridcari(Y, 3) = ssdgcari.Item("ItemName", x).Value
                        getgridcari(Y, 4) = ssdgcari.Item("Section", x).Value
                        Y += 1
                    End If
                Next x
        End Select
        biasa_arrow()
        If bbenar Then
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            Me.Close()
        End If
    End Sub
    Private Sub ResizeForm()
        Dim lebarform As Integer = 30
        For x As Integer = 0 To jmlkolomfind - 1
            If Me.ssdgcari.Columns(x).Visible Then
                lebarform = lebarform + Me.ssdgcari.Columns(x).Width
            End If
        Next
        Me.Width = lebarform
        If centerscreen = True Then
            Me.CenterToScreen()
            centerscreen = False
        End If 
    End Sub
     
    Private Sub isi_data_find_Section()
        pesan = "isi grid " & titleformcari
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        sqlstr1 = ""
        Try
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            ssdgcari.Columns.Clear()
            ssdgcari.Refresh()

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            sqlstr = "select SectionID, Section from Section Where SectionID<>0  "


            If Trim(Me.TextBox1.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (a.SectionID like '" & Trim(Me.TextBox1.Text) & "%') "
            End If
            If Trim(Me.TextBox2.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (a.Section like '" & Trim(Me.TextBox2.Text) & "%') "
            End If
            If sqlstr1 <> "" Then
                sqlstr = sqlstr & " where " & sqlstr1
            End If

            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)
            If cn.State = ConnectionState.Open Then cn.Close()
            Me.ssdgcari.ReadOnly = False
            Me.ssdgcari.DataSource = ds.Tables(0)

            widthchange = False
            jmlkolomfind = 2
            jmlttlkolomfindhide = 0

            Me.lbcolomfnd1.Text = "Section ID"
            Me.lbcolomfnd2.Text = "Section Name"
            Me.ssdgcari.Columns(0).Width = 60
            Me.ssdgcari.Columns(1).Width = 250
            
            For urut = 0 To ssdgcari.Columns.Count - 1
                ssdgcari.Columns(urut).ReadOnly = True
            Next

            ResizeForm()
            widthchange = True
        Catch ex As Exception
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub isi_data_find_Material()
        pesan = "isi grid " & titleformcari
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        sqlstr1 = ""
        Try
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            ssdgcari.Columns.Clear()
            ssdgcari.Refresh()

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            sqlstr = "select ItemID, ItemName, ItemCategory, Composition, Unit From material  Where ItemID<>0  "


            If Trim(Me.TextBox1.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (ItemID like '" & Trim(Me.TextBox1.Text) & "%') "
            End If
            If Trim(Me.TextBox2.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (ItemName like '" & Trim(Me.TextBox2.Text) & "%') "
            End If

            If Trim(Me.TextBox3.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (ItemCategory like '" & Trim(Me.TextBox3.Text) & "%') "
            End If

            If Trim(Me.TextBox4.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Composition like '" & Trim(Me.TextBox4.Text) & "%') "
            End If

            If Trim(Me.TextBox5.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Unit like '" & Trim(Me.TextBox5.Text) & "%') "
            End If


            If sqlstr1 <> "" Then
                sqlstr = sqlstr & " where " & sqlstr1
            End If

            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)
            If cn.State = ConnectionState.Open Then cn.Close()
            Me.ssdgcari.ReadOnly = False
            Me.ssdgcari.DataSource = ds.Tables(0)

            widthchange = False
            jmlkolomfind = 5
            jmlttlkolomfindhide = 0

            Me.lbcolomfnd1.Text = "Item ID"
            Me.lbcolomfnd2.Text = "Material Item Name"
            Me.lbcolomfnd3.Text = "Category"
            Me.lbcolomfnd4.Text = "Composition"
            Me.lbcolomfnd5.Text = "Unit"

            Me.ssdgcari.Columns(0).Width = 100
            Me.ssdgcari.Columns(1).Width = 400
            Me.ssdgcari.Columns(2).Width = 60
            Me.ssdgcari.Columns(3).Width = 100
            Me.ssdgcari.Columns(4).Width = 60

            For urut = 0 To ssdgcari.Columns.Count - 1
                ssdgcari.Columns(urut).ReadOnly = True
            Next

            ResizeForm()
            widthchange = True
        Catch ex As Exception
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub
 
    Private Sub isi_data_find_Unit()
        pesan = "isi grid " & titleformcari
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        sqlstr1 = ""
        Try
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            ssdgcari.Columns.Clear()
            ssdgcari.Refresh()

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            sqlstr = "select Unit From Unit Where UnitID<>0  "


            If Trim(Me.TextBox1.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Unit like '" & Trim(Me.TextBox1.Text) & "%') "
            End If
            
            If sqlstr1 <> "" Then
                sqlstr = sqlstr & " where " & sqlstr1
            End If

            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)
            If cn.State = ConnectionState.Open Then cn.Close()
            Me.ssdgcari.ReadOnly = False
            Me.ssdgcari.DataSource = ds.Tables(0)

            widthchange = False
            jmlkolomfind = 1
            jmlttlkolomfindhide = 0

            Me.lbcolomfnd1.Text = "Unit"

            Me.ssdgcari.Columns(0).Width = 100
         
            For urut = 0 To ssdgcari.Columns.Count - 1
                ssdgcari.Columns(urut).ReadOnly = True
            Next

            ResizeForm()
            widthchange = True
        Catch ex As Exception
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub isi_data_find_Customer()
        pesan = "isi grid " & titleformcari
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        sqlstr1 = ""
        Try
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            ssdgcari.Columns.Clear()
            ssdgcari.Refresh()

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            sqlstr = "select CustomerID, CustName,Address1, Address2,Phone1, Fax From Customer   Where CustomerID<>0  "


            If Trim(Me.TextBox1.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (CustomerID like '" & Trim(Me.TextBox1.Text) & "%') "
            End If
            If Trim(Me.TextBox2.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (CustName like '" & Trim(Me.TextBox2.Text) & "%') "
            End If

            If Trim(Me.TextBox3.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Address1 like '" & Trim(Me.TextBox3.Text) & "%') "
            End If

            If Trim(Me.TextBox4.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Address2 like '" & Trim(Me.TextBox4.Text) & "%') "
            End If

            If Trim(Me.TextBox5.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Phone1 like '" & Trim(Me.TextBox5.Text) & "%') "
            End If

            If Trim(Me.TextBox6.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Fax like '" & Trim(Me.TextBox6.Text) & "%') "
            End If


            If sqlstr1 <> "" Then
                sqlstr = sqlstr & " where " & sqlstr1
            End If

            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)
            If cn.State = ConnectionState.Open Then cn.Close()
            Me.ssdgcari.ReadOnly = False
            Me.ssdgcari.DataSource = ds.Tables(0)

            widthchange = False
            jmlkolomfind = 6
            jmlttlkolomfindhide = 0

            Me.lbcolomfnd1.Text = "CustomerID"
            Me.lbcolomfnd2.Text = "Name"
            Me.lbcolomfnd3.Text = "Address1"
            Me.lbcolomfnd4.Text = "Address2"
            Me.lbcolomfnd5.Text = "Phone"
            Me.lbcolomfnd6.Text = "Fax"

            Me.ssdgcari.Columns(0).Width = 80
            Me.ssdgcari.Columns(1).Width = 200
            Me.ssdgcari.Columns(2).Width = 300
            Me.ssdgcari.Columns(3).Width = 300
            Me.ssdgcari.Columns(4).Width = 75
            Me.ssdgcari.Columns(5).Width = 75

            For urut = 0 To ssdgcari.Columns.Count - 1
                ssdgcari.Columns(urut).ReadOnly = True
            Next

            ResizeForm()
            widthchange = True
        Catch ex As Exception
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub


    Private Sub isi_data_find_Supplier()
        pesan = "isi grid " & titleformcari
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        sqlstr1 = ""
        Try
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            ssdgcari.Columns.Clear()
            ssdgcari.Refresh()

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            sqlstr = "select SuppID, SuppName,Address1, Address2,Phone1, Fax From Supplier   Where SuppID<>0  "


            If Trim(Me.TextBox1.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (SuppID like '" & Trim(Me.TextBox1.Text) & "%') "
            End If
            If Trim(Me.TextBox2.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (SuppName like '" & Trim(Me.TextBox2.Text) & "%') "
            End If

            If Trim(Me.TextBox3.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Address1 like '" & Trim(Me.TextBox3.Text) & "%') "
            End If

            If Trim(Me.TextBox4.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Address2 like '" & Trim(Me.TextBox4.Text) & "%') "
            End If

            If Trim(Me.TextBox5.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Phone1 like '" & Trim(Me.TextBox5.Text) & "%') "
            End If


            If Trim(Me.TextBox6.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Fax like '" & Trim(Me.TextBox6.Text) & "%') "
            End If


            If sqlstr1 <> "" Then
                sqlstr = sqlstr & " where " & sqlstr1
            End If

            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)
            If cn.State = ConnectionState.Open Then cn.Close()
            Me.ssdgcari.ReadOnly = False
            Me.ssdgcari.DataSource = ds.Tables(0)

            widthchange = False
            jmlkolomfind = 6
            jmlttlkolomfindhide = 0

            Me.lbcolomfnd1.Text = "SupplierID"
            Me.lbcolomfnd2.Text = "Name"
            Me.lbcolomfnd3.Text = "Address1"
            Me.lbcolomfnd4.Text = "Address2"
            Me.lbcolomfnd5.Text = "Phone"
            Me.lbcolomfnd6.Text = "Fax"

            Me.ssdgcari.Columns(0).Width = 80
            Me.ssdgcari.Columns(1).Width = 200
            Me.ssdgcari.Columns(2).Width = 300
            Me.ssdgcari.Columns(3).Width = 300
            Me.ssdgcari.Columns(4).Width = 75
            Me.ssdgcari.Columns(5).Width = 75

            For urut = 0 To ssdgcari.Columns.Count - 1
                ssdgcari.Columns(urut).ReadOnly = True
            Next

            ResizeForm()
            widthchange = True
        Catch ex As Exception
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub isi_data_find_PR()
        tunggu_arrow()
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        Dim sqlstr1 As String = ""

        Try
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            ssdgcari.Columns.Clear()
            ssdgcari.Refresh()
            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr

            sqlstr = "Select A.PRNo, CONVERT(varchar(12),A.PRDate,106) PRDate, MAT.ItemName, S.Section " & _
                      "  From PurchaseRequest A  " & _
                      "      INNER JOIN PurchaseRequestDetail B 	" & _
                      "           ON (A.PRNo = B.PRNo) " & _
                      "  INNER JOIN Material MAT 	" & _
                      "          ON (B.ItemID = MAT.ItemID)  " & _
                      "  LEFT OUTER JOIN Section S 	" & _
                      "           ON (A.SectionID = S.SectionID) 	" & _
                      "  LEFT OUTER JOIN PurchaseOrderDetail POD " & _
                      "         ON (B.PRNo=POD.PRNo " & _
                      "    	     AND B.ItemID = POD.ItemID) " & _
                      "  WHERE B.Qty - ISNULL(POD.QtyOrder, 0) > 0 "

            If Trim(Me.TextBox2.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & " A.PRNo like '%" & ubahhrf(Trim(Me.TextBox2.Text)) & "%' "
            End If


            If Trim(Me.TextBox3.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "CONVERT(varchar(12),A.PRDate,106) like '" & ubahhrf(Trim(Me.TextBox3.Text)) & "%' "
            End If


            If Trim(Me.TextBox4.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & " MAT.ItemName like '" & ubahhrf(Trim(Me.TextBox4.Text)) & "%' "
            End If


            If Trim(Me.TextBox5.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  S.Section like '" & ubahhrf(Trim(Me.TextBox5.Text)) & "%' "
            End If

            If sqlstr1 <> "" Then
                sqlstr = sqlstr & " and " & sqlstr1
            End If

            sqlstr = sqlstr & " order by  A.PRNo ASC "
            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)

            Dim chk As New DataGridViewCheckBoxColumn()
            ssdgcari.Columns.Add(chk)
            chk.HeaderText = "Check Data"
            chk.Name = "chk"


            If cn.State = ConnectionState.Open Then cn.Close()
            Me.ssdgcari.DataSource = ds.Tables(0)

            Me.ssdgcari.ReadOnly = False
            For row As Integer = 0 To Me.ssdgcari.ColumnCount - 1
                Me.ssdgcari.Columns(row).ReadOnly = True
            Next
            Me.ssdgcari.Columns(0).ReadOnly = False
             
            widthchange = False
            jmlkolomfind = 5


            Me.lbcolomfnd1.Text = "Check"
            Me.lbcolomfnd2.Text = "PRNo"
            Me.lbcolomfnd3.Text = "PRDate"
            Me.lbcolomfnd4.Text = "Item Name"
            Me.lbcolomfnd5.Text = "Section"

            Me.ssdgcari.Columns(0).Width = 30
            Me.ssdgcari.Columns(1).Width = 75
            Me.ssdgcari.Columns(2).Width = 75
            Me.ssdgcari.Columns(3).Width = 300
            Me.ssdgcari.Columns(4).Width = 100


            ResizeForm()

            widthchange = True

            biasa_arrow()
        Catch ex As Exception
            biasa_arrow()
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub isi_data_find_Tax()
        pesan = "isi grid " & titleformcari
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        sqlstr1 = ""
        Try
            If Me.ssdgcari.DataSource Is Nothing Then
            Else
                Me.ssdgcari.DataSource = Nothing
            End If
            ssdgcari.Columns.Clear()
            ssdgcari.Refresh()

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            sqlstr = "Select Tax from Tax  Where TaxType = '" & gridcaricode1 & "' "


            If Trim(Me.TextBox1.Text) <> "" Then
                If sqlstr1 <> "" Then
                    sqlstr1 = sqlstr1 & " and "
                End If
                sqlstr1 = sqlstr1 & "  (Tax like '" & Trim(Me.TextBox1.Text) & "%') "
            End If

            If sqlstr1 <> "" Then
                sqlstr = sqlstr & " where " & sqlstr1
            End If

            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)
            If cn.State = ConnectionState.Open Then cn.Close()
            Me.ssdgcari.ReadOnly = False
            Me.ssdgcari.DataSource = ds.Tables(0)

            widthchange = False
            jmlkolomfind = 1
            jmlttlkolomfindhide = 0

            Me.lbcolomfnd1.Text = "Tax %"

            Me.ssdgcari.Columns(0).Width = 100

            For urut = 0 To ssdgcari.Columns.Count - 1
                ssdgcari.Columns(urut).ReadOnly = True
            Next

            ResizeForm()
            widthchange = True
        Catch ex As Exception
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub tunggu_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    End Sub

    Private Sub biasa_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
 
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress, TextBox8.KeyPress, TextBox9.KeyPress, TextBox10.KeyPress, TextBox11.KeyPress, TextBox12.KeyPress, TextBox13.KeyPress, TextBox14.KeyPress, TextBox15.KeyPress, TextBox20.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        Else
            If Char.IsLower(e.KeyChar) Then
                e.Handled = True
                SendKeys.Send(Char.ToUpper(e.KeyChar))
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, TextBox6.TextChanged, TextBox7.TextChanged, TextBox8.TextChanged, TextBox9.TextChanged, TextBox10.TextChanged, TextBox11.TextChanged, TextBox12.TextChanged, TextBox13.TextChanged, TextBox14.TextChanged, TextBox15.TextChanged, TextBox20.TextChanged
        Select Case spasscari
            Case "FIND_SECTION"
                isi_data_find_Section()

            Case "FIND_MATERIAL_ITEM"
                isi_data_find_Material()

            Case "FIND_UNIT"
                isi_data_find_Unit()

            Case "FIND_TAX"
                isi_data_find_Tax()

            Case "FIND_SUPPLIER"
                isi_data_find_Supplier()

            Case "FIND_CUSTOMER"
                isi_data_find_Customer()

            Case "FIND_PR"
                isi_data_find_PR()
        End Select
        GridCari_ResizeEnd(sender, e)
    End Sub

    Private Sub All_Item_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles All_Item.CheckedChanged
       

        If All_Item.Checked = True Then
            For jumrow As Integer = 0 To ssdgcari.RowCount - 1
                If jumrow <= 1000 Then
                    ssdgcari.Item("chk", jumrow).Value = True
                End If
            Next
             
        Else
            For jumrow As Integer = 0 To ssdgcari.RowCount - 1
                ssdgcari.Item("chk", jumrow).Value = False
            Next
        End If
    End Sub

    Private Sub ssdgcari_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles ssdgcari.ColumnWidthChanged
        Try
            If widthchange Then
                Select Case jmlkolomfind
                    Case 0
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                    Case 1
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                    Case 2
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                    Case 3
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                    Case 4
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                    Case 5
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                    Case 6
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                    Case 7
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                    Case 8
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                    Case 9
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                    Case 10
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                    Case 11
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                    Case 12
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                    Case 13
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                    Case 14
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                    Case 15
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                    Case 16
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                    Case 17
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                    Case 18
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                    Case 19
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                        Me.split_find18.SplitterDistance = Me.ssdgcari.Columns(17).Width - 1
                    Case 20
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                        Me.split_find18.SplitterDistance = Me.ssdgcari.Columns(17).Width - 1
                        Me.split_find19.SplitterDistance = Me.ssdgcari.Columns(18).Width - 1
                    Case Else
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                        Me.split_find18.SplitterDistance = Me.ssdgcari.Columns(17).Width - 1
                        Me.split_find19.SplitterDistance = Me.ssdgcari.Columns(18).Width - 1
                        Me.split_find20.SplitterDistance = Me.ssdgcari.Columns(19).Width - 1
                End Select
            End If
        Catch ex As Exception
            'MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub splitContainer1_SplitterMoving(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs) Handles split_find1.SplitterMoving, split_find2.SplitterMoving, split_find3.SplitterMoving, split_find4.SplitterMoving, split_find5.SplitterMoving, split_find6.SplitterMoving, split_find7.SplitterMoving, split_find8.SplitterMoving, _
        split_find9.SplitterMoving, split_find10.SplitterMoving, split_find11.SplitterMoving, split_find12.SplitterMoving, split_find13.SplitterMoving, split_find14.SplitterMoving, split_find15.SplitterMoving, split_find16.SplitterMoving, split_find17.SplitterMoving, split_find18.SplitterMoving, split_find19.SplitterMoving, _
        split_find20.SplitterMoving

        ' As the splitter moves, change the cursor type.
        Cursor.Current = System.Windows.Forms.Cursors.NoMoveVert
    End Sub 'splitContainer1_SplitterMoving

    Private Sub GridCari_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd, split_find1.SplitterMoved, split_find2.SplitterMoved, split_find3.SplitterMoved, split_find4.SplitterMoved, split_find5.SplitterMoved, split_find6.SplitterMoved, split_find7.SplitterMoved, split_find8.SplitterMoved, _
        split_find9.SplitterMoved, split_find10.SplitterMoved, split_find11.SplitterMoved, split_find12.SplitterMoved, split_find13.SplitterMoved, split_find14.SplitterMoved, split_find15.SplitterMoved, split_find16.SplitterMoved, split_find17.SplitterMoved, split_find18.SplitterMoved, split_find19.SplitterMoved, _
        split_find20.SplitterMoved

        Cursor.Current = System.Windows.Forms.Cursors.Default
        Try
            If widthchange Then
                widthchange = False
                Select Case jmlkolomfind
                    Case Is = 0
                        Exit Sub
                    Case Is = 1
                        Me.ssdgcari.Columns(0).Width = Me.ssdgcari.Width
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Width

                        Me.split_find1.Visible = True

                        Me.split_find2.Visible = False
                        Me.split_find3.Visible = False
                        Me.split_find4.Visible = False
                        Me.split_find5.Visible = False
                        Me.split_find6.Visible = False
                        Me.split_find7.Visible = False
                        Me.split_find8.Visible = False
                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 2
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True

                        Me.split_find3.Visible = False
                        Me.split_find4.Visible = False
                        Me.split_find5.Visible = False
                        Me.split_find6.Visible = False
                        Me.split_find7.Visible = False
                        Me.split_find8.Visible = False
                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 3
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True

                        Me.split_find4.Visible = False
                        Me.split_find5.Visible = False
                        Me.split_find6.Visible = False
                        Me.split_find7.Visible = False
                        Me.split_find8.Visible = False
                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 4
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True

                        Me.split_find5.Visible = False
                        Me.split_find6.Visible = False
                        Me.split_find7.Visible = False
                        Me.split_find8.Visible = False
                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 5
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True

                        Me.split_find6.Visible = False
                        Me.split_find7.Visible = False
                        Me.split_find8.Visible = False
                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 6
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True

                        Me.split_find7.Visible = False
                        Me.split_find8.Visible = False
                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 7
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True

                        Me.split_find8.Visible = False
                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 8
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True

                        Me.split_find9.Visible = False
                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 9
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True

                        Me.split_find10.Visible = False
                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False

                    Case Is = 10
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True

                        Me.split_find11.Visible = False
                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False

                    Case Is = 11
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True

                        Me.split_find12.Visible = False
                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False

                    Case Is = 12
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True

                        Me.split_find13.Visible = False
                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 13
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True

                        Me.split_find14.Visible = False
                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False
                    Case Is = 14
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True

                        Me.split_find15.Visible = False
                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False

                    Case Is = 15
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True
                        Me.split_find15.Visible = True

                        Me.split_find16.Visible = False
                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False


                    Case Is = 16
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True
                        Me.split_find15.Visible = True
                        Me.split_find16.Visible = True

                        Me.split_find17.Visible = False
                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False


                    Case Is = 17
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True
                        Me.split_find15.Visible = True
                        Me.split_find16.Visible = True
                        Me.split_find17.Visible = True

                        Me.split_find18.Visible = False
                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False


                    Case Is = 18
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                        Me.split_find18.SplitterDistance = Me.ssdgcari.Columns(17).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True
                        Me.split_find15.Visible = True
                        Me.split_find16.Visible = True
                        Me.split_find17.Visible = True
                        Me.split_find18.Visible = True

                        Me.split_find19.Visible = False
                        Me.split_find20.Visible = False


                    Case Is = 19
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                        Me.split_find18.SplitterDistance = Me.ssdgcari.Columns(17).Width - 1
                        Me.split_find19.SplitterDistance = Me.ssdgcari.Columns(18).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True
                        Me.split_find15.Visible = True
                        Me.split_find16.Visible = True
                        Me.split_find17.Visible = True
                        Me.split_find18.Visible = True
                        Me.split_find19.Visible = True

                        Me.split_find20.Visible = False


                    Case Is = 20
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                        Me.split_find18.SplitterDistance = Me.ssdgcari.Columns(17).Width - 1
                        Me.split_find19.SplitterDistance = Me.ssdgcari.Columns(18).Width - 1
                        Me.split_find20.SplitterDistance = Me.ssdgcari.Columns(19).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True
                        Me.split_find15.Visible = True
                        Me.split_find16.Visible = True
                        Me.split_find17.Visible = True
                        Me.split_find18.Visible = True
                        Me.split_find19.Visible = True
                        Me.split_find20.Visible = True

                        Me.lbcolomfnd21.Visible = True
                        Me.TextBox21.Visible = False

                    Case Else
                        Me.split_find1.SplitterDistance = Me.ssdgcari.Columns(0).Width
                        Me.split_find2.SplitterDistance = Me.ssdgcari.Columns(1).Width - 1
                        Me.split_find3.SplitterDistance = Me.ssdgcari.Columns(2).Width - 1
                        Me.split_find4.SplitterDistance = Me.ssdgcari.Columns(3).Width - 1
                        Me.split_find5.SplitterDistance = Me.ssdgcari.Columns(4).Width - 1
                        Me.split_find6.SplitterDistance = Me.ssdgcari.Columns(5).Width - 1
                        Me.split_find7.SplitterDistance = Me.ssdgcari.Columns(6).Width - 1
                        Me.split_find8.SplitterDistance = Me.ssdgcari.Columns(7).Width - 1
                        Me.split_find9.SplitterDistance = Me.ssdgcari.Columns(8).Width - 1
                        Me.split_find10.SplitterDistance = Me.ssdgcari.Columns(9).Width - 1
                        Me.split_find11.SplitterDistance = Me.ssdgcari.Columns(10).Width - 1
                        Me.split_find12.SplitterDistance = Me.ssdgcari.Columns(11).Width - 1
                        Me.split_find13.SplitterDistance = Me.ssdgcari.Columns(12).Width - 1
                        Me.split_find14.SplitterDistance = Me.ssdgcari.Columns(13).Width - 1
                        Me.split_find15.SplitterDistance = Me.ssdgcari.Columns(14).Width - 1
                        Me.split_find16.SplitterDistance = Me.ssdgcari.Columns(15).Width - 1
                        Me.split_find17.SplitterDistance = Me.ssdgcari.Columns(16).Width - 1
                        Me.split_find18.SplitterDistance = Me.ssdgcari.Columns(17).Width - 1
                        Me.split_find19.SplitterDistance = Me.ssdgcari.Columns(18).Width - 1
                        Me.split_find20.SplitterDistance = Me.ssdgcari.Columns(19).Width - 1

                        Me.split_find1.Visible = True
                        Me.split_find2.Visible = True
                        Me.split_find3.Visible = True
                        Me.split_find4.Visible = True
                        Me.split_find5.Visible = True
                        Me.split_find6.Visible = True
                        Me.split_find7.Visible = True
                        Me.split_find8.Visible = True
                        Me.split_find9.Visible = True
                        Me.split_find10.Visible = True
                        Me.split_find11.Visible = True
                        Me.split_find12.Visible = True
                        Me.split_find13.Visible = True
                        Me.split_find14.Visible = True
                        Me.split_find15.Visible = True
                        Me.split_find16.Visible = True
                        Me.split_find17.Visible = True
                        Me.split_find18.Visible = True
                        Me.split_find19.Visible = True
                        Me.split_find20.Visible = True

                        Me.lbcolomfnd21.Visible = True
                        Me.TextBox21.Visible = False
                End Select

                Dim x As Integer
                If jmlkolomfind < jmlttlkolomfindhide Then
                    For x = jmlkolomfind To jmlttlkolomfindhide
                        Me.ssdgcari.Columns(x).Visible = False
                    Next
                End If

                widthchange = True
            Else
                Exit Sub
            End If
        Catch ex As Exception
            'MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub Btn_FndHis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_FndHis.Click
        MsgBox(spasscari)
        If sdivisi = "IT" Then
            Me.txtspasscari.Text = spasscari
            Me.txtisiGrid.Text = "Sub " & isiGrid
            Me.txtisiQuery.Text = sqlstr
            Me.txtspasscari.Visible = True
            Me.txtisiGrid.Visible = True
            Me.txtisiQuery.Visible = True
        End If
    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.TextBox4.Text = ""
        Me.TextBox5.Text = ""
        Me.TextBox6.Text = ""
        Me.TextBox7.Text = ""
        Me.TextBox8.Text = ""
        Me.TextBox9.Text = ""
        Me.TextBox10.Text = ""
        Me.TextBox11.Text = ""
        Me.TextBox12.Text = ""
        Me.TextBox13.Text = ""
        Me.TextBox14.Text = ""
        Me.TextBox15.Text = ""
        Me.TextBox16.Text = ""
        Me.TextBox17.Text = ""
        Me.TextBox18.Text = ""
        Me.TextBox19.Text = ""
        Me.TextBox20.Text = ""
        Me.TextBox21.Text = ""
    End Sub

    Private Sub Btn_Enter_Click(sender As Object, e As EventArgs) Handles Btn_Enter.Click
        Try
            For i As Integer = 0 To Me.ssdgcari.RowCount - 1
                If ssdgcari.SelectedCells.Count = 0 Then
                Else
                    If Me.ssdgcari.Rows(i).Selected = True Then
                        If Me.ssdgcari.Columns(0).Name.ToUpper = "CHK" Then
                            Me.ssdgcari.Item(0, i).Value = True
                        End If
                    End If
                End If
            Next
            ssdgcari_KLIK(ssdgcari.CurrentCell.ColumnIndex, ssdgcari.CurrentCell.RowIndex)
        Catch ex As Exception

        End Try
    End Sub

End Class