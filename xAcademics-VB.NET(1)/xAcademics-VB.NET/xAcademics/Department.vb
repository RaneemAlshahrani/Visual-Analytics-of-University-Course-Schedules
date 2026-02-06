Public Class Department
    ' Private field
    Private _name As String

    ' Constructor
    Public Sub New(name As String)
        _name = name
    End Sub

    ' Getter method
    Public Function GetName() As String
        Return _name
    End Function

    ' ToString method for debugging
    Public Overrides Function ToString() As String
        Return "Department: " & _name
    End Function
End Class