Imports MySql.Data.MySqlClient

Public Class biometrics

    Private _emp_no As Integer
    Private _state As String
    Private _date_time As DateTime
    Private _work_code As Integer

    Public Property emp_no() As Integer
        Get
            Return _emp_no
        End Get
        Set(ByVal value As Integer)
            _emp_no = value
        End Set
    End Property

    Public Property state() As String
        Get
            Return _state
        End Get
        Set(ByVal value As String)
            _state = value
        End Set
    End Property

    Public Property date_time() As DateTime
        Get
            Return _date_time
        End Get
        Set(ByVal value As DateTime)
            _date_time = value
        End Set
    End Property

    Public Property work_code() As Integer
        Get
            Return _work_code
        End Get
        Set(ByVal value As Integer)
            _work_code = value
        End Set
    End Property

    Public Function SAVE() As Boolean
        Dim cmd As New MySqlCommand
        SET_COMMAND_PROPERTIES(cmd, "BIOMETRICS_NEW")
        cmd.Parameters.AddWithValue("_emp_no", emp_no)
        cmd.Parameters.AddWithValue("_state", state)
        cmd.Parameters.AddWithValue("_date_time", date_time)
        cmd.Parameters.AddWithValue("_work_code", work_code)

        If EXECUTE_COMMAND(cmd) Then
            SAVE = True
        Else
            SAVE = False
        End If
    End Function


End Class
