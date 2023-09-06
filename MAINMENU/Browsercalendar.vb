Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlTransaction
Imports System.Data.OleDb.OleDbTransaction
Imports System.DBNull

Public Class Browsercalendar
    Dim ax As New MyGlobal

    Private Sub cmdclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Me.Close()
    End Sub

    Private Sub DG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Me.Close()
        cn.Close()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Close()
    End Sub
     

    Private Sub MonthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        stxtgetfromgrid = "Y"
        If gridcaricode2 = "DATETIME" Then
            getgridcari(0, 1) = FormatTanggal_View(e.Start.Date) & " " & Now.ToLongTimeString
        ElseIf gridcaricode2 = "DATEAWAL" Then
            getgridcari(0, 1) = FormatTanggal_View(CDate(e.Start.Date.Month & "/1/" & e.Start.Date.Year))
        ElseIf gridcaricode2 = "DATEAKHIR" Then 
            getgridcari(0, 1) = FormatTanggal_View(CDate(e.Start.Date.Month & "/" & Periode_end(e.Start.Date.Month, e.Start.Date.Year) & "/" & e.Start.Date.Year))
        Else
            getgridcari(0, 1) = FormatTanggal_View(e.Start.Date)
        End If
        Close()
    End Sub

    Private Sub Browsercalendar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If gridcaricode1 <> Nothing Then
            If gridcaricode1.Trim <> "" Then
                If IsDate(gridcaricode1) Then
                    'MonthCalendar1.TodayDate = CDate(FormatTanggal_Save(gridcaricode1))
                    Dim dt As Date = CDate(FormatTanggal_Save(gridcaricode1)) 'MonthNumber(blnname) + "/01/" + txtperiode.Text.Trim()
                    MonthCalendar1.SelectionStart = dt
                End If
            End If
        End If
        'isi_holiday()
    End Sub


    Private Sub isi_holiday()
        Try
            Dim Ilist As New List(Of Date) 'A list that will hold combobox items
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dtRead As SqlDataReader

            If cn.State = ConnectionState.Open Then cn.Close()
            cn = ax.cntsvr
            cmd.Connection = cn

            sqlstr = "select date from PRD_FM_HOLIDAY_V "
            sqlstr = sqlstr & " Order by date "
            cmd.CommandText = sqlstr
            dtRead = cmd.ExecuteReader
            If dtRead.Read = True Then
                Do
                    Ilist.Add(IIf(dtRead!date Is DBNull.Value, CDate("1900-01-01"), dtRead!date))
                Loop Until dtRead.Read = False
            End If
            dtRead.Close()
            dtRead = Nothing

            Dim startDate As Date = New Date(MonthCalendar1.TodayDate.Year, 1, 1)
            Dim endDate As Date = New Date(MonthCalendar1.TodayDate.Year, 12, 31)

            While startDate.DayOfWeek <> DayOfWeek.Saturday
                startDate = startDate.AddDays(1)
            End While

            Dim list As New List(Of Date)
            While startDate < endDate
                ' Add Saturday
                Ilist.Add(startDate)
                startDate = startDate.AddDays(1)
                ' Add Sunday
                Ilist.Add(startDate)

                ' Move to next week.
                startDate = startDate.AddDays(6)
            End While


            Dim AllHolidays As New List(Of Date)
            AllHolidays.AddRange(Ilist)

            MonthCalendar1.BoldedDates = AllHolidays.ToArray

            'Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()

            '' Set the calendar location.

            'Me.MonthCalendar1.Location = New System.Drawing.Point(47, 16)

            '' Change the color.

            'Me.MonthCalendar1.BackColor = System.Drawing.SystemColors.Info()

            'Me.MonthCalendar1.ForeColor = System.Drawing.Color.FromArgb(240)

            '' Add dates to MonthlyBoldedDates array.

            'Me.MonthCalendar1.MonthlyBoldedDates = New System.DateTime() {New System.DateTime(2011, 9, 15, 0, 0, 0, 0), New System.DateTime(2002, 9, 30, 0, 0, 0, 0)}

            '' Sets the maximum visible date on the calendar to 12/31/2011.

            'Me.MonthCalendar1.MaxDate = New System.DateTime(2011, 12, 31, 0, 0, 0, 0)

            '' Set the minimum visible date on the calendar to 01/01/1999.

            'Me.MonthCalendar1.MinDate = New System.DateTime(1999, 1, 1, 0, 0, 0, 0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class