Public Class Form4

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Me.Employee_InformationTableAdapter.Fill(Me.RGITDataSet1.Employee_Information)
        
        Me.Employee_InformationTableAdapter.Fill(Me.RGITDataSet1.Employee_Information)

        
        Me.Employee_InformationTableAdapter.Fill(Me.RGITDataSet1.Employee_Information)
        
        With ComboBox1.Items
            .Add("Mr")
            .Add("Mrs")
            .Add("Miss")
        End With
        With ComboBox2.Items
            .Add("A")
            .Add("B")
            .Add("C")
            .Add("D")
            .Add("E")
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        
        Dim i, Employee_Salary As Double
        Dim Employee_Dob As Date
        Dim Employee_Title, Employee_Names, Employee_Surname, Employee_ID, Employee_EAddress, Employee_LAddress,
     Employee_Description, Employee_Type, Employee_MNumber, Employee_PNumber As String
        Employee_ID = TextBox1.Text
        Employee_Title = ComboBox1.SelectedItem
        Employee_Names = TextBox2.Text
        Employee_Surname = TextBox3.Text
        Employee_Dob = DateTimePicker1.Value
        Employee_MNumber = TextBox4.Text
        Employee_PNumber = TextBox5.Text
        Employee_EAddress = TextBox6.Text
        Employee_PAddress = TextBox7.Text
        Employee_Description = TextBox9.Text
        Employee_Type = ComboBox2.SelectedItem
        Employee_Salary = TextBox10.Text
        Dim rw As DataRow = RGITDataSet1.Tables(0).NewRow
        rw.Item("Employee_ID") = Employee_ID
        rw.Item("Employee Title") = Employee_Title
        rw.Item("Employee_Names") = Employee_Names
        rw.Item("Employee_Surname") = Employee_Surname
        rw.Item("Employee_Dob") = Employee_Dob
        rw.Item("Employee_MNumber") = Employee_MNumber
        rw.Item("Employee_PNumber") = Employee_PNumber
        rw.Item("Employee_EAddress") = Employee_EAddress
        rw.Item("Employee_LAddress") = Employee_LAddress
        rw.Item("Employee_Description") = Employee_Description
        rw.Item("Employee_Type") = Employee_Type
        rw.Item("Employee_Salary") = Employee_Salary
        Try
            RGITDataSet1.Tables(0).Rows.Add(rw)
            i = Employee_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows added " & i)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        
        Dim query = From line In RGITDataSet1.Employee_Information
                    Select line.Employee_ID, line.Employee_Title, line.Employee_Names, line.Employee_Surname, line.Employee_Dob,
                        line.Employee_MNumber, line.Employee_PNumber,
                        line.Employee_LAddress, line.Employee_Description, line.Employee_Type, line.Employee_Salary
        DataGridView1.DataSource = query.ToList
        DataGridView1.CurrentCell = Nothing

        

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        
        Try
            Dim query = From line In RGITDataSet1.Employee_Information
                        Where line.Employee_ID = TextBox15.Text
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
        columnName = TextBox11.Text
        rowNumber = Val(TextBox12.Text)
        newValue = TextBox13.Text
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Item(columnName) = newValue
            i = Employee_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows modified " & i)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        
        Dim i, rowNumber As Integer
        rowNumber = Val(TextBox14.Text)
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Delete()
            i = Employee_InformationTableAdapter.Update(RGITDataSet1)
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
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Application.Exit()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form3.Show()
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
    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form8.Show()
        Me.Hide()

    End Sub
End Class
