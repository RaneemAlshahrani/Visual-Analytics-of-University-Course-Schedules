<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class application
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DrawingPanel = New Panel()
        TxtCRN = New TextBox()
        CRNLabel = New Label()
        ResultsLabel = New Label()
        UBtn = New Button()
        MBtn = New Button()
        TBtn = New Button()
        WBtn = New Button()
        RBtn = New Button()
        ResultsTextBox = New TextBox()
        SuspendLayout()
        ' 
        ' DrawingPanel
        ' 
        DrawingPanel.BackColor = SystemColors.Window
        DrawingPanel.BackgroundImage = My.Resources.Resources.KFUPM_Map
        DrawingPanel.BackgroundImageLayout = ImageLayout.Stretch
        DrawingPanel.BorderStyle = BorderStyle.FixedSingle
        DrawingPanel.ForeColor = SystemColors.ControlLightLight
        DrawingPanel.Location = New Point(62, 216)
        DrawingPanel.Margin = New Padding(4, 5, 4, 5)
        DrawingPanel.Name = "DrawingPanel"
        DrawingPanel.Size = New Size(760, 812)
        DrawingPanel.TabIndex = 0
        ' 
        ' TxtCRN
        ' 
        TxtCRN.Location = New Point(423, 77)
        TxtCRN.Name = "TxtCRN"
        TxtCRN.Size = New Size(960, 31)
        TxtCRN.TabIndex = 1
        ' 
        ' CRNLabel
        ' 
        CRNLabel.AutoSize = True
        CRNLabel.Font = New Font("Segoe UI", 12F)
        CRNLabel.Location = New Point(99, 75)
        CRNLabel.Name = "CRNLabel"
        CRNLabel.Size = New Size(318, 32)
        CRNLabel.TabIndex = 2
        CRNLabel.Text = "Enter Student CRN Numbers"
        ' 
        ' ResultsLabel
        ' 
        ResultsLabel.AutoSize = True
        ResultsLabel.Font = New Font("Segoe UI", 12F)
        ResultsLabel.Location = New Point(1135, 155)
        ResultsLabel.Name = "ResultsLabel"
        ResultsLabel.Size = New Size(88, 32)
        ResultsLabel.TabIndex = 3
        ResultsLabel.Text = "Results"
        ' 
        ' UBtn
        ' 
        UBtn.BackColor = SystemColors.ControlDark
        UBtn.Font = New Font("Segoe UI", 14F)
        UBtn.Location = New Point(957, 233)
        UBtn.Name = "UBtn"
        UBtn.Size = New Size(60, 45)
        UBtn.TabIndex = 4
        UBtn.Text = "U"
        UBtn.UseVisualStyleBackColor = False
        ' 
        ' MBtn
        ' 
        MBtn.BackColor = SystemColors.ControlDark
        MBtn.Font = New Font("Segoe UI", 14F)
        MBtn.Location = New Point(1054, 233)
        MBtn.Name = "MBtn"
        MBtn.Size = New Size(60, 45)
        MBtn.TabIndex = 5
        MBtn.Text = "M"
        MBtn.UseVisualStyleBackColor = False
        ' 
        ' TBtn
        ' 
        TBtn.BackColor = SystemColors.ControlDark
        TBtn.Font = New Font("Segoe UI", 14F)
        TBtn.Location = New Point(1151, 233)
        TBtn.Name = "TBtn"
        TBtn.Size = New Size(60, 45)
        TBtn.TabIndex = 6
        TBtn.Text = "T"
        TBtn.UseVisualStyleBackColor = False
        ' 
        ' WBtn
        ' 
        WBtn.BackColor = SystemColors.ControlDark
        WBtn.Font = New Font("Segoe UI", 14F)
        WBtn.Location = New Point(1250, 233)
        WBtn.Name = "WBtn"
        WBtn.Size = New Size(60, 45)
        WBtn.TabIndex = 7
        WBtn.Text = "W"
        WBtn.UseVisualStyleBackColor = False
        ' 
        ' RBtn
        ' 
        RBtn.BackColor = SystemColors.ControlDark
        RBtn.Font = New Font("Segoe UI", 14F)
        RBtn.Location = New Point(1345, 233)
        RBtn.Name = "RBtn"
        RBtn.Size = New Size(60, 45)
        RBtn.TabIndex = 8
        RBtn.Text = "R"
        RBtn.UseVisualStyleBackColor = False
        ' 
        ' ResultsTextBox
        ' 
        ResultsTextBox.BackColor = SystemColors.Window
        ResultsTextBox.Location = New Point(954, 322)
        ResultsTextBox.Multiline = True
        ResultsTextBox.Name = "ResultsTextBox"
        ResultsTextBox.ReadOnly = True
        ResultsTextBox.ScrollBars = ScrollBars.Vertical
        ResultsTextBox.Size = New Size(450, 600)
        ResultsTextBox.TabIndex = 9
        ' 
        ' application
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1470, 1050)
        Controls.Add(ResultsTextBox)
        Controls.Add(RBtn)
        Controls.Add(WBtn)
        Controls.Add(TBtn)
        Controls.Add(MBtn)
        Controls.Add(UBtn)
        Controls.Add(ResultsLabel)
        Controls.Add(CRNLabel)
        Controls.Add(TxtCRN)
        Controls.Add(DrawingPanel)
        Margin = New Padding(4, 5, 4, 5)
        Name = "application"
        Text = "Application"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents DrawingPanel As Panel
    Friend WithEvents TxtCRN As TextBox
    Friend WithEvents CRNLabel As Label
    Friend WithEvents ResultsLabel As Label
    Friend WithEvents UBtn As Button
    Friend WithEvents MBtn As Button
    Friend WithEvents TBtn As Button
    Friend WithEvents WBtn As Button
    Friend WithEvents RBtn As Button
    Friend WithEvents ResultsTextBox As TextBox
End Class
