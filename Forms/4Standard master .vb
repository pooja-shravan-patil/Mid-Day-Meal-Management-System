Imports System.Data
Imports System.Data.SqlClient

Public Class stdM
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand
    Dim str As String

   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub
   

    Private Sub stdMsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stdMsave.Click

        cn.Open()
        Dim cmd As New SqlCommand
        'schtotM.Text = Val(schtotM.Text) + Val(totM.Text)


        cmd.CommandText = "select max(TotStudSch) from StandardDetails"
        cmd.Connection = cn
        str = cmd.ExecuteScalar.ToString
        schtotM.Text = Val(str) + Val(totM.Text)
        'cn.Close()








        cmd = New SqlCommand("insert into StandardDetails (Standard,Division,TotalStudentInDivision,TotStudSch) values (@Standard,@Division,@TotalStudentInDivision,@TotStudSch)", cn)
        cmd.Parameters.Add("@Standard", SqlDbType.Int).Value = Convert.ToInt32(cb_std.Text)
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = (cb_div.Text)
        cmd.Parameters.Add("@TotalStudentInDivision", SqlDbType.Int).Value = Convert.ToInt32(totM.Text)
        cmd.Parameters.Add("@TotStudSch", SqlDbType.Int).Value = Convert.ToInt32(schtotM.Text)
        dr = cmd.ExecuteReader()
        cn.Close()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        'End Try



        MessageBox.Show("Record Inserted", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)

        cb_std.Text = ""
        cb_div.Text = ""
        totM.Text = ""




    End Sub

  

    Private Sub stdM_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stdMcl.Click
        Me.Close()
    End Sub

    Private Sub txt_tstu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles schtotM.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

 

    Private Sub txt_stu_div_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles totM.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

   
    Private Sub stdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stdview.Click
        'Try
        cn.Open()
        dt = New DataTable
        'cmd = New SqlCommand("Select * from StandardDetails", cn)
        cmd = New SqlCommand("Select Standard,Division,TotalStudentInDivision from StandardDetails", cn)
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        DataGridView1.DataSource = dt
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try
    End Sub

    Private Sub stdMupd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stdMupd.Click
        'Try
        cn.Open()
        cmd = New SqlCommand("update StandardDetails set TotalStudentInDivision=@TotalStudentInDivision where Standard=@Standard  ", cn)
        cmd.Parameters.AddWithValue("@Standard", cb_std.Text)
        cmd.Parameters.AddWithValue("@TotalStudentInDivision", totM.Text)
        'cmd.Parameters.AddWithValue("@stock", txtstk.Text)
        dr = cmd.ExecuteReader()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        MessageBox.Show("Updated  Student in Division", "update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cn.Close()
        'End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'Try

        If e.RowIndex = -1 Then
            Exit Sub
        End If
        cb_std.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        cb_div.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        totM.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        'End Try
    End Sub

    Private Sub stdMrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stdMrpt.Click
        Standardrpt.Show()
    End Sub
End Class