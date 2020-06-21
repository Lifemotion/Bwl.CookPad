Imports Bwl.TextBoxEx

Public Class IngredientsParser
    Private ReadOnly _tb As TextBoxEx.TextBoxEx
    Private WithEvents _timer As New Timer With {.Interval = 1000, .Enabled = True}

    Private _attrPrice As New TextAttribute With {.ForeColor = Color.DarkRed}
    Private _attrName As New TextAttribute With {.ForeColor = Color.Blue}
    Private _attrEnergy As New TextAttribute With {.ForeColor = Color.DarkGreen}
    Public ReadOnly Property Items As New List(Of IngredientInfo)
    Public Sub New(tb As TextBoxEx.TextBoxEx)
        Me._tb = tb
    End Sub
    Public Sub ParseAll()
        Dim newList As New List(Of IngredientInfo)
        Dim linesChanged As Boolean
        For Each line In _tb.Lines
            Dim attrs(line.Text.Length - 1) As TextAttribute
            Dim tokens = Token.Tokenize(line.Text)
            If tokens.Count > 0 Then
                Dim nameToken = tokens(0)
                Dim price As Single = -1
                Dim energy As Single = -1
                For Each token In tokens
                    Dim parts = token.Str.Trim.Split({" "}, StringSplitOptions.None)
                    If parts.Length = 2 AndAlso IsNumeric(parts(0).Trim) Then
                        If parts(1).Trim.ToLower = "ккал" Then
                            energy = Val(parts(0))
                            token.ApplyAttribute(attrs, _attrEnergy)
                        End If
                        If parts(1).Trim.ToLower = "руб" Then
                            price = Val(parts(0))
                            token.ApplyAttribute(attrs, _attrPrice)
                        End If
                    End If
                    If parts.Length = 4 AndAlso IsNumeric(parts(0).Trim) AndAlso IsNumeric(parts(2)) Then
                        If parts(1).Trim.ToLower = "руб" And parts(3).StartsWith("г") Then
                            price = Val(parts(0)) / Val(parts(2)) * 100.0
                            line.OverlayText = Space(line.Text.Length + 1) + "(" + price.ToString("0") + " руб\100г)"
                            token.ApplyAttribute(attrs, _attrPrice)
                        End If
                    End If
                Next
                If price >= 0 Or energy >= 0 Then
                    nameToken.ApplyAttribute(attrs, _attrName)
                    Dim comp As New IngredientInfo(nameToken.Str, energy, price)
                    newList.Add(comp)
                End If
            End If
            line.SetAttributes(attrs)
            linesChanged = True
        Next
        _Items = newList
        If linesChanged Then
            _tb.RedrawAll()
        End If
    End Sub
    Private Sub _timer_Tick(sender As Object, e As EventArgs) Handles _timer.Tick
        ParseAll()
    End Sub
End Class

Public Class IngredientInfo
    Protected _energyPer100g As Single
    Protected _pricePer100g As Single

    Public Sub New(name As String, energyPer100g As Single, pricePer100g As Single)
        _Name = name
        _energyPer100g = energyPer100g
        _pricePer100g = pricePer100g
    End Sub
    Public ReadOnly Property Name As String
    Public ReadOnly Property EnergyPer100g As Single
        Get
            Return _energyPer100g
        End Get
    End Property
    Public ReadOnly Property PricePer100g As Single
        Get
            Return _pricePer100g
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return Name + " " + EnergyPer100g.ToString("0") + " ккал " + PricePer100g.ToString("0") + " руб"
    End Function
End Class