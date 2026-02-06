' This interface defines a contract for all schedule-related features.
' Each implementing class must provide a unique name and an Execute method
' that performs a specific operation on the provided schedule data.
Public Interface IScheduleFeature

    ' A human-readable name identifying the feature.
    ' Used for display, logging, or feature selection.
    ReadOnly Property Name As String

    ' The core method that every feature must implement.
    ' Parameters:
    '   sections      - A list of Section objects representing the schedule.
    '   buildingCoords - A dictionary mapping building identifiers to their coordinates.
    '   selectedDay    - The currently selected day for context-sensitive features.
    ' Returns:
    '   A string describing the result or output of the feature.
    Function Execute(sections As List(Of Section),
                     buildingCoords As Dictionary(Of String, PointF),
                     selectedDay As String) As String
End Interface
