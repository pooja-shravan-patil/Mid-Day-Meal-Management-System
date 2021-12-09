Imports System.Data
Imports System.Data.SqlClient

Public Class ingM
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As SqlCommand
    Dim i As Integer
    Dim str As String
    Dim last As Integer
    Dim st As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub

    Private Sub ingMadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ingMadd.Click
        'Try
        cn.Open()
        cmd = New SqlCommand("insert into Stock values (@ingredientid,@ingredientname,@stock)", cn)
        cmd.Parameters.AddWithValue("@ingredientid", ingMid.Text)
        cmd.Parameters.AddWithValue("@ingredientname", ingMnm.Text)
        cmd.Parameters.AddWithValue("@stock", txtstk.Text)
        dr = cmd.ExecuteReader()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        MessageBox.Show("Save Ingredient", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cn.Close()
        ingMid.Text = ""
        ingMnm.Text = ""
        'End Try

    End Sub

    Private Sub ingMvi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ingMvi.Click
        'Try
        cn.Open()
        dt = New DataTable
        cmd = New SqlCommand("Select ingredientid,ingredientname from Stock", cn)
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        stk_m_dgv.DataSource = dt
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try
    End Sub

    Private Sub ingMid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ingMid.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If
    End Sub

    Private Sub ingMid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ingMid.LostFocus


    End Sub

    Private Sub ingMnm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ingMnm.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only alphabets")
            End If
        End If

    End Sub

    Private Sub ing_cl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ing_cl.Click
        Me.Close()

    End Sub

    Private Sub ingMid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ingMid.TextChanged

    End Sub

    Private Sub ingMnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ingMnew.Click
        'Try
        cn.Open()
        Dim cmd As New SqlCommand
        cmd.CommandText = "select max(ingredientid) from Stock"
        cmd.Connection = cn
        str = cmd.ExecuteScalar.ToString
        ingMid.Text = Val(str) + 1
        cn.Close()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        'End Try

    End Sub

    Private Sub stk_m_dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles stk_m_dgv.CellContentClick

    End Sub

    Private Sub stk_m_dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles stk_m_dgv.CellDoubleClick
        Try

            If e.RowIndex = -1 Then
                Exit Sub
            End If
            ingMid.Text = stk_m_dgv.Rows(e.RowIndex).Cells(0).Value.ToString
            ingMnm.Text = stk_m_dgv.Rows(e.RowIndex).Cells(1).Value.ToString
            txtstk.Text = stk_m_dgv.Rows(e.RowIndex).Cells(2).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ingMup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ingMup.Click
        'Try
        cn.Open()
        cmd = New SqlCommand("update Stock set ingredientname=@ingredientname where ingredientid=@ingredientid ", cn)
        cmd.Parameters.AddWithValue("@ingredientid", ingMid.Text)
        cmd.Parameters.AddWithValue("@ingredientname", ingMnm.Text)
        dr = cmd.ExecuteReader()
        MessageBox.Show("Updated Ingredient name", "update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        ingMid.Text = ""
        ingMnm.Text = ""
        'End Try
    End Sub

    Private Sub ingMdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ingMdel.Click

        'Try
        cn.Open()
        cmd = New SqlCommand("Delete  from Stock where  ingredientid=@ingredientid ", cn)
        cmd.Parameters.AddWithValue("@ingredientid", ingMid.Text)
        dr = cmd.ExecuteReader()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        MessageBox.Show("Delete Ingredient name", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cn.Close()
        ingMid.Text = ""
        ingMnm.Text = ""
        'End Try
    End Sub
    
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class