' This class implements the IScheduleFeature interface to provide
' functionality for counting the total number of courses in the given schedule.
Public Class CourseCountFeature
    Implements IScheduleFeature

    ' Property representing the name of this feature.
    ' Returns a fixed string that identifies the feature.
    Public ReadOnly Property Name As String Implements IScheduleFeature.Name
        Get
            Return "Course Counter"
        End Get
    End Property

    ' Executes the feature logic:
    ' Accepts a list of sections, a dictionary mapping building IDs to coordinates,
    ' and a selected day (unused here).
    ' Returns a formatted string showing how many courses are in the list.
    Public Function Execute(sections As List(Of Section),
                            buildingCoords As Dictionary(Of String, PointF),
                            selectedDay As String) As String Implements IScheduleFeature.Execute
        Return $"Number of Courses = {sections.Count}"
    End Function
End Class
