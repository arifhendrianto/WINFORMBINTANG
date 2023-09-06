Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportViewerSQL

    Private Sub ReportViewerSQL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       

    End Sub

    'Public Shared Function SetCrystalConnectionString(ByVal rptDoc As ReportDocument, ByVal strConn As String) As ReportDocument

    '    Dim sqlCon As System.Data.SqlClient.SqlConnectionStringBuilder = New  _
    '        System.Data.SqlClient.SqlConnectionStringBuilder(strConn)
    '    Dim CConInfo As New ConnectionInfo
    '    Dim tables As Tables = rptDoc.Database.Tables
    '    Dim t As Table
    '    Dim tlogInfo As TableLogOnInfo
    '    Dim rs As Section
    '    Dim ro As ReportObject
    '    Dim srpt As ReportDocument
    '    'create connection Info object from connection string
    '    CConInfo.IntegratedSecurity = False
    '    CConInfo.ServerName = sqlCon.DataSource
    '    CConInfo.DatabaseName = sdbs 'sqlCon.InitialCatalog
    '    CConInfo.UserID = sqlCon.UserID
    '    CConInfo.Password = spwd 'sqlCon.Password
    '    For Each t In tables
    '        tlogInfo = t.LogOnInfo
    '        tlogInfo.ConnectionInfo = CConInfo
    '        t.ApplyLogOnInfo(tlogInfo)
    '    Next

    '    'check for sub reports and update connection strings.

    '    For Each rs In rptDoc.ReportDefinition.Sections
    '        For Each ro In rs.ReportObjects
    '            If ro.Kind = ReportObjectKind.SubreportObject Then
    '                Dim srptO As SubreportObject = ro
    '                srpt = srptO.OpenSubreport(srptO.SubreportName)
    '                For Each t In srpt.Database.Tables
    '                    tlogInfo = t.LogOnInfo
    '                    tlogInfo.ConnectionInfo = CConInfo
    '                    t.ApplyLogOnInfo(tlogInfo)
    '                Next
    '            End If
    '        Next
    '    Next
    '    Return rptDoc
    'End Function
End Class