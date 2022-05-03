Public Class Form7

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Me.Fees_InformationTableAdapter.Fill(Me.RGITDataSet1.Fees_Information)
        
        Me.Fees_InformationTableAdapter.Fill(Me.RGITDataSet1.Fees_Information)
        With ComboBox1.Items
            .Add("M65")
            .Add("EFT")
            .Add("CHEQUE")
        End With
        With ComboBox2.Items
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
        With ComboBox3.Items
            .Add("2018")
            .Add("2019")
            .Add("2020")
            .Add("2021")
            .Add("2022")
            .Add("2023")
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        
        Dim query = From line In RGITDataSet1.Fees_Information
                    Select line.Student_ID, line.Fees_ID, line.Payment_Type, line.Fees_Date, line.Fees_Month,
                        line.Fees_Year, line.Fees_Amount
        DataGridView1.DataSource = query.ToList
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i, Student_ID, Fees_ID As Double
        Dim Fees_Date As Date
        Dim Payment_Type, Fees_Month, Fees_Year, Fees_Amount As String
        Fees_ID = TextBox1.Text
        Student_ID = TextBox2.Text
        Payment_Type = ComboBox1.SelectedItem
        Fees_Date = DateTimePicker1.Value
        Fees_Month = ComboBox2.SelectedItem
        Fees_Year = ComboBox3.SelectedItem
        Fees_Amount = TextBox3.Text
        Dim rw As DataRow = RGITDataSet1.Tables(0).NewRow
        rw.Item("Fees_ID") = Fees_ID
        rw.Item("Student_ID") = Student_ID
        rw.Item("Payment_Type") = Payment_Type
        rw.Item("Fees_Date") = Fees_Date
        rw.Item("Fees_Month") = Fees_Month
        rw.Item("Fees_Year") = Fees_Year
        rw.Item("Fees_Amount") = Fees_Amount
        Try
            RGITDataSet1.Tables(0).Rows.Add(rw)
            i = Fees_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows added " & i)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        
        Try
            Dim query = From line In RGITDataSet1.Fees_Information
                        Where line.Fees_ID = TextBox8.Text
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
        columnName = TextBox4.Text
        rowNumber = Val(TextBox5.Text)
        newValue = TextBox6.Text
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Item(columnName) = newValue
            i = Fees_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows modified " & i)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        
        Dim i, rowNumber As Integer
        rowNumber = Val(TextBox7.Text)
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Delete()
            i = Fees_InformationTableAdapter.Update(RGITDataSet1)
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

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form8.Show()
        Me.Hide()

    End Sub
End Class