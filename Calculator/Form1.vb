Imports System.Runtime.CompilerServices

Public Class Form1
    'Fields
    Dim result As Double = 0
    Dim operation As String = String.Empty
    Dim fstNum, secNum As String
    Dim enterValue As Boolean = False

    'Track the mouse movement for dragging the form
    Dim drag As Boolean = False
    Dim mouseX As Integer
    Dim mouseY As Integer

    'Track resizing
    Dim resizing As Boolean
    Dim resizeDir As String = ""

    Function CheckForText(display As String) As AsyncVoidMethodBuilder
        If display.Equals("There's no history yet.") Then
            RTBoxDisplayHistory.Clear()
            RTBoxDisplayHistory.AppendText($"{fstNum} {secNum} = {TxtDisplay1.Text} {Environment.NewLine}")
        Else
            RTBoxDisplayHistory.AppendText($"{fstNum} {secNum} = {TxtDisplay1.Text} {Environment.NewLine}")
        End If
    End Function

    Private Sub BtnMathOperation_Click(sender As Object, e As EventArgs) Handles TxtDisplay1.Click, BtnMultiply.Click, BtnMinus.Click, BtnDivide.Click, BtnAdd.Click
        BtnEquals.PerformClick()
        If TypeOf sender Is Button Then
            Dim btn As Button = CType(sender, Button)
            operation = btn.Text
            enterValue = True


            fstNum = $"{result} {operation}"
            TxtDisplay2.Text = fstNum
            TxtDisplay1.Text = "0"
        End If
    End Sub

    Private Sub BtnEquals_Click(sender As Object, e As EventArgs) Handles BtnEquals.Click
        secNum = TxtDisplay1.Text
        TxtDisplay2.Text = $"{TxtDisplay2.Text} {TxtDisplay1.Text} ="

        If Not TxtDisplay1.Text.Equals(String.Empty) Then
            If TxtDisplay1.Text.Equals("0") Then
                TxtDisplay2.Text = String.Empty
            End If

            Select Case operation
                Case "+"
                    TxtDisplay1.Text = (result + Double.Parse(TxtDisplay1.Text)).ToString()
                    CheckForText(RTBoxDisplayHistory.Text)
                Case "-"
                    TxtDisplay1.Text = (result - Double.Parse(TxtDisplay1.Text)).ToString()
                    CheckForText(RTBoxDisplayHistory.Text)
                Case "×"
                    TxtDisplay1.Text = (result * Double.Parse(TxtDisplay1.Text)).ToString()
                    CheckForText(RTBoxDisplayHistory.Text)
                Case "÷"
                    TxtDisplay1.Text = (result / Double.Parse(TxtDisplay1.Text)).ToString()
                    CheckForText(RTBoxDisplayHistory.Text)
                Case Else
                    TxtDisplay2.Text = $"{TxtDisplay1.Text} = "
            End Select

            result = Double.Parse(TxtDisplay1.Text)
            operation = String.Empty
        End If
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles BtnHistory.Click
        If PnlHistory.Height.Equals(5) Then
            PnlHistory.Height = 345
        Else
            PnlHistory.Height = 5
        End If
    End Sub

    Private Sub BtnClearHistory_Click(sender As Object, e As EventArgs) Handles BtnClearHistory.Click
        RTBoxDisplayHistory.Clear()

        If RTBoxDisplayHistory.Text.Equals(String.Empty) Then
            RTBoxDisplayHistory.Text = "There's no history yet."
        End If
    End Sub

    Private Sub BtnBackSpace_Click(sender As Object, e As EventArgs) Handles BtnBackSpace.Click
        If TxtDisplay1.Text.Length > 0 AndAlso Not Double.Parse(TxtDisplay1.Text).Equals(0) Then
            TxtDisplay1.Text = TxtDisplay1.Text.Substring(0, TxtDisplay1.Text.Length - 1)
        End If

        If TxtDisplay1.Text.Equals(String.Empty) Then
            TxtDisplay1.Text = "0"
        End If
    End Sub

    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        TxtDisplay1.Text = "0"
        TxtDisplay2.Text = String.Empty
        result = 0
    End Sub

    Private Sub BtnCE_Click(sender As Object, e As EventArgs) Handles BtnCE.Click
        TxtDisplay1.Text = "0"
    End Sub

    Private Sub BtnOperations_Click(sender As Object, e As EventArgs) Handles BtnX2.Click, BtnSquare.Click, BtnPM.Click, BtnPercent.Click, Btn1x.Click
        Dim btn As Button = CType(sender, Button)
        operation = btn.Text

        Select Case operation
            Case "√x"
                TxtDisplay2.Text = $"√({TxtDisplay1.Text})"
                TxtDisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(TxtDisplay1.Text)))
            Case "^2"
                TxtDisplay2.Text = $"({TxtDisplay1.Text})^2"
                TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text) * Convert.ToDouble(TxtDisplay1.Text))
            Case "¹/x"
                TxtDisplay2.Text = $"¹/({TxtDisplay1.Text})"
                TxtDisplay1.Text = Convert.ToString(1.0 / Convert.ToDouble(TxtDisplay1.Text))
            Case "%"
                TxtDisplay2.Text = $"{TxtDisplay1.Text}%"
                TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text) / 100)
            Case "±"
                TxtDisplay1.Text = Convert.ToString(-1 * Convert.ToDouble(TxtDisplay1.Text))
        End Select

        RTBoxDisplayHistory.AppendText($"{TxtDisplay2.Text} = {TxtDisplay1.Text} {Environment.NewLine}")
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Application.Exit()
    End Sub

    Private Sub BtnMinimize_Click(sender As Object, e As EventArgs) Handles BtnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtnMaximize_Click(sender As Object, e As EventArgs) Handles BtnMaximize.Click
        If Me.WindowState.Equals(FormWindowState.Normal) Then
            MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
            WindowState = FormWindowState.Maximized
            Me.WindowState = FormWindowState.Maximized
        ElseIf Me.WindowState.Equals(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub BtnNum_Click(sender As Object, e As EventArgs) Handles BtnDecimal.Click, Btn9.Click, Btn8.Click, Btn7.Click, Btn6.Click, Btn5.Click, Btn4.Click, Btn3.Click, Btn2.Click, Btn1.Click, Btn0.Click
        If (TxtDisplay1.Text.Equals("0") Or enterValue) Then
            TxtDisplay1.Text = String.Empty
        End If

        enterValue = False
        Dim btn As Button = CType(sender, Button)

        If btn.Text.Equals(".") Then
            If Not TxtDisplay1.Text.Contains(".") Then
                TxtDisplay1.Text = TxtDisplay1.Text + btn.Text
            End If
        Else
            TxtDisplay1.Text = TxtDisplay1.Text + btn.Text
        End If
    End Sub

    Private Sub PnlTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles PnlTitle.MouseDown
        drag = True ' Start dragging
        mouseX = Cursor.Position.X - Me.Left ' Capture the difference between the mouse position and the form's left position
        mouseY = Cursor.Position.Y - Me.Top ' Capture the difference between the mouse position and the form's top position
    End Sub

    Private Sub PnlTitle_MouseMove(sender As Object, e As MouseEventArgs) Handles PnlTitle.MouseMove
        If drag Then ' If dragging is enabled
            Me.Left = Cursor.Position.X - mouseX ' Set the form's left position based on the difference captured during mouse down event
            Me.Top = Cursor.Position.Y - mouseY ' Set the form's top position based on the difference captured during mouse down event
        End If
    End Sub

    Private Sub PnlTitle_MouseUp(sender As Object, e As MouseEventArgs) Handles PnlTitle.MouseUp
        drag = False ' Stop dragging
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            ' Check if the mouse is near the form's edges for resizing
            If e.X < 5 Then
                resizing = True
                resizeDir = "L" ' Left edge
            ElseIf e.X > Me.Width - 5 Then
                resizing = True
                resizeDir = "R" ' Right edge
            ElseIf e.Y < 5 Then
                resizing = True
                resizeDir = "T" ' Top edge
            ElseIf e.Y > Me.Height - 5 Then
                resizing = True
                resizeDir = "B" ' Bottom edge
            End If
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If resizing Then
            Select Case resizeDir
                Case "L"
                    Me.Width = Me.Right - e.X
                    Me.Left = e.X
                Case "R"
                    Me.Width = e.X
                Case "T"
                    Me.Height = Me.Bottom - e.Y
                    Me.Top = e.Y
                Case "B"
                    Me.Height = e.Y
            End Select
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        resizing = False
        resizeDir = ""
    End Sub
End Class