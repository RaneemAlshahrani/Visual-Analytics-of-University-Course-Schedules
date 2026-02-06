' This class implements the IScheduleFeature interface
' to list all courses in the provided schedule.
Public Class CourseListFeature
    Implements IScheduleFeature

    ' Property representing the name of the feature.
    ' Returns a fixed descriptive string.
    Public ReadOnly Property Name As String Implements IScheduleFeature.Name
        Get
            Return "Course Lister"
        End Get
    End Property

    ' Executes the feature logic:
    ' Takes a list of sections, a dictionary mapping building IDs to coordinates,
    ' and a selected day (not used here).
    ' Returns a formatted list of all courses with their codes and names.
    Public Function Execute(sections As List(Of Section),
                            buildingCoords As Dictionary(Of String, PointF),
                            selectedDay As String) As String Implements IScheduleFeature.Execute

        ' StringBuilder for efficient string concatenation.
        Dim result As New Text.StringBuilder()

        ' Index counter to number each listed course.
        Dim idx As Integer = 1

        ' Iterate through all sections and extract course info.
        For Each s In sections
            result.AppendLine($"{idx}- {s.GetCourse().GetCode()}: {s.GetCourse().GetName()}")
            idx += 1
        Next

        ' Return the final formatted course list, trimmed of extra line breaks.
        Return result.ToString().Trim()
    End Function
End Class