Public Class LogSetCon

    Dim classmodule As New MyGlobal

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        bbenar = True
        If Trim(Me.FrUser.Text) = "" Then
            bbenar = False
        End If
        If bbenar And Trim(Me.Frsvr.Text) = "" Then
            bbenar = False
        End If
        If bbenar And Trim(Me.FrDtbs.Text) = "" Then
            bbenar = False
        End If
        If bbenar And Trim(Me.FrPswd.Text) = "" Then
            bbenar = False
        End If
        If bbenar And Trim(Me.txtmdb.Text) = "" Then
            bbenar = False
        End If
        If bbenar Then
            FileOpen(1, pdir & "\svrcfg.txt", OpenMode.Output)
            PrintLine(1, encrypt(Trim(Me.FrUser.Text)))
            PrintLine(1, encrypt(Trim(Me.Frsvr.Text)))
            PrintLine(1, encrypt(Trim(Me.FrDtbs.Text)))
            PrintLine(1, encrypt(Trim(Me.FrPswd.Text)))
            FileClose(1)

            FileOpen(1, pdir & "\mdbcfg.html", OpenMode.Output)
            PrintLine(1, Trim(Me.txtmdb.Text))
            FileClose(1)
        End If   
        If bbenar Then
            Me.Close()
        Else
            MsgBox("Configuration File Not Found !", vbExclamation)
        End If
    End Sub

    Private Sub Frsvr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Frsvr.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Me.FrDtbs.Focus()
        Else
            ' e.KeyChar = UCase(Chr(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrDtbs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FrDtbs.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Me.FrUser.Focus()
        Else
            ' e.KeyChar = UCase(Chr(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrPswd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FrPswd.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Me.btnOK.Focus()
        Else
            ' e.KeyChar = UCase(Chr(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub LogSetCon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myfile1, nmfile1 As Object 
        Try
            'If (UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0) Then
            '    MsgBox("Application Already Running ! Further Process Denied !", vbCritical)
            '    End
            'End If

            myfile1 = ""
            nmfile1 = pdir & "svrcfg.txt"
            myfile1 = Dir(Trim(nmfile1))

            If myfile1 = "" Then
                classmodule.baca_svrcfg()
                Me.FrUser.Text = suid
                Me.Frsvr.Text = sserver
                Me.FrDtbs.Text = sdbs
                Me.FrPswd.Text = spwd
            Else
                'sresponse = MsgBox("Server Configuration File Not Found !", vbExclamation)
                'LogSetCon.Show()
            End If

        Catch ex As Exception
            'MsgBox("Check Application Error !")
        End Try
    End Sub
End Class