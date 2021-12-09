Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Public Class search
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim dt As New DataTable
    Dim crpt As New ReportDocument

    Dim ds As New DataSet
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        'cn.ConnectionString = "WindowsApplication1.My.MySettings.Database1ConnectionString1"
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cn.Open()
        cmd.CommandText = "select * from DailyUse where Date ='" & DateTimePicker1.Value.Date & "'  "
        cmd.Connection = cn
        'cmd.ExecuteNonQuery()

        dr = cmd.ExecuteReader()

        dt.Load(dr)
        dr.Close()
        crpt.Load("C:\Users\admin\Desktop\main design\MDM project\Dailyentry.rpt")
        crpt.SetDataSource(dt)
        CrystalReportViewer1.ReportSource = crpt
        CrystalReportViewer1.Refresh()
        cn.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class