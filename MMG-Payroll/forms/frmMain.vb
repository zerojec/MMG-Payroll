
Imports MySql.Data.MySqlClient

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim em As New emp
        Dim dt As New DataTable

        Dim d1, d2 As Date
        d1 = CDate("01/01/2015")
        d2 = CDate("01/30/2015")

        dt = em.GET_ATTENDANCE_BETWEEN_DATE(d1, d2)

        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                For Each r As DataRow In dt.Rows
                    Dim l As New ListViewItem
                    l.Tag = r.Item("emp_no")
                    l.Text = r.Item("name_")
                    l.SubItems.Add(r.Item("state"))
                    l.SubItems.Add(r.Item("date_time"))
                    lv.Items.Add(l)
                Next
            Else
                MsgBox("Error (Count):" & err_global.Message, MsgBoxStyle.Exclamation, "Error")
            End If
        Else
            MsgBox("Error (Nothing):" & err_global.Message, MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
End Class