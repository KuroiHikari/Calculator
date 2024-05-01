Public Class Form1
    'Fields
    Dim result As Double = 0
    Dim operation As String = String.Empty
    Dim fstNum, secNum As String
    Dim enterValue As Boolean = False

    Private Sub BtnMathOperation_Click(sender As Object, e As EventArgs) Handles TxtDisplay1.Click, BtnMultiply.Click, BtnMinus.Click, BtnDivide.Click, BtnAdd.Click
        If Not result.Equals(0) Then
            BtnEquals.PerformClick()
        Else
            result = Double.Parse(TxtDisplay1.Text)
        End If

        Dim btn As Button = CType(sender, Button)
        operation = btn.Text
        enterValue = True

        If Not TxtDisplay1.Text.Equals("0") Then
            fstNum = $"{result} {operation}"
            TxtDisplay2.Text = fstNum
            TxtDisplay1.Text = String.Empty
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
                    RTBoxDisplayHistory.AppendText($"{fstNum} {secNum} = {TxtDisplay1.Text} {Environment.NewLine}")
                Case "-"
                    TxtDisplay1.Text = (result - Double.Parse(TxtDisplay1.Text)).ToString()
                    RTBoxDisplayHistory.AppendText($"{fstNum} {secNum} = {TxtDisplay1.Text} {Environment.NewLine}")
                Case "×"
                    TxtDisplay1.Text = (result * Double.Parse(TxtDisplay1.Text)).ToString()
                    RTBoxDisplayHistory.AppendText($"{fstNum} {secNum} = {TxtDisplay1.Text} {Environment.NewLine}")
                Case "÷"
                    TxtDisplay1.Text = (result / Double.Parse(TxtDisplay1.Text)).ToString()
                    RTBoxDisplayHistory.AppendText($"{fstNum} {secNum} = {TxtDisplay1.Text} {Environment.NewLine}")
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
            TxtDisplay1.Text = "0"
            'TxtDisplay1.Text.Remove(Double.Parse(TxtDisplay1.Text) - 1, 1)'
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
                TxtDisplay2.Text = $"%({TxtDisplay1.Text})"
                TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text) / 100)
            Case "±"
                TxtDisplay1.Text = Convert.ToString(-1 * Convert.ToDouble(TxtDisplay1.Text))
        End Select

        RTBoxDisplayHistory.AppendText($"{TxtDisplay2.Text} = {TxtDisplay1.Text} {Environment.NewLine}")
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Application.Exit()
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
End Class
