
Public Class scherm
    'Globale variabelen
    Dim Dimension As Integer = 4
    Dim Field(Dimension - 1, Dimension - 1) As Label
    Dim MaxScore As Integer = 2048
    Dim MergedValue As Integer
    Dim TotalMergedValue As Integer
    Dim WithEvents Joker As Button
    Dim JokerIsUsed As Boolean = False
    Dim ValidMove As Boolean = False
    Dim Background As Label
    Dim FieldIsSet As Boolean = False
    Dim First512Reached As Boolean = False


    'Method to set an empty board
    Private Sub createBoard()

        Dim xcoordinate As Integer = 40
        Dim ycoordinate As Integer = 40

        'The Background label is a square drawn behind the tiles, which makes it look like the tiles are placed on a board (like in the original game) 
        Background = New Label
        Background.Location = New Point(30, 30)
        Background.Size = New Size(10 + Dimension * 60, 10 + Dimension * 60)
        Background.SendToBack()
        Background.BackColor = Color.LightGray
        Me.Controls.Add(Background)

        'Row by row, tile by tile is created, the properties are set and the tile is added to the form
        For i As Integer = 0 To Dimension - 1
            For j As Integer = 0 To Dimension - 1
                Field(i, j) = New Label
                Field(i, j).Size = New Size(50, 50)
                Field(i, j).TextAlign = ContentAlignment.MiddleCenter
                Field(i, j).Font = New Font("Calibri", 24, FontStyle.Bold)
                Field(i, j).Name = "tile_" & i & "_" & j
                Field(i, j).Location = New Point(xcoordinate, ycoordinate)
                Field(i, j).BackColor = Color.White
                Field(i, j).Text = ""

                Me.Controls.Add(Field(i, j))
                'Labels are usually placed in the back, which is why the Background Label will be drawn
                'in front of the tiles. That's why we bring the tiles to the front with BringToFront.
                Field(i, j).BringToFront()
                'The width of the tiles is 50, so we raise the xcoordinate with 60 so there is a space
                'of 10 in between the tiles.
                xcoordinate += 60
            Next
            xcoordinate = 40
            'We also create this space of 10 in the vertical direction.
            ycoordinate += 60
        Next
        'We want the infobox to be next to the board, whatever the dimension and the window has to have
        'the right size. 
        infoBox.Location = New Point(75 + Dimension * 60, 25)
        infoBox.Size = New Size(175, 250)
        If Dimension <= 3 Then
            Me.Size = New Size(Dimension * 60 + 290, 290)
        Else
            Me.Size = New Size(Dimension * 60 + 300, Dimension * 60 + 110)
        End If
        FieldIsSet = True
        StartButton.Enabled = False
    End Sub

    'Method to make the board empty again
    Private Sub RemoveBoard()
        'This method gets called by the RestartButton, so we want the player to be able to choose another 
        'dimension for the game.
        DimensionBox.Enabled = True
        'In case he now chooses a smaller dimension than the one before, we have to remove the previous field.
        For Each Label As Label In Field
            Me.Controls.Remove(Label)
        Next
        Me.Controls.Remove(Background)
        FieldIsSet = False
    End Sub

    'Method to call after every move to keep the score up to date
    Private Sub UpdateScore()
        'Score is a variable in which we store the score the player had before he made the move.
        Dim Score As Integer
        'NewPoints is the score we have to add, for the merge he made.
        Dim NewPoints As Integer
        Score = CInt(ScoreLabel.Text)
        NewPoints = TotalMergedValue
        Score += NewPoints
        ScoreLabel.Text = CStr(Score)
        If HighScoreLabel.Text <> "" Then
            If CInt(HighScoreLabel.Text) < CInt(ScoreLabel.Text) Then
                HighScoreLabel.Text = ScoreLabel.Text
            End If
        Else
            MsgBox("nee")
            HighScoreLabel.Text = ScoreLabel.Text
        End If
        TotalMergedValue = 0
    End Sub

    Private Sub UpdateBestTime()
        BestTimeLabel2.Text = TimeLabel2.Text
        BestTimeLabel.Text = TimeLabel.Text
    End Sub

    'Method that lets the player know when 2048 is reached and stops the game
    Private Sub ReachedMaxScore()
        If MergedValue = MaxScore Then
            UpdateScore()
            MsgBox("Congratulations, you have reached " + CStr(MaxScore) + " and won!")
            Me.KeyPreview = False
        End If
        Timer1.Enabled = False
    End Sub

    'Method to add a new tile to the board
    Private Sub AddTile()
        Dim xcoordinate As Integer
        Dim ycoordinate As Integer
        Dim chance As Integer
        Randomize()
        'We choose a random xcoordinate and a random ycoordinate to have a random position in the Field. 
        xcoordinate = CInt(Math.Floor(Dimension * Rnd()))
        ycoordinate = CInt(Math.Floor(Dimension * Rnd()))
        'In case this Field is not empty anymore, a new position has to be chosen untill one is found. 
        While Field(xcoordinate, ycoordinate).BackColor <> Color.White
            xcoordinate = CInt(Math.Floor(Dimension * Rnd()))
            ycoordinate = CInt(Math.Floor(Dimension * Rnd()))
        End While
        chance = CInt(Math.Floor(10 * Rnd())) + 1
        'There's a 10% chance that the random function chooses 1. In that case the new tile has value 4.
        If chance = 1 Then
            Field(xcoordinate, ycoordinate).Text = "4"
            Field(xcoordinate, ycoordinate).BackColor = TileColor("4")
            'If the 90% chance gets real, a 2 is put in the added tile.
        Else
            Field(xcoordinate, ycoordinate).Text = "2"
            Field(xcoordinate, ycoordinate).BackColor = TileColor("2")
        End If
        'If this method is called because a move has been made, the boolean ValidMove has been set to true
        'by the merge or swipe that has been made. Because this boolean is a condition for a new tile to be
        'added and there's not supposed to appear a new tile until a new merge or swipe has happened, it has
        'to be set to False again.
        ValidMove = False
        'There are a lot of fond and layout properties that come along with every value, so DecideLayOut
        'makes sure that every tile has a certain layout depending on its value.
        DecideLayOut(xcoordinate, ycoordinate)
        'When the first tile is added, the player can use the joker button to remove a tile.
        If ScoreLabel.Text = 0 Then
            jokerbutton.Enabled = True
        End If
        'After a new tile has been added, we have to check if this add has made it impossible to make
        'another move. 
        GameOver()
        Field(xcoordinate, ycoordinate).Focus()
    End Sub

    'Method that lets the player know that he has no options left and the game is over
    Private Sub GameOver()
        Dim FinalScore As String
        If EmptyTiles() = False And NoMoreOptions() = True Then
            FinalScore = ScoreLabel.Text
            MsgBox("Game Over. Je score is " + FinalScore + "!", MsgBoxStyle.DefaultButton1, "2048")
            'When the game is over, the player is not supposed to use his joker anymore
            jokerbutton.Enabled = False
        End If
        Timer1.Enabled = False
    End Sub

    'Method that associates the right color with the right value
    Private Function TileColor(ByVal value As String) As Color
        Select Case value
            Case ""
            Case "2"
                Return Color.FromArgb(238, 228, 218)
            Case "4"
                Return Color.FromArgb(237, 224, 200)
            Case "8"
                Return Color.FromArgb(242, 177, 121)
            Case "16"
                Return Color.FromArgb(245, 149, 99)
            Case "32"
                Return Color.FromArgb(246, 124, 95)
            Case "64"
                Return Color.FromArgb(246, 94, 59)
            Case "128"
                Return Color.FromArgb(237, 207, 114)
            Case "256"
                Return Color.FromArgb(237, 204, 97)
            Case "512"
                Return Color.FromArgb(237, 200, 80)
            Case "1024"
                Return Color.FromArgb(237, 197, 63)
            Case "2048"
                Return Color.FromArgb(237, 194, 46)
        End Select
    End Function

    'Method that changes the ForeColor and size of the number for every number.
    Private Sub DecideLayOut(row As Integer, column As Integer)
        Dim value As Integer
        If Field(row, column).Text <> "" Then
            'Numbers starting from eight have to be white.
            value = CInt(Field(row, column).Text)
            If value > 4 Then
                Field(row, column).ForeColor = Color.White
            Else
                Field(row, column).ForeColor = Color.Black
            End If
            'The size of the font depends on the number of characters in the tile.
            If value > 512 Then
                Field(row, column).Font = New Font("Calibri", 14, FontStyle.Bold)
            ElseIf value > 64 Then
                Field(row, column).Font = New Font("Calibri", 18, FontStyle.Bold)
            Else
                Field(row, column).Font = New Font("Calibri", 24, FontStyle.Bold)
            End If
        End If
    End Sub


    'Method to move all tiles as much up as possible
    Private Sub MoveUp()
        'Column by column, we move all the tiles as much up as possible.
        For j As Integer = 0 To Dimension - 1
            'Variable i_high will be the highest empty tile in the Field.
            Dim i_high As Integer = 0
            'Variable i_low will be the highest non empty tile in the Field, down of i_high.
            Dim i_low As Integer = 1
            'As long as i_low has not reached the lowest tile in the Field, i_high and i_low have to
            'be raised with 1 after every move.
            While i_low <= Dimension - 1
                'We look for the first empty value in the column.
                If Field(i_high, j).Text = "" Then
                    'We look for the first non empty value after i_high in the column. We can not do this
                    'anymore when i_low is the last tile in the column, because if we then raise it's value
                    'the position will not be in the Field anymore.
                    While i_low <= Dimension - 2 And Field(i_low, j).Text = ""
                        i_low += 1
                    End While
                    'When we found a value for i_low, the while loop is ended and we can swipe the two values
                    'we have found.
                    Swipe(i_high, j, i_low, j)
                End If
                i_low += 1
                i_high += 1
            End While
        Next
    End Sub

    'Method to move all tiles as much down as possible
    Private Sub MoveDown()
        For j As Integer = 0 To Dimension - 1
            Dim i_low As Integer = Dimension - 1
            Dim i_high As Integer = Dimension - 2
            While i_high >= 0
                If Field(i_low, j).Text = "" Then
                    While i_high >= 1 And Field(i_high, j).Text = ""
                        i_high -= 1
                    End While
                    Swipe(i_low, j, i_high, j)
                End If
                i_high -= 1
                i_low -= 1
            End While
        Next
    End Sub

    'Method to vertically merge all tiles with the same value that are up and down of each other
    Private Sub MergeVertically()
        'Column by column, we check in every row if there are values to be merged
        For j As Integer = 0 To Dimension - 1
            'For every tile in the row but the last, we check if the tile is equal to the next tile in the
            'column. For the last tile, it will be checked if he needs to be merged when we handle the one 
            'but last.
            For i As Integer = 0 To Dimension - 2
                'If two tiles are equal to each other and they are not empty, we merge them.
                If Field(i + 1, j).BackColor = Field(i, j).BackColor And Field(i, j).BackColor <> Color.White Then
                    Merge(i, j, i + 1, j)
                End If
            Next
        Next
    End Sub

    'Method to move all tiles as much left as possible
    Private Sub MoveLeft()
        For i As Integer = 0 To Dimension - 1
            Dim j_left As Integer = 0
            Dim j_right As Integer = 1
            While j_right <= Dimension - 1
                If Field(i, j_left).Text = "" Then
                    While j_right <= Dimension - 2 And Field(i, j_right).Text = ""
                        j_right += 1
                    End While
                    Swipe(i, j_left, i, j_right)
                End If
                j_right += 1
                j_left += 1
            End While
        Next
    End Sub

    'Method to move all tiles as much right as possible
    Private Sub MoveRight()
        For i As Integer = 0 To Dimension - 1
            Dim j_right As Integer = Dimension - 1
            Dim j_left As Integer = Dimension - 2
            While j_left >= 0
                If Field(i, j_right).Text = "" Then
                    While j_left >= 1 And Field(i, j_left).Text = ""
                        j_left -= 1
                    End While
                    Swipe(i, j_right, i, j_left)
                End If
                j_left -= 1
                j_right -= 1
            End While
        Next
    End Sub

    'Method to horizontally merge all tiles with the same value that are left and right of each other
    Private Sub MergeHorizontally()
        For i As Integer = 0 To Dimension - 1
            For j As Integer = 0 To Dimension - 2
                If Field(i, j + 1).BackColor = Field(i, j).BackColor And Field(i, j).BackColor <> Color.White Then
                    Merge(i, j, i, j + 1)
                End If
            Next
        Next
    End Sub

    
    'Method that swipes two tiles in the move methods (tile 1 is the empty tile).
    Private Sub Swipe(row_1 As Integer, column_1 As Integer, row_2 As Integer, column_2 As Integer)
        'The tile at position 1 is initially empty and the tile at position 2 has a value (sometimes it will
        'be empty, in which case this method does not matter). Tile 1 therefor gets the same text, color
        'and layout as tile 2 initially had.
        Field(row_1, column_1).Text = Field(row_2, column_2).Text
        Field(row_1, column_1).BackColor = Field(row_2, column_2).BackColor
        DecideLayOut(row_1, column_1)
        'Tile 2 now can be made empty and get the layout of an empty tile.
        Field(row_2, column_2).Text = ""
        Field(row_2, column_2).BackColor = Color.White
        DecideLayOut(row_2, column_2)
        'If tile 2 initially had a value, tile 1 now has this value and the move was succesfull. This means
        'that a new tile should be added after this move. In order to do that, we have to set the boolean
        'that is the condition for the addtile method to true.
        If Field(row_1, column_1).Text <> "" Then
            ValidMove = True
        End If
    End Sub

    'Method that merges to tiles with the same value, by making one empty and replacing the other by the double value
    Private Sub Merge(row_1 As Integer, column_1 As Integer, row_2 As Integer, column_2 As Integer)
        'OldValue contains the value of tile 1 and 2, NewValue will be used to store twice their value
        Dim OldValue As Integer
        Dim NewValue As Integer
        'We empty one of the tiles (which one doesn't matter, because after this move we have to do the
        'move method again, whatever direction the tiles have to be moved into)
        Field(row_2, column_2).Text = ""
        Field(row_2, column_2).BackColor = Color.White
        DecideLayOut(row_2, column_2)
        'We calculate the NewValue and put this in the other tile 
        OldValue = CInt(Field(row_1, column_1).Text)
        NewValue = OldValue * 2
        Field(row_1, column_1).BackColor = TileColor(CStr(NewValue))
        Field(row_1, column_1).Text = CStr(NewValue)
        DecideLayOut(row_1, column_1)
        'We still need this NewValue to update the score and to check whether or not 2048 has been reached
        'yet. We need to variables for this, because the score has to be update with the total value that
        'has been merged in every move. If there are two pairs of equal values, this will ofcourse be more
        'than the single values. For every single merged value though, we have to check if this equals 2048
        'because in that case the game is over. 
        MergedValue = NewValue
        TotalMergedValue += NewValue
        ReachedMaxScore()
        ValidMove = True
        If MergedValue = 32 And First512Reached = False Then
            Reached512()
        End If
    End Sub

    Private Sub Reached512()
        For i As Integer = 0 To Dimension - 1
            For j As Integer = 0 To Dimension - 1
                If Field(i, j).Text <> "" Then
                    If CInt(Field(i, j).Text) = 2 Then
                        Field(i, j).BackColor = Color.Red
                    End If
                End If
            Next
        Next
        Application.DoEvents()
        System.Threading.Thread.Sleep(2000)
        RestoreAfterReached512()
    End Sub

    Private Sub RestoreAfterReached512()
            For i As Integer = 0 To Dimension - 1
                For j As Integer = 0 To Dimension - 1
                    If Field(i, j).Text <> "" Then
                        If CInt(Field(i, j).Text) = 2 Then
                            DecideLayOut(i, j)
                            Field(i, j).BackColor = TileColor(2)
                        End If
                    End If
                Next
            Next
        First512Reached = True
    End Sub

    'Given Methods to make the keyboard arrows work
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If FieldIsSet Then
            Me.KeyPreview = True

        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp

        Select Case e.KeyCode
            Case Keys.Right
                'First we have to move, to make sure that tiles with equal value are next to each other
                MoveRight()
                'Then we move horizontally
                MergeHorizontally()
                'Now there is an empty space where one of the equal tiles used to be. Because there might
                'still be tiles that are further away from the direction we were moving into, there might
                'be a gap after the merge. To solve this, we have to move again.
                MoveRight()
                'If a merge has been made, the score needs to be updated. If there was no merge, the 
                'MergeValue still is 0 and nothing changes.
                UpdateScore()
                'If there still are empty tiles left and a move or merge has been made (which has made
                'the move valid), a new tile has to be added before the player can make his next move.
                If EmptyTiles() = True And ValidMove = True Then
                    AddTile()
                End If

            Case Keys.Left
                MoveLeft()
                MergeHorizontally()
                MoveLeft()
                UpdateScore()
                If EmptyTiles() = True And ValidMove = True Then
                    AddTile()
                End If

            Case Keys.Up
                MoveUp()
                MergeVertically()
                MoveUp()
                UpdateScore()
                If EmptyTiles() = True And ValidMove = True Then
                    AddTile()
                End If

            Case Keys.Down
                MoveDown()
                MergeVertically()
                MoveDown()
                UpdateScore()
                If EmptyTiles() = True And ValidMove = True Then
                    AddTile()
                End If

        End Select
    End Sub


    'Boolean that is true when no tile can be merged in any direction
    Private Function NoMoreOptions() As Boolean
        'We check for every row if there is a tile that is equal to a tile left or right of it. If this 
        'is the case, the player can still make a merge. That means the game is not over yet. Therefor this
        'condition for the GameOver method needs to be false when the game is over.
        For i As Integer = 0 To Dimension - 1
            For j As Integer = 0 To Dimension - 2
                If EmptyTiles() = False Then
                    If Field(i, j).Text = Field(i, j + 1).Text Then
                        Return False
                    End If
                End If
            Next
        Next
        'We also have to check for every column if there is a tile that is equal to the tile up or down of it.
        For j As Integer = 0 To Dimension - 1
            For i As Integer = 0 To Dimension - 2
                If EmptyTiles() = False Then
                    If Field(i, j).Text = Field(i + 1, j).Text Then
                        Return False
                    End If
                End If
            Next
        Next
        Return True
    End Function

    'Boolean that is true when there are no empty tiles left
    Private Function EmptyTiles() As Boolean
        For i As Integer = 0 To Dimension - 1
            For j As Integer = 0 To Dimension - 1
                'We simply check for every tile in the Field if it's empty. If an empty tile can be found,
                'a new tile can still be added to the Field.
                If Field(i, j).Text = "" Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function


    'StartButton
    Private Sub start_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        'If the player has not the changed the default value 4, a 4x4 Field needs to be created. The 
        'DimensionBox needs to be disabled, so the the player can't change this anymore while playing.
        'Two tiles are added to the Field before the first move can be made.
        If String.Compare(DimensionBox.Text, "4") = 0 Then
            Dimension = 4
            Dim Field2(3, 3) As Label
            Field = Field2
            createBoard()
            DimensionBox.Enabled = False
            AddTile()
            AddTile()
        Else
            If Not IsNumeric(DimensionBox.Text) Then
                MsgBox("Please insert an integer value.")
            ElseIf CInt(DimensionBox.Text) < 4 And CInt(DimensionBox.Text) > -1 Then
                MsgBox("Please insert a value greater than 3. Otherwise it is impossible to reach 2048.")
            ElseIf CInt(DimensionBox.Text) < 0 Then
                MsgBox("It is impossible to make a roster with a negative size.")
            ElseIf CInt(DimensionBox.Text) > 10 Then
                MsgBox("Please insert a value smaller than 10.")
                'Only if a value between 4 and 10 is inserted, the game can be started. The board is created
                'for the inserted Dimension, the Dimension can not be changed by the player anymore and two
                'tiles are added to the empty Field. 
            Else
                Dim New_Dimension As Integer = Convert.ToInt32(DimensionBox.Text)
                Dim rooster2(New_Dimension - 1, New_Dimension - 1) As Label
                Field = rooster2
                Dimension = New_Dimension
                createBoard()
                DimensionBox.Enabled = False
                AddTile()
                AddTile()
            End If
        End If
        'When the board is created, the player can use the arrows to make a move.
        Me.KeyPreview = True
        Timer1.Enabled = True

    End Sub

    'RestartButton
    Private Sub nieuwSpelButton_Click(sender As Object, e As EventArgs) Handles RestartButton.Click
        'Every tile of the Field is removed
        RemoveBoard()
        'The score is reset to 0
        ScoreLabel.Text = "0"
        'The joker can be used again if the player starts a new game
        JokerIsUsed = False
        'The player can click on the jokerbutton again
        jokerbutton.Enabled = True
        'The infobox and formsize get changed to their initial values
        Me.Size = New Size(600, 400)
        infoBox.Location = New Point(200, 80)
        'The player can click on start to start a new game
        StartButton.Enabled = True
        'The key arrows can not be used until a new game has been started
        Me.KeyPreview = False
        Timer1.Enabled = False
        TimeLabel.Text = 0
        TimeLabel2.Text = 0
    End Sub

    'EndgameButton
    Private Sub EndGameButton_Click(sender As Object, e As EventArgs) Handles EndGameButton.Click
        Me.Close()
    End Sub

    'JokerButton
    Private Sub jokerbutton_Click(sender As Object, e As EventArgs) Handles jokerbutton.Click
        For i As Integer = 0 To Dimension - 1
            For j As Integer = 0 To Dimension - 1
                'When the player clicked the jokerbutton, every tile is clickable. When one of the tiles 
                'is clicked, the onLabelClick Method is called, which will make the tile on which the player
                'clicked empty again.
                AddHandler Field(i, j).Click, AddressOf onLabelClick
            Next
        Next
    End Sub

    'This needs to happen when the joker has been enabled and the player clicked on a tile
    Private Sub onLabelClick(ByVal sender As Label, ByVal e As EventArgs) 'sender bevat aangeklikte Label ...
        If sender.BackColor <> Color.White And Not JokerIsUsed Then
            sender.Text = ""
            sender.BackColor = Color.White
            'The jokerbutton can only be used once, so the button gets disabled again and the condition
            'for the making empty of a tile is set to False.
            jokerbutton.Enabled = False
            JokerIsUsed = True
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimeLabel.Text = Val(TimeLabel.Text) + 1
        If TimeLabel.Text = 60 Then
            TimeLabel.Text = 0
            TimeLabel2.Text += 1
            If TimeLabel2.Text = 60 Then
                MsgBox("Your time is up.")
                Me.KeyPreview = False
            End If
        End If
        If TimeLabel2.Text * 60 + TimeLabel.Text > BestTimeLabel2.Text * 60 + BestTimeLabel.Text Then
            UpdateBestTime()
        End If
    End Sub
End Class
