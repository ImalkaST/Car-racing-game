Public Class Form1
    Dim speed As Integer
    Dim road(7) As PictureBox
    Dim score As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        speed = 3
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For x As Integer = 0 To 7
            road(x).Top += 2
            If road(x).Top >= Me.Height Then
                road(x).Top = -road(x).Height

            End If
        Next
        If score > 10 And score < 20 Then
            speed = 5
        End If
        If score > 20 And score < 30 Then
            speed = 6
        End If
        If score > 30 And score < 40 Then
            speed = 7
        End If
        Speed_Text.Text = "speed" & speed
        If (Car.Bounds.IntersectsWith(EnemyCar1.Bounds)) Then
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar2.Bounds)) Then
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar3.Bounds)) Then
            gameOver()
        End If
    End Sub
    Private Sub gameOver()
        Button1.Visible = True
        End_Text.Visible = True

        Timer1.Stop()
        enemover1.Stop()
        enemover2.Stop()
        enemover3.Stop()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            right_mover.Start()
        End If
        If e.KeyCode = Keys.Left Then
            left_mover.Start()
        End If
    End Sub

    Private Sub left_mover_Tick(sender As Object, e As EventArgs) Handles left_mover.Tick
        If (Car.Location.X > 0) Then
            Car.Left -= 5
        End If

    End Sub

    Private Sub right_mover_Tick(sender As Object, e As EventArgs) Handles right_mover.Tick
        If (Car.Location.X < 179) Then
            Car.Left += 5
        End If

    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        right_mover.Stop()
        left_mover.Stop()
    End Sub

    Private Sub EnemyCar2_Click(sender As Object, e As EventArgs) Handles EnemyCar2.Click

    End Sub

    Private Sub enemover1_Tick(sender As Object, e As EventArgs) Handles enemover1.Tick
        EnemyCar1.Top += speed / 2
        If EnemyCar1.Top >= Me.Height Then
            score += 1
            Score_text.Text = "Score " & score

            EnemyCar1.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar1.Height)
            EnemyCar1.Left = CInt(Math.Ceiling(Rnd() * 40)) + 0
        End If

    End Sub

    Private Sub enemover2_Tick(sender As Object, e As EventArgs) Handles enemover2.Tick
        EnemyCar2.Top += speed * 3 / 2
        If EnemyCar2.Top >= Me.Height Then
            score += 1
            Score_text.Text = "Score " & score

            EnemyCar2.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar2.Height)
            EnemyCar2.Left = CInt(Math.Ceiling(Rnd() * 50)) + 70

        End If
    End Sub

    Private Sub enemover3_Tick(sender As Object, e As EventArgs) Handles enemover3.Tick
        EnemyCar3.Top += 2.5
        If EnemyCar3.Top >= Me.Height Then
            score += 1
            Score_text.Text = "Score " & score

            EnemyCar3.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar3.Height)
            EnemyCar3.Left = CInt(Math.Ceiling(Rnd() * 90)) + 100
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        score = 0
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
    End Sub
End Class
