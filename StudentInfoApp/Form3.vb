Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Me.Admin_InformationTableAdapter.Fill(Me.RGITDataSet1.Admin_Information)

        
        Me.Admin_InformationTableAdapter.Fill(Me.RGITDataSet1.Admin_Information)
        
        With ComboBox1.Items
            .Add("A")
            .Add("B")
            .Add("C")
            .Add("D")
            .Add("E")
        End With
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        
        Dim query = From line In RGITDataSet1.Admin_Information
                    Select line.Employee_ID, line.Employee_Number, line.Employee_Names, line.Employee_Surnames, line.Employee_DoB,
                           line.Employee_Description, line.Employee_Type, line.Employee_PAddress, line.Employee_LAddress
        DataGridView1.DataSource = query.ToList
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        
        Dim i, Employee_Number As Double
        Dim Employee_ID, Employee_Names, Employee_Surnames, Employee_DoB, Employee_Description, Employee_Type,
            Employee_LAddress As String
        Dim rw As DataRow = RGITDataSet1.Tables(0).NewRow
        Employee_ID = TextBox1.Text
        Employee_Number = Val(TextBox2.Text)
        Employee_Names = TextBox3.Text
        Employee_Surnames = TextBox4.Text
        Employee_DoB = DateTimePicker1.Value
        Employee_Type = ComboBox1.SelectedItem
        Employee_Description = TextBox5.Text
        Employee_LAddress = TextBox6.Text
        rw.Item("Employee_ID") = Employee_ID
        rw.Item("Employee_Number") = Employee_Number
        rw.Item("Employee_Names") = Employee_Names
        rw.Item("Employee_Surnames") = Employee_Surnames
        rw.Item("Employee_DoB") = Employee_DoB
        rw.Item("Employee_Type") = Employee_Type
        rw.Item("Employee_Description") = Employee_Description
        rw.Item("Employee_LAddress") = Employee_LAddress
        Try
            RGITDataSet1.Tables(0).Rows.Add(rw)
            i = Admin_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows added " & i)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        
        Try
            Dim query = From line In RGITDataSet1.Admin_Information
                        Where line.Employee_ID = TextBox12.Text Or line.Employee_Number = Val(TextBox12.Text)
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
        columnName = TextBox8.Text
        rowNumber = Val(TextBox9.Text)
        newValue = TextBox10.Text
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Item(columnName) = newValue
            i = Admin_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows modified " & i)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        
        Dim i, rowNumber As Integer
        rowNumber = Val(TextBox11.Text)
        Try
            RGITDataSet1.Tables(0).Rows(rowNumber).Delete()
            i = Admin_InformationTableAdapter.Update(RGITDataSet1)
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
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Application.Exit()
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
    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Form8.Show()
        Me.Hide()

    End Sub

End Class
