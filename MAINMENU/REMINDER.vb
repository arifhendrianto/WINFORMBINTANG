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
Imports System.Threading
Imports System.ComponentModel
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO.FileStream
Imports System.IO.StreamReader
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.IO.Compression

Public Class REMINDER
    Dim ax As New MyGlobal
    Dim tmprptcn As New OleDb.OleDbConnection
    Dim cn As New SqlConnection '  SqlConnection
    Dim cmd As New SqlCommand
    Dim dtRead As SqlDataReader



    Private Sub REMINDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cn.State = ConnectionState.Open Then cn.Close()
        cn = ax.cntsvr

        BindUnActive()
        'BindContract()

    End Sub


    Private Sub BindContract()

        Try
            Dim SqlContract As String = "[spReminder_Contract]  '" & siduser.Trim & "'"
            Dim cmdContract As New SqlCommand(SqlContract)
            Dim dtContract As DataTable = ax.GetDataTable(cmdContract)
            Me.dgContract.DataSource = dtContract

            If dgContract.Rows.Count > 0 Then
                dgContract.Columns.Item("No").DefaultCellStyle.BackColor = Color.FromArgb(206, 206, 202)

                Dim row As DataGridViewRow = Me.dgContract.Rows(0)
                Dim i As Integer = 1
                For Each col As DataGridViewColumn In row.DataGridView.Columns
                    col.ReadOnly = True
                Next
            End If


            dgContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgContract.AutoResizeColumns()
            Me.txtTotalContract.Text = dgContract.Rows.Count

            For i As Integer = 0 To Me.dgContract.Rows.Count - 1
                If CDbl(Me.dgContract.Rows(i).Cells("Days.Left").Value) <= 0 Then
                    Me.dgContract.Rows(i).Cells("Days.Left").Style.BackColor = Color.FromArgb(255, 102, 102)
                End If
            Next

             
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BindUnActive()

        Try
            Dim SqlContract As String = "[spReminder_UnActiveContract]  '" & siduser.Trim & "'"
            Dim cmdContract As New SqlCommand(SqlContract)
            Dim dtUnActive As DataTable = ax.GetDataTable(cmdContract)
            Me.dgUnActive.DataSource = dtUnActive

            If dgUnActive.Rows.Count > 0 Then
                dgUnActive.Columns.Item("No").DefaultCellStyle.BackColor = Color.FromArgb(206, 206, 202)
                dgUnActive.Columns.Item("LastPayroll").DefaultCellStyle.BackColor = Color.Yellow

                Dim row As DataGridViewRow = Me.dgUnActive.Rows(0)
                Dim i As Integer = 1
                For Each col As DataGridViewColumn In row.DataGridView.Columns
                    col.ReadOnly = True
                Next
            End If


            dgUnActive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgUnActive.AutoResizeColumns()
            Me.txtTotalUnActive.Text = dgUnActive.Rows.Count

            For i As Integer = 0 To Me.dgUnActive.Rows.Count - 1
                If CDbl(Me.dgUnActive.Rows(i).Cells("Days.Left").Value) <= 0 Then
                    Me.dgUnActive.Rows(i).Cells("Days.Left").Style.BackColor = Color.FromArgb(255, 102, 102)
                End If
            Next


        Catch ex As Exception
        End Try
    End Sub

    Private Sub BindActing()

        Try
            Dim SqlActing As String = "[spReminder_Acting]  '" & siduser.Trim & "'"
            Dim cmdActing As New SqlCommand(SqlActing)
            Dim dtActing As DataTable = ax.GetDataTable(cmdActing)
            Me.dgActing.DataSource = dtActing

            If dgActing.Rows.Count > 0 Then
                dgActing.Columns.Item("No").DefaultCellStyle.BackColor = Color.FromArgb(206, 206, 202)
                dgActing.Columns.Item("Days.Left").DefaultCellStyle.BackColor = Color.Yellow

                Dim row As DataGridViewRow = Me.dgActing.Rows(0)
                Dim i As Integer = 1
                For Each col As DataGridViewColumn In row.DataGridView.Columns
                    col.ReadOnly = True
                Next
            End If


            dgActing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgActing.AutoResizeColumns()
            Me.txtTotalActing.Text = dgActing.Rows.Count

            For i As Integer = 0 To Me.dgActing.Rows.Count - 1
                If CDbl(Me.dgActing.Rows(i).Cells("Days.Left").Value) <= 0 Then
                    Me.dgActing.Rows(i).Cells("Days.Left").Style.BackColor = Color.FromArgb(255, 102, 102)
                End If
            Next


        Catch ex As Exception
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                BindUnActive()
            Case 1
                BindContract()
            Case 2
                BindActing()


        End Select

    End Sub



    Private Sub btnExcelContract_Click(sender As Object, e As EventArgs) Handles btnExcelContract.Click
        Export_Excel("EXPORT", FormatTanggal_View(Date.Now))
    End Sub
   

    Private Sub Export_Excel(status As String, filename As String)
        Dim namafilexls As String = ""
        Try
            pesan = "save excel"
            tunggu_arrow()
            Dim xlApp As Microsoft.Office.Interop.Excel.Application 'Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook 'Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            xlWorkSheet.Name = "REMINDER CONTRACT"

            Dim titlerpt As String = ""

            titlerpt = "REMINDER CONTRACT PER " & filename

            xlWorkSheet.Cells(1, 1) = titlerpt
            xlWorkSheet.Cells(1, 1).EntireRow.Font.size = 16
            xlWorkSheet.Cells(1, 1).EntireRow.Font.color = 3
            xlWorkSheet.Cells(1, 1).EntireRow.font.bold = True

            xlWorkSheet.Cells(1, 9) = "Print Date :"
            xlWorkSheet.Cells(1, 11) = "'" & LoginForm.get_date_server
            Dim jrow As Integer = 2


            xlWorkSheet.Cells(jrow, 1).EntireRow.Font.size = 12
            xlWorkSheet.Cells(jrow, 1).EntireRow.font.bold = True

            For col As Integer = 0 To Me.dgContract.Columns.Count - 1
                xlWorkSheet.Cells(jrow, col + 1) = Me.dgContract.Columns(col).HeaderText
            Next

            jrow += 1

            For row As Integer = 0 To Me.dgContract.RowCount - 1
                For col As Integer = 0 To Me.dgContract.Columns.Count - 1
                    xlWorkSheet.Cells(jrow, col + 1) = Me.dgContract.Item(col, row).Value
                Next
                jrow += 1
            Next

            If (Not System.IO.Directory.Exists("C:\UNITYFILE\")) Then
                System.IO.Directory.CreateDirectory("C:\UNITYFILE")
            End If

            namafilexls = ""

            namafilexls = namafilexls & Str(Me.dgContract.RowCount)
            namafilexls = ubahhrf_namafile(titlerpt) & ".xlsx"
            xlWorkSheet.SaveAs("C:\UNITYFILE\" & namafilexls)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            biasa_arrow()
            If status = "EXPORT" Then
                MsgBox("You can find the file C:\UNITYFILE\" & namafilexls)
                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Open("C:\UNITYFILE\" & namafilexls)
                xlApp.Visible = True
                xlWorkBook.Activate()
            End If

        Catch ex As Exception
            biasa_arrow()
            If Err.Number = 1004 Then
                MessageBox.Show(pesan & vbCrLf & "File " & namafilexls & ".xls Already Open, Close First ", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub btnExcelUnActive_Click(sender As Object, e As EventArgs) Handles btnExcelUnActive.Click
        Export_Excel_Payroll("EXPORT", FormatTanggal_View(Date.Now))
    End Sub


    Private Sub Export_Excel_Payroll(status As String, filename As String)
        Dim namafilexls As String = ""
        Try
            pesan = "save excel"
            tunggu_arrow()
            Dim xlApp As Microsoft.Office.Interop.Excel.Application 'Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook 'Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            xlWorkSheet.Name = "REMINDER CONTRACT UNACTIVE"

            Dim titlerpt As String = ""

            titlerpt = "REMINDER CONTRACT UNACTIVE PER " & filename

            xlWorkSheet.Cells(1, 1) = titlerpt
            xlWorkSheet.Cells(1, 1).EntireRow.Font.size = 16
            xlWorkSheet.Cells(1, 1).EntireRow.Font.color = 3
            xlWorkSheet.Cells(1, 1).EntireRow.font.bold = True

            xlWorkSheet.Cells(1, 9) = "Print Date :"
            xlWorkSheet.Cells(1, 11) = "'" & LoginForm.get_date_server
            Dim jrow As Integer = 2


            xlWorkSheet.Cells(jrow, 1).EntireRow.Font.size = 12
            xlWorkSheet.Cells(jrow, 1).EntireRow.font.bold = True

            For col As Integer = 0 To Me.dgUnActive.Columns.Count - 1
                xlWorkSheet.Cells(jrow, col + 1) = Me.dgUnActive.Columns(col).HeaderText
            Next

            jrow += 1

            For row As Integer = 0 To Me.dgUnActive.RowCount - 1
                For col As Integer = 0 To Me.dgUnActive.Columns.Count - 1
                    xlWorkSheet.Cells(jrow, col + 1) = Me.dgUnActive.Item(col, row).Value
                Next
                jrow += 1
            Next

            If (Not System.IO.Directory.Exists("C:\UNITYFILE\")) Then
                System.IO.Directory.CreateDirectory("C:\UNITYFILE")
            End If

            namafilexls = ""

            namafilexls = namafilexls & Str(Me.dgUnActive.RowCount)
            namafilexls = ubahhrf_namafile(titlerpt) & ".xlsx"
            xlWorkSheet.SaveAs("C:\UNITYFILE\" & namafilexls)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            biasa_arrow()

            If status = "EXPORT" Then
                MsgBox("You can find the file C:\UNITYFILE\" & namafilexls)
                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Open("C:\UNITYFILE\" & namafilexls)
                xlApp.Visible = True
                xlWorkBook.Activate()
            End If


        Catch ex As Exception
            biasa_arrow()
            If Err.Number = 1004 Then
                MessageBox.Show(pesan & vbCrLf & "File " & namafilexls & ".xls Already Open, Close First ", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub proc_exit()
        Me.Close()
    End Sub

    Private Sub tunggu_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    End Sub

    Private Sub biasa_arrow()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Btn_Email_Click(sender As Object, e As EventArgs) Handles Btn_Email.Click
        Try

            tunggu_arrow()
            '=================== STYLE =============================
            Dim tglfile As String = FormatTanggal_View(Date.Now)
            If (Not System.IO.Directory.Exists("C:\UNITYFILE\" & "REMINDER CONTRACT PER " & tglfile & ".xlsx")) Then
                Export_Excel("EMAIL", tglfile)
            End If

            Me.Refresh()

            pesan = "Send Email"
            Dim objOutlk As New Outlook.Application 'Outlook
            Const olMailItem As Integer = 0
            Dim objMail As New System.Object
            Dim msg As String = ""

            objMail = objOutlk.CreateItem(olMailItem) 'Email item

            Dim tomsg As String = "mukti@fotexco.com;hrd.wanaherang@fotexco.com"
            objMail.To = tomsg

            'Insert your "CC" address...it can by dynamically populated
            objMail.cc = "paul@fotexco.com" 'Enter an address here To include a carbon copy; bcc is For blind carbon copy's
            'objMail.Bcc = "didi@fotexco.com"

            'Set up Subject Line
            objMail.subject = "End Kontrak STAFF dan NON STAFF"

            'To add an attachment, use:
            If (Not System.IO.Directory.Exists("C:\UNITYFILE\" & "REMINDER CONTRACT PER " & tglfile)) Then

                objMail.attachments.add("C:\UNITYFILE\" & "REMINDER CONTRACT PER " & tglfile & ".xlsx")
            End If

            ''otherwise, if no attachment, you can comment the objMail.attachments.add("") out with an apostrophe

            Dim smsg As String = "Dear Pak Paul "
            smsg = smsg & vbCrLf & ""
            smsg = smsg & vbCrLf & "Berikut ini saya Informasikan Karyawan yang masa Kontrak nya telah/akan habis"
            smsg = smsg & vbCrLf & "Data ada di Attachment File"

             

            smsg = smsg & vbCrLf & ""
            objMail.display()
            Dim signature As String = ""
            signature = objMail.body
            objMail.body = smsg & vbCrLf & signature
            objMail = Nothing
            objOutlk = Nothing

            biasa_arrow()

        Catch ex As Exception
            biasa_arrow()
            MsgBox("Error : " & Err.Description & vbCrLf & pesan)
        End Try
    End Sub

   
    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click, Btn_Close1.Click
        Me.Close()
    End Sub

    Private Sub Btn_Email1_Click(sender As Object, e As EventArgs) Handles Btn_Email1.Click
        Try

            tunggu_arrow()
            '=================== STYLE =============================
            Dim tglfile As String = FormatTanggal_View(Date.Now)
            If (Not System.IO.Directory.Exists("C:\UNITYFILE\" & "REMINDER CONTRACT PER " & tglfile & ".xlsx")) Then
                Export_Excel_Payroll("EMAIL", tglfile)
            End If

            Me.Refresh()

            pesan = "Send Email"
            Dim objOutlk As New Outlook.Application 'Outlook
            Const olMailItem As Integer = 0
            Dim objMail As New System.Object
            Dim msg As String = ""

            objMail = objOutlk.CreateItem(olMailItem) 'Email item

            Dim tomsg As String = "mukti@fotexco.com;hrd.wanaherang@fotexco.com"
            objMail.To = tomsg

            'Insert your "CC" address...it can by dynamically populated
            objMail.cc = "paul@fotexco.com" 'Enter an address here To include a carbon copy; bcc is For blind carbon copy's
            'objMail.Bcc = "didi@fotexco.com"

            'Set up Subject Line
            objMail.subject = "End Kontrak STAFF dan NON STAFF"

            'To add an attachment, use:
            If (Not System.IO.Directory.Exists("C:\UNITYFILE\" & "REMINDER CONTRACT PER " & tglfile)) Then

                objMail.attachments.add("C:\UNITYFILE\" & "REMINDER CONTRACT PER " & tglfile & ".xlsx")
            End If

            ''otherwise, if no attachment, you can comment the objMail.attachments.add("") out with an apostrophe

            Dim smsg As String = "Dear Pak Paul "
            smsg = smsg & vbCrLf & ""
            smsg = smsg & vbCrLf & "Berikut ini saya Informasikan Karyawan yang sudah tidak aktif, tetapi Payroll masih aktif."
            smsg = smsg & vbCrLf & "Data ada di Attachment File"



            smsg = smsg & vbCrLf & ""
            objMail.display()
            Dim signature As String = ""
            signature = objMail.body
            objMail.body = smsg & vbCrLf & signature
            objMail = Nothing
            objOutlk = Nothing

            biasa_arrow()

        Catch ex As Exception
            biasa_arrow()
            MsgBox("Error : " & Err.Description & vbCrLf & pesan)
        End Try
    End Sub

    Private Sub dgContract_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgContract.CellContentClick

    End Sub

    Private Sub dgContract_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgContract.CurrentCellChanged
        Try
            ' If select_cell = "CELLSELECT" Then
            If dgContract.SelectedCells.Count = 0 Then
            Else
                If dgContract.CurrentCell.ColumnIndex >= 0 Then
                    For y As Integer = 0 To dgContract.RowCount - 1
                        If y Mod 2 = 0 Then
                            Me.dgContract.Rows(y).DefaultCellStyle.BackColor = Drawing.Color.White
                        Else
                            Me.dgContract.Rows(y).DefaultCellStyle.BackColor = Drawing.Color.WhiteSmoke
                        End If
                    Next
                    Me.dgContract.Rows(dgContract.CurrentRow.Index).DefaultCellStyle.BackColor = Drawing.Color.LightSkyBlue
                End If

                
            End If
            'End If
        Catch ex As Exception
            biasa_arrow()
            'MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgUnActive_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgUnActive.CurrentCellChanged
        Try
            ' If select_cell = "CELLSELECT" Then
            If dgUnActive.SelectedCells.Count = 0 Then
            Else
                If dgUnActive.CurrentCell.ColumnIndex >= 0 Then
                    For y As Integer = 0 To dgUnActive.RowCount - 1
                        If y Mod 2 = 0 Then
                            Me.dgUnActive.Rows(y).DefaultCellStyle.BackColor = Drawing.Color.White
                        Else
                            Me.dgUnActive.Rows(y).DefaultCellStyle.BackColor = Drawing.Color.WhiteSmoke
                        End If
                    Next
                    Me.dgUnActive.Rows(dgContract.CurrentRow.Index).DefaultCellStyle.BackColor = Drawing.Color.LightSkyBlue
                End If
            End If
            'End If
        Catch ex As Exception
            biasa_arrow()
            'MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExcelActing_Click(sender As Object, e As EventArgs) Handles ExcelActing.Click
        Dim namafilexls As String = "Reminder_Acting"
        Try
            pesan = "save excel"
            tunggu_arrow()
            Dim xlApp As Microsoft.Office.Interop.Excel.Application 'Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook 'Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            xlWorkSheet.Name = "REMINDER ACTING"

            Dim titlerpt As String = ""

            titlerpt = "REMINDER ACTING "

            xlWorkSheet.Cells(1, 1) = titlerpt
            xlWorkSheet.Cells(1, 1).EntireRow.Font.size = 16
            xlWorkSheet.Cells(1, 1).EntireRow.Font.color = 3
            xlWorkSheet.Cells(1, 1).EntireRow.font.bold = True

            xlWorkSheet.Cells(1, 9) = "Print Date :"
            xlWorkSheet.Cells(1, 11) = "'" & LoginForm.get_date_server
            Dim jrow As Integer = 2


            xlWorkSheet.Cells(jrow, 1).EntireRow.Font.size = 12
            xlWorkSheet.Cells(jrow, 1).EntireRow.font.bold = True

            For col As Integer = 0 To Me.dgActing.Columns.Count - 1
                xlWorkSheet.Cells(jrow, col + 1) = Me.dgActing.Columns(col).HeaderText
            Next

            jrow += 1

            For row As Integer = 0 To Me.dgActing.RowCount - 1
                For col As Integer = 0 To Me.dgActing.Columns.Count - 1
                    xlWorkSheet.Cells(jrow, col + 1) = Me.dgActing.Item(col, row).Value
                Next
                jrow += 1
            Next

            If (Not System.IO.Directory.Exists("C:\UNITYFILE\")) Then
                System.IO.Directory.CreateDirectory("C:\UNITYFILE")
            End If

            namafilexls = ""

            namafilexls = namafilexls & Str(Me.dgActing.RowCount)
            namafilexls = ubahhrf_namafile(titlerpt) & ".xlsx"
            xlWorkSheet.SaveAs("C:\UNITYFILE\" & namafilexls)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            biasa_arrow()


            MsgBox("You can find the file C:\UNITYFILE\" & namafilexls)
            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Open("C:\UNITYFILE\" & namafilexls)
            xlApp.Visible = True
            xlWorkBook.Activate()
            
        Catch ex As Exception
            biasa_arrow()
            If Err.Number = 1004 Then
                MessageBox.Show(pesan & vbCrLf & "File " & namafilexls & ".xls Already Open, Close First ", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(pesan & vbCrLf & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
End Class