'Imports CrystalDecisions.CrystalReports.Engine
Public Class ReportViewer

    Private Sub ReportViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.DisplayToolbar = True
        Me.CrystalReportViewer1.DisplayStatusBar = True
        Me.CrystalReportViewer1.ToolPanelView = False
        Me.CrystalReportViewer1.ReportSource = Nothing
        Me.CrystalReportViewer1.ReportSource = pdir & "\" & reportname
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.RefreshReport()
        Me.Refresh()

        Me.CrystalReportViewer1.ReportSource = Nothing
        'Dim cryRpt As New ReportDocument
        'cryRpt.Load(pdir & "\" & "EX_DE_BC27_PDKBMRPT.rpt")
        'cryRpt.DataDefinition.FormulaFields(0).Text = "'Masuk'"
        Me.CrystalReportViewer1.ReportSource = pdir & "\" & reportname 
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.RefreshReport()
        Me.Refresh()

        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.RefreshReport()
        Me.Refresh()

    End Sub
     
End Class