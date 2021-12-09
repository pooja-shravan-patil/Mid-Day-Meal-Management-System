Imports System.Data
Imports System.Data.SqlClient

Public Class d_entry
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand
    Dim i As Integer
    Dim str As String
    Dim last As Integer

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")

        cn.Open()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("select distinct Standard from StandardDetails order by Standard", cn)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                cb_std.Items.Add(dt.Rows(i).Item("Standard"))
            Next
        End If

        cn.Close()

        cn.Open()
        dt = New DataTable
        da = New SqlDataAdapter("select distinct Division from StandardDetails order by Division", cn)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                cb_div.Items.Add(dt.Rows(i).Item("Division"))
            Next
        End If
        cn.Close()

        cn.Open()
        dt = New DataTable
        da = New SqlDataAdapter("select distinct MenuName from MenuMaster order by MenuName", cn)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                ComboBox1.Items.Add(dt.Rows(i).Item("MenuName"))
            Next
        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try

        

    End Sub

    Private Sub cb_std_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_std.SelectedIndexChanged

    End Sub

    Private Sub cb_div_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_div.SelectedIndexChanged

    End Sub

    Private Sub dentry_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub std_d_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles std_d_save.Click
        'cn.Open()
        'Dim cmd As New SqlCommand
        'txt_tstu.Text = Val(txt_tstu.Text) + Val(txt_stu_div.Text)

        'cmd = New SqlCommand("insert into StandardDetails (Standard,Division,TotStudDiv,TotStudSch) values (@Standard,@Division,@TotStudDiv,@TotStudSch)", cn)
        'cmd.Parameters.Add("@Standard", SqlDbType.Int).Value = Convert.ToInt32(cb_std.Text)
        'cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = (cb_div.Text)
        'cmd.Parameters.Add("@TotPresentStudDiv", SqlDbType.Int).Value = Convert.ToInt32(txt_stu_div.Text)
        'cmd.Parameters.Add("@TotPresentStudSch", SqlDbType.Int).Value = Convert.ToInt32(txt_tstu.Text)
        'dr = cmd.ExecuteReader()
        'cn.Close()

        'MessageBox.Show("Record Saved")

        'Try
        cn.Open()
        Dim cmd As New SqlCommand
        txt_tstu.Text = Val(txt_stu_div.Text) + Val(txt_tstu.Text)

        cmd = New SqlCommand("insert into Attendence (Date,Standard,Division,TotPresentStudDiv,TotPresentStudSch) values (@Date,@Standard,@Division,@TotPresentStudDiv,@TotPresentStudSch)", cn)
        cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = dtp_std_d_dt.Value.ToShortDateString
        cmd.Parameters.Add("@Standard", SqlDbType.Int).Value = Convert.ToInt32(cb_std.Text)
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = (cb_div.Text)
        cmd.Parameters.Add("@TotPresentStudDiv", SqlDbType.Int).Value = Convert.ToInt32(txt_stu_div.Text)
        cmd.Parameters.Add("@TotPresentStudSch", SqlDbType.Int).Value = Convert.ToInt32(txt_tstu.Text)

        dr = cmd.ExecuteReader()
        cn.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        MessageBox.Show("Record Inserted", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)

        cb_std.Text = ""
        cb_div.Text = ""
        txt_stu_div.Text = ""
        'End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Try
        cn.Open()
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("select MenuId from MenuMaster where MenuName like '" & ComboBox1.SelectedItem & "'")
        cmd.Connection = cn
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            TextBox1.Text = dr(0).ToString()

        End If
        dr.Close()
        cn.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try
    End Sub

    Private Sub std_d_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_stu_div_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_stu_div.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub txt_stu_div_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stu_div.TextChanged

    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = txt_tstu.Text
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles View.Click

        cn.Open()
        dt = New DataTable
        cmd = New SqlCommand("Select MenuId from MenuMaster where MenuName like '" & ComboBox1.SelectedItem & "'")
        cmd.Connection = cn
        Dim str As String
        str = cmd.ExecuteScalar.ToString
        'MessageBox.Show(str)
        cn.Close()
        cn.Open()
        cmd = New SqlCommand("Select ingredientname,quantity,quantity*" & Val(TextBox2.Text) & " from MenuMaster1 where MenuId= " & Val(str), cn)


        '  cmd.Parameters.Add("@Id", SqlDbType.numeric).Value = TextBox2.Text
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        DataGridView1.DataSource = dt
        DataGridView1.Columns(2).HeaderText = "Used Quantity"
        cn.Close()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        'End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d_save.Click
        'cn.Open()
        'Dim cmd, cmd1 As New SqlCommand
        'Dim i As Integer
        'cmd = New SqlCommand("insert into MenuSelection (Date,PresentStudSch,MenuName) values (@Date,@PresentStudSch,@MenuName)", cn)
        'cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTimePicker1.Value
        'cmd.Parameters.Add("@PresentStudSch", SqlDbType.Int).Value = Val(TextBox2.Text)
        'cmd.Parameters.Add("@MenuName", SqlDbType.VarChar).Value = ComboBox1.SelectedItem
        'cmd.ExecuteNonQuery()
        'Dim n As Integer
        'n = DataGridView1.Rows.Count - 2

        'For i = 0 To n
        '    cmd1 = New SqlCommand("insert into DailyUse values(@MenuId,@IngredientName,@Quantity)", cn)
        '    cmd1.Parameters.AddWithValue("@MenuId", TextBox1.Text)
        '    cmd1.Parameters.AddWithValue("@IngredientName", DataGridView1.Rows(i).Cells(0).Value.ToString)
        '    cmd1.Parameters.AddWithValue("@Quantity", DataGridView1.Rows(i).Cells(2).Value)

        '    cmd1.ExecuteNonQuery()
        'Next
        'Try
        cn.Open()
        Dim cmd, cmd1 As New SqlCommand
        Dim cmd2, cmd3 As New SqlCommand
        Dim i As Integer
        Dim qty0 As Integer

        Dim id As Integer
        qty0 = Val(DataGridView1.Rows(i).Cells(2).Value)
        id = Val(TextBox1.Text)
        Dim str As String
        str = DateTimePicker1.Value



        Dim n As Integer
        n = DataGridView1.Rows.Count - 2

        For i = 0 To n
            cmd1 = New SqlCommand("insert into DailyUse values(@Date,@PresentStudentSch,@MenuId,@IngredientName,@Quantity)", cn)
            cmd1.Parameters.AddWithValue("@Date", DateTimePicker1.Value.ToShortDateString)
            cmd1.Parameters.AddWithValue("@PresentStudentSch", TextBox2.Text)
            cmd1.Parameters.AddWithValue("@MenuId", TextBox1.Text)
            cmd1.Parameters.AddWithValue("@IngredientName", DataGridView1.Rows(i).Cells(0).Value.ToString)
            cmd1.Parameters.AddWithValue("@Quantity", DataGridView1.Rows(i).Cells(2).Value)

            cmd1.ExecuteNonQuery()

            cmd2.CommandText = "update Stock set stock=stock-" & (Val(DataGridView1.Rows(i).Cells(2).Value) / 1000) & "where ingredientname like '" & DataGridView1.Rows(i).Cells(0).Value.ToString & "'"
            cmd2.Connection = cn
            cmd2.ExecuteNonQuery()
            'Dim a As Double
            'Dim str1 As String
            'str1 = cmd.ExecuteScalar.ToString
            'MessageBox.Show(str1)
        Next

        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        MessageBox.Show("Records Inserted", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_tstu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tstu.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub txt_tstu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tstu.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TabControl1.SelectedTab = TabPage2
        txt_tstu.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        DataGridView1.Columns(e.ColumnIndex).HeaderText = "Used Quantity  "
    End Sub

    Private Sub std_d_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles std_d_report.Click
        search.Show()
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
End Class