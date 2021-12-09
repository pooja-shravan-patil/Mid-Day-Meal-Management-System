
Public NotInheritable Class Form1
    Public Delegate Sub SetProgressBarDelegate(ByVal max As Integer)
    Public Delegate Sub UpdateProgressBarDelegate(ByVal value As Integer)

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Public Sub BarLong(ByVal MemCount As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New SetProgressBarDelegate(AddressOf BarLong), MemCount)
        Else
            Me.ProgressBar1.Maximum = MemCount
        End If
    End Sub
    Public Sub ShowBar(ByVal SoFar As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateProgressBarDelegate(AddressOf ShowBar), SoFar)
        Else
            Me.ProgressBar1.Value = SoFar
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BarLong(100)
        Dim i As Integer = 0
        While i <= 100
            Me.ShowBar(i)
            i += 1
        End While
        Threading.Thread.Sleep(100)
    End Sub
End Class
