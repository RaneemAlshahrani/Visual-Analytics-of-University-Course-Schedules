Public Class Building
    ' Private field
    Private _buildingNumber As String

    ' Constructor
    Public Sub New(buildingNumber As String)
        _buildingNumber = buildingNumber
    End Sub

    ' Getter method
    Public Function GetBuildingNumber() As String
        Return _buildingNumber
    End Function

    ' Optional: ToString method for better debugging
    Public Overrides Function ToString() As String
        Return "Building " & _buildingNumber
    End Function
End Class