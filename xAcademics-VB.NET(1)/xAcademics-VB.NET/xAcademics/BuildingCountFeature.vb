' This class implements the IScheduleFeature interface to provide 
' functionality for counting distinct buildings in a schedule.
Public Class BuildingCountFeature
    Implements IScheduleFeature

    ' Property representing the name of the feature.
    ' Returns a constant descriptive string.
    Public ReadOnly Property Name As String Implements IScheduleFeature.Name
        Get
            Return "Building Counter"
        End Get
    End Property

    ' Executes the feature's logic:
    ' Takes a list of sections, a dictionary mapping building IDs to coordinates,
    ' and the selected day as input, then counts the number of distinct buildings.
    Public Function Execute(sections As List(Of Section),
                            buildingCoords As Dictionary(Of String, PointF),
                            selectedDay As String) As String Implements IScheduleFeature.Execute

        ' Extracts building numbers from the sections,
        ' filters out duplicates, and counts how many unique buildings exist.
        Dim uniqueBuildings = sections.
            Select(Function(s) s.GetRoom().GetBuilding().GetBuildingNumber()).
            Distinct().
            Count()

        ' Returns the result as a formatted string.
        Return $"Number of Different Buildings = {uniqueBuildings}"
    End Function
End Class
