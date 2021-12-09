Imports System.Data
Imports System.Data.SqlClient
Public Class amu_tran
    Dim cn As New SqlConnection
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cn.ConnectionString = ("WindowsApplication1.My.MySettings.Database1ConnectionString1")
        cn.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\main design\MDM project\Database1.mdf;Integrated Security=True;User Instance=True")
    End Sub
    Private Sub tran_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tran_save.Click
        'Try
        cn.Open()
        Dim cmd As New SqlCommand
        If lbl_nostu.Text = "" Or c_month.Text = "" Or lbl_amu_rec.Text = "" Or lbl_b_nm.Text = "" Or lbl_b_ch.Text = "" Or lbl_b_br.Text = "" Or TextBox12.Text = "" Or lbl_amu.Text = "" Then
            tran_save.Enabled = True
            MessageBox.Show("some fields are empty")

        Else


            cmd = New SqlCommand("insert into AmountTransaction(StudentCount,Month,AmountReceive,BankName,BranchName,Chequeno,ReceiveDate,AuthorityName,IssueAmount,IssueDate)values(@studentCount,@Month,@AmountReceive,@BankName,@BranchName,@Chequeno,@ReceiveDate,@AuthorityName,@IssueAmount,@IssueDate)", cn)
            cmd.Parameters.AddWithValue("@StudentCount", lbl_nostu.Text)
            cmd.Parameters.AddWithValue("@Month", c_month.Text)
            cmd.Parameters.AddWithValue("@AmountReceive", lbl_amu_rec.Text)
            cmd.Parameters.AddWithValue("@BankName", lbl_b_nm.Text)
            cmd.Parameters.AddWithValue("@BranchName", lbl_b_br.Text)
            cmd.Parameters.AddWithValue("@Chequeno", lbl_b_ch.Text)
            cmd.Parameters.AddWithValue("@ReceiveDate", DateTimePicker2.Value)

            cmd.Parameters.AddWithValue("@AuthorityName", TextBox12.Text)
            cmd.Parameters.AddWithValue("@IssueAmount", lbl_amu.Text)
            cmd.Parameters.AddWithValue("@IssueDate", DateTimePicker1.Value)
            cmd.ExecuteNonQuery()
            'dr = cmd.ExecuteReader()
            MessageBox.Show(" Record inserted ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        cn.Close()
        'End Try

    End Sub

    Private Sub lbl_b_nm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lbl_b_nm.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only alphabets")
            End If
        End If

    End Sub

    Private Sub lbl_b_nm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_b_nm.TextChanged

    End Sub

    Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only alphabets")
            End If
        End If

    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub tran_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tran_close.Click
        Me.Close()
    End Sub

    Private Sub lbl_nostu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lbl_nostu.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub lbl_nostu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_nostu.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub lbl_amu_rec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lbl_amu_rec.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub lbl_amu_rec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_amu_rec.TextChanged

    End Sub

    Private Sub lbl_b_ch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lbl_b_ch.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub lbl_b_ch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_b_ch.TextChanged

    End Sub

    Private Sub lbl_amu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lbl_amu.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsDigit(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only Numbers")
            End If
        End If


    End Sub

    Private Sub lbl_amu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_amu.TextChanged

    End Sub

    Private Sub lbl_b_br_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lbl_b_br.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar) = True) Or (Char.IsWhiteSpace(e.KeyChar) = True) Then
            Else
                e.Handled = True
                MessageBox.Show("Enter only alphabets")
            End If
        End If

    End Sub

    Private Sub lbl_b_br_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_b_br.TextChanged

    End Sub

    Private Sub c_month_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c_month.SelectedIndexChanged

    End Sub
End Class