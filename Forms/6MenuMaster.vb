Imports System.Data
Imports System.Data.SqlClient
Public Class Menu_m
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim da As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim str As String

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
                com_ing.Items.Add(dt.Rows(i).Item("ingredientName"))
            Next
        End If

        cn.Close()




        cn.Open()
        dt = New DataTable
        da = New SqlDataAdapter("select distinct MenuName from MenuMaster order by MenuName", cn)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                com_v_menu.Items.Add(dt.Rows(i).Item("MenuName"))
            Next
        End If
        'Catch ex As Exception
        ''MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub m_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim s As String
        s = com_ing.SelectedItem + "-" + quantity.Text


    End Sub

    Private Sub m_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_save.Click
        'Try
        cn.Open()

        Dim cmd1 As New SqlCommand
        Dim cmd As New SqlCommand
        If TextBox1.Text <> "" Then
            cmd.CommandText = "Insert into MenuMaster values(@MenuId,@MenuName)"
            cmd.Connection = cn
            cmd.Parameters.AddWithValue("@MenuId", TextBox2.Text)
            cmd.Parameters.AddWithValue("@MenuName", TextBox1.Text)
            cmd.ExecuteNonQuery()
            TextBox1.Text = ""
        End If
        cmd1.CommandText = "Insert into MenuMaster1 values(@MenuId,@IngredientName,@Quantity)"
        cmd1.Connection = cn
        cmd1.Parameters.AddWithValue("@MenuId", TextBox2.Text)
        cmd1.Parameters.AddWithValue("@IngredientName", com_ing.SelectedItem)
        cmd1.Parameters.AddWithValue("@Quantity", quantity.Text)
        cmd1.ExecuteNonQuery()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        MessageBox.Show("Menu Inserted", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try

    End Sub

    Private Sub com_ing_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles com_ing.MouseClick
        
    End Sub

    Private Sub com_ing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles com_ing.SelectedIndexChanged

    End Sub

    Private Sub com_v_menu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles com_v_menu.SelectedIndexChanged

    End Sub

    Private Sub v_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v_view.Click
        'Try
        cn.Open()
        dt = New DataTable
        cmd = New SqlCommand("Select MenuId from MenuMaster where MenuName like '" & com_v_menu.SelectedItem & "'")
        cmd.Connection = cn
        Dim str As String
        str = cmd.ExecuteScalar.ToString
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        'MessageBox.Show(str)
        cn.Close()
        'End Try

        'Try
        cn.Open()
        cmd = New SqlCommand("Select IngredientName,Quantity from MenuMaster1 where MenuId= " & Val(str), cn)
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        DataGridView1.DataSource = dt
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only alphabets")
            End If
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

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

    Private Sub TextBox2_gotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Try
        cn.Open()
        Dim cmd As New SqlCommand
        cmd.CommandText = "select max(Id) from menu1"
        cmd.Connection = cn
        str = cmd.ExecuteScalar.ToString
        TextBox2.Text = Val(str) + 1
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try

    End Sub

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub close_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub menu_cl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_cl.Click
        Me.Close()
    End Sub

    Private Sub quantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles quantity.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub quantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quantity.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Try
        cn.Open()
        Dim cmd As New SqlCommand
        cmd.CommandText = "select max(MenuId) from MenuMaster1"
        cmd.Connection = cn
        str = cmd.ExecuteScalar.ToString
        TextBox2.Text = Val(str) + 1
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try
    End Sub

    Private Sub v_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v_delete.Click
        'Try
        cn.Open()
        cmd = New SqlCommand("Delete  from MenuMaster where  MenuId=@MenuId ", cn)
        cmd.Parameters.AddWithValue("@MenuId", TextBox2.Text)
        'cmd.Parameters.AddWithValue("@ingredientname", ingMnm.Text)
        'cmd.Parameters.AddWithValue("@stock", txtstk.Text)
        dr = cmd.ExecuteReader()

        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        MessageBox.Show("Delete Menu", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cn.Close()
        TextBox1.Text = ""
        TextBox2.Text = ""
        'End Try
    End Sub

    Private Sub mview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mview.Click
        'Try
        cn.Open()
        dt = New DataTable
        cmd = New SqlCommand("Select * from MenuMaster", cn)
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        DataGridView1.DataSource = dt
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'Try

            If e.RowIndex = -1 Then
                Exit Sub
            End If
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
            'txtstk.Text = stk_m_dgv.Rows(e.RowIndex).Cells(2).Value.ToString
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        'End Try
    End Sub

    Private Sub m_master_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_master.Enter

    End Sub

    Private Sub m_view_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_view.Enter

    End Sub
End Class