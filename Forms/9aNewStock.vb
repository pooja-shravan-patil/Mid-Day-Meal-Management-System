Imports System.Data
Imports System.Data.SqlClient
Public Class stk_n
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
        'Try
        cn.Open()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("select distinct ingredientname from Stock order by ingredientname", cn)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                cb_stk_n_ing.Items.Add(dt.Rows(i).Item("ingredientname"))
            Next
        End If
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try
    End Sub
    Private Sub stk_n_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_n_add.Click
        'stk_n_dgv.Rows.Add(cb_stk_n_ing.SelectedItem, txt_ing.Text)
        stkupdate.Text = Val(txtstk.Text) + Val(txt_ing.Text)
        'Try
        cn.Open()
        cmd = New SqlCommand("update Stock set stock=" & stkupdate.Text & " where ingredientname='" & cb_stk_n_ing.Text & "'")
        cmd.Connection = cn
        cmd.ExecuteNonQuery()
        cn.Close()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        stk_n_dgv.Rows.Add(nstk_id.Text, cb_stk_n_ing.SelectedItem, txt_ing.Text)
        cb_stk_n_ing.Text = ""
        txt_ing.Text = ""
        'End Try
    End Sub

    Private Sub stk_n_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_n_save.Click
        'cn.Open()
        'Dim cmd As New SqlCommand
        'cmd = New SqlCommand("insert into NewStock (Date,ingredientid,Quantity) values (@Date,@ingredientid,@Quantity)", cn)
        'cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dtp_stk_n.Value
        'cmd.Parameters.Add("@ingredientid", SqlDbType.Int).Value = nstk_id.Text

        'cmd.Parameters.Add("@IngredientName", SqlDbType.VarChar).Value = cb_stk_n_ing.Text
        'cmd.Parameters.Add("@Quantity", SqlDbType.Float).Value = txt_ing.Text

        'cmd.ExecuteNonQuery()
        'dr = cmd.ExecuteReader()
        'cn.Close()
        'MessageBox.Show("Recored inserted ")
        'Try
        cn.Open()
        Dim cmd1 As New SqlCommand
        Dim i As Integer
        Dim n As Integer
        Dim id As Integer
        'qty0 = Val(txt_ing.Text)
        n = stk_n_dgv.Rows.Count - 2
        id = stk_n_dgv.Rows(i).Cells(0).Value
        Dim str As String
        str = dtp_stk_n.Value.ToShortDateString

        For i = 0 To n
            cmd1 = New SqlCommand("insert into NewStock values(@Date,@Ingredientid,@Quantity)", cn)
            cmd1.Parameters.AddWithValue("@Date", dtp_stk_n.Value.ToShortDateString)
            cmd1.Parameters.AddWithValue("@Ingredientid", stk_n_dgv.Rows(i).Cells(0).Value)

            cmd1.Parameters.AddWithValue("@Quantity", stk_n_dgv.Rows(i).Cells(2).Value)

            cmd1.ExecuteNonQuery()
        Next
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        MessageBox.Show("record save", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try

    End Sub

    Private Sub stk_n_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_n_report.Click
        Newstockrpt.Show()
    End Sub

    Private Sub stk_n_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_n_close.Click
        Me.Close()
    End Sub

    Private Sub stk_n_dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles stk_n_dgv.CellContentClick

    End Sub

    Private Sub stk_n_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_n_view.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub txt_ing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ing.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub txt_ing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ing.TextChanged

    End Sub

    Private Sub stk_n_ing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stk_n_ing.Click

    End Sub

    Private Sub cb_stk_n_ing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_stk_n_ing.SelectedIndexChanged
        'Try
        cn.Open()
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("select ingredientid from Stock where ingredientname like '" & cb_stk_n_ing.SelectedItem & "'")
        cmd.Connection = cn
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            nstk_id.Text = dr(0).ToString()

        End If
        dr.Close()
        cn.Close()


        'stock display
        cn.Open()
        'Dim cmd As New SqlCommand
        cmd = New SqlCommand("select stock from Stock where ingredientname like '" & cb_stk_n_ing.SelectedItem & "'")
        cmd.Connection = cn
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            txtstk.Text = dr(0).ToString()

        End If
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        dr.Close()
        cn.Close()
        'End Try
    End Sub

    Private Sub nstk_id_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nstk_id.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True

            End If
        End If

    End Sub

    Private Sub nstk_id_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nstk_id.MouseDoubleClick

    End Sub

    Private Sub nstk_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nstk_id.TextChanged

    End Sub

    Private Sub stk_n_dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles stk_n_dgv.CellDoubleClick
        
    End Sub
End Class