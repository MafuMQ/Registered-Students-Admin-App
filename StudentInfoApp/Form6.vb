Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Me.Course_InformationTableAdapter.Fill(Me.RGITDataSet1.Course_Information)
        
        Me.Course_InformationTableAdapter.Fill(Me.RGITDataSet1.Course_Information)
        With ComboBox1.Items
            .Add("BSCINS512")
            .Add("BSCVB512")
            .Add("BSCWT512")
            .Add("BSCNET512")
            .Add("BSCMAT512")
        End With
        With ComboBox2.Items
            .Add("1")
            .Add("2")
            .Add("3")
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Course_ID, i As Double
        Dim Course_Title, Course_Name, Course_Code, Course_Fee, Course_Duration As String
        Course_ID = TextBox1.Text
        Course_Title = TextBox2.Text
        Course_Name = TextBox3.Text
        Course_Code = ComboBox1.SelectedItem
        Course_Fee = TextBox4.Text
        Course_Duration = ComboBox2.SelectedItem
        Dim rw As DataRow = RGITDataSet1.Tables(0).NewRow
        rw.Item("Course_ID") = Course_ID
        rw.Item("Course_Title") = Course_Title
        rw.Item("Course_Name") = Course_Name
        rw.Item("Course_Code") = Course_Code
        rw.Item("Course_Fee") = Course_Fee
        rw.Item("Course_Duration") = Course_Duration
        Try
            RGITDataSet1.Tables(0).Rows.Add(rw)
            i = Course_InformationTableAdapter.Update(RGITDataSet1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Number of rows added " & i)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        
        Dim query = From line In RGITDataSet1.Course_Information
                    Select line.Course_ID, line.Course_Title, line.Course_Name, line.Course_Code, line.Course_Fee, line.Course_Duration
        DataGridView1.DataSource = query.ToList
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        
        Try
            Dim query = From line In RGITDataSet1.Course_Information
                        Where line.Course_ID = TextBox9.Text
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
            i = Course_InformationTableAdapter.Update(RGITDataSet1)
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
            i = Course_InformationTableAdapter.Update(RGITDataSet1)
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

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Form7.Show()
        Me.Hide()
    End Sub
    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form8.Show()
        Me.Hide()

    End Sub
End Class