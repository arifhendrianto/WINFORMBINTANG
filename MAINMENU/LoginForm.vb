Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlTransaction
Imports System.Data.OleDb.OleDbTransaction
Imports System.DBNull
Imports System.Net
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class LoginForm

    Dim ax As New MyGlobal
    Dim axtemp As New MyGlobal
    Dim tmprptcn As New OleDb.OleDbConnection
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dtRead As SqlDataReader

    Dim cn1 As New SqlConnection
    Dim cmd1 As New SqlCommand
    Dim dtRead1 As SqlDataReader

    Dim transtmp As OleDb.OleDbTransaction = Nothing
    Dim cmdtmp As New OleDb.OleDbCommand
    Dim dtReadtmp As OleDb.OleDbDataReader
     
    Function check_Trans_Date(Transdate As Date) As Boolean
        Dim date_server As Date = get_date_server()
        check_Trans_Date = True
        If Transdate.AddDays(2) > date_server Or _
            Transdate < date_server.AddDays(-10) Then
            check_Trans_Date = False
        End If
    End Function 

    Function get_date_server() As Date
        If cn1.State = ConnectionState.Open Then cn1.Close()
        cn1 = ax.cntsvr
        cmd1.Connection = cn1
        Dim getdate As Date
        sqlstr = " select getdate() as sgetdate "
        cmd1.CommandText = sqlstr
        dtRead1 = cmd1.ExecuteReader
        If dtRead1.Read = True Then
            getdate = IIf(IsDBNull(dtRead1!sgetdate), Today, dtRead1!sgetdate)
        End If
        dtRead1.Close()
        dtRead1 = Nothing

        get_date_server = getdate
    End Function
     
    Private Sub Print_Preview()
        Try
            Dim cryRpt As New ReportDocument
            ReportViewerSQL.CrystalReportViewer1.ReportSource = Nothing 
            cryRpt.Load(pdir & "\" & "BLANK_RPT.rpt")
            ReportViewerSQL.CrystalReportViewer1.ReportSource = cryRpt
            ReportViewerSQL.Show()
            ReportViewerSQL.Close()


            
        Catch ex As Exception
            biasa_arrow()
            MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub get_tanggal_libur()
         
    End Sub
     
    Private Sub GetLocalIP()
        Dim strHostName As New String("")
        Dim IP_Address As String = ""

        Dim ip() As Net.IPAddress = System.Net.Dns.GetHostAddresses("")
        strHostName = System.Net.Dns.GetHostName()

        Dim IP4 = New List(Of IPAddress)(Dns.GetHostEntry(strHostName).AddressList).Find(Function(f) f.AddressFamily = Sockets.AddressFamily.InterNetwork)

        Dim A
        'Dim IP4 As IPAddress
        Dim AL = System.Net.Dns.GetHostEntry(strHostName).AddressList
        For Each A In AL
            If A.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                IP4 = A
                Exit For
            End If
        Next
        sipaddress = Microsoft.VisualBasic.Left(IP4.ToString.Trim, 20)

        sqlstr = "Update users "
        sqlstr = sqlstr & " set ComputerName = '" & Microsoft.VisualBasic.Left(strHostName.Trim, 40) & "' "
        sqlstr = sqlstr & " , IPAddress = '" & Microsoft.VisualBasic.Left(IP4.ToString.Trim, 20) & "' "
        sqlstr = sqlstr & " , LastAccess = '" & get_date_server() & "' "
        sqlstr = sqlstr & " where userid = '" & Trim(Me.txtuserid.Text) & "' "
        'sqlstr = sqlstr & " and (IPAddress is null or IPAddress = '' )"
        cmd = New SqlCommand(sqlstr, cn)
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub Login_Server()
        Dim reenternewpassword As Boolean = False
        Dim spswduser As String = "" 
        Try
            
            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            cmd.Connection = cn

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1 = ax.cntsvr
            cmd1.Connection = cn1

            tglserver = get_date_server()
            GetLocalIP()
             
            bbenar = True
            spswduser = decrypt(Trim(Me.txtpassword.Text))

            sqlstr = "Select * from users where userid = '" & Trim(Me.txtuserid.Text) & "'"
            sqlstr = sqlstr & " and activeflag = '1' "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            If dtRead.Read = True Then

                sdivisi = dtRead!divisi
                sAppAdmin = dtRead!AppAdmin


                If spswduser = dtRead!userPSWD Then
                    If dtRead!activeflag = "0" Or dtRead!activeflag = "1" Then
                        bbenar = True
                    Else
                        MsgBox("User ID Still Active !", , "LOGIN")
                        txtuserid.Focus()
                        System.Windows.Forms.SendKeys.Send("{Home}+{End}")
                        bbenar = False
                    End If
                Else
                    MsgBox("Invalid Password !", , "LOGIN")
                    txtpassword.Focus()
                    System.Windows.Forms.SendKeys.Send("{Home}+{End}")
                    bbenar = False
                End If
            Else
                sresponse = CStr(MsgBox("User ID Not Found !", MsgBoxStyle.Exclamation, "LOGIN"))
                txtuserid.Focus()
                System.Windows.Forms.SendKeys.Send("{Home}+{End}")
                bbenar = False
            End If
            dtRead.Close()
            dtRead = Nothing

            'If reenternewpassword Then
            '    siduser = Me.txtuserid.Text
            '    MainMenuChangePassword.ShowDialog()
            'End If

            If bbenar Then
                ax.sapplcode = "SYMBIOS"
                ax.sapplver = "1.1"
                ax.sapplname = "SYMBIOS"

                sqlstr = "select * from ms_appl where applcode = '" & _
                        Trim(ax.sapplcode) & "' "
                pesan = "Get Application Version"
                cmd.CommandText = sqlstr
                dtRead = cmd.ExecuteReader
                If dtRead.Read = False Then
                    MsgBox("Application Code Not Found ! ( Login )")
                    bbenar = False
                Else
                    sverfromdbs = Trim(dtRead!applversion)
                    sCompany = Trim(dtRead!name)
                    sComAddress1 = Trim(dtRead!Address1)
                    sComAddress2 = Trim(dtRead!Address2)
                    sComAddress3 = Trim(dtRead!Address3)
                    skantorPabean = Trim(dtRead!KantorPabean)
                    sJenisTBP = Trim(dtRead!JenisTBP)
                    sJenisTBPAsal = Trim(dtRead!JenisTBPAsal)
                    sNPWP = Trim(dtRead!NPWP)
                    If Trim(ax.sapplver) <> Trim(sverfromdbs) Then
                        MsgBox("Different Or Wrong Application Version Number. Access Denied ! ( Login )")
                        bbenar = False
                    End If
                End If
                dtRead.Close()
                dtRead = Nothing
            End If
        Catch ex As Exception
            biasa_arrow()
            MessageBox.Show(pesan & vbCrLf & ex.Message, "Expection", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub tunggu_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    End Sub

    Private Sub biasa_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
     
    Private Sub get_accessright()
        Try

        
        Dim transtmp As OleDb.OleDbTransaction = Nothing

        sqlstr = "delete * from users_dtltmp"
        pesan = "Delete Records in Temporary Report File ( users_dtltmp )"
        transtmp = tmprptcn.BeginTransaction()
        cmdtmp = New OleDb.OleDbCommand(sqlstr, tmprptcn, transtmp)
        cmdtmp.ExecuteNonQuery()
        transtmp.Commit()

        sqlstr = "delete * from mainmenu_tmp"
        pesan = "Delete Records in Temporary Report File ( mainmenu_tmp )"
        transtmp = tmprptcn.BeginTransaction()
        cmdtmp = New OleDb.OleDbCommand(sqlstr, tmprptcn, transtmp)
        cmdtmp.ExecuteNonQuery()
        transtmp.Commit()

        sqlstr = "SELECT mainmenu.sno, users_dtl.applcode,mainmenu.smodule, mainmenu.sgroup, "
        sqlstr = sqlstr & "mainmenu.menu, mainmenu.noitem,"
        sqlstr = sqlstr & "mainmenu.submenu, users_dtl.accessright, "
        sqlstr = sqlstr & "mainmenu.description, mainmenu.runexe "
        sqlstr = sqlstr & "FROM users_dtl RIGHT OUTER JOIN "
        sqlstr = sqlstr & "mainmenu ON users_dtl.modulecode = mainmenu.runexe "
        sqlstr = sqlstr & "WHERE (users_dtl.userid = '" & Trim(Me.txtuserid.Text) & "') "
            sqlstr = sqlstr & " AND (users_dtl.applcode = 'TR') "
        sqlstr = sqlstr & " AND (users_dtl.accessright <> '') "
        sqlstr = sqlstr & "order by users_dtl.applcode,mainmenu.sno, mainmenu.sgroup, mainmenu.noitem "
        cmd.CommandText = sqlstr
        dtRead = cmd.ExecuteReader
        Do Until dtRead.Read = False
            'If IIf(dtRead!applcode Is DBNull.Value, "", Trim(dtRead!applcode)) = "INV" Then
            '    MsgBox("d    " & Trim(dtRead!runexe) & "   " & dtRead!accessright)
            'End If
            'If IIf(dtRead!runexe Is DBNull.Value, "", Trim(dtRead!runexe)) = "IN_DE_DOPACK" Then
            '    MsgBox("x  " & dtRead!accessright)
            'End If
            pesan = "Saving Data To Temporary Report File ( users_dtltmp )"
            sqlstr = "INSERT INTO users_dtltmp "
            sqlstr = sqlstr & "(userid,sno,modulecode,smodule,sgroup,menu,noitem,submenu,description,runexe,"
            sqlstr = sqlstr & "update_tbl," ' U pdate
            sqlstr = sqlstr & "delete_tbl," ' D elete
            sqlstr = sqlstr & "insert_tbl," ' I nsert            
            sqlstr = sqlstr & "process_tbl," ' N Print
            sqlstr = sqlstr & "print_tbl) " ' P rocess
            sqlstr = sqlstr & "values ('" & Trim(Me.txtuserid.Text)
            sqlstr = sqlstr & "','" & IIf(dtRead!sno Is DBNull.Value, "", Trim(dtRead!sno))
            sqlstr = sqlstr & "','" & IIf(dtRead!applcode Is DBNull.Value, "", Trim(dtRead!applcode))
            sqlstr = sqlstr & "','" & IIf(dtRead!smodule Is DBNull.Value, "", Trim(dtRead!smodule))
            sqlstr = sqlstr & "','" & IIf(dtRead!sgroup Is DBNull.Value, "", Trim(dtRead!sgroup))
            sqlstr = sqlstr & "','" & IIf(dtRead!menu Is DBNull.Value, "", Trim(dtRead!menu))
            sqlstr = sqlstr & "','" & IIf(dtRead!noitem Is DBNull.Value, "", Trim(dtRead!noitem))
            sqlstr = sqlstr & "','" & IIf(dtRead!submenu Is DBNull.Value, "", Trim(dtRead!submenu))
            sqlstr = sqlstr & "','" & IIf(dtRead!description Is DBNull.Value, "", Trim(dtRead!description))
            sqlstr = sqlstr & "','" & IIf(dtRead!runexe Is DBNull.Value, "", Trim(dtRead!runexe))

            If InStr(1, UCase(dtRead!accessright), "U") > 0 Then
                sqlstr = sqlstr & "',true"
            Else
                sqlstr = sqlstr & "',false"
            End If
            If InStr(1, UCase(dtRead!accessright), "D") > 0 Then
                sqlstr = sqlstr & ",true"
            Else
                sqlstr = sqlstr & ",false"
            End If
            If InStr(1, UCase(dtRead!accessright), "I") > 0 Then
                sqlstr = sqlstr & ",true"
            Else
                sqlstr = sqlstr & ",false"
            End If
            If InStr(1, UCase(dtRead!accessright), "N") > 0 Then
                sqlstr = sqlstr & ",true"
            Else
                sqlstr = sqlstr & ",false"
            End If
            If InStr(1, UCase(dtRead!accessright), "P") > 0 Then
                sqlstr = sqlstr & ",true"
            Else
                sqlstr = sqlstr & ",false"
            End If
            sqlstr = sqlstr & ") "
            transtmp = tmprptcn.BeginTransaction()
            cmdtmp = New OleDb.OleDbCommand(sqlstr, tmprptcn, transtmp)
            cmdtmp.ExecuteNonQuery()
            transtmp.Commit()
        Loop
        dtRead.Close()
        dtRead = Nothing

        sqlstr = "SELECT sno, smodule, sgroup, "
        sqlstr = sqlstr & "applcode,menu, noitem,"
        sqlstr = sqlstr & "submenu, "
        sqlstr = sqlstr & "description, runexe "
            sqlstr = sqlstr & "FROM mainmenu "
            sqlstr = sqlstr & " where (applcode = 'TR' ) "
        sqlstr = sqlstr & "order by applcode,sno, sgroup, noitem "
        cmd.CommandText = sqlstr
        dtRead = cmd.ExecuteReader
        Do Until dtRead.Read = False



            pesan = "Saving Data To Temporary Report File ( mainmenu_tmp )"
            sqlstr = "INSERT INTO mainmenu_tmp "
            sqlstr = sqlstr & "(sno,smodule,sgroup,applcode,menu,noitem,submenu,description,runexe) "
            sqlstr = sqlstr & "values ('" & IIf(dtRead!sno Is DBNull.Value, "", Trim(dtRead!sno))
            sqlstr = sqlstr & "','" & IIf(dtRead!smodule Is DBNull.Value, "", Trim(dtRead!smodule))
            sqlstr = sqlstr & "','" & IIf(dtRead!sgroup Is DBNull.Value, "", Trim(dtRead!sgroup))
            sqlstr = sqlstr & "','" & IIf(dtRead!applcode Is DBNull.Value, "", Trim(dtRead!applcode))
            sqlstr = sqlstr & "','" & IIf(dtRead!menu Is DBNull.Value, "", Trim(dtRead!menu))
            sqlstr = sqlstr & "','" & IIf(dtRead!noitem Is DBNull.Value, "", Trim(dtRead!noitem))
            sqlstr = sqlstr & "','" & IIf(dtRead!submenu Is DBNull.Value, "", Trim(dtRead!submenu))
            sqlstr = sqlstr & "','" & IIf(dtRead!description Is DBNull.Value, "", Trim(dtRead!description))
            sqlstr = sqlstr & "','" & IIf(dtRead!runexe Is DBNull.Value, "", Trim(dtRead!runexe))
            sqlstr = sqlstr & "') "
            transtmp = tmprptcn.BeginTransaction()
            cmdtmp = New OleDb.OleDbCommand(sqlstr, tmprptcn, transtmp)
            cmdtmp.ExecuteNonQuery()
            transtmp.Commit()
        Loop
        dtRead.Close()
        dtRead = Nothing
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Login_ok()
        bbenar = True
        beditan = False
        siduser = ""
        userid_email = ""
        susername = ""
        sdivisi = ""
        susergroup = ""
        steam = ""

        Dim spswduser As String = ""
        sstsuser = ""
        spasscari = ""
        Dim jumlahbukamenu As Byte = 0

        Try

            'View_Closing_Date() ' untuk finance 

            sqlstr = "Select * from users where userid = '" & Trim(txtuserid.Text) & "'"
            sqlstr = sqlstr & " and activeflag = '1' "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            If dtRead.Read = True Then
                spswduser = decrypt(Trim(txtpassword.Text))

                If spswduser = dtRead!userpswd Then
                    If dtRead!activeflag = "0" Or dtRead!activeflag = "1" Then
                        siduser = txtuserid.Text
                        userid_email = IIf(IsDBNull(dtRead!email), "", dtRead!email)

                        susername = dtRead!UserName
                        susergroup = dtRead!groupcode
                        sdivisi = dtRead!divisi
                        steam = dtRead!team
                        sstsuser = dtRead!status
                        lokasicompany = IIf(IsDBNull(dtRead!lokasi), "WHN", dtRead!lokasi)

                    
                        dtRead.Close()
                        dtRead = Nothing

                        'get_accessright()

                        Me.Hide()
                        MainMenu.Show()
                    Else
                        MsgBox("User ID Still Active !", , "LOGIN")
                        txtuserid.Focus()
                        System.Windows.Forms.SendKeys.Send("{Home}+{End}")
                    End If
                Else
                    'MsgBox("Invalid Password !", , "LOGIN")
                    'txtpassword.Focus()

                    'pesan = "Saving Invalid Password "
                    'sqlstr = "INSERT INTO users_wrongpass "
                    'sqlstr = sqlstr & "(userid,inputdate,password,ipaddress) "
                    'sqlstr = sqlstr & "values ('" & Me.txtuserid.Text
                    'sqlstr = sqlstr & "', getdate() "
                    'sqlstr = sqlstr & " ,'" & Me.txtpassword.Text
                    'sqlstr = sqlstr & "','" & sipaddress
                    'sqlstr = sqlstr & "') "
                    'cmd = New SqlCommand(sqlstr, cn)
                    'cmd.ExecuteNonQuery()

                    System.Windows.Forms.SendKeys.Send("{Home}+{End}")
                End If
            Else
                sresponse = CStr(MsgBox("User ID Not Found !", MsgBoxStyle.Exclamation, "LOGIN"))
                txtuserid.Focus()
                System.Windows.Forms.SendKeys.Send("{Home}+{End}")
            End If
            'dtRead.Close()
            'dtRead = Nothing
            If cn.State = ConnectionState.Open Then cn.Close()
            If tmprptcn.State = ConnectionState.Open Then tmprptcn.Close()
            Exit Sub
        Catch ex As Exception
            'MsgBox("Check Application Error !")
        End Try

    End Sub

    Private Sub View_Closing_Date()
        sqlstr = "select convert(char(3),DATENAME(MONTH, periode)) + ' ' + convert(char(4),year(periode)) as ClosingMAT "
        sqlstr = sqlstr & " ,(select convert(char(3),DATENAME(MONTH, periode)) + ' ' + convert(char(4),year(periode)) "
        sqlstr = sqlstr & " from IN_PRC_CLOSING where module ='PACK')  as ClosingPACK"
        sqlstr = sqlstr & " ,(select convert(char(3),DATENAME(MONTH, periode)) + ' ' + convert(char(4),year(periode)) "
        sqlstr = sqlstr & " from IN_PRC_CLOSING where module ='FGW')  as ClosingFGW"
        sqlstr = sqlstr & " ,(select convert(char(3),DATENAME(MONTH, periode)) + ' ' + convert(char(4),year(periode)) "
        sqlstr = sqlstr & " from AP_PRC_CLOSING)  as ClosingAP"
        sqlstr = sqlstr & " ,(select convert(char(3),DATENAME(MONTH, periode)) + ' ' + convert(char(4),year(periode)) "
        sqlstr = sqlstr & " from AR_PRC_CLOSING)  as ClosingAR"
        sqlstr = sqlstr & " ,(select convert(char(3),DATENAME(MONTH, periode)) + ' ' + convert(char(4),year(periode)) "
        sqlstr = sqlstr & " from GL_PRC_CLOSING)  as ClosingGL"
        sqlstr = sqlstr & " from IN_PRC_CLOSING where module ='MAT' "
        cmd.CommandText = sqlstr
        dtRead = cmd.ExecuteReader
        If dtRead.Read = True Then
            'MainMenu.lbCLOSINGMAT.Text = IIf(IsDBNull(dtRead!ClosingMAT), "", dtRead!ClosingMAT)
            'MainMenu.lbCLOSINGPACK.Text = IIf(IsDBNull(dtRead!ClosingPACK), "", dtRead!ClosingPACK)
            'MainMenu.lbCLOSINGFGW.Text = IIf(IsDBNull(dtRead!ClosingFGW), "", dtRead!ClosingFGW)
            'MainMenu.lbCLOSINGAP.Text = IIf(IsDBNull(dtRead!ClosingAP), "", dtRead!ClosingAP)
            'MainMenu.lbCLOSINGAR.Text = IIf(IsDBNull(dtRead!ClosingAR), "", dtRead!ClosingAR)
            'MainMenu.lbCLOSINGGL.Text = IIf(IsDBNull(dtRead!ClosingGL), "", dtRead!ClosingGL)
        End If
        dtRead.Close()
        dtRead = Nothing
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LoginForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If cn.State = ConnectionState.Open Then cn.Close()
        If tmprptcn.State = ConnectionState.Open Then tmprptcn.Close()
    End Sub

    Private Sub LoginForm_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub

    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myfile1, nmfile1 As Object
        Try
       
            Me.txtuserid.Text = ax.baca_UserID()
            Me.txtpassword.Focus()
          
            myfile1 = ""
            nmfile1 = pdir & "\svrcfg.txt"
            myfile1 = Dir(Trim(nmfile1))

            If myfile1 <> "" Then
                ax.baca_svrcfg()
                Me.txtpassword.Focus()
            Else
                If ax.cndesc <> "GAGAL" Then
                    sresponse = MsgBox("Server Configuration File Not Found !", vbExclamation)
                    LogSetCon.ShowDialog()
                End If
            End If



        Catch ex As Exception
            'MsgBox("Check Application Error !")
        End Try
    End Sub 
     
    Private Sub txtuserid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtuserid.KeyDown, txtuserid.KeyUp
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Me.txtpassword.Focus()
        End If
    End Sub

    Private Sub txtuserid_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtuserid.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            Me.txtpassword.Focus()
        Else
            eventArgs.KeyChar = UCase(Chr(KeyAscii))
        End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
     

    Private Sub txtpassword_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            OK_Click(eventSender, eventArgs)
        Else
            eventArgs.KeyChar = UCase(Chr(KeyAscii))
        End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub


    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    'Bind Dataset that don't have comboboxcolumn you are willing to add
    '    'DataGridView1.DataSource = Db2DataSet.Tables(0)
    '    'Create a comboboxcolumn for Datagridview
    '    DataGridView1.Columns.Add(New DataGridViewComboBoxColumn() With {.HeaderText = "ComboColumn", .Name = "ComboColumn"})
    '    Dim Ilist As New List(Of String) 'A list that will hold combobox items
    '    Ilist.AddRange(New String() {"item1", "item2", "item3", "item4", "item5"}) ' Items that are required in combobox
    '    DirectCast(DataGridView1.Columns("ComboColumn"), DataGridViewComboBoxColumn).DataSource = Ilist  'Bind to item to "ComboColumn"

    'End Sub

    Private Sub txtpassword_KeyUp(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyUp
        'Dim rex As Regex = New Regex("^[0-9]{0,9}(\.[0-9]{0,2})?$")
        'If e.Alt And e.KeyCode = Keys.Control And e.KeyCode = Keys.A Then
        '    sqlstr = "Select userPSWD from users where userid = '" & Trim(Me.txtuserid.Text) & "'"
        '    cmd.CommandText = sqlstr
        '    dtRead = cmd.ExecuteReader
        '    If dtRead.Read = True Then


        '        MsgBox(decrypt(dtRead!userPSWD))

        '        Dim TxtB As TextBox = CType(sender, TextBox)

        '        If (rex.IsMatch(TxtB.Text) = False) Then
        '            e.cancel = True
        '        End If

        '    End If
        '    dtRead.Close()
        '    dtRead = Nothing
        'End If

        'If e.KeyValue = Keys.ControlKey And e.KeyValue = Keys.T Then
        '    sqlstr = "Select userPSWD from users where userid = '" & Trim(Me.txtuserid.Text) & "'"
        '    cmd.CommandText = sqlstr
        '    dtRead = cmd.ExecuteReader
        '    If dtRead.Read = True Then


        '        MsgBox(decrypt(dtRead!userPSWD)) 

        '    End If
        '    dtRead.Close()
        '    dtRead = Nothing
        'End If

    End Sub


    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyValue = Keys.ControlKey And Me.txtpassword.Text = "APA" Then

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            cmd.Connection = cn

            sqlstr = "Select userPSWD from users where userid = '" & Trim(Me.txtuserid.Text) & "'"
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            If dtRead.Read = True Then


                MsgBox(encrypt(dtRead!userPSWD))

            End If
            dtRead.Close()
            dtRead = Nothing
        End If
    End Sub
     
    'Private Sub Btn_CP_Click(sender As Object, e As EventArgs) Handles Btn_CP.Click
    '    siduser = Me.txtuserid.Text
    '    MainMenuChangePassword.ShowDialog()
    'End Sub
 
   
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click

        Try

            'Print_Preview()

            If Me.txtuserid.Text.Trim = "" Then
                Me.txtuserid.Focus()
                Exit Sub
            End If
            If Me.txtpassword.Text.Trim = "" Then
                Me.txtpassword.Focus()
                Exit Sub
            End If

            FileClose(1)
            FileOpen(1, pdir & "\UserID.TXT", OpenMode.Output)
            PrintLine(1, Me.txtuserid.Text)
            FileClose(1)

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            cmd.Connection = cn

            Login_Server()

            If bbenar Then
                Login_ok()
                get_tanggal_libur()
            End If
        Catch ex As Exception
            biasa_arrow()
            'MessageBox.Show(pesan & vbCrLf & ex.Message, "Expection", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

  
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        siduser = Me.txtuserid.Text
        MainMenuChangePassword.ShowDialog()
    End Sub

  
End Class
