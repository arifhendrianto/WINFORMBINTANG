Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

'Imports System.Windows.Forms.Form

Module MyModule
    'Public pdir As String = "C:\Documents and Settings\Admin\My Documents\Visual Studio 2005\Projects\MDAPPL\MDAPPL\"
    Public pdir As String = "C:\Program Files\SYMBIOS_BSMM\"
    'Public pdir As String = Application.StartupPath
    Public siduser As String
    Public sdatabs As String
    Public userid_email As String
    Public susername As String
    Public sdivisi As String
    Public sAppAdmin As String
    Public susergroup As String
    Public steam As String
    Public sipaddress As String
    'Public sketproses As String
    Public sstsuser As String
    Public urut As Integer
    Public sqlstr As String
    Public sqlstr1 As String
    Public sqlstr2 As String
    Public cnMR As SqlClient.SqlConnection '  SqlConnection
    'Public cnMR_ADO As ADODB.Connection
    Public cn_Prod As SqlClient.SqlConnection '  SqlConnection
    Public cn As SqlClient.SqlConnection '  SqlConnection
    Public cn_md As SqlClient.SqlConnection '  SqlConnection
    Public cn1 As SqlClient.SqlConnection '  SqlConnection
    Public cn_sage As OdbcConnection ' OleDb.OleDbConnection
    Public tmprptcn As OleDb.OleDbConnection
    'Public dbfcnt As Odbc.OdbcConnection
    Public pesan As String
    Public ada_record As String
    Public beditan As Boolean
    Public sresponse As String
    Public bbenar As Boolean
    Public sgeserstat As String
    Public stablename As String
    Public stabledesc As String
    Public sprintopt As String = "Print Company Name ?"
    Public spasspar As String, spasscari As String, titleformcari As String
    Public sserver, suid As String
    Public spwd, sdbs As String
    Public sfieldname As String
    Public bunique As Boolean
    Public srunno As String
    Public strmonth, stgl, stryear, strday As String
    Public tglserver As DateTime = Now
    Public bbypass As Boolean
    Public syearacc, syearelse As String
    Public stxtgetfromgrid As String = ""
    Public modulename As String = ""
    Public kolomcheck As Boolean = False
    Public getgridcari(1000, 25)
    Public getgridcariBOM(20, 50)
    Public dtlarray(50, 3, 4) As String
    Public cndesc As String
    Public gridcaricode1 As String
    Public gridcaricode2 As String
    Public gridcaricode3 As String
    Public gridcaricode4 As String
    Public gridcaricode5 As String
    Public gridcaricode6 As String
    Public reportname As String 
    Public gaccteomdate As Date, gaccteomtmpdate As Date
    Public temp_stylecode As String = ""
    Public temp_sizebasic As String = ""
    Public temp_mcetype As String = ""
    Public sCompany As String
    Public sComAddress1 As String
    Public sComAddress2 As String
    Public sComAddress3 As String
    Public skantorPabean As String
    Public sJenisTBP As String
    Public sJenisTBPAsal As String
    Public sNPWP As String
    Public lokasicompany As String = "WHN"
   
    Public sverfromdbs As String = ""

    Public dtlarraylibur(0, 1)
    Public dtlarrayliburOT(0, 1)
 
    'Function UnSortedColumn(ByVal dg As DataGridView, Optional enabled As Boolean = False)
    '    For f As Integer = 0 To dg.Rows.Count - 1
    '        If enabled = False Then
    '            dg.Columns(f).SortMode = DataGridViewColumnSortMode.NotSortable
    '        Else
    '            dg.Columns(f).SortMode = DataGridViewColumnSortMode.Automatic
    '        End If
    '    Next
    'End Function

    Function FindDate(sfinddate As String, datetime As String) As String
        stxtgetfromgrid = "N"
        gridcaricode1 = sfinddate
        gridcaricode2 = datetime
        Browsercalendar.ShowDialog()
        If stxtgetfromgrid = "Y" Then
            sfinddate = getgridcari(0, 1)
            'If datetime = "DATETIME" Then
            '    sfinddate = getgridcari(0, 1)
            'ElseIf datetime = "DATEAWAL" Then
            '    sfinddate = getgridcari(0, 1)
            'Else
            '    sfinddate = FormatTanggal_View(getgridcari(0, 1))
            'End If
        End If
        FindDate = sfinddate
    End Function

    Function cek_holidaydate(ByVal cekdate As Date) As Boolean
        Dim tambah As Boolean = False
        Dim crlibur As Integer = 0
        If cekdate.DayOfWeek <> DayOfWeek.Sunday And cekdate.DayOfWeek <> DayOfWeek.Saturday Then
            For crlibur = 0 To UBound(dtlarraylibur)
                If cekdate = CDate(dtlarraylibur(crlibur, 1)) Then
                    tambah = True
                    Exit For
                End If
            Next crlibur
        Else
            tambah = True
            For crlibur = 0 To UBound(dtlarrayliburOT)
                If cekdate = CDate(dtlarrayliburOT(crlibur, 1)) Then
                    tambah = False
                    Exit For
                End If
            Next crlibur
        End If
        cek_holidaydate = tambah
    End Function

    Function ubahhrf_char(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, ")", "%") ' kurung jadi kotak
        hasil = Replace(hasil, "(", "%")
        hasil = Replace(hasil, "]", "%")
        hasil = Replace(hasil, "[", "%")
        ubahhrf_char = hasil
    End Function

    Function ubahhrf(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, "'", "`") ' petik satu jadi "`"
        hasil = Replace(hasil, Chr(34), " ") ' petik dua jadi spasi
        'hasil = Replace(hasil, ")", "]") ' kurung jadi kotak
        'hasil = Replace(hasil, "(", "[")
        hasil = Replace(hasil, "[", "(")
        hasil = Replace(hasil, "]", ")")
        hasil = Replace(hasil, ",", ".")
        ubahhrf = hasil
    End Function

    Function ubahhrf_fnd(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, "'", "`") ' petik satu jadi "`"
        hasil = Replace(hasil, Chr(34), " ") ' petik dua jadi spasi
        hasil = Replace(hasil, ")", "%") ' kurung jadi kotak
        hasil = Replace(hasil, "(", "%")
        hasil = Replace(hasil, "]", "%") ' kurung jadi kotak
        hasil = Replace(hasil, "[", "%")
        hasil = Replace(hasil, ",", ".")
        ubahhrf_fnd = hasil
    End Function

    Function ubahhrf_Enter(ByRef inputan As String) As String
        Dim hasil_enter As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil_enter = ""
        hasil_enter = Replace(inputan, Chr(13), "") ' petik dua jadi spasi
        ubahhrf_Enter = hasil_enter
    End Function

    Function ubahhrf_sage(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, "`", "%") ' petik satu jadi "`"
        hasil = Replace(inputan, " ", "%") ' petik satu jadi "`"
        'hasil = Replace(hasil, Chr(13), "") ' petik dua jadi spasi
        hasil = Replace(hasil, "]", ")") ' kurung jadi kotak
        hasil = Replace(hasil, "[", "(")
        hasil = Replace(hasil, ",", ".")
        ubahhrf_sage = hasil
    End Function

    Function ubahhrf_rpt(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, "'", "`") ' petik satu jadi "`"
        hasil = Replace(hasil, Chr(34), " ") ' petik dua jadi spasi
        hasil = Replace(hasil, ")", "]") ' kurung jadi kotak
        hasil = Replace(hasil, "(", "[")
        hasil = Replace(hasil, ",", ".")
        ubahhrf_rpt = hasil
    End Function

    Function ubahhrf_namafile(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, "'", "") ' petik satu jadi "`"
        hasil = Replace(inputan, "`", "") ' petik satu jadi "`"
        hasil = Replace(hasil, Chr(34), " ") ' petik dua jadi spasi
        hasil = Replace(hasil, ")", "") ' kurung jadi kotak
        hasil = Replace(hasil, "(", "")
        hasil = Replace(hasil, "]", "") ' kurung jadi kotak
        hasil = Replace(hasil, "[", "")
        hasil = Replace(hasil, "\", "")
        hasil = Replace(hasil, "/", "")
        hasil = Replace(hasil, "*", "")
        hasil = Replace(hasil, "%", "")
        hasil = Replace(hasil, "&", "")
        hasil = Replace(hasil, "!", "")
        hasil = Replace(hasil, "+", "")
        hasil = Replace(hasil, "=", "")
        hasil = Replace(hasil, "|", "")
        hasil = Replace(hasil, "?", "")
        hasil = Replace(hasil, ">", "")
        hasil = Replace(hasil, "<", "")
        hasil = Replace(hasil, ":", "")
        hasil = Replace(hasil, ";", "")
        hasil = Replace(hasil, "@", "")
        hasil = Replace(hasil, "#", "")
        hasil = Replace(hasil, "^", "")
        hasil = Replace(hasil, ".", "")
        hasil = Replace(hasil, ",", "")
        ubahhrf_namafile = hasil
    End Function

    Function ubahhrf_find(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, "'", "`") ' petik satu jadi "`"        
        hasil = Replace(hasil, ",", ".")
        ubahhrf_find = hasil
    End Function

    Function cek_field_null(ByRef inputan As String) As String
        Dim hasil As String
        ' untuk mengubah tanda petik satu ( ' ) menjadi "`" dan petik dua ( " ) menjadi spasi
        hasil = ""
        hasil = Replace(inputan, "'", "`") ' petik satu jadi "`"
        hasil = Replace(hasil, Chr(34), " ") ' petik dua jadi spasi
        'hasil = Replace(hasil, ")", "]") ' kurung jadi kotak
        'hasil = Replace(hasil, "(", "[")
        'hasil = Replace(hasil, ",", ".")
        cek_field_null = hasil
    End Function

    Function kol_layout(ByRef inputan As String, ByRef pjgkol As Short, ByRef ialign As Short) As String
        Dim pjgfld As Short
        Dim hsllayout As String = ""
        inputan = UCase(Trim(inputan))
        pjgfld = Len(inputan)

        Select Case pjgfld
            Case Is < pjgkol
                Select Case ialign
                    Case 0
                        hsllayout = inputan & Space(pjgkol - pjgfld)
                    Case 1
                        hsllayout = Space(pjgkol - pjgfld) & inputan
                End Select
            Case Is >= pjgkol
                Select Case ialign
                    Case 0
                        hsllayout = Left(Trim(inputan), pjgkol)
                    Case 1
                        hsllayout = Right(Trim(inputan), pjgkol)
                End Select
        End Select
        kol_layout = hsllayout
    End Function

    Sub cmp_datesystem_next(ByRef fldname As String, ByRef transname As String, ByRef datevalue_Renamed As Date)
        Dim scurrdate, seomdate As String
        If bbenar Then
            scurrdate = Trim(CStr(Year(CDate(datevalue_Renamed)))) & Format(Month(datevalue_Renamed), "00")

            If Month(tglserver.Date) + 1 >= 13 Then
                Call Periode_end(CShort(Trim(CStr(1))), CShort(Trim(CStr(Year(tglserver.Date) + 1))))
                seomdate = Trim(CStr(1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(tglserver.Date) + 1))
            Else
                Call Periode_end(CShort(Trim(CStr(Month(tglserver.Date) + 1))), CShort(Trim(CStr(Year(tglserver.Date)))))
                seomdate = Trim(CStr(Month(tglserver.Date) + 1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(tglserver.Date)))
            End If

            If Month(CDate(seomdate)) + 1 >= 13 Then
                Call Periode_end(CShort(Trim(CStr(1))), CShort(Trim(CStr(Year(CDate(seomdate)) + 1))))
                seomdate = Trim(CStr(1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(CDate(seomdate)) + 1))
            Else
                Call Periode_end(CShort(Trim(CStr(Month(CDate(seomdate)) + 1))), CShort(Trim(CStr(Year(CDate(seomdate))))))
                seomdate = Trim(CStr(Month(CDate(seomdate)) + 1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(CDate(seomdate))))
            End If

            If IsDate(seomdate) Then
            Else
                seomdate = Trim(CStr(Month(CDate(seomdate)) + 1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(CDate(seomdate))))
            End If

            seomdate = Trim(CStr(Year(CDate(seomdate)))) & Format(Month(seomdate), "00") 'Trim(Month(CDate(datevalue)))
            If Val(scurrdate) > Val(seomdate) Then
                bbenar = False
                pesan = fldname & " > Date System Next 2 month. Process Denied ! ( " & Trim(transname) & " )"
            End If

        End If
    End Sub

    Sub cmp_datesystem_prev(ByRef fldname As String, ByRef transname As String, ByRef datevalue_Renamed As Date)
        Dim scurrdate, seomdate As String
        If bbenar Then
            scurrdate = Trim(CStr(Year(CDate(datevalue_Renamed)))) & Format(Month(datevalue_Renamed), "00")
            If Month(tglserver.Date) - 1 = 0 Then
                Call Periode_end(CShort(Trim(CStr(12))), CShort(Trim(CStr(Year(tglserver.Date) - 1))))
                seomdate = Trim(CStr(12)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(tglserver.Date) - 1))
            Else
                Call Periode_end(CShort(Trim(CStr(Month(tglserver.Date) - 1))), CShort(Trim(CStr(Year(tglserver.Date)))))
                seomdate = Trim(CStr(Month(tglserver.Date) - 1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(tglserver.Date)))
            End If

            If Month(CDate(seomdate)) - 1 = 0 Then
                Call Periode_end(CShort(Trim(CStr(12))), CShort(Trim(CStr(Year(CDate(seomdate)) - 1))))
                seomdate = Trim(CStr(12)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(CDate(seomdate)) - 1))
            Else
                Call Periode_end(CShort(Trim(CStr(Month(CDate(seomdate)) - 1))), CShort(Trim(CStr(Year(CDate(seomdate))))))
                seomdate = Trim(CStr(Month(CDate(seomdate)) - 1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(CDate(seomdate))))
            End If

            If IsDate(seomdate) Then
            Else
                seomdate = Trim(CStr(Month(CDate(seomdate)) - 1)) & "/" & Trim(stgl) & "/" & Trim(CStr(Year(CDate(seomdate))))
            End If

            seomdate = Trim(CStr(Year(CDate(seomdate)))) & Format(Month(seomdate), "00") 'Trim(Month(CDate(datevalue)))
            If Val(scurrdate) <= Val(seomdate) Then
                bbenar = False
                pesan = fldname & " < Date System previous 2 month. Process Denied ! ( " & Trim(transname) & " )"
            End If

        End If
    End Sub

    Sub blockdate_lebihkecil_lebihbesar_daritglserver(ByRef fldname As String, ByRef transname As String, ketproses As String, ByRef datevalue As Date, ByRef datevalueprev As Date, prevday As Integer, nextday As Integer)
        Dim scurrdate
        Dim sdatevalue As Date = datevalue
        Select Case ketproses
            Case "ADD", "SAVE", "UPDATEE"
                sdatevalue = datevalueprev
            Case Else
                sdatevalue = datevalue
                If tglserver.Date > sdatevalue Then
                    sdatevalue = tglserver.Date
                End If
        End Select
        If bbenar Then
            scurrdate = DateDiff(DateInterval.Day, tglserver.Date, sdatevalue)
            If scurrdate < prevday Then
                bbenar = False
                pesan = fldname & " <= Date System previous " & prevday & " day. Process Denied ! ( " & Trim(transname) & " )"
            End If
        End If
        If bbenar And nextday > 0 Then
            scurrdate = DateDiff(DateInterval.Day, tglserver.Date, datevalue)
            If scurrdate >= nextday Then
                bbenar = False
                pesan = fldname & " >= Date System  " & nextday & " day. Process Denied ! ( " & Trim(transname) & " )"
            End If
        End If
    End Sub

    Sub cmp_datesystem_prev14_day(ByRef fldname As String, ByRef transname As String, ByRef datevalue_Renamed As Date)
        Dim scurrdate
        If bbenar Then
            scurrdate = DateDiff(DateInterval.Day, tglserver.Date, datevalue_Renamed)
            If scurrdate <= -14 Then
                bbenar = False
                pesan = fldname & " < Date System previous 14 day. Process Denied ! ( " & Trim(transname) & " )"
            End If
        End If
    End Sub

    Sub cmp_datesystem_next2day(ByRef fldname As String, ByRef transname As String, ByRef datevalue_Renamed As Date)
        Dim scurrdate
        If bbenar Then
            scurrdate = DateDiff(DateInterval.Day, tglserver.Date, datevalue_Renamed)
            If scurrdate >= 2 Then
                bbenar = False
                pesan = fldname & " > Date System (" & Today.Date & ") . Process Denied ! ( " & Trim(transname) & " )"
            End If
        End If
    End Sub

    Sub cmp_datesystem_prev1_month(ByRef fldname As String, ByRef transname As String, ByRef datevalue_Renamed As Date)
        Dim scurrdate
        If bbenar Then
            scurrdate = DateDiff(DateInterval.Day, tglserver.Date, datevalue_Renamed)
            If scurrdate <= -30 Then
                bbenar = False
                pesan = fldname & " < Date System previous 1 month. Process Denied ! ( " & Trim(transname) & " )"
            End If
        End If
    End Sub

    Sub cmp_datesystem_next1_month(ByRef fldname As String, ByRef transname As String, ByRef datevalue_Renamed As Date)
        Dim scurrdate
        If bbenar Then
            scurrdate = DateDiff(DateInterval.Day, tglserver.Date, datevalue_Renamed)
            If scurrdate >= 30 Then
                bbenar = False
                pesan = fldname & " > Date System Next 1 month. Process Denied ! ( " & Trim(transname) & " )"
            End If
        End If
    End Sub

    Public Function Periode_end(ByRef iBul As Short, ByRef iYear As Short) As String
        Select Case iBul
            Case 1, 3, 5, 7, 8, 10, 12
                stgl = "31"
            Case 2
                If (iYear Mod 4) = 0 Then
                    stgl = "29"
                Else
                    stgl = "28"
                End If
            Case 4, 6, 9, 11
                stgl = "30"
        End Select
        '
        Periode_end = stgl
        '
    End Function

    Function encrypt(ByVal inputan As String) As String
        Dim ambil As String, ganti As String, hasil As String
        Dim ctr As Integer, pjgfld As Integer, myresult As Integer
        hasil = ""
        pjgfld = Len(inputan)
        pjgfld = pjgfld
        For ctr = 1 To pjgfld Step 1
            ambil = ""
            ambil = Mid(inputan, ctr, 1)
            myresult = ctr Mod 2
            If myresult = 0 Then
                ganti = Chr(Asc(ambil) - ctr)
            Else
                ganti = Chr(Asc(ambil) + ctr)
            End If
            hasil = hasil & ganti
        Next ctr
        encrypt = hasil
    End Function

    Function decrypt(ByRef inputan As String) As String
        Dim ganti, ambil, hasil As String
        Dim pjgfld, myresult As Short
        hasil = ""
        pjgfld = Len(inputan)
        pjgfld = pjgfld
        For urut = 1 To pjgfld Step 1
            ambil = ""
            ambil = Mid(inputan, urut, 1)
            myresult = urut Mod 2
            If myresult = 0 Then
                ganti = Chr(Asc(ambil) + urut)
            Else
                ganti = Chr(Asc(ambil) - urut)
            End If
            hasil = hasil & ganti
        Next urut
        decrypt = hasil
    End Function

    Function kurangi_tgl(ByVal inputdate As Date, ByVal krg As Integer) As String
        Dim hsltglkurang As String = ""
        Dim tgl As Integer

        tgl = (Val(Microsoft.VisualBasic.Day(CDate(inputdate))) - krg)
        If bbenar Then

            If tgl <= 0 Then
                If Val(Month(inputdate)) - 1 <= 0 Then
                    hsltglkurang = "12" & "/31/" & Val(Microsoft.VisualBasic.Right(Year(inputdate), 2)) - 1
                Else
                    Call Periode_end(Val(Month(inputdate)) - 1, CShort(Trim(CStr(Year(inputdate)))))
                    hsltglkurang = Format(Val(Month(inputdate)) - 1, "00") & "/" & Trim(stgl) & "/" & Microsoft.VisualBasic.Right(Year(inputdate), 2)
                End If
            Else
                hsltglkurang = Format(Month(inputdate), "00") & "/" & tgl & "/" & Microsoft.VisualBasic.Right(Year(inputdate), 2)
            End If

        End If
        kurangi_tgl = hsltglkurang
    End Function

    Function MonthName(ByVal sBlnName As String) As String
        Dim sKata As String

        sKata = ""

        Select Case Trim(sBlnName)
            Case "1", "01"
                sKata = "January"
            Case "2", "02"
                sKata = "February"
            Case "3", "03"
                sKata = "March"
            Case "4", "04"
                sKata = "April"
            Case "5", "05"
                sKata = "May"
            Case "6", "06"
                sKata = "June"
            Case "7", "07"
                sKata = "July"
            Case "8", "08"
                sKata = "August"
            Case "9", "09"
                sKata = "September"
            Case "10"
                sKata = "October"
            Case "11"
                sKata = "November"
            Case "12"
                sKata = "December"
            Case "13"
                sKata = "Cancel Order"
        End Select
        MonthName = sKata
    End Function

    Function MonthNumber(ByVal sBlnName As String) As String
        Dim sKata As String

        sKata = ""

        Select Case UCase(Trim(sBlnName))
            Case Is = "January", "JANUARY", "Jan", "JAN"
                sKata = "01"
            Case "February", "FEBRUARY", "Feb", "FEB"
                sKata = "02"
            Case "March", "MARCH", "Mar", "MAR"
                sKata = "03"
            Case "April", "APRIL", "Apr", "APR"
                sKata = "04"
            Case "May", "MAY", "May", "MAY"
                sKata = "05"
            Case "June", "JUNE", "Jun", "JUN"
                sKata = "06"
            Case "July", "JULY", "Jul", "JUL"
                sKata = "07"
            Case "August", "AUGUST", "Aug", "AUG"
                sKata = "08"
            Case "September", "SEPTEMBER", "Sep", "SEP"
                sKata = "09"
            Case "October", "OCTOBER", "Oct", "OCT"
                sKata = "10"
            Case "November", "NOVEMBER", "Nov", "NOV"
                sKata = "11"
            Case "December", "DECEMBER", "Dec", "DEC"
                sKata = "12"
            Case "Cancel Order", "CANCEL ORDER", "Cancel", "CANCEL"
                sKata = "13"
        End Select
        MonthNumber = sKata
    End Function

    Function Abjad(ByVal noAbjad As String) As String
        Dim sHuruf As String

        sHuruf = ""

        Select Case Trim(Val(noAbjad) + 1)
            Case "1", "01"
                sHuruf = "A"
            Case "2", "02"
                sHuruf = "B"
            Case "3", "03"
                sHuruf = "C"
            Case "4", "04"
                sHuruf = "D"
            Case "5", "05"
                sHuruf = "E"
            Case "6", "06"
                sHuruf = "F"
            Case "7", "07"
                sHuruf = "G"
            Case "8", "08"
                sHuruf = "H"
            Case "9", "09"
                sHuruf = "I"
            Case "10"
                sHuruf = "J"
            Case "11"
                sHuruf = "K"
            Case "12"
                sHuruf = "L"

            Case "13"
                sHuruf = "M"
            Case "14"
                sHuruf = "N"
            Case "15"
                sHuruf = "O"
            Case "16"
                sHuruf = "P"
            Case "17"
                sHuruf = "Q"
            Case "18"
                sHuruf = "R"
            Case "19"
                sHuruf = "S"
            Case "20"
                sHuruf = "T"
            Case "21"
                sHuruf = "U"
            Case "22"
                sHuruf = "V"
            Case "23"
                sHuruf = "W"
            Case "24"
                sHuruf = "X"
            Case "25"
                sHuruf = "Y"
            Case "26"
                sHuruf = "Z"
            Case "27"
                sHuruf = "AA"
            Case "28"
                sHuruf = "AB"
            Case "29"
                sHuruf = "AC"
            Case "30"
                sHuruf = "AD"
            Case "31"
                sHuruf = "AE"
            Case "32"
                sHuruf = "AF"
            Case "33"
                sHuruf = "AG"
            Case "34"
                sHuruf = "AH"
            Case "35"
                sHuruf = "AI"
            Case "36"
                sHuruf = "AJ"
            Case "37"
                sHuruf = "AK"
            Case "38"
                sHuruf = "AL"
            Case "39"
                sHuruf = "AM"
            Case "40"
                sHuruf = "AN"
            Case "41"
                sHuruf = "AO"
            Case "42"
                sHuruf = "AP"
            Case "43"
                sHuruf = "AQ"
            Case "44"
                sHuruf = "AR"
            Case "45"
                sHuruf = "AS"
            Case "46"
                sHuruf = "AT"
            Case "47"
                sHuruf = "AU"
            Case "48"
                sHuruf = "AV"
            Case "49"
                sHuruf = "AW"
            Case "50"
                sHuruf = "AX"
            Case "51"
                sHuruf = "AY"
            Case "52"
                sHuruf = "AZ"
            Case "53"
                sHuruf = "BA"
            Case "54"
                sHuruf = "BB"
            Case "55"
                sHuruf = "BC"
            Case "56"
                sHuruf = "BD"
            Case "57"
                sHuruf = "BE"
            Case "58"
                sHuruf = "BF"
            Case "59"
                sHuruf = "BG"
            Case "60"
                sHuruf = "BH"
            Case "61"
                sHuruf = "BI"
            Case "62"
                sHuruf = "BJ"
            Case "63"
                sHuruf = "BK"
            Case "64"
                sHuruf = "BL"
            Case "65"
                sHuruf = "BM"
            Case "66"
                sHuruf = "BN"
            Case "67"
                sHuruf = "BO"
            Case "68"
                sHuruf = "BP"

        End Select
        Abjad = sHuruf
    End Function

    Function FormatTanggal_View(ByVal stanggal As Date) As String
        Dim sKata As String
        sKata = ""
        If stanggal = "01/01/1900" Or stanggal = "01/01/2000" Then
            sKata = ""
        Else
            sKata = Format(stanggal, "dd MMM yy")
        End If
        FormatTanggal_View = sKata
    End Function

    Function FormatTanggal_Save(ByVal stanggal As String) As Date
        Dim sKata As Date
        If stanggal = "" Then
            sKata = CDate("01/01/1900")
        Else
            sKata = CDate(stanggal)
        End If
        FormatTanggal_Save = sKata
    End Function

    Function FormatNumber_View(ByVal nilai As Double, ByVal sdecimal As Integer) As String
        Dim snilai As String = ""
        Select Case sdecimal
            Case 0
                snilai = Format(nilai, "###,###,###,###")
            Case 1
                snilai = Format(nilai, "###,###,###,##0.0")
            Case 2
                snilai = Format(nilai, "###,###,###,##0.#0")
            Case 3
                snilai = Format(nilai, "###,###,###,##0.##0")
            Case 4
                snilai = Format(nilai, "###,###,###,##0.###0")
            Case 5
                snilai = Format(nilai, "###,###,###,##0.####0")
            Case 6
                snilai = Format(nilai, "###,###,###,##0.#####0")
        End Select
        'If nilai >= 0 And nilai < 0.9 Then
        '    snilai = nilai
        'End If
        FormatNumber_View = snilai
    End Function

    Function FormatNumber_clear(ByVal nilai As String) As String
        FormatNumber_clear = Replace(nilai, ",", "")
    End Function

    Function FormatNumber_excel(ByVal nilai As Double, ByVal sdecimal As Integer) As String
        Dim snilai As String = ""
        Select Case sdecimal
            Case 0
                snilai = Format(nilai, "###,###,###,###")
            Case 1
                snilai = Format(nilai, "###,###,###,###.#")
            Case 2
                snilai = Format(nilai, "###,###,###,###.##")
            Case 3
                snilai = Format(nilai, "###,###,###,###.###")
            Case 4
                snilai = Format(nilai, "###,###,###,###.####")
            Case 5
                snilai = Format(nilai, "###,###,###,###.#####")
            Case 6
                snilai = Format(nilai, "###,###,###,###.######")
        End Select

        FormatNumber_excel = IIf(nilai = 0, "-", snilai)
    End Function

    Function FormatAcct_View(ByVal nilai As String) As String
        Dim snilai As String = nilai
        If Len(nilai) >= 7 Then
            snilai = Microsoft.VisualBasic.Left(nilai, 3) & "-" & Microsoft.VisualBasic.Mid(nilai, 4, 4)
        End If
        FormatAcct_View = snilai
    End Function

    Function FormatAcct_Save(ByVal nilai As String) As String
        FormatAcct_Save = Replace(nilai, "-", "")
    End Function

    Function Get_days_sizeset(ByVal prodtype) As Integer
        Dim dayss As Integer = 0
        If (InStr(1, UCase(prodtype.Trim), "NON MOULD", CompareMethod.Binary) <> 0) Then
            dayss = 45
        ElseIf (InStr(1, UCase(prodtype.Trim), "MOULD", CompareMethod.Binary) <> 0) Then
            dayss = 70
        Else ' "Brief", "Thong", "Boxer"
            dayss = 30
        End If
        Get_days_sizeset = dayss
    End Function

    Function Get_days_sample(ByVal prodtype) As Integer
        Dim daypp As Integer = 0
        If (InStr(1, UCase(prodtype.Trim), "NON MOULD", CompareMethod.Binary) <> 0) Then
            daypp = 30
        ElseIf (InStr(1, UCase(prodtype.Trim), "MOULD", CompareMethod.Binary) <> 0) Then
            daypp = 40
        Else ' "Brief", "Thong", "Boxer"
            daypp = 30
        End If
        Get_days_sample = daypp
    End Function
End Module
