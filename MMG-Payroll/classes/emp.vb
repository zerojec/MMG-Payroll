Imports MySql.Data.MySqlClient
Public Class emp

    Private _emp_no As Integer
    Private _name As String

    Public Property emp_no() As Integer
        Get
            Return _emp_no
        End Get
        Set(ByVal value As Integer)
            _emp_no = value
        End Set
    End Property
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Function save() As Boolean
        Dim cmd As New MySqlCommand
        SET_COMMAND_PROPERTIES(cmd, "EMPLOYEE_NEW")
        cmd.Parameters.AddWithValue("_emp_no", emp_no)
        cmd.Parameters.AddWithValue("_name", _name)

        If EXECUTE_COMMAND(cmd) Then
            save = True
        Else
            save = False
        End If
    End Function

    Public Function GET_ATTENDANCE_BETWEEN_DATE(ByVal d1 As Date, ByVal d2 As Date) As DataTable
        Dim dt As New DataTable
        Dim cmd As New MySqlCommand
        SET_COMMAND_PROPERTIES(cmd, "ATTENDANCE_BETWEEN_DATE")
        cmd.Parameters.AddWithValue("_from_date", d1)
        cmd.Parameters.AddWithValue("_to_date", d2)


        dt = LOAD_DATATABLE_FROM_STOREDPRO(cmd)

        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                GET_ATTENDANCE_BETWEEN_DATE = dt
            Else
                GET_ATTENDANCE_BETWEEN_DATE = Nothing
            End If
        End If

    End Function

End Class
