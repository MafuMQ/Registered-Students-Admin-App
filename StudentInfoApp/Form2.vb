Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value >= 100 Then
            ProgressBar1.Value = 0
            Timer1.Stop()
            Form3.Show()
            Me.Hide()
        Else
            ProgressBar1.Value = ProgressBar1.Value + 1
            Label3.Text = ProgressBar1.Value & "% Completing..."
        End If

    End Sub

    
End Class
