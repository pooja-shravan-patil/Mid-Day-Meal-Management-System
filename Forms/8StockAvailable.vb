Imports System.Data
Imports System.Data.SqlClient

Public Class stk_av
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub
    Private Sub stk_av_req_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_av_req.Click
        stk_req.Show()
    End Sub

    Private Sub stk_av_nstk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_av_nstk.Click
        stk_n.Show()
    End Sub

    Private Sub stk_av_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_av_close.Click
        Me.Close()
    End Sub

    Private Sub stk_av_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_av_view.Click
        'Try
        cn.Open()
        dt = New DataTable
        cmd = New SqlCommand("Select * from Stock", cn)
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        stk_av_dgv.DataSource = dt
        ' Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try
    End Sub

    Private Sub stk_av_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_av_report.Click
        StockAvailablerpt.Show()
    End Sub
End Class