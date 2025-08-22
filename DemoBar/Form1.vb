Imports System.IO

Public Class Form1
    Dim url As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = "Total Letters : 0"
        ToolStripStatusLabel2.Text = ""
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim nextForm As New Form1
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim mystream As Stream = Nothing
        OpenFileDialog1.Filter = "Text files|(*.txt)|*.txt|all files(*.*)*.*"
        If (OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (OpenFileDialog1.FileName.Length > 0) Then
            Try
                mystream = OpenFileDialog1.OpenFile()
                If (mystream IsNot Nothing) Then
                    RichTextBox1.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                    url = OpenFileDialog1.FileName
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot read file from disk error: " & ex.Message)
            Finally
                If (mystream IsNot Nothing) Then
                    mystream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save"
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.Filter = "Text files|(*.txt)|*.txt|all files(*.*)*.*"
        Try
            RichTextBox1.SaveFile(url, RichTextBoxStreamType.PlainText)
            ToolStripStatusLabel2.Text = "File Saved"
        Catch ex As Exception
            Call SaveAsToolStripMenuItem_Click(Me, e)
        End Try
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save As"
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.Filter = "Text files|(*.txt)|*.txt|all files(*.*)*.*"

        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            RichTextBox1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
            ToolStripStatusLabel2.Text = "File Saved"
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        If RichTextBox1.SelectionLength > 0 Then
            RichTextBox1.Cut()
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If RichTextBox1.SelectionLength > 0 Then
            RichTextBox1.Copy()
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        RichTextBox1.SelectedText = ""
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.Font = RichTextBox1.Font
        FontDialog1.ShowDialog()
        RichTextBox1.Font = FontDialog1.Font
    End Sub

    Private Sub RichTextBox1_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        ToolStripStatusLabel1.Text = "Total Letters : " + RichTextBox1.TextLength.ToString()
    End Sub
End Class
