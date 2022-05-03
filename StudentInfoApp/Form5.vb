Public Class Form5

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RGITDataSet1.Student_Information' table. You can move, or remove it, as needed.
        Me.Student_InformationTableAdapter.Fill(Me.RGITDataSet1.Student_Information)

        'TODO: This line of code loads data into the 'RGITDataSet5.Student_Information' table. You can move, or remove it, as needed.
        Me.Student_InformationTableAdapter.Fill(Me.RGITDataSet1.Student_Information)
        With ComboBox2.Items
            .Add("Male")
            .Add("Female")
            .Add("Other")
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'submit button
        Dim i As Integer
        Dim Stu_DoB As Date
        Dim Student_ID, First_Names, Last_Names, Stu_Gender, Mother_Name, Father_Name, Email_Address,
            Local_Address, Contact_Number As String
        Student_ID = TextBox1.Text
        First_Names = TextBox2.Text
        Last_Names = TextBox3.Text
        Stu_DoB = DateTimePicker1.Value
        Mother_Name = TextBox4.Text
        Father_Name = TextBox5.Text
        Stu_Gender = ComboBox2.SelectedItem
        Contact_Number = TextBox6.Text
        Email_Address = TextBox7.Text
        Local_Address = TextBox8.Text
        Dim rw As DataRow = RGITDataSet1.Tables(0).NewRow
        rw.Item("Student_ID") = Student_ID
        rw.Item("First_Names") = First_Names
        rw.Item("Last_Names") = Last_Names
        rw.Item("Stu_DoB") = Stu_DoB
        rw.Item("Mother_Name") = Mother_Name
        rw.Item("Father_Name") = Father_Name
        rw.Item("Stu_Gender") = Stu_Gender
        rw.Item("Contact_Number") = Contact_Number
        rw.Item("Email_Address") = Email_Address
        rw.Item("Local_Address") = Local_Address
        Try
            RGITDataSet1.Tables(0).Rows.Add(rw)
            i = Student_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows added " & i)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'view button
        Dim query = From line In RGITDataSet1.Student_Information
                    Select line.Student_ID, line.First_Names, line.Last_Names, line.Stu_DoB, line.Stu_Gender,
                        line.Stu_Category, line.Blood_Group, line.Mother_Name, line.Father_Name,
                        line.Email_Address, line.Local_Address, line.Permanent_Address, line.Contact_Number
        DataGridView1.DataSource = query.ToList
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'search button
        Try
            Dim query = From line In RGITDataSet1.Student_Information
                        Where line.Student_ID = TextBox14.Text
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
        'modify button
        Dim i, rowNumber As Integer
        Dim columnName As String
        Dim newValue As Object
        columnName = TextBox10.Text
        rowNumber = Val(TextBox11.Text)
        newValue = TextBox12.Text
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Item(columnName) = newValue
            i = Student_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows modified " & i)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'delete button
        Dim i, rowNumber As Integer
        rowNumber = Val(TextBox13.Text)
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Delete()
            i = Student_InformationTableAdapter.Update(RGITDataSet1)
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
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
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

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Form7.Show()
        Me.Hide()
    End Sub
    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form8.Show()
        Me.Hide()
    End Sub

End Class 
