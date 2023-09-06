Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlTransaction
Imports System.Data.OleDb.OleDbTransaction
Imports System.DBNull

Public Class SendEmail

    Private Sub SendEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            'Dim dtRead As SqlDataReader
            Dim ds As New DataSet

            sqlstr = " SELECT username as User_Name,Email "
            sqlstr = sqlstr & " FROM users "
            sqlstr = sqlstr & " WHERE  (email <> '') "
            Dim adapter = New SqlDataAdapter(sqlstr, cn)
            adapter.Fill(ds)
            Dim chk As New DataGridViewCheckBoxColumn()
            dgfind.Columns.Add(chk)
            chk.HeaderText = "Check Data"
            chk.Name = "chk"
            Me.dgfind.DataSource = ds.Tables(0)
            Me.dgfind.Columns(0).Width = 30
            Me.dgfind.Columns(1).Width = 150
            Me.dgfind.Columns(2).Width = 100
        Catch ex As Exception

        End Try
    End Sub
     
End Class