Imports System.Data
Imports System.Data.SqlClient
Public Class stk_req
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")

        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("select distinct ingredientname from Stock order by ingredientname", cn)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                stkreqcb.Items.Add(dt.Rows(i).Item("ingredientname"))
            Next
        End If
        cn.Close()


    End Sub
    Private Sub stkreqadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stkreqadd.Click
        stk_r_dgv.Rows.Add(stkreqing.Text, stkreqcb.SelectedItem, stkreqquan.Text)

    End Sub


    Private Sub stksave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stkreqsave.Click
        'cn.Open()
        'Dim cmd As New SqlCommand
        'cmd = New SqlCommand("insert into StockRequest (Date,ingredientid,Quantity) values (@Date,@ingredientid,@Quantity)", cn)
        'cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dtp_stk_r.Value
        'cmd.Parameters.Add("@ingredientid", SqlDbType.VarChar).Value = stkreqing.Text
        ''cmd.Parameters.Add("@IngredientName", SqlDbType.VarChar).Value = stkreqcb.Text
        'cmd.Parameters.Add("@Quantity", SqlDbType.Float).Value = stkreqquan.Text


        'cmd.ExecuteNonQuery()
        'dr = cmd.ExecuteReader()
        'cn.Close()
        cn.Open()
        Dim cmd1 As New SqlCommand
        Dim i As Integer
        Dim n As Integer
        Dim id As Integer
        'qty0 = Val(txt_ing.Text)
        n = stk_r_dgv.Rows.Count - 2
        id = stk_r_dgv.Rows(i).Cells(0).Value
        Dim str As String
        str = dtp_stk_r.Value

        For i = 0 To n
            cmd1 = New SqlCommand("insert into StockRequest values(@Date,@ingredientid,@Quantity)", cn)
            cmd1.Parameters.AddWithValue("@Date", dtp_stk_r.Value.ToShortDateString)
            cmd1.Parameters.AddWithValue("@ingredientid", stk_r_dgv.Rows(i).Cells(0).Value)

            cmd1.Parameters.AddWithValue("@Quantity", stk_r_dgv.Rows(i).Cells(2).Value)

            cmd1.ExecuteNonQuery()
        Next
        cn.Close()
        MessageBox.Show("record save", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub stkreqcb_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles stkreqcb.MouseClick
        
    End Sub

    

    Private Sub stkreqcl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stkreqcl.Click
        Me.Close()
    End Sub

    Private Sub stkreqing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles stkreqing.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True

            End If
        End If


    End Sub

    

    Private Sub stkreqquan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles stkreqquan.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    
    Private Sub stkreqcb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stkreqcb.SelectedIndexChanged
        cn.Open()
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("select ingredientid from Stock where ingredientname like '" & stkreqcb.SelectedItem & "'")
        cmd.Connection = cn
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            stkreqing.Text = dr(0).ToString()

        End If
        dr.Close()
        cn.Close()
    End Sub

    Private Sub stkreqdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stkreqdel.Click
        cn.Open()
        cmd = New SqlCommand("Delete  from StockRequest where  ingredientid=@ingredientid ", cn)
        cmd.Parameters.AddWithValue("@ingredientid", stkreqing.Text)
        dr = cmd.ExecuteReader()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        MessageBox.Show("Delete Ingredient name", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cn.Close()
        'cn.Open()
        'Dim cmd As New SqlCommand
        'cmd = New SqlCommand(" delete from stu where Roll=@Roll", cn)
        'cmd.Parameters.Add("@Roll", SqlDbType.Int).Value = Val(TextBox1.Text)
        'cmd.ExecuteNonQuery()
        'dr = cmd.ExecuteReader()
        'If dr.Read() Then
        '    If dr(0).ToString = TextBox1.Text Then
        '        TextBox2.Text = dr(1)
        '    End If
        'End If
        'MessageBox.Show("Record Deleted...")

        'cn.Close()

        stkreqquan.Text = ""
        stkreqing.Text = ""
        stkreqcb.Text = ""
    End Sub

    Private Sub stkreqrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stkreqrpt.Click
        Stockrequestrpt.Show()
    End Sub

    Private Sub stk_r_dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles stk_r_dgv.CellContentClick

    End Sub

    Private Sub stk_r_dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles stk_r_dgv.CellDoubleClick
        Try

            If e.RowIndex = -1 Then
                Exit Sub
            End If
            stkreqing.Text = stk_r_dgv.Rows(e.RowIndex).Cells(0).Value.ToString()
            stkreqcb.Text = stk_r_dgv.Rows(e.RowIndex).Cells(1).Value.ToString
            stkreqquan.Text = stk_r_dgv.Rows(e.RowIndex).Cells(2).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class


































