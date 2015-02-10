Public Class Form1

    Dim total_ctr As Integer = 0
    Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click
        If Me.Text = "" Then Exit Sub
        lb.Items.Clear()
        lv.Items.Clear()


        bgAnalyzer.RunWorkerAsync()
    End Sub

    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
        Dim fd As New OpenFileDialog
        fd.Filter = "Text Files (*.txt)|*.txt|Dat Files (*.dat)|*.dat"
        Dim filename As String = ""

        If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
            filename = fd.FileName
            Me.Text = filename

            Dim objReader As New System.IO.StreamReader(Me.Text)
            'read linebyline
            Dim line As String
            Dim ctr As Integer = 0
            Do While objReader.Peek() <> -1
                line = objReader.ReadLine()
                ctr += 1
            Loop
            total_ctr = ctr
            pb.setMax(total_ctr)

            btnAnalyze.Enabled = True
        Else
            btnAnalyze.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If OPEN_CONNECTION() Then
            Me.BackColor = Color.GreenYellow
        Else
            Me.BackColor = Color.Red
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


#Region "delegates and its subs"
    ' a delegate is for cross thread operations
    ' because you cannot access controls from another thread.
    ' since we use background worker (another thread)
    ' we use a delegate to access form controls, which is 
    ' from the original frmMain thread.

    Public Delegate Sub SetLabelText_Delegate(ByVal [Label] As Label, ByVal [text] As String)
    Public Delegate Sub AddItemsDelegate(ByVal lv As ListView, ByVal li As ListViewItem)
    ' The delegates subroutine.
    Public Sub SetLabelText_ThreadSafe(ByVal [Label] As Label, ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If [Label].InvokeRequired Then
            Dim MyDelegate As New SetLabelText_Delegate(AddressOf SetLabelText_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[Label], [text]})
        Else
            [Label].Text = [text]
        End If
    End Sub
    Public Sub AddItemsThreadSafe(ByVal lv As ListView, ByVal li As ListViewItem)
        If lv.InvokeRequired Then
            Dim myDelegate As New AddItemsDelegate(AddressOf AddItemsThreadSafe)
            Me.Invoke(myDelegate, New Object() {lv, li})
        Else
            lv.Items.Add(li)
        End If
    End Sub

#End Region

    Private Sub bgAnalyzer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgAnalyzer.DoWork
        Dim objReader As New System.IO.StreamReader(Me.Text)
        'read linebyline
        Dim line As String

        Dim ctr As Integer = 0
        Do While objReader.Peek() <> -1

            line = objReader.ReadLine()
            Dim str() As String = Split(line, vbTab)

            Dim dept, empno, name, date_time, state, terminal, work_code As String
            dept = str(0)
            empno = str(1)
            name = str(2)
            date_time = str(3)
            state = str(4)
            terminal = str(5)
            work_code = str(6)

            'lb.Items.Add(empno & "-" & name & "-> " & date_time)

            Dim b As New biometrics
            b.emp_no = empno
            b.date_time = date_time
            b.state = state
            b.work_code = work_code

            If b.SAVE Then
                Dim li As New ListViewItem
                li.Text = name
                li.SubItems.Add(date_time)
                li.SubItems.Add(dept)
                'lv.Items.Add(li)
                Dim em As New emp
                em.emp_no = empno
                em.name = name
                If em.save Then
                End If
            Else
                'Dim li As New ListViewItem
                ' li.Text = "error :" & err_global.Message
                'lv.Items.Add(li)
            End If
            ctr += 1

            SetLabelText_ThreadSafe(Me.pb.lblcount, ctr & "/" & total_ctr)
            SetLabelText_ThreadSafe(Me.pb.lblpercent, Format(ctr / total_ctr, "0.00%"))

            Dim p As Integer = CInt(ctr)
            bgAnalyzer.ReportProgress(p)

            System.Threading.Thread.Sleep(10)
        Loop
        objReader.Close()

    End Sub

    Private Sub bgAnalyzer_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgAnalyzer.ProgressChanged
        pb.setProgress(CDec(e.ProgressPercentage))
    End Sub
End Class
