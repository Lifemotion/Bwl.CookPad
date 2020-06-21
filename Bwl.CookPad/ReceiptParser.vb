Imports Bwl.TextBoxEx

Public Class ReceiptParser
    Private _tb As TextBoxEx.TextBoxEx
    Private _ingredientsParser As IngredientsParser
    Private WithEvents _timer As New Timer With {.Interval = 1000, .Enabled = True}

    Private _attrCaption As New TextAttribute With {.ForeColor = Color.DarkRed}
    Private _attrPart As New TextAttribute With {.ForeColor = Color.DarkGreen}
    Private _attrName As New TextAttribute With {.ForeColor = Color.Blue}
    Private _attrMass As New TextAttribute With {.ForeColor = Color.Purple}
    Private _attrImportant As New TextAttribute With {.ForeColor = Color.Red}
    Public Sub New(tb As TextBoxEx.TextBoxEx, ingredientsParser As IngredientsParser)
        _tb = tb
        _ingredientsParser = ingredientsParser
    End Sub
    Public Sub ParseAll()
        Dim linesChanged As Boolean

        Dim ingredientsLibrary = _ingredientsParser.Items.ToArray()

        Dim meal As New List(Of MealPart)
        Dim mealPart As MealPart = Nothing

        For Each line In _tb.Lines
            Dim attrs(line.Text.Length - 1) As TextAttribute
            Dim tokens = Token.Tokenize(line.Text)
            If tokens.Count > 0 Then
                If tokens(0).Str.StartsWith("*") Then
                    If tokens(0).Str.Length > 1 Then
                        mealPart = New MealPart(line.Text.Substring(1))
                        tokens(0).ApplyAttribute(attrs, _attrPart)
                    Else
                        If mealPart IsNot Nothing Then
                            meal.Add(mealPart)
                            mealPart.RecalculateTotals()
                            mealPart.EndLine = line
                            mealPart = Nothing
                        End If
                    End If

                End If

                If mealPart IsNot Nothing Then

                    If line.Text.Contains("!ккал") Then mealPart.ShowEnergy = True

                    Dim ingInfo As IngredientInfo
                    ingInfo = meal.FirstOrDefault(Function(elem As IngredientInfo) elem.Name.ToLower.Contains(tokens(0).Str.Trim.ToLower))
                    If ingInfo Is Nothing Then ingInfo = ingredientsLibrary.FirstOrDefault(Function(elem As IngredientInfo) elem.Name.ToLower.Contains(tokens(0).Str.Trim.ToLower))

                    If ingInfo IsNot Nothing Then
                        tokens(0).ApplyAttribute(attrs, _attrName)
                        Dim mass As Single = 0
                        Dim newMass As Single = 0
                        For Each token In tokens
                            Dim parts = token.Str.Trim.Split({" "}, StringSplitOptions.None)
                            If parts.Length >= 2 And IsNumeric(parts(0).Trim) Then
                                If parts(1).Trim.ToLower = "г" Or parts(1).Trim.StartsWith("гр") Then
                                    mass += Val(parts(0))
                                    token.ApplyAttribute(attrs, _attrMass)
                                    linesChanged = True
                                    For Each part In parts
                                        If part.StartsWith("!") And IsNumeric(part.Substring(1)) Then
                                            newMass = Val(part.Substring(1))
                                            token.ApplyAttribute(attrs, _attrImportant)
                                        End If
                                    Next
                                End If
                            End If

                        Next
                        If mass <> 0 Then
                            mealPart.IngredientsList.Add(New MealIngredient(ingInfo, mass, line))
                            If newMass > 0 Then mealPart.MassKoeff = newMass / mass
                        End If
                    End If
                End If
                line.SetAttributes(attrs)
            End If
        Next

        For Each part In meal
            For Each ingredient In part.IngredientsList
                Dim addToLine = ""
                If part.MassKoeff <> 1.0 Then
                    ingredient.Mass *= part.MassKoeff
                    addToLine = "->" + ingredient.Mass.ToString("0") + " г"
                End If
                If part.ShowEnergy Then
                    addToLine = " (" + (ingredient.Mass / 100.0 * ingredient.Ingredient.EnergyPer100g).ToString("0") + " ккал)"
                End If
                ingredient.Line.OverlayText = Space(ingredient.Line.Text.Length + 1) + addToLine
            Next
            part.RecalculateTotals()
            part.EndLine.OverlayText = Space(part.EndLine.Text.Length + 1) + " Всего: " + part.TotalMass.ToString("0") + " гр, " +
                part.TotalEnergy.ToString("0") + " ккал, " + part.TotalPrice.ToString("0") + " руб"
        Next

        _tb.Lines(0).SetAttributeToAll(_attrCaption)

        If linesChanged Then
            _tb.RedrawAll()
        End If
    End Sub
    Private Sub _timer_Tick(sender As Object, e As EventArgs) Handles _timer.Tick
        ParseAll()
    End Sub
End Class
Public Class MealIngredient
    Public Sub New(ing As IngredientInfo, mass As Single, line As TextLine)
        Ingredient = ing
        _Mass = mass
        _Line = line
    End Sub
    Public Property Ingredient As IngredientInfo
    Public Property Mass As Single
    Public Property Line As TextLine
End Class
Public Class MealPart
    Inherits IngredientInfo
    Public ReadOnly Property TotalMass As Single
    Public ReadOnly Property TotalPrice As Single
    Public ReadOnly Property TotalEnergy As Single
    Public Property MassKoeff As Single = 1.0
    Public Property ShowEnergy As Boolean
    Public Property EndLine As TextLine
    Public Sub New(name As String)
        MyBase.New(name, 0, 0)

    End Sub
    Public Sub RecalculateTotals()
        _TotalEnergy = _IngredientsList.Sum(Function(elem) elem.Mass * elem.Ingredient.EnergyPer100g / 100.0)
        _TotalPrice = _IngredientsList.Sum(Function(elem) elem.Mass * elem.Ingredient.PricePer100g / 100.0)
        _TotalMass = _IngredientsList.Sum(Function(elem) elem.Mass)
        _energyPer100g = TotalEnergy * 100.0 / _TotalMass
        _pricePer100g = TotalPrice * 100.0 / _TotalMass
    End Sub

    Public ReadOnly Property IngredientsList As New List(Of MealIngredient)
End Class