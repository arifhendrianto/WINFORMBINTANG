Imports System.Data
Imports System.Data.OleDb.OleDbTransaction
Imports System.DBNull
Imports System.Data.SqlClient
Imports System
Imports System.Diagnostics
Imports System.ComponentModel 

Public Class MainMenu
    Dim ax As New MyGlobal
    Dim sqlstr As String, menuselected As Integer = 0
    Dim exefile

    Dim cn As New SqlConnection '  SqlConnection
    Dim cmd As New SqlCommand
    Dim dtRead As SqlDataReader

    Dim cn1 As New SqlConnection '  SqlConnection
    Dim cmd1 As New SqlCommand
    Dim dtRead1 As SqlDataReader

    Dim cn2 As New SqlConnection '  SqlConnection
    Dim cmd2 As New SqlCommand
    Dim dtRead2 As SqlDataReader


    Dim cn3 As New SqlConnection '  SqlConnection
    Dim cmd3 As New SqlCommand
    Dim dtRead3 As SqlDataReader


    Private Sub menu_module_show_MST(ByVal exefile As String)
        Select Case exefile

            Case "PROFILE"
                PROFILE.MdiParent = Me
                PROFILE.Show()
                If PROFILE.WindowState = FormWindowState.Minimized Then
                    PROFILE.WindowState = FormWindowState.Normal
                End If
                PROFILE.Focus()

            
            Case Else
                MsgBox(exefile)
        End Select
    End Sub


    Private Sub menu_module_show_IN(ByVal exefile As String)
        Select Case exefile
            
            Case "REQUEST_ORDER"
                REQUEST_ORDER.MdiParent = Me
                REQUEST_ORDER.Show()
                If REQUEST_ORDER.WindowState = FormWindowState.Minimized Then
                    REQUEST_ORDER.WindowState = FormWindowState.Normal
                End If
                REQUEST_ORDER.Focus()
                 
            Case "PURCHASE_ORDER"
                PURCHASE_ORDER.MdiParent = Me
                PURCHASE_ORDER.Show()
                If PURCHASE_ORDER.WindowState = FormWindowState.Minimized Then
                    PURCHASE_ORDER.WindowState = FormWindowState.Normal
                End If
                PURCHASE_ORDER.Focus()

            Case Else
                MsgBox(exefile)
        End Select
    End Sub


    Private Sub menu_module_show_OUT(ByVal exefile As String)
        Select Case exefile
            Case "SALES_ORDER"
                SALES_ORDER.MdiParent = Me
                SALES_ORDER.Show()
                If SALES_ORDER.WindowState = FormWindowState.Minimized Then
                    SALES_ORDER.WindowState = FormWindowState.Normal
                End If
                SALES_ORDER.Focus()
            Case Else
                MsgBox(exefile)
        End Select
    End Sub


    Private Sub menu_module_show_RPT(ByVal exefile As String)
        Select Case exefile
            Case "FRMBARCODE"
                'FRMBARCODE.MdiParent = Me
                'FRMBARCODE.Show()
                'If FRMBARCODE.WindowState = FormWindowState.Minimized Then
                '    FRMBARCODE.WindowState = FormWindowState.Normal
                'End If
                'FRMBARCODE.Focus()
                 
            Case Else
                MsgBox(exefile)
        End Select
    End Sub

    Public Sub closechild()
        Dim f As New Form
        f = Me.ActiveMdiChild
        If Not f Is Nothing Then
            f.Close()
        End If
    End Sub

    'Private Sub MainMenu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  
    'End Sub

    Private Sub MainMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'txtversi.Text = "Ver." & Trim(sverfromdbs)

            If cn.State = ConnectionState.Open Then cn.Close()
            If cn1.State = ConnectionState.Open Then cn1.Close()
            If cn2.State = ConnectionState.Open Then cn2.Close()
            If cn3.State = ConnectionState.Open Then cn3.Close()
           
            cn = ax.cntsvr
            cn1 = ax.cntsvr
            cn2 = ax.cntsvr
            cn3 = ax.cntsvr
           
            cmd.Connection = cn
            cmd1.Connection = cn1
            cmd2.Connection = cn2
            cmd3.Connection = cn3


            Panel_main.Visible = False
             
            If sAppAdmin = True Then
                'BTNSETUP.Enabled = True
                'BTNGLA.Enabled = True
                BTNULA.Enabled = True
                'BTNLAYOUT.Enabled = True
            End If


            sqlstr = "SELECT distinct ApplCode "
            sqlstr = sqlstr & "From users_dtl "
            sqlstr = sqlstr & "Where userid = '" & Trim(siduser) & "' Order BY ApplCode "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader()
            Do Until dtRead.Read = False

                For x As Integer = 0 To 2
                    If tab_module.TabPages(x).Name.Trim = Trim(dtRead!ApplCode) Then
                        tab_module.TabPages(x).PageVisible = True
                        Exit For
                    End If
                Next

            Loop
            dtRead.Close()
            dtRead = Nothing
             
            Me.ChangePassword.Text = "Change Password : " & siduser
            'Me.txtDATABS.Text = sdatabs
            Me.Text = "SymbiOs System    (" & sserver & ", " & sdbs & ", " & susername & ", " & sdivisi & ")" & "  - Location : Jakarta "
             
            Panel_main.Width = 280
            tab_module.Visible = True
            Panel_main.Visible = True


            Me.lblLoginTime.Text = Microsoft.VisualBasic.Format(Today, "dddd") & ",    " & Microsoft.VisualBasic.MonthName(Microsoft.VisualBasic.Month(Today)) & "  " & Microsoft.VisualBasic.Day(Today) & ", " & Microsoft.VisualBasic.Year(Today)
            Me.lblLoginName.Text = "User Login : " & siduser
            Me.lblLoginPC.Text = "IP Address : " & sipaddress
            Me.lblLoginLast.Text = "Last Login : "


            Call Refresh_menu("MST")
            Call Refresh_menu("TIN")
            Call Refresh_menu("SLS")
            Call Refresh_menu("STK")
            Call Refresh_menu("RPT")
            
            tab_module.TabPages(0).TabControl.SelectedTabPageIndex = 0
            'Me.txtInfo.Text = txtInfo.Text & " - " & sipaddress

            TETAP.Visible = True
            BERUBAH.Visible = False

            ''SHOW REMINDER
            ''--------------
            'REMINDER.ShowDialog()
            'REMINDER.WindowState = FormWindowState.Normal
            'REMINDER.StartPosition = FormStartPosition.CenterScreen
            'REMINDER.Focus()
             
        Catch ex As Exception

        End Try

    End Sub

    Sub Refresh_menu(ByVal applcode As String)
        Dim nd As New TreeNode 

        sqlstr = "SELECT distinct sno,smodule "
        sqlstr = sqlstr & "From MAINMENU "
        sqlstr = sqlstr & "Where applcode = '" & Trim(applcode) & "' "
        sqlstr = sqlstr & "Order by sno "
        cmd.CommandText = sqlstr
        dtRead = cmd.ExecuteReader()
        Do Until dtRead.Read = False
            Select Case applcode
                Case "MST"
                    nd = TV_MST.Nodes.Add(Trim(dtRead!smodule))
                Case "TIN"
                    nd = TV_IN.Nodes.Add(Trim(dtRead!smodule))
                Case "SLS"
                    nd = TV_OUT.Nodes.Add(Trim(dtRead!smodule))
                Case "STK"
                    nd = TV_STK.Nodes.Add(Trim(dtRead!smodule))
                Case "RPT"
                    nd = TV_RPT.Nodes.Add(Trim(dtRead!smodule))

            End Select
            nd.Tag = Trim(dtRead!smodule)
            nd.ForeColor = Color.Black
            carimenu(applcode, dtRead!smodule, nd)
        Loop
        dtRead.Close()
        dtRead = Nothing
    End Sub
     

    Sub carimenu(ByVal applcode As String, ByVal submodule As String, ByRef currentnode As TreeNode)
        sqlstr = "SELECT DISTINCT sno,sgroup ,smodule,menu "
        sqlstr = sqlstr & "From MAINMENU "
        sqlstr = sqlstr & "Where smodule = '" & Trim(submodule) & "' "
        sqlstr = sqlstr & "and applcode = '" & Trim(applcode) & "' "
        sqlstr = sqlstr & "Order by sno,sgroup  "
        cmd1.CommandText = sqlstr
        dtRead1 = cmd1.ExecuteReader()
        Do Until dtRead1.Read = False
            Dim nd1 As TreeNode
            nd1 = New TreeNode(Trim(dtRead1!menu))
            nd1 = currentnode.Nodes.Add(Trim(dtRead1!menu))
            nd1.Tag = Trim(dtRead1!menu)

            sqlstr = "Select Distinct  menu from MAINMENU A " & _
            "LEFT OUTER JOIN users_dtl B " & _
            "	ON (A.RunExe = B.ModuleCode)" & _
            "Where A.menu = '" & Trim(dtRead1!menu) & "' "

            cmd2.CommandText = sqlstr
            dtRead2 = cmd2.ExecuteReader()
            If dtRead2.Read = False Then
                nd1.ForeColor = Color.DarkGray
            Else
                nd1.ForeColor = Color.Black
            End If
            dtRead2.Close()
            dtRead2 = Nothing
            carisubmenu(applcode, dtRead1!sno, dtRead1!sgroup, dtRead1!menu, nd1)
        Loop

        dtRead1.Close()
        dtRead1 = Nothing
    End Sub

    Sub carisubmenu(ByVal applcode As String, ByVal sno As String, ByVal sgroup As String, ByVal submodule As String, ByRef currentnode As TreeNode)
        sqlstr = "SELECT distinct smodule,menu,noitem,submenu "
        sqlstr = sqlstr & "From mainmenu "
        sqlstr = sqlstr & "Where menu = '" & Trim(submodule) & "' AND (menu <> submenu) "
        sqlstr = sqlstr & "and sno = '" & Trim(sno) & "' "
        sqlstr = sqlstr & "and sgroup = '" & Trim(sgroup) & "' "
        sqlstr = sqlstr & "and applcode = '" & Trim(applcode) & "' "
        sqlstr = sqlstr & "Order by noitem "
        cmd3.CommandText = sqlstr
        dtRead3 = cmd3.ExecuteReader()
        Do Until dtRead3.Read = False
            Dim nd As TreeNode
            nd = New TreeNode(Trim(dtRead3!submenu))
            nd = currentnode.Nodes.Add(Trim(dtRead3!submenu))
            nd.ForeColor = Color.Black

            'sqlstr = "SELECT distinct submenu "
            'sqlstr = sqlstr & "From users_dtl "
            'sqlstr = sqlstr & "Where submenu = '" & Trim(dtRead3!submenu) & "' AND (menu <> submenu) "
            'cmd.CommandText = sqlstr
            'dtRead4 = cmd.ExecuteReader()
            'If dtRead4.Read = False Then
            '    nd.ForeColor = Color.Black
            'End If
            'dtRead4.Close()
            'dtRead4 = Nothing
        Loop
        dtRead3.Close()
        dtRead3 = Nothing
    End Sub

    Private Sub logoff_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bbenar As Boolean = False
        Try
            Close()
            End
        Catch ex As Exception
            'MsgBox("Check Application Error !")
        End Try
    End Sub
    Private Sub TV_MST_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV_MST.MouseDoubleClick
        bbenar = False
        'If menuselected > 2 Then Exit Sub
        Try
            Call execute_exe_lib("MST")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TV_IN_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV_IN.MouseDoubleClick
        bbenar = False
        'If menuselected > 2 Then Exit Sub
        Try
            Call execute_exe_lib("TIN")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TV_OUT_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV_OUT.MouseDoubleClick
        bbenar = False
        If menuselected > 2 Then Exit Sub
        Try
            Call execute_exe_lib("SLS")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TV_RPT_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV_RPT.MouseDoubleClick
        bbenar = False
        If menuselected > 2 Then Exit Sub
        Try
            Call execute_exe_lib("RPT")
        Catch ex As Exception
        End Try
    End Sub
 
    Sub execute_exe_lib(ByVal modules As String)
        Dim nd As TreeNode = Nothing
        Select Case modules
            Case "MST"
                nd = TV_MST.SelectedNode
            Case "TIN"
                nd = TV_IN.SelectedNode
            Case "SLS"
                nd = TV_OUT.SelectedNode
            Case "RPT"
                nd = TV_RPT.SelectedNode
        End Select

        If nd.ForeColor = Color.DarkGray Then
            MsgBox("Access Right Have Not Been Initialized Yet ")
        ElseIf nd.Text = "EXIT" Then
            Close()
        Else

            sqlstr = "SELECT ApplCode,runexe "
            sqlstr = sqlstr & "From MAINMENU "
            sqlstr = sqlstr & "Where submenu = '" & Trim(nd.Text) & "' "
            sqlstr = sqlstr & "and ApplCode = '" & Trim(modules) & "' "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader()
            If dtRead.Read = True Then
                exefile = Trim((dtRead!runexe))
                bbenar = True
            End If
            dtRead.Close()
            dtRead = Nothing
            If bbenar = True Then
                Select Case modules
                    Case "MST"
                        Call menu_module_show_MST(exefile)
                    Case "TIN"
                        Call menu_module_show_IN(exefile)
                    Case "SLS"
                        Call menu_module_show_OUT(exefile)
                    Case "RPT"
                        Call menu_module_show_RPT(exefile)
                End Select
            End If
        End If
    End Sub
    Private Sub BTNEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEXIT.Click
        Close()
    End Sub

    Private Sub BTNABOUT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNABOUT.Click
        About_Form.ShowDialog()
    End Sub

    Private Sub ChangePassword_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePassword.Click
        MainMenuChangePassword.ShowDialog()
    End Sub


    Private Sub MainMenu_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        Me.Move, Panel_main.Move, StatusStrip2.Move, tab_module.Move, TV_MST.Move, TV_IN.Move, TV_OUT.Move, _
        Me.MouseLeave, Panel_main.MouseLeave, StatusStrip2.MouseLeave, tab_module.MouseLeave, TV_MST.MouseLeave, TV_IN.MouseLeave, TV_OUT.MouseLeave, _
        Me.MouseHover, Panel_main.MouseHover, StatusStrip2.MouseHover, tab_module.MouseHover, TV_MST.MouseHover, TV_IN.MouseHover, TV_OUT.MouseHover, _
        Me.MouseMove, Panel_main.MouseMove, StatusStrip2.MouseMove, tab_module.MouseMove, TV_MST.MouseMove, TV_IN.MouseMove, TV_OUT.MouseMove


        Dim centerscreen As Integer = Panel_main.Height / 2
        If TETAP.Visible = True Then Exit Sub

        If MousePosition.X >= 280 Then
            If Panel_main.Width = 280 Then
                Panel_main.Width = 2
                tab_module.Visible = False
            End If
        Else
            If MousePosition.X = 0 Then
                If MousePosition.Y >= centerscreen - 50 And MousePosition.Y <= centerscreen + 50 Then
                    Panel_main.Width = 280
                    tab_module.Visible = True
                End If
            End If
        End If
    End Sub


    'Private Sub BTNGLA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGLA.Click
    '    Dim formmenu As New STP_FM_USERGROUP
    '    formmenu.MdiParent = Me
    '    formmenu.Show()
    '    If formmenu.WindowState = FormWindowState.Minimized Or _
    '        formmenu.WindowState = FormWindowState.Normal Then
    '        formmenu.WindowState = FormWindowState.Maximized
    '    End If
    'End Sub

    Private Sub BTNULA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNULA.Click
        Dim formmenu As New USERS
        formmenu.MdiParent = Me
        formmenu.Show()
        If formmenu.WindowState = FormWindowState.Minimized Or _
            formmenu.WindowState = FormWindowState.Normal Then
            formmenu.WindowState = FormWindowState.Maximized
        End If
    End Sub
      

    'Private Sub BTNOK_Click(sender As Object, e As EventArgs) Handles BTNOK.Click
    '    If XCOMPANY.Text = "CURRENT" Then
    '        FileOpen(1, pdir & "\svrcfg.TXT", OpenMode.Output)
    '        PrintLine(1, "t_")
    '        PrintLine(1, "tooojl}]{#sfq")
    '        PrintLine(1, "Gmwa}]vOW=Yc{EƒQwT")
    '        PrintLine(1, "toodw^9(:+")
    '        FileClose(1)
    '        End
    '    ElseIf XCOMPANY.Text = "DEVELOPER" Then
    '        FileOpen(1, pdir & "\svrcfg.TXT", OpenMode.Output)
    '        PrintLine(1, "t_")
    '        PrintLine(1, "tooojl}]{#qVv")
    '        PrintLine(1, "Gmwa}]vOW=Yc{EƒQwT")
    '        PrintLine(1, "toobgc")
    '        FileClose(1)
    '        End
    '    End If
    'End Sub


    'Private Sub BTNOK_Click(sender As Object, e As EventArgs) Handles BTNOK.Click
    '    If XCOMPANY.Text = "CURRENT" Then
    '        FileOpen(1, pdir & "\svrcfg.TXT", OpenMode.Output)
    '        PrintLine(1, "t_")
    '        PrintLine(1, "TOOOJL]=[#SFQ")
    '        PrintLine(1, "IPGJthZlj\q")
    '        PrintLine(1, "toodw^9(:+")
    '        FileClose(1) 
    '        End
    '    ElseIf XCOMPANY.Text = "DEVELOPER" Then
    '        FileOpen(1, pdir & "\svrcfg.TXT", OpenMode.Output)
    '        PrintLine(1, "t_")
    '        PrintLine(1, "TOOOJL]=[#Q6V")
    '        PrintLine(1, "IPGJthZlj\q")
    '        PrintLine(1, "toobgc")
    '        FileClose(1)  
    '        End
    '    End If
    'End Sub
     
    Private Sub XCOMPANY_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub
 
    Private Sub BERUBAH_ButtonClick(sender As Object, e As EventArgs) Handles BERUBAH.ButtonClick
        TETAP.Visible = True
        BERUBAH.Visible = False
    End Sub

    Private Sub TETAP_ButtonClick(sender As Object, e As EventArgs) Handles TETAP.ButtonClick
        TETAP.Visible = False
        BERUBAH.Visible = True
    End Sub

     
    Private Sub MainMenu_Move(sender As Object, e As MouseEventArgs)

    End Sub
End Class
