Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Public Class amountreceiverpt

    'Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim cn As New SqlConnection
        Dim ds As New DataSet
        Dim da As SqlDataAdapter

        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        da = New SqlDataAdapter("select * from AmountTransaction", cn)
        da.Fill(ds, "AmountTransaction")
        Dim crpt As New ReportDocument
        crpt.Load("C:\Users\admin\Desktop\main design\MDM project\amount receive.rpt")
        crpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = crpt
        CrystalReportViewer1.Refresh()
        cn.Close()
    End Sub
End Class