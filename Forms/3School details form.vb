Imports System.Data
Imports System.Data.SqlClient



Public Class sch_dtls
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim cmd As New SqlCommand

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub


    Private Sub schsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles schsave.Click

        cn.Open()
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("insert into SchoolDetails values(@SchoolRegNo,@SchoolName,@SchoolAddress,@SchoolPhnNo,@SchoolEmail,@PrincipalName,@PrincipalAddress,@PrincipalPhnNo,@PrincipalEmail,@KitchenIncName,@KitchenIncAddress,@KitchenIncPhnNo,@KitchenIncEmail)", cn)
        cmd.Parameters.AddWithValue("@SchoolRegNo", schreg.Text)
        cmd.Parameters.AddWithValue("@SchoolName", schnm.Text)
        cmd.Parameters.AddWithValue("@SchoolAddress", schadd.Text)
        cmd.Parameters.AddWithValue("@SchoolPhnNo", Val(schphn.Text))
        cmd.Parameters.AddWithValue("@SchoolEmail", schemid.Text)
        cmd.Parameters.AddWithValue("@PrincipalName", prnnm.Text)
        cmd.Parameters.AddWithValue("@PrincipalAddress", prnadd.Text)
        cmd.Parameters.AddWithValue("@PrincipalPhnNo", Val(prnphno.Text))
        cmd.Parameters.AddWithValue("@PrincipalEmail", prnemid.Text)
        cmd.Parameters.AddWithValue("@KitchenIncName", kinchnm.Text)
        cmd.Parameters.AddWithValue("@KitchenIncAddress", kinchadd.Text)
        cmd.Parameters.AddWithValue("@KitchenIncPhnNo", Val(kinchphno.Text))
        cmd.Parameters.AddWithValue("@KitchenIncEmail", kinchemid.Text)

        cmd.ExecuteNonQuery()
        'Catch ex As Exception
        MessageBox.Show("Record Inserted", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)


        cn.Close()
        'End Try

        'cn.Open()
        'Dim cmd As New SqlCommand
        'cmd = New SqlCommand("insert into SchoolDetails values(@SchoolRegNo,@SchoolName,@SchoolAddress,@SchoolPhnNo,@SchoolEmail,@PrincipalName,@PrincipalAddress,@PrincipalPhnNo,@PrincipalEmail,@KitchenIncName,@KitchenIncAddress,@KitchenIncPhnNo,@KitchenIncEmail)", cn)
        'cmd.Parameters.AddWithValue("SchoolRegNo", schreg.Text)

    End Sub





    Private Sub txt_sch_phno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles schphn.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If

    End Sub

    Private Sub txt_sch_phno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles schphn.LostFocus
        Dim cmd As New SqlCommand
        If schphn.Text = "" Then

        End If

        If schphn.Text.Length <> 9 Then
        End If
        cn.Open()
        cmd.CommandText = "Select SchoolPhnNo from SchoolDetails where SchoolPhnNo=" & Val(schphn.Text)
        cmd.Connection = cn
        dr = cmd.ExecuteReader
        If (dr.Read) Then
            MessageBox.Show("Mobile Number already exists")
        End If
        dr.Close()
        cn.Close()


    End Sub



    Private Sub txt_sch_no_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles schreg.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If
    End Sub



    Private Sub txt_sch_nm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles schnm.KeyPress
        'If (Char.IsControl(e.KeyChar) = False) Then
        '    If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
        '    Else
        '        e.Handled = True
        '        MessageBox.Show("Enter only characters")
        '    End If
        'End If
    End Sub


    Private Sub txt_prn_nm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles prnnm.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only characters")
            End If
        End If
    End Sub


    Private Sub txt_k_inch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kinchnm.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only characters")
            End If
        End If
    End Sub



    Private Sub sch_cl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles schcl.Click
        Me.Close()

    End Sub

    Private Sub txt_prn_no_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles prnphno.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If
    End Sub

    Private Sub txt_prn_no_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles prnphno.LostFocus
        'Dim cmd As New SqlCommand
        'If prnphno.Text = "" Then

        'End If

        'If prnphno.Text.Length <> 9 Then
        'End If
        'cn.Open()
        'cmd.CommandText = "Select PrincipalPhnNo from SchooolDetails where PrincipalPhnNo=" & Val(prnphno.Text)
        'cmd.Connection = cn
        'dr = cmd.ExecuteReader
        'If (dr.Read) Then
        '    MessageBox.Show("Mobile Number already exists")
        'End If
        'dr.Close()
        'cn.Close()


        Dim cmd As New SqlCommand
        If prnphno.Text = "" Then

        End If

        If prnphno.Text.Length <> 9 Then
        End If
        cn.Open()
        cmd.CommandText = "Select PrincipalPhnNo from SchoolDetails where PrincipalPhnNo=" & Val(prnphno.Text)
        cmd.Connection = cn
        dr = cmd.ExecuteReader
        If (dr.Read) Then
            MessageBox.Show("Mobile Number already exists")
        End If
        dr.Close()
        cn.Close()
    End Sub



    Private Sub txt_k_no_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kinchphno.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If
    End Sub

    Private Sub txt_k_no_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles kinchphno.LostFocus
        Dim cmd As New SqlCommand
        If kinchphno.Text = "" Then

        End If

        If kinchphno.Text.Length <> 9 Then
        End If
        cn.Open()
        cmd.CommandText = "Select KitcheIncPhnNo from SchoolDetails where KitcheIncPhnNo=" & Val(kinchphno.Text)
        cmd.Connection = cn
        dr = cmd.ExecuteReader
        If (dr.Read) Then
            MessageBox.Show("Mobile Number already exists")
        End If
        dr.Close()
        cn.Close()
    End Sub

    Private Sub schnm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles schnm.TextChanged

    End Sub

    Private Sub schview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles schview.Click
        'Try
        cn.Open()
        dt = New DataTable
        cmd = New SqlCommand("Select * from SchoolDetails", cn)
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        DataGridView1.DataSource = dt
        cn.Close()
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        'End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try

            If e.RowIndex = -1 Then
                Exit Sub
            End If
            schreg.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
            schnm.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
            schadd.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
            schphn.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
            schemid.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
            prnnm.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
            prnadd.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
            prnphno.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
            prnemid.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
            kinchnm.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
            kinchadd.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString
            kinchphno.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString
            kinchemid.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub schupd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles schupd.Click
        Try
            cn.Open()
            cmd = New SqlCommand("update SchoolDetails set SchoolName=@SchoolName,SchoolAddress=@SchoolAddress,SchoolPhnNo=@SchoolPhnNo,SchoolEmail=@SchoolEmail,PrincipalName=@PrincipalName,PrincipalAddress=@PrincipalAddress,PrincipalPhnNo=@PrincipalPhnNo,PrincipalEmail=@PrincipalEmail,KitchenIncName=@KitchenIncName,KitchenIncAddress=KitchenIncAddress,KitchenIncPhnNo=@KitchenIncPhnNo,KitchenIncEmail=@KitchenIncEmail where SchoolRegNo=@SchoolRegNo ", cn)
            cmd.Parameters.AddWithValue("@SchoolRegNo", schreg.Text)
            cmd.Parameters.AddWithValue("@SchoolName", schnm.Text)
            cmd.Parameters.AddWithValue("@SchoolAddress", schadd.Text)
            cmd.Parameters.AddWithValue("@SchoolPhnNo", Val(schphn.Text))
            cmd.Parameters.AddWithValue("@SchoolEmail", schemid.Text)
            cmd.Parameters.AddWithValue("@PrincipalName", prnnm.Text)
            cmd.Parameters.AddWithValue("@PrincipalAddress", prnadd.Text)
            cmd.Parameters.AddWithValue("@PrincipalPhnNo", Val(prnphno.Text))
            cmd.Parameters.AddWithValue("@PrincipalEmail", prnemid.Text)
            cmd.Parameters.AddWithValue("@KitchenIncName", kinchnm.Text)
            cmd.Parameters.AddWithValue("@KitchenIncAddress", kinchadd.Text)
            cmd.Parameters.AddWithValue("@KitchenIncPhnNo", Val(kinchphno.Text))
            cmd.Parameters.AddWithValue("@KitchenIncEmail", kinchemid.Text)





            dr = cmd.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            MessageBox.Show("Updated record", "update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cn.Close()
        End Try

    End Sub

    Private Sub sch_dtl_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sch_dtl.Enter

    End Sub

    Private Sub prn_dtl_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prn_dtl.Enter

    End Sub
End Class