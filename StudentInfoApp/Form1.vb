Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Me.Admin_InformationTableAdapter.Fill(Me.RGITDataSet1.Admin_Information)
        
        Me.Admin_InformationTableAdapter.Fill(Me.RGITDataSet1.Admin_Information)

        
        Me.Admin_InformationTableAdapter.Fill(Me.RGITDataSet1.Admin_Information)
        DataGridView1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" AndAlso TextBox2.Text = "" Then
            MessageBox.Show("Enter password or username", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                Dim query = From line In RGITDataSet1.Admin_Information
                            Where line.Employee_ID = TextBox1.Text AndAlso line.Employee_Number = TextBox2.Text
                If query.Count = 1 Then
                    MessageBox.Show("Welcome", "Start", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Form2.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid password or username", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox1.Focus()

                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
