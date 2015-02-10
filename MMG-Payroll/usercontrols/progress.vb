
Public Class progress

    Private _max As Integer
    Public Property max() As Integer
        Get
            Return _max
        End Get
        Set(ByVal value As Integer)
            _max = value
        End Set
    End Property

    Public Sub setProgress(ByVal val As Decimal)
        pb.Value = val
    End Sub

    Public Sub setMax(ByVal val As Integer)
        max = val
        lblcount.Text = ".../" & max
        pb.Maximum = max
    End Sub

End Class
