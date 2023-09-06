Public Class ReportViewerText
    'Friend WithEvents PrintPreviewControl1 As PrintPreviewControl
    Private WithEvents docToPrint As New Printing.PrintDocument


    Private Sub ReportViewerText_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Using fs As New FileStream("file path here", FileMode.Append)
        '    RichTextBox1.SaveFile(fs, RichTextBoxStreamType.PlainText)
        'End Using


        '-----------
        'Dim read As IO.StreamReader
        'read = IO.File.OpenText("C:\BOM\PRINT_BOM.txt")
        'RichTextBox1.Text = read.ReadToEnd()
        'read.Close()

        RichTextBox1.Text = System.IO.File.ReadAllText("C:\BOM\PRINT_BOM.txt")

        'RichTextBox1.Text = IO.File.ReadAllText("file path here")
    End Sub

    'Private Sub InitializePrintPreviewControl()

    '    ' Construct the PrintPreviewControl. 
    '    Me.PrintPreviewControl1 = New PrintPreviewControl

    '    ' Set location, name, and dock style for PrintPreviewControl1. 
    '    Me.PrintPreviewControl1.Location = New Point(88, 80)
    '    Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
    '    Me.PrintPreviewControl1.Dock = DockStyle.Fill

    '    ' Set the Document property to the PrintDocument  
    '    ' for which the PrintPage event has been handled. 
    '    Me.PrintPreviewControl1.Document = docToPrint

    '    ' Set the zoom to 25 percent. 
    '    Me.PrintPreviewControl1.Zoom = 0.25

    '    ' Set the document name. This will show be displayed when  
    '    ' the document is loading into the control. 
    '    Me.PrintPreviewControl1.Document.DocumentName = "C:\BOM\PRINT_BOM.txt"

    '    ' Set the UseAntiAlias property to true so fonts are smoothed 
    '    ' by the operating system. 
    '    Me.PrintPreviewControl1.UseAntiAlias = True

    '    ' Add the control to the form. 
    '    Me.Controls.Add(Me.PrintPreviewControl1)
    'End Sub

    '' The PrintPreviewControl will display the document 
    '' by handling the documents PrintPage event 
    'Private Sub docToPrint_PrintPage(ByVal sender As Object, _
    '   ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
    '       Handles docToPrint.PrintPage

    '    ' Insert code to render the page here. 
    '    ' This code will be called when the control is drawn. 

    '    ' The following code will render a simple 
    '    ' message on the document in the control. 
    '    Dim text As String = "In docToPrint_PrintPage method."
    '    Dim printFont As New Font _
    '        ("Arial", 35, System.Drawing.FontStyle.Regular)

    '    e.Graphics.DrawString(text, printFont, _
    '        System.Drawing.Brushes.Black, 10, 10)
    'End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

    End Sub
End Class