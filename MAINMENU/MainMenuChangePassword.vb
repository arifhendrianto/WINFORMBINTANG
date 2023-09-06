Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlTransaction
Imports System.Data.OleDb.OleDbTransaction
Imports System.DBNull

Public Class MainMenuChangePassword
    Dim ax As New MyGlobal
    Dim axtemp As New MyGlobal
    Dim tmprptcn As New OleDb.OleDbConnection

    Dim cn As New SqlConnection '  SqlConnection
    Dim cmd As New SqlCommand
    Dim dtRead As SqlDataReader

    Dim trans As SqlTransaction = Nothing
    Dim transtmp As OleDb.OleDbTransaction = Nothing

    Dim cmdtmp As New OleDb.OleDbCommand
    Dim dtReadtmp As OleDb.OleDbDataReader

    Private Sub txtOLDpassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOLDpassword.TextChanged
        Try

            'ax.compac_repair_LocalMDB()

            'If cn.State = ConnectionState.Open Then cn.Close()
            'cn = ax.cntsvr
            'cmd.Connection = cn

            'tmprptcn = axtemp.connectiondatatemp
            'cmdtmp.Connection = tmprptcn

            bbenar = True
            sqlstr = "Select * from users "
            sqlstr = sqlstr & "where userid = '" & Trim(Me.txtuserid.Text) & "' "
            sqlstr = sqlstr & "and userPSWD = '" & decrypt(UCase(Trim(Me.txtOLDpassword.Text))) & "' "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            If dtRead.Read = True Then
                Me.txtNEWpassword.Enabled = True
                Me.txtReNEWpassword.Enabled = True
            Else
                Me.txtNEWpassword.Enabled = False
                Me.txtReNEWpassword.Enabled = False
                Me.txtNEWpassword.Text = ""
                Me.txtReNEWpassword.Text = ""
            End If
            dtRead.Close()
            dtRead = Nothing
        Catch ex As Exception
            biasa_arrow()
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub MainMenuChangePassword_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If cn.State = ConnectionState.Open Then cn.Close()
        If tmprptcn.State = ConnectionState.Open Then tmprptcn.Close()
        End
    End Sub

    Private Sub MainMenuChagePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            tunggu_arrow()

            If cn.State = ConnectionState.Open Then cn.Close()
            If tmprptcn.State = ConnectionState.Open Then tmprptcn.Close()

            cn = ax.cntsvr

            tmprptcn = axtemp.connectiondatatemp

            cmd.Connection = cn


            cmdtmp.Connection = tmprptcn

            Me.txtuserid.Text = siduser
            Me.txtOLDpassword.Text = ""
            Me.txtNEWpassword.Text = ""
            Me.txtReNEWpassword.Text = ""
            Me.txtNEWpassword.Enabled = False
            Me.txtReNEWpassword.Enabled = False
            Me.Btn_OK.Enabled = False
            If siduser = "DD" Then
                Me.txtuserid.ReadOnly = False
            End If
            biasa_arrow()

        Catch ex As Exception
            biasa_arrow()
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub
    Private Sub tunggu_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    End Sub

    Private Sub biasa_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        'Me.Close()
        End
    End Sub

    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click
        Try
            bbenar = True
            If Len(Me.txtNEWpassword.Text) <= 3 Then
                MsgBox("Minimum Length 4 Digit")
                bbenar = False
            End If
            If Me.txtNEWpassword.Text = "" And bbenar Then
                MsgBox("Please Enter new Password ")
                bbenar = False
            End If
            If Me.txtReNEWpassword.Text = "" And bbenar Then
                MsgBox("Please Retype new password ")
                bbenar = False
            End If
            If Me.txtNEWpassword.Text.Trim <> Me.txtReNEWpassword.Text.Trim And bbenar Then
                MsgBox("Invalid Retype new Password")
                bbenar = False
            End If
            If bbenar Then
                If Me.txtuserid.Text <> siduser Then
                    stxtgetfromgrid = "N"
                    gridcaricode1 = "Pass_Change_Password_Login_Users"
                    Password.ShowDialog()
                    If stxtgetfromgrid = "Y" Then
                        If getgridcari(0, 1) = "Y" Then
                        Else
                            MessageBox.Show("password is wrong")
                            bbenar = False
                        End If
                    End If
                End If
            End If
            If bbenar Then
                If Me.txtReNEWpassword.Text.Trim = Me.txtNEWpassword.Text.Trim Then
                    Dim trans As SqlTransaction = Nothing
                    trans = cn.BeginTransaction()
                    pesan = "Update users "
                    sqlstr = "update users  "
                    sqlstr = sqlstr & " set UserPswdOld = '" & decrypt(UCase(Me.txtOLDpassword.Text.Trim)) & "' "
                    sqlstr = sqlstr & " , UserPswd = '" & decrypt(UCase(Me.txtNEWpassword.Text.Trim)) & "' "
                    sqlstr = sqlstr & " , DatePswd = '" & System.DateTime.FromOADate(Today.ToOADate + 60) & "' "
                    sqlstr = sqlstr & " where userid = '" & Trim(Me.txtuserid.Text) & "' "
                    sqlstr = sqlstr & " or userid = '" & Trim(Me.txtuserid.Text) & "FBI' "
                    cmd = New SqlCommand(sqlstr, cn, trans)
                    cmd.ExecuteNonQuery()
                    trans.Commit()
                    MsgBox("Change Sucessfully ")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            biasa_arrow()
            MsgBox(pesan & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub txtReNEWpassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReNEWpassword.TextChanged
        If Me.txtReNEWpassword.Text.Trim = Me.txtNEWpassword.Text.Trim Then
            Me.Btn_OK.Enabled = True
        End If
    End Sub

    Private Sub txtuserid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtuserid.KeyPress
        ' MsgBox(e.KeyChar)
    End Sub
     
End Class