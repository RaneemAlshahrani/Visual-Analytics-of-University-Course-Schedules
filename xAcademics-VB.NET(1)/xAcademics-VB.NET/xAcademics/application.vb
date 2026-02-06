Imports System.Drawing.Drawing2D

Public Class application
    Private _sections As New List(Of Section)()
    Private _selectedDay As String
    Private _orderedForPaint As New List(Of Section)()
    Private _features As List(Of IScheduleFeature)


    Private _buildingCoords As New Dictionary(Of String, PointF) From {
        {"1", New PointF(160, 216)},
        {"2", New PointF(198, 180)},
        {"3", New PointF(232, 199)},
        {"4", New PointF(294, 209)},
        {"5", New PointF(337, 267)},
        {"6", New PointF(395, 335)},
        {"7", New PointF(397, 398)},
        {"8", New PointF(459, 429)},
        {"9", New PointF(477, 483)},
        {"10", New PointF(477, 546)},
        {"11", New PointF(547, 629)},
        {"12", New PointF(307, 388)},
        {"14", New PointF(332, 482)},
        {"15", New PointF(222, 397)},
        {"16", New PointF(282, 268)},
        {"17", New PointF(407, 461)},
        {"18", New PointF(380, 562)},
        {"19", New PointF(403, 593)},
        {"20", New PointF(430, 625)},
        {"21", New PointF(525, 512)},
        {"22", New PointF(588, 558)},
        {"23", New PointF(626, 577)},
        {"24", New PointF(610, 660)},
        {"25", New PointF(640, 672)},
        {"26", New PointF(144, 146)},
        {"40", New PointF(475, 98)},
        {"59", New PointF(503, 323)},
        {"63", New PointF(215, 85)},
        {"68", New PointF(420, 204)},
        {"76", New PointF(700, 575)}
    }

    ' ============================
    ' === FORM LOAD ============
    ' ============================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim excelPath As String =
                "C:\Users\96653\Downloads\xAcademics-VB.NET(1)\xAcademics-VB.NET\xAcademics\Term Schedule 251.xlsx"

            If IO.File.Exists(excelPath) Then
                _sections = New ScheduleReader(excelPath).ReadSections()
            End If

            SetDoubleBuffered(DrawingPanel)

            _features = New List(Of IScheduleFeature) From {
                New DaySetterFeature(AddressOf OnDaySelected),
                New CourseCountFeature(),
                New CourseListFeature(),
                New BuildingCountFeature(),
                New DistanceFeature()
            }

        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub OnDaySelected(day As String)
        _selectedDay = day
    End Sub

    Private Sub SetDoubleBuffered(ctrl As Control)
        ctrl.GetType().InvokeMember("DoubleBuffered",
            Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.SetProperty,
            Nothing, ctrl, New Object() {True})
    End Sub

    ' ============================
    ' === EVENT HANDLERS ========
    ' ============================
    Private Sub TxtCRN_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCRN.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            DrawSchedule()
        End If
    End Sub

    Private Sub DayBtn_Click(sender As Object, e As EventArgs) _
        Handles UBtn.Click, MBtn.Click, TBtn.Click, WBtn.Click, RBtn.Click

        Dim btn As Button = CType(sender, Button)
        _selectedDay = btn.Text.Trim().ToUpper()

        For Each b As Button In {UBtn, MBtn, TBtn, WBtn, RBtn}
            b.BackColor = SystemColors.Control
        Next
        btn.BackColor = Color.LightGreen

        Me.BeginInvoke(Sub() DrawSchedule())
    End Sub

    ' ============================
    ' === DRAW SCHEDULE =========
    ' ============================
    Private Sub DrawSchedule()
        Try
            If _sections.Count = 0 Then
                MsgBox("No schedule data found.")
                Return
            End If

            Dim crnList = TxtCRN.Text.Split({" ", ",", vbCrLf},
                                            StringSplitOptions.RemoveEmptyEntries).ToList()

            If crnList.Count = 0 Then
                MsgBox("Please enter one or more CRNs separated by spaces.")
                Return
            End If

            Dim validCRNs = New HashSet(Of String)(_sections.Select(Function(s) s.GetCRN()), StringComparer.Ordinal)
            If Not crnList.All(Function(c) validCRNs.Contains(c)) Then
                MsgBox("Some CRNs are invalid or not found in Excel.", MsgBoxStyle.Critical)
                Return
            End If

            Dim ordered = _sections.Where(Function(s) crnList.Contains(s.GetCRN()) AndAlso
                                               s.GetSchedule().GetDays().ToUpper().Contains(_selectedDay)).
                                    OrderBy(Function(s)
                                                Dim dt As Date
                                                If Date.TryParse(s.GetSchedule().GetStartTime(), dt) Then Return dt
                                                Return Date.MinValue
                                            End Function).ToList()

            If ordered.Count = 0 Then
                ResultsTextBox.Text = "No sections found for the entered CRNs."
                _orderedForPaint.Clear()
                DrawingPanel.Refresh()
                Return
            End If

            _orderedForPaint = ordered
            DrawingPanel.Refresh()

            Dim sb As New Text.StringBuilder()
            For Each feature In _features
                sb.AppendLine(feature.Execute(ordered, _buildingCoords, _selectedDay))
            Next
            ResultsTextBox.Text = sb.ToString().Trim()

        Catch ex As Exception
            MsgBox("Error drawing schedule: " & ex.Message)
        End Try
    End Sub

    ' ============================
    ' === DRAWING PANEL =========
    ' ============================
    Private Sub DrawingPanel_Paint(sender As Object, e As PaintEventArgs) Handles DrawingPanel.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        If _orderedForPaint.Count = 0 Then Return

        ' Safe font creation: guaranteed to exist on all Windows installs
        Dim safeFont As Font
        Try
            safeFont = New Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point)
        Catch
            safeFont = New Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold, GraphicsUnit.Point)
        End Try

        Using routePen As New Pen(Color.Black, 3),
              textBrush As Brush = Brushes.Black

            routePen.CustomEndCap = New AdjustableArrowCap(6, 6)

            For i = 0 To _orderedForPaint.Count - 1
                Dim b = _orderedForPaint(i).GetRoom().GetBuilding().GetBuildingNumber()
                If Not _buildingCoords.ContainsKey(b) Then Continue For
                Dim p = _buildingCoords(b)

                ' Draw arrow line to the next building
                If i < _orderedForPaint.Count - 1 Then
                    Dim nextB = _orderedForPaint(i + 1).GetRoom().GetBuilding().GetBuildingNumber()
                    If _buildingCoords.ContainsKey(nextB) Then
                        e.Graphics.DrawLine(routePen, p, _buildingCoords(nextB))
                    End If
                End If

                ' Draw orange circle
                e.Graphics.FillEllipse(Brushes.Orange, p.X - 8, p.Y - 8, 16, 16)

                ' Draw centered number text safely
                Dim rect As New Rectangle(CInt(p.X - 8), CInt(p.Y - 8), 16, 16)
                TextRenderer.DrawText(e.Graphics,
                                      (i + 1).ToString(),
                                      safeFont,
                                      rect,
                                      Color.Black,
                                      TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.NoPadding)
            Next
        End Using
    End Sub
End Class
