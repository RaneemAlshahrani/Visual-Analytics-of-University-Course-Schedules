Public Class Schedule
    ' Private fields
    Private _days As String
    Private _startTime As String
    Private _endTime As String

    ' Constructor
    Public Sub New(days As String, startTime As String, endTime As String)
        _days = days
        _startTime = startTime
        _endTime = endTime
    End Sub

    ' Getter methods
    Public Function GetDays() As String
        Return _days
    End Function

    Public Function GetStartTime() As String
        Return _startTime
    End Function

    Public Function GetEndTime() As String
        Return _endTime
    End Function

    ' ToString method for debugging
    Public Overrides Function ToString() As String
        Return "Schedule: " & _days & " from " & _startTime & " to " & _endTime
    End Function
End Class