
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms
Imports DevExpress.XtraTab
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.ReportAppServer
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel

Public Class USERS
    Dim ax As New MyGlobal
    Dim cn As New SqlConnection '  SqlConnection
    Dim cmd As New SqlCommand
    Dim dtRead As SqlDataReader

    Dim cn1 As New SqlConnection 'SqlConnection
    Dim cmd1 As New SqlCommand
    Dim dtRead1 As SqlDataReader

    Dim cn5 As New SqlConnection 'SqlConnection
    Dim cmd5 As New SqlCommand
    Dim dtRead5 As SqlDataReader


    Dim nmkolom As String
    Dim sketproses As String
    Dim select_cell As String
    Dim findChange As Boolean = False
    Dim widthchange As Boolean = False

    Public pID As String
    Public pSketproses As String
    Public row As Integer

    Private Sub USERS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class