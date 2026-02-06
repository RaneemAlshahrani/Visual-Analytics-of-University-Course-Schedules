Public Class Course
    ' Private fields
    Private _code As String
    Private _name As String
    Private _department As Department

    ' Constructor
    Public Sub New(code As String, name As String, department As Department)
        _code = code
        _name = name
        _department = department
    End Sub

    ' Getter methods
    Public Function GetCode() As String
        Return _code
    End Function

    Public Function GetName() As String
        Return _name
    End Function

    Public Function GetDepartment() As Department
        Return _department
    End Function

    ' ToString method for debugging
    Public Overrides Function ToString() As String
        Return _code & " - " & _name & " (" & _department.GetName() & ")"
    End Function
End Class