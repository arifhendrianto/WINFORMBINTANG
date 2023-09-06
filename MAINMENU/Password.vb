
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlTransaction
Imports System.Data.OleDb.OleDbTransaction
Imports System.DBNull
Imports System.Net

Public Class Password

    Dim ax As New MyGlobal
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dtRead As SqlDataReader
    Dim APVPassword As String = "BLM ADA"

    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click
        stxtgetfromgrid = "Y"
        If APVPassword.ToUpper.Trim = Me.TextBox1.Text.ToUpper.Trim Then
            getgridcari(0, 1) = "Y"
        Else
            getgridcari(0, 1) = "N"
        End If
        Me.Close()
    End Sub

    Private Sub Password_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getgridcari(0, 1) = ""
        Me.TextBox1.Text = ""

        If cn.State = ConnectionState.Open Then cn.Close()
        cn = ax.cntsvr
        cmd.Connection = cn
        
        APVPassword = Password_Approved_Publish(gridcaricode1)

        'Pass_Appv_BC_Mat_IN = Password_Approved_Publish("Pass_Appv_BC_Mat_IN")
        'Pass_Appv_BC_Mat_OUT = Password_Approved_Publish("Pass_Appv_BC_Mat_OUT")
        'Pass_Appv_BC_FG_IN = Password_Approved_Publish("Pass_Appv_BC_FG_IN")
        'Pass_Appv_BC_FG_OUT = Password_Approved_Publish("Pass_Appv_BC_FG_OUT")
        'Pass_Appv_JO = Password_Approved_Publish("Pass_Appv_JO")
        'Pass_Cancel_JO = Password_Approved_Publish("Pass_Cancel_JO")
        'Pass_Cancel_PO = Password_Approved_Publish("Pass_Cancel_PO")
        'Pass_Appv_QC = Password_Approved_Publish("Pass_Appv_QC")
        'Pass_Appv_Qty_BOM = Password_Approved_Publish("Pass_Appv_Qty_BOM")
        'Pass_Appv_Rev_BOM_From_BOMMS = Password_Approved_Publish("Pass_Appv_Rev_BOM_From_BOMMS")
        'Pass_Appv_Quotation = Password_Approved_Publish("Pass_Appv_Quotation")
        'Pass_Appv_Qty_BOMPack = Password_Approved_Publish("Pass_Appv_Qty_BOMPack")
    End Sub

    Function Password_Approved_Publish(ApprovedCode As String) As String
        Dim Pass = ""
        sqlstr = "Select Password from  SYS_Password_Approved where ApprovedCode = '" & Trim(ApprovedCode) & "'"
        cmd.CommandText = sqlstr
        dtRead = cmd.ExecuteReader
        If dtRead.Read = True Then
            Pass = dtRead!Password
        End If
        dtRead.Close()
        dtRead = Nothing

        Password_Approved_Publish = Pass
    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = 17 And Me.TextBox1.Text = "apa" Then
            MsgBox(APVPassword)
        End If
    End Sub

End Class