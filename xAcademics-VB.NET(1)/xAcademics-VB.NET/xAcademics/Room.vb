Public Class Room
    ' Private attributes
    Private _roomNumber As String
    Private _building As Building

    ' Constructor
    Public Sub New(roomNumber As String, building As Building)
        _roomNumber = roomNumber
        _building = building
    End Sub

    ' Public getter methods
    Public Function GetRoomNumber() As String
        Return _roomNumber
    End Function

    Public Function GetBuilding() As Building
        Return _building
    End Function

    ' Optional: ToString method for debugging
    Public Overrides Function ToString() As String
        Return "Room " & _roomNumber & " in " & _building.GetBuildingNumber()
    End Function
End Class
