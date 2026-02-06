Imports System.Globalization
Imports Microsoft.Office.Interop

Public Class ScheduleReader
    Private _filePath As String

    Public Sub New(filePath As String)
        _filePath = filePath
    End Sub

    Public Function ReadSections() As List(Of Section)
        Dim sections As New List(Of Section)()
        Dim excelApp As New Excel.Application()
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet = Nothing

        Try
            workbook = excelApp.Workbooks.Open(_filePath)
            worksheet = CType(workbook.Worksheets(1), Excel.Worksheet) ' First sheet

            Dim usedRange As Excel.Range = worksheet.UsedRange
            Dim rowCount As Integer = usedRange.Rows.Count

            For row As Integer = 2 To rowCount ' Skip header row
                Dim crn As String = If(worksheet.Cells(row, 2).Value, "").ToString()
                Dim sectionNumber As String = If(worksheet.Cells(row, 5).Value, "").ToString()
                Dim courseCode As String = If(worksheet.Cells(row, 3).Value, "").ToString()
                Dim courseName As String = If(worksheet.Cells(row, 6).Value, "").ToString()
                Dim departmentName As String = If(worksheet.Cells(row, 4).Value, "").ToString()
                Dim days As String = If(worksheet.Cells(row, 8).Value, "").ToString()
                Dim startTime As String = If(worksheet.Cells(row, 9).Value, "").ToString()
                Dim endTime As String = If(worksheet.Cells(row, 10).Value, "").ToString()
                Dim buildingNumber As String = If(worksheet.Cells(row, 11).Value, "").ToString()
                Dim roomNumber As String = If(worksheet.Cells(row, 12).Value, "").ToString()

                ' Create objects
                Dim department As New Department(departmentName)
                Dim course As New Course(courseCode, courseName, department)
                Dim building As New Building(buildingNumber)
                Dim room As New Room(roomNumber, building)
                Dim schedule As New Schedule(days, startTime, endTime)

                Dim section As New Section(crn, sectionNumber, course, schedule, room)
                sections.Add(section)
            Next
        Catch ex As Exception
            MessageBox.Show("Error reading file: " & ex.StackTrace)
        Finally
            If workbook IsNot Nothing Then workbook.Close(False)
            excelApp.Quit()
        End Try

        Return sections
    End Function
End Class