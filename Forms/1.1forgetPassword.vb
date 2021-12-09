Imports System.Data
Imports System.Data.SqlClient

Public Class forgetpass
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand

    Private Sub forgetpass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub


    Private Sub fpcl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fpcl.Click
        Me.Close()
    End Sub

    Private Sub fpsub_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fpsub.Click

        cn.Open()
        Dim cmd As New SqlCommand
        Dim m As Integer
        Dim table As New DataTable()
        cmd = New SqlCommand("select SchoolRegNo,SchoolName,SchoolEmail,PrincipalEmail from SchoolDetails WHERE SchoolRegNo=" & Val(fpregno.Text), cn)
        cmd.Parameters.Add("@SchoolRegNo", SqlDbType.Int).Value = Val(fpregno.Text)
        cmd.Parameters.Add("@SchoolName", SqlDbType.VarChar).Value = Val(fpschnm.Text)
        cmd.Parameters.Add("@SchoolEmail", SqlDbType.VarChar).Value = Val(fpschem.Text)
        cmd.Parameters.Add("@PrincipalEmail", SqlDbType.NVarChar).Value = Val(fpprnem.Text)
        'cmd.ExecuteNonQuery()

        Dim ad As New SqlDataAdapter(cmd)
        ad.Fill(table)
        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("error")
        End Try
        dr = cmd.ExecuteReader()
        If table.Rows.Count() > 0 Then
            If dr.Read() Then
                'If dr(0).ToString = TextBox1.Text And dr(1).ToString = TextBox2.Text Then
                '    Form3.Show()
                MsgBox("your id=9130 & password=admin")
                'If m = DialogResult.OK Then
                login.Show()
                Me.Hide()
                'End If
                If m = DialogResult.OK Then
                    login.Show()

                End If
            End If
        Else
            MsgBox("Please enter the correct information")

        End If

        cn.Close()




    End Sub
    



End Class