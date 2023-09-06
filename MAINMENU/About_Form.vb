Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Public Class About_Form

    Inherits System.Windows.Forms.Form

    ' Reg Key Security Options...
    Const READ_CONTROL As Integer = &H20000
    Const KEY_QUERY_VALUE As Short = &H1S
    Const KEY_SET_VALUE As Short = &H2S
    Const KEY_CREATE_SUB_KEY As Short = &H4S
    Const KEY_ENUMERATE_SUB_KEYS As Short = &H8S
    Const KEY_NOTIFY As Short = &H10S
    Const KEY_CREATE_LINK As Short = &H20S
    Const KEY_ALL_ACCESS As Double = KEY_QUERY_VALUE + KEY_SET_VALUE + KEY_CREATE_SUB_KEY + KEY_ENUMERATE_SUB_KEYS + KEY_NOTIFY + KEY_CREATE_LINK + READ_CONTROL

    ' Reg Key ROOT Types...
    Const HKEY_LOCAL_MACHINE As Integer = &H80000002
    Const ERROR_SUCCESS As Short = 0
    Const REG_SZ As Short = 1 ' Unicode nul terminated string
    Const REG_DWORD As Short = 4 ' 32-bit number

    Const gREGKEYSYSINFOLOC As String = "SOFTWARE\Microsoft\Shared Tools Location"
    Const gREGVALSYSINFOLOC As String = "MSINFO"
    Const gREGKEYSYSINFO As String = "SOFTWARE\Microsoft\Shared Tools\MSINFO"
    Const gREGVALSYSINFO As String = "PATH"

    Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" (ByVal hKey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByVal lpData As String, ByRef lpcbData As Integer) As Integer
    Private Declare Function RegCloseKey Lib "advapi32" (ByVal hKey As Integer) As Integer

    Private Sub About_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbPT.Text = sCompany
        lbAlamat.Text = sComAddress1 & vbCrLf & _
           sComAddress2 & vbCrLf & _
           sComAddress3

        'lbPT.Text = decrypt(sCompany)
        'lbAlamat.Text = decrypt(sComAddress1) & vbCrLf & _
        '   decrypt(sComAddress2) & vbCrLf & _
        ' decrypt(sComAddress3)


        'lbPT.Text = "PT. Fotexco Busana International"
        'lbAlamat.Text = "Jl. Madura 6 Block D/04C," & vbCrLf & _
        '   "KBN Cakung Cilincing, Jakarta 14140, indonesia" & vbCrLf & _
        '   "Tel: +62 21 44820889      Fax: +62 21 44820229"

        '"This computer program is protected by copyright " & _
        '    "law and international treatis." & vbCrLf & _
        '    "Unauthorized reproduction or distribution " & _
        '    "of this program, or any portion of it, may " & _
        '    "result in severe civil and criminal penalties, " & _
        '    "and will be prosecuted to the maximum extent " & _
        '    "possible under law."
        lblDescription.Text = "Symbios System " & _
                vbCrLf & "Copyright 2023, All rights reserved."

        '      Sage PFW ERP (Version 5.4)
        '      Sage(Software)
        'Copyright 1995-2005 (c) Sage Software, Inc.  All rights reserved.

    End Sub

    Private Sub BTNSySINFO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSySINFO.Click
        Call StartSysInfo()
    End Sub

    Public Sub StartSysInfo()
        '        On Error GoTo SysInfoErr

        '        Dim rc As Long
        '        Dim SysInfoPath As String

        '        ' Try To Get System Info Program Path\Name From Registry...
        '        If GetKeyValue(HKEY_LOCAL_MACHINE, gREGKEYSYSINFO, gREGVALSYSINFO, SysInfoPath) Then
        '            ' Try To Get System Info Program Path Only From Registry...
        '        ElseIf GetKeyValue(HKEY_LOCAL_MACHINE, gREGKEYSYSINFOLOC, gREGVALSYSINFOLOC, SysInfoPath) Then
        '            ' Validate Existance Of Known 32 Bit File Version
        '            If (Dir(SysInfoPath & "\MSINFO32.EXE") <> "") Then
        '                SysInfoPath = SysInfoPath & "\MSINFO32.EXE"

        '                ' Error - File can't Be Found...
        '            Else
        '                GoTo SysInfoErr
        '            End If
        '            ' Error - Registry Entry can't Be Found...
        '        Else
        '            GoTo SysInfoErr
        '        End If

        '        Call Shell(SysInfoPath, vbNormalFocus)

        '        Exit Sub
        'SysInfoErr:
        '        MsgBox("System Information Is Unavailable At This Time", vbOKOnly)
    End Sub

    Public Function GetKeyValue(ByVal KeyRoot As Long, ByVal KeyName As String, ByVal SubKeyRef As String, ByRef KeyVal As String) As Boolean
        Dim i As Long                                           ' Loop Counter
        Dim rc As Long                                          ' Return Code
        Dim hKey As Long                                        ' Handle To An Open Registry Key
        'Dim hDepth As Long                                      '
        Dim KeyValType As Long                                  ' Data Type Of A Registry Key
        Dim tmpVal As String                                    ' Tempory Storage For A Registry Key Value
        Dim KeyValSize As Long                                  ' Size Of Registry Key Variable
        '------------------------------------------------------------
        ' Open RegKey Under KeyRoot {HKEY_LOCAL_MACHINE...}
        '------------------------------------------------------------
        rc = RegOpenKeyEx(KeyRoot, KeyName, 0, KEY_ALL_ACCESS, hKey) ' Open Registry Key

        If (rc <> ERROR_SUCCESS) Then GoTo GetKeyError ' Handle Error...

        tmpVal = New String(Chr(0), 1024)                             ' Allocate Variable Space
        KeyValSize = 1024                                       ' Mark Variable Size

        '------------------------------------------------------------
        ' Retrieve Registry Key Value...
        '------------------------------------------------------------
        rc = RegQueryValueEx(hKey, SubKeyRef, 0, _
                             KeyValType, tmpVal, KeyValSize)    ' Get/Create Key Value

        If (rc <> ERROR_SUCCESS) Then GoTo GetKeyError ' Handle Errors

        If (Asc(Mid(tmpVal, KeyValSize, 1)) = 0) Then           ' Win95 Adds Null Terminated String...
            tmpVal = VB.Left(tmpVal, KeyValSize - 1)               ' Null Found, Extract From String
        Else                                                    ' WinNT Does NOT Null Terminate String...
            tmpVal = VB.Left(tmpVal, KeyValSize)                   ' Null Not Found, Extract String Only
        End If
        '------------------------------------------------------------
        ' Determine Key Value Type For Conversion...
        '------------------------------------------------------------
        Select Case KeyValType                                  ' Search Data Types...
            Case REG_SZ                                             ' String Registry Key Data Type
                KeyVal = tmpVal                                     ' Copy String Value
            Case REG_DWORD                                          ' Double Word Registry Key Data Type
                For i = Len(tmpVal) To 1 Step -1                    ' Convert Each Bit
                    KeyVal = KeyVal + Hex(Asc(Mid(tmpVal, i, 1)))   ' Build Value Char. By Char.
                Next
                KeyVal = Format$("&h" + KeyVal)                     ' Convert Double Word To String
        End Select

        GetKeyValue = True                                      ' Return Success
        rc = RegCloseKey(hKey)                                  ' Close Registry Key
        Exit Function                                           ' Exit

GetKeyError:  ' Cleanup After An Error Has Occured...
        KeyVal = ""                                             ' Set Return Val To Empty String
        GetKeyValue = False                                     ' Return Failure
        rc = RegCloseKey(hKey)                                  ' Close Registry Key
    End Function

    Private Sub BTNOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNOK.Click
        Close()
    End Sub
     
   
End Class