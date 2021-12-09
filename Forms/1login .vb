Imports System.Data
Imports System.Data.SqlClient

Public Class login
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logcl.Click
        Me.Close()

    End Sub

    Private Sub loglogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loglogin.Click
        cn.Open()
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("select id, password from logform WHERE id=@id", cn)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Val(logid.Text)

        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            If dr(0).ToString = logid.Text And dr(1).ToString = logpass.Text Then
                HomePage.Show()
            Else
                MsgBox("INCORRECT ID OR PASSWORD")
            End If
        End If

        cn.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        forgetpass.Show()
        Me.Hide()

    End Sub
End Class