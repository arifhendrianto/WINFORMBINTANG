Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnDoTrans_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDoTrans.Click
        Dim success As Boolean = False
        Dim conn As SqlConnection = Nothing
        Dim trans As SqlTransaction = Nothing

        Dim sql1 As String = _
        "INSERT INTO Categories(CategoryName) VALUES('Toilettries')"

        Dim sql2 As String = _
        "UPDATE Products SET UnitPrice=UnitPrice*1.1 WHERE CategoryID=20"

        Try
            conn = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("NWdb2005").ConnectionString.ToString())

            conn.Open()
            trans = conn.BeginTransaction( _
                          System.Data.IsolationLevel.Serializable)

            Using cmd1 As New SqlCommand(sql1, conn, trans)
                Dim rowsupdated1 As Integer = cmd1.ExecuteNonQuery()
                If rowsupdated1 > 0 Then
                    Using cmd2 As New SqlCommand(sql2, conn, trans)
                        Dim rowsupdated2 As Integer = cmd2.ExecuteNonQuery()
                        If rowsupdated2 > 0 Then
                            success = True
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            Response.Write(ex.Message())
        Finally
            If success Then
                trans.Commit()
            Else
                trans.Rollback()
            End If

            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try
    End Sub

    Protected Sub btnDoDistTrans_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDoDistTrans.Click
        Dim options As New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 2, 0)
        Dim sql1 As String = _
                "INSERT INTO Categories(CategoryName) VALUES('Toilettries')"

        Dim sql2 As String = _
        "UPDATE Products SET UnitPrice=UnitPrice*1.1 WHERE CategoryID=20"

        Using scope As New TransactionScope(TransactionScopeOption.Required, options)
            Using conn1 As New SqlConnection( _
            ConfigurationManager.ConnectionStrings("NWdb2005").ConnectionString.ToString())

                Using cmd1 As New SqlCommand(sql1, conn1)
                    Dim rowsupdated1 As Integer = cmd1.ExecuteNonQuery()
                    If rowsupdated1 > 0 Then
                        Using conn2 As New SqlConnection( _
                        ConfigurationManager.ConnectionStrings("NWxpress").ConnectionString.ToString())
                            Using cmd2 As New SqlCommand(sql2, conn2)
                                Dim rowsupdated2 As Integer = cmd2.ExecuteNonQuery()
                                If rowsupdated2 > 0 Then
                                    scope.Complete()
                                End If
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
End Class
