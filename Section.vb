Public Class Section
    ' Private fields
    Private _crn As String
    Private _sectionNumber As String
    Private _course As Course
    Private _schedule As Schedule
    Private _room As Room

    ' Constructor
    Public Sub New(crn As String, sectionNumber As String, course As Course, schedule As Schedule, room As Room)
        _crn = crn
        _sectionNumber = sectionNumber
        _course = course
        _schedule = schedule
        _room = room
    End Sub

    ' Getter methods
    Public Function GetCRN() As String
        Return _crn
    End Function

    Public Function GetSectionNumber() As String
        Return _sectionNumber
    End Function

    Public Function GetCourse() As Course
        Return _course
    End Function

    Public Function GetSchedule() As Schedule
        Return _schedule
    End Function

    Public Function GetRoom() As Room
        Return _room
    End Function

    ' ToString method for debugging
    Public Overrides Function ToString() As String
        Return "Section " & _sectionNumber & " (CRN: " & _crn & ") for " & _course.GetCode() & " in " & _room.GetRoomNumber()
    End Function
End Class