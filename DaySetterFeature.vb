' This class implements the IScheduleFeature interface to allow 
' setting or updating the currently selected day in a schedule system.
Public Class DaySetterFeature
    Implements IScheduleFeature

    ' A private callback delegate that will be invoked when the day is set.
    Private ReadOnly _callback As Action(Of String)

    ' Constructor that takes a callback function.
    ' The callback allows external code to react whenever a new day is selected.
    Public Sub New(callback As Action(Of String))
        _callback = callback
    End Sub

    ' Property representing the name of this feature.
    ' Returns a constant string identifier for clarity.
    Public ReadOnly Property Name As String Implements IScheduleFeature.Name
        Get
            Return "Day Setter"
        End Get
    End Property

    ' Executes the feature's logic:
    ' - Invokes the callback with the selected day code.
    ' - Converts the short day code into a full day name.
    ' - Returns a formatted string showing the selected day.
    Public Function Execute(sections As List(Of Section),
                            buildingCoords As Dictionary(Of String, PointF),
                            selectedDay As String) As String Implements IScheduleFeature.Execute
        _callback(selectedDay)
        Dim fullDay = GetFullDayName(selectedDay)
        Return $"Selected Day: {fullDay}"
    End Function

    ' Helper function that maps short day codes to their full names.
    ' If an unrecognized code is passed, it simply returns it unchanged.
    Private Function GetFullDayName(shortDay As String) As String
        Select Case shortDay
            Case "U" : Return "Sunday"
            Case "M" : Return "Monday"
            Case "T" : Return "Tuesday"
            Case "W" : Return "Wednesday"
            Case "R" : Return "Thursday"
            Case Else : Return shortDay
        End Select
    End Function
End Class
