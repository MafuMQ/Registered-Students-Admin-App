Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Me.Salary_InformationTableAdapter.Fill(Me.RGITDataSet1.Salary_Information)
        
        Me.Salary_InformationTableAdapter.Fill(Me.RGITDataSet1.Salary_Information)
        With ComboBox1.Items
            .Add("January")
            .Add("February")
            .Add("March")
            .Add("April")
            .Add("May")
            .Add("June")
            .Add("July")
            .Add("August")
            .Add("September")
            .Add("October")
            .Add("November")
            .Add("December")
        End With
        With ComboBox2.Items
            .Add("Yes")
            .Add("No")
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i, Employee_ID, Salary_ID As Double
        Dim Dates As Date
        Dim Amount, Months, Is_Paid, Due_Amount As String
        Employee_ID = TextBox1.Text
        Salary_ID = TextBox2.Text
        Amount = TextBox3.Text
        Months = ComboBox1.SelectedItem
        Is_Paid = ComboBox2.Text
        Due_Amount = TextBox4.Text
        Dates = DateTimePicker1.Text
        Dim rw As DataRow = RGITDataSet1.Tables(0).NewRow
        rw.Item("Employee_ID") = Employee_ID
        rw.Item("Salary_ID") = Salary_ID
        rw.Item("Amount") = Amount
        rw.Item("Months") = Months
        rw.Item("Is_Paid") = Is_Paid
        rw.Item("Due_Amount") = Due_Amount
        rw.Item("Dates") = Dates
        Try
            RGITDataSet1.Tables(0).Rows.Add(rw)
            i = Salary_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows added " & i)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        
        Dim query = From line In RGITDataSet1.Salary_Information
                    Select line.Employee_ID, line.Salary_ID, line.Amount, line.Months, line.Is_Paid,
                        line.Dates, line.Due_Amount
        DataGridView1.DataSource = query.ToList
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        
        Try
            Dim query = From line In RGITDataSet1.Salary_Information
                        Where line.Employee_ID = TextBox9.Text
            If query.Count = 1 Then
                DataGridView1.DataSource = query.ToList
                DataGridView1.CurrentCell = Nothing
            Else
                MessageBox.Show("Student not found!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to connect to database!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        
        Dim i, rowNumber As Integer
        Dim columnName As String
        Dim newValue As Object
        columnName = TextBox5.Text
        rowNumber = Val(TextBox6.Text)
        newValue = TextBox7.Text
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Item(columnName) = newValue
            i = Salary_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows modified " & i)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        
        Dim i, rowNumber As Integer
        rowNumber = Val(TextBox8.Text)
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Delete()
            i = Salary_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows deleted " & i)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Application.Exit()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Form7.Show()
        Me.Hide()
    End Sub

End Class
