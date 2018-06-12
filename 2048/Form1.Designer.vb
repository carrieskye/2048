<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scherm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.infoBox = New System.Windows.Forms.GroupBox()
        Me.SizeInfoLabel = New System.Windows.Forms.Label()
        Me.HighScoreLabel = New System.Windows.Forms.Label()
        Me.TitelHighScoreLabel = New System.Windows.Forms.Label()
        Me.ScoreLabel = New System.Windows.Forms.Label()
        Me.LabelScore = New System.Windows.Forms.Label()
        Me.TitelScoreLabel = New System.Windows.Forms.Label()
        Me.DimensionBox = New System.Windows.Forms.TextBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.RestartButton = New System.Windows.Forms.Button()
        Me.EndGameButton = New System.Windows.Forms.Button()
        Me.jokerbutton = New System.Windows.Forms.Button()
        Me.TitelTimeLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimeLabel2 = New System.Windows.Forms.Label()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.BestTimeLabel = New System.Windows.Forms.Label()
        Me.BestTimeLabel2 = New System.Windows.Forms.Label()
        Me.TitelBestTimeLabel = New System.Windows.Forms.Label()
        Me.infoBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'infoBox
        '
        Me.infoBox.Controls.Add(Me.BestTimeLabel)
        Me.infoBox.Controls.Add(Me.BestTimeLabel2)
        Me.infoBox.Controls.Add(Me.TitelBestTimeLabel)
        Me.infoBox.Controls.Add(Me.TimeLabel)
        Me.infoBox.Controls.Add(Me.TimeLabel2)
        Me.infoBox.Controls.Add(Me.TitelTimeLabel)
        Me.infoBox.Controls.Add(Me.SizeInfoLabel)
        Me.infoBox.Controls.Add(Me.HighScoreLabel)
        Me.infoBox.Controls.Add(Me.TitelHighScoreLabel)
        Me.infoBox.Controls.Add(Me.ScoreLabel)
        Me.infoBox.Controls.Add(Me.LabelScore)
        Me.infoBox.Controls.Add(Me.TitelScoreLabel)
        Me.infoBox.Controls.Add(Me.DimensionBox)
        Me.infoBox.Controls.Add(Me.StartButton)
        Me.infoBox.Controls.Add(Me.RestartButton)
        Me.infoBox.Controls.Add(Me.EndGameButton)
        Me.infoBox.Controls.Add(Me.jokerbutton)
        Me.infoBox.Location = New System.Drawing.Point(213, 115)
        Me.infoBox.Name = "infoBox"
        Me.infoBox.Size = New System.Drawing.Size(175, 128)
        Me.infoBox.TabIndex = 0
        Me.infoBox.TabStop = False
        '
        'SizeInfoLabel
        '
        Me.SizeInfoLabel.AutoSize = True
        Me.SizeInfoLabel.Location = New System.Drawing.Point(6, 59)
        Me.SizeInfoLabel.Name = "SizeInfoLabel"
        Me.SizeInfoLabel.Size = New System.Drawing.Size(87, 13)
        Me.SizeInfoLabel.TabIndex = 12
        Me.SizeInfoLabel.Text = "Size of the board"
        '
        'HighScoreLabel
        '
        Me.HighScoreLabel.AutoSize = True
        Me.HighScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HighScoreLabel.ForeColor = System.Drawing.Color.DimGray
        Me.HighScoreLabel.Location = New System.Drawing.Point(84, 151)
        Me.HighScoreLabel.Name = "HighScoreLabel"
        Me.HighScoreLabel.Size = New System.Drawing.Size(24, 26)
        Me.HighScoreLabel.TabIndex = 11
        Me.HighScoreLabel.Text = "0"
        '
        'TitelHighScoreLabel
        '
        Me.TitelHighScoreLabel.AutoSize = True
        Me.TitelHighScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitelHighScoreLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TitelHighScoreLabel.Location = New System.Drawing.Point(85, 126)
        Me.TitelHighScoreLabel.Name = "TitelHighScoreLabel"
        Me.TitelHighScoreLabel.Size = New System.Drawing.Size(59, 24)
        Me.TitelHighScoreLabel.TabIndex = 10
        Me.TitelHighScoreLabel.Text = "BEST"
        '
        'ScoreLabel
        '
        Me.ScoreLabel.AutoSize = True
        Me.ScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScoreLabel.ForeColor = System.Drawing.Color.DimGray
        Me.ScoreLabel.Location = New System.Drawing.Point(2, 150)
        Me.ScoreLabel.Name = "ScoreLabel"
        Me.ScoreLabel.Size = New System.Drawing.Size(24, 26)
        Me.ScoreLabel.TabIndex = 9
        Me.ScoreLabel.Text = "0"
        '
        'LabelScore
        '
        Me.LabelScore.AutoSize = True
        Me.LabelScore.Location = New System.Drawing.Point(10, 200)
        Me.LabelScore.Name = "LabelScore"
        Me.LabelScore.Size = New System.Drawing.Size(0, 13)
        Me.LabelScore.TabIndex = 8
        '
        'TitelScoreLabel
        '
        Me.TitelScoreLabel.AutoSize = True
        Me.TitelScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitelScoreLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TitelScoreLabel.Location = New System.Drawing.Point(2, 126)
        Me.TitelScoreLabel.Name = "TitelScoreLabel"
        Me.TitelScoreLabel.Size = New System.Drawing.Size(76, 24)
        Me.TitelScoreLabel.TabIndex = 7
        Me.TitelScoreLabel.Text = "SCORE"
        '
        'DimensionBox
        '
        Me.DimensionBox.Location = New System.Drawing.Point(102, 56)
        Me.DimensionBox.Name = "DimensionBox"
        Me.DimensionBox.Size = New System.Drawing.Size(22, 20)
        Me.DimensionBox.TabIndex = 5
        Me.DimensionBox.Text = "4"
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(7, 20)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 0
        Me.StartButton.TabStop = False
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'RestartButton
        '
        Me.RestartButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.RestartButton.Location = New System.Drawing.Point(89, 91)
        Me.RestartButton.Name = "RestartButton"
        Me.RestartButton.Size = New System.Drawing.Size(75, 23)
        Me.RestartButton.TabIndex = 0
        Me.RestartButton.TabStop = False
        Me.RestartButton.Text = "Restart"
        Me.RestartButton.UseVisualStyleBackColor = True
        Me.RestartButton.UseWaitCursor = True
        '
        'EndGameButton
        '
        Me.EndGameButton.Location = New System.Drawing.Point(89, 20)
        Me.EndGameButton.Name = "EndGameButton"
        Me.EndGameButton.Size = New System.Drawing.Size(75, 23)
        Me.EndGameButton.TabIndex = 0
        Me.EndGameButton.TabStop = False
        Me.EndGameButton.Text = "End Game"
        Me.EndGameButton.UseVisualStyleBackColor = True
        '
        'jokerbutton
        '
        Me.jokerbutton.Enabled = False
        Me.jokerbutton.Location = New System.Drawing.Point(7, 91)
        Me.jokerbutton.Name = "jokerbutton"
        Me.jokerbutton.Size = New System.Drawing.Size(75, 23)
        Me.jokerbutton.TabIndex = 0
        Me.jokerbutton.TabStop = False
        Me.jokerbutton.Text = "Joker"
        Me.jokerbutton.UseVisualStyleBackColor = True
        '
        'TitelTimeLabel
        '
        Me.TitelTimeLabel.AutoSize = True
        Me.TitelTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitelTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TitelTimeLabel.Location = New System.Drawing.Point(2, 189)
        Me.TitelTimeLabel.Name = "TitelTimeLabel"
        Me.TitelTimeLabel.Size = New System.Drawing.Size(55, 24)
        Me.TitelTimeLabel.TabIndex = 13
        Me.TitelTimeLabel.Text = "TIME"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'TimeLabel2
        '
        Me.TimeLabel2.AutoSize = True
        Me.TimeLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.TimeLabel2.Location = New System.Drawing.Point(2, 213)
        Me.TimeLabel2.Name = "TimeLabel2"
        Me.TimeLabel2.Size = New System.Drawing.Size(24, 26)
        Me.TimeLabel2.TabIndex = 15
        Me.TimeLabel2.Text = "0"
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLabel.ForeColor = System.Drawing.Color.DimGray
        Me.TimeLabel.Location = New System.Drawing.Point(33, 213)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(24, 26)
        Me.TimeLabel.TabIndex = 16
        Me.TimeLabel.Text = "0"
        '
        'BestTimeLabel
        '
        Me.BestTimeLabel.AutoSize = True
        Me.BestTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BestTimeLabel.ForeColor = System.Drawing.Color.DimGray
        Me.BestTimeLabel.Location = New System.Drawing.Point(116, 213)
        Me.BestTimeLabel.Name = "BestTimeLabel"
        Me.BestTimeLabel.Size = New System.Drawing.Size(24, 26)
        Me.BestTimeLabel.TabIndex = 19
        Me.BestTimeLabel.Text = "0"
        '
        'BestTimeLabel2
        '
        Me.BestTimeLabel2.AutoSize = True
        Me.BestTimeLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BestTimeLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.BestTimeLabel2.Location = New System.Drawing.Point(84, 213)
        Me.BestTimeLabel2.Name = "BestTimeLabel2"
        Me.BestTimeLabel2.Size = New System.Drawing.Size(24, 26)
        Me.BestTimeLabel2.TabIndex = 18
        Me.BestTimeLabel2.Text = "0"
        '
        'TitelBestTimeLabel
        '
        Me.TitelBestTimeLabel.AutoSize = True
        Me.TitelBestTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitelBestTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TitelBestTimeLabel.Location = New System.Drawing.Point(85, 189)
        Me.TitelBestTimeLabel.Name = "TitelBestTimeLabel"
        Me.TitelBestTimeLabel.Size = New System.Drawing.Size(59, 24)
        Me.TitelBestTimeLabel.TabIndex = 17
        Me.TitelBestTimeLabel.Text = "BEST"
        '
        'scherm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.infoBox)
        Me.Name = "scherm"
        Me.Text = "2048"
        Me.infoBox.ResumeLayout(False)
        Me.infoBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents infoBox As System.Windows.Forms.GroupBox
    Friend WithEvents RestartButton As System.Windows.Forms.Button
    Friend WithEvents EndGameButton As System.Windows.Forms.Button
    Friend WithEvents jokerbutton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents DimensionBox As System.Windows.Forms.TextBox
    Friend WithEvents LabelScore As System.Windows.Forms.Label
    Friend WithEvents TitelScoreLabel As System.Windows.Forms.Label
    Friend WithEvents ScoreLabel As System.Windows.Forms.Label
    Friend WithEvents HighScoreLabel As System.Windows.Forms.Label
    Friend WithEvents TitelHighScoreLabel As System.Windows.Forms.Label
    Friend WithEvents SizeInfoLabel As System.Windows.Forms.Label
    Friend WithEvents TitelTimeLabel As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TimeLabel As System.Windows.Forms.Label
    Friend WithEvents TimeLabel2 As System.Windows.Forms.Label
    Friend WithEvents BestTimeLabel As System.Windows.Forms.Label
    Friend WithEvents BestTimeLabel2 As System.Windows.Forms.Label
    Friend WithEvents TitelBestTimeLabel As System.Windows.Forms.Label

End Class
