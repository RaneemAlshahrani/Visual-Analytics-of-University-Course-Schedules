' This class implements the IScheduleFeature interface to calculate
' the total travel distance between consecutive buildings in a schedule.
Public Class DistanceFeature
    Implements IScheduleFeature

    ' Property representing the name of the feature.
    ' Returns a descriptive string for identification.
    Public ReadOnly Property Name As String Implements IScheduleFeature.Name
        Get
            Return "Distance Calculator"
        End Get
    End Property

    ' Executes the feature logic:
    ' Takes a list of sections, building coordinates, and the selected day (unused here).
    ' Calculates the total Euclidean distance between consecutive buildings in the schedule.
    Public Function Execute(sections As List(Of Section),
                            buildingCoords As Dictionary(Of String, PointF),
                            selectedDay As String) As String Implements IScheduleFeature.Execute

        ' Accumulator for total distance.
        Dim totalDist As Double = 0

        ' Iterate through all adjacent section pairs.
        For i = 0 To sections.Count - 2
            ' Get building numbers for the current and next section.
            Dim b1 = sections(i).GetRoom().GetBuilding().GetBuildingNumber()
            Dim b2 = sections(i + 1).GetRoom().GetBuilding().GetBuildingNumber()

            ' Only calculate distance if both buildings have known coordinates.
            If buildingCoords.ContainsKey(b1) AndAlso buildingCoords.ContainsKey(b2) Then
                Dim p1 = buildingCoords(b1)
                Dim p2 = buildingCoords(b2)

                ' Use the Euclidean distance formula: √((x1 - x2)² + (y1 - y2)²)
                totalDist += Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
            End If
        Next

        ' Return the total distance, rounded to two decimal places.
        Return $"Distance Traveled = {Math.Round(totalDist, 2)} m"
    End Function
End Class
