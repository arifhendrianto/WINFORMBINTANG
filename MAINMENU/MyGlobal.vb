Imports System.Data
Imports System.Data.SqlClient

Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO.FileStream
Imports System.IO.StreamReader

Public Class MyGlobal

    Public sapplname, sapplcode As String
    Public sapplver As String
    Public cndesc As String


    Dim cn1 As New SqlConnection
    Dim cmd1 As New SqlCommand
    Dim dtRead1 As SqlDataReader
    Dim trans As SqlTransaction = Nothing
    
    Private Shared sqlCommand As SqlCommand
    Private Shared sqlTrans As SqlTransaction

    Public Function ConvertBytesToMemoryStream(ByVal ImageData As Byte()) As IO.MemoryStream
        Try
            If IsNothing(ImageData) = True Then
                Return Nothing
                'Throw New ArgumentNullException("Image Binary Data Cannot be Null or Empty", "ImageData")
            End If
            Return New System.IO.MemoryStream(ImageData)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Dim returnImage As Image = Image.FromStream(ms)
        Return returnImage
    End Function

    Public Function ImageToByte(ByVal img As Image) As Byte()
        Dim imgStream As MemoryStream = New MemoryStream()
        If IsNothing(img) = True Then
            Return Nothing
        Else
            img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Jpeg)
            imgStream.Close()
            Dim byteArray As Byte() = imgStream.ToArray()
            imgStream.Dispose()

            Return byteArray
        End If
        
    End Function

    Public Function ConvertImageFiletoBytes(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
     

    Function connectiondatatemp() As OleDb.OleDbConnection
        
        tmprptcn = New OleDb.OleDbConnection("provider=microsoft.jet.oledb.4.0;" & _
                    "data source = " & pdir & "\INVDATA.mdb;" & _
                    "persist security info=false")
          
        Try
            MsgBox("buka access")
            tmprptcn.Open()
            'MsgBox("open buka access")
        Catch sx As OleDb.OleDbException
            MsgBox(sx.Message)
            'MsgBox(sx.InnerException.Message)
            MsgBox("Access Database Not Connected, FAIL !!!!!!!!!!!!!.........(connectiondatatemp)")
        End Try
        Return tmprptcn
    End Function
     

    Function cntsvr() As SqlConnection
        cndesc = ""
        baca_svrcfg()
        cn = New SqlConnection("server=" & Trim(sserver) & ";uid=" & Trim(suid) & ";pwd=" & Trim(spwd) & ";database=" & Trim(sdbs) & ";MultipleActiveResultSets=True")

        
        Try
            cn.Open()
            'cndesc = "GAGAL"
        Catch ex As Exception
            MsgBox("Database Server Not Connected, FAIL !!!!!!!!!!!!!......... , Connected Local Data ")
            cndesc = "GAGAL"
        End Try
        Return cn
    End Function
     
    Function baca_UserID()
        Dim UserID = ""

        Dim nmfile1 As String = pdir & "\UserID.txt"

        If Dir(Trim(nmfile1)) <> "" Then
            Dim objReader As New StreamReader(pdir & "\UserID.TXT")
            UserID = objReader.ReadLine()
            objReader.Close()
        End If

        baca_UserID = UserID
    End Function

     

    'Sub baca_svrcfg()
    '    Dim MyString = ""
    '    Dim ctr As Short

    '    FileOpen(1, pdir & "\SVRCFG.TXT", OpenMode.Input) ' Open file for input.

    '    ctr = 1
    '    Do While Not EOF(1)
    '        Input(1, MyString)
    '        Select Case ctr
    '            Case Is = 1
    '                suid = "sa"
    '            Case Is = 2
    '                sserver = "IT-07"
    '            Case Is = 3
    '                sdbs = "DBBINTANG"
    '            Case Is = 4
    '                spwd = "sqlhrd2015"
    '        End Select
    '        ctr = ctr + 1
    '    Loop
    '    FileClose(1)
    'End Sub


    Sub baca_svrcfg()
        Dim MyString = ""
        Dim ctr As Short

        FileOpen(1, pdir & "\SVRCFG.TXT", OpenMode.Input) ' Open file for input.

        ctr = 1
        Do While Not EOF(1)
            Input(1, MyString)
            Select Case ctr
                Case Is = 1
                    suid = dec_svrcfg(Trim(MyString))
                Case Is = 2
                    sserver = dec_svrcfg(Trim(MyString))
                Case Is = 3
                    sdbs = dec_svrcfg(Trim(MyString))
                Case Is = 4
                    spwd = dec_svrcfg(Trim(MyString))
            End Select
            ctr = ctr + 1
        Loop
        FileClose(1)
    End Sub


    Sub simpan_svrcfg()
        FileOpen(1, pdir & "\SVRCFG.TXT", OpenMode.Output) ' Open file for output.
        PrintLine(1, enc_svrcfg(Trim(suid))) ' Print text to file.
        PrintLine(1, enc_svrcfg(Trim(sserver)))
        PrintLine(1, enc_svrcfg(Trim(sdbs)))
        PrintLine(1, enc_svrcfg(Trim(spwd)))
        FileClose(1)
    End Sub

    Function enc_svrcfg(ByRef inputan As String) As String
        Dim ganti, ambil, hasil As String
        Dim pjgfld, ctr, myresult As Short
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
        enc_svrcfg = hasil
    End Function


    Function dec_svrcfg(ByRef inputan As String) As String
        Dim ganti, ambil, hasil As String
        Dim pjgfld, ctr, myresult As Short
        hasil = ""
        pjgfld = Len(inputan)
        pjgfld = pjgfld
        For ctr = 1 To pjgfld Step 1
            ambil = ""
            ambil = Mid(inputan, ctr, 1)
            myresult = ctr Mod 2
            If myresult = 0 Then
                ganti = Chr(Asc(ambil) + ctr)
            Else
                ganti = Chr(Asc(ambil) - ctr)
            End If
            hasil = hasil & ganti
        Next ctr
        dec_svrcfg = hasil
    End Function

    Function get_monthdays(ByRef dinputdate As Date) As Date
        Dim imonth, iYear As Short
        Dim tmpstr As String

        imonth = Month(dinputdate)
        iYear = Year(dinputdate)
        imonth = imonth + 1
        If imonth = 13 Then
            imonth = 1
            iYear = iYear + 1
        End If
        tmpstr = Format(imonth, "00") & "/01/" & Format(iYear, "0000")
        get_monthdays = System.DateTime.FromOADate(CDate(Format(tmpstr, "mm/dd/yyyy")).ToOADate - 1)
    End Function

    Function Periode_end(ByRef iBul As Short, ByRef iYear As Short) As String
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
     
    Public Function GetDataTable(cmd As SqlCommand) As DataTable
        Using sda As New SqlDataAdapter()
            cmd.Connection = cn
            sda.SelectCommand = cmd
            Using dt As New DataTable()
                sda.Fill(dt)
                Return dt
            End Using
        End Using
    End Function

    Public Function GetDataSet(ByVal query As String, ByVal table As String) As DataSet
        Using oleDa As New SqlDataAdapter(query, cn)
            Dim ds As New DataSet
            Try
                oleDa.Fill(ds, table)
                Return ds
            Catch ex As Exception
                Throw New Exception(ex.Message.ToString, ex)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function ExecuteNonQuery(ByVal query As String) As Boolean
        Try
            sqlCommand = New SqlCommand(query, cn, sqlTrans)
            sqlCommand.CommandType = CommandType.Text
            sqlCommand.CommandTimeout = 36000
            sqlCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                If Not sqlTrans.Connection Is DBNull.Value Then
                    sqlTrans.Rollback()
                End If
                'cn.Close()
            End If
            Throw New Exception(ex.Message.ToString, ex)
        End Try
    End Function


End Class
