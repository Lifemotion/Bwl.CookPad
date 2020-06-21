Public Class CookPad
    Private _components As IngredientsParser
    Private _receiptParser As ReceiptParser
    Private _basePath As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive\CookPad")
    Private _componentsFile As String = IO.Path.Combine(_basePath, "!Ингредиенты.txt")
    Private _receiptFile As String = ""
    Private _receiptChanged As Boolean

    Public Sub New()
        If Not IO.Directory.Exists(_basePath) Then IO.Directory.CreateDirectory(_basePath)
        If Not IO.File.Exists(_componentsFile) Then IO.File.WriteAllText(_componentsFile, "Список ингредиентов")
        InitializeComponent()
    End Sub

    Private Sub CookPad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbComponents.LoadFromString(IO.File.ReadAllText(_componentsFile))
        _components = New IngredientsParser(tbComponents)
        _receiptParser = New ReceiptParser(tbRecipe, _components)
        ListRecipes()
    End Sub

    Private Sub tbRecipe_TextChanged(sender As Object) Handles tbRecipe.TextChanged
        _receiptChanged = True
    End Sub
    Private Sub CloseRecipe()
        If _receiptChanged Then
            Dim _nameFromRecipe = Trim(tbRecipe.Lines(0).Text)
            If _receiptFile = "" OrElse IO.Path.GetFileNameWithoutExtension(_receiptFile) <> _nameFromRecipe Then
                If _receiptFile > "" Then IO.File.Delete(_receiptFile)
            End If
            IO.File.WriteAllText(IO.Path.Combine(_basePath, _nameFromRecipe + ".txt"), tbRecipe.ToString)
            ListRecipes()
        End If
    End Sub
    Private Sub ListRecipes()
        Dim files = IO.Directory.GetFiles(_basePath, "*.txt")
        lbRecipesList.Items.Clear()
        For Each file In files
            Dim name = IO.Path.GetFileNameWithoutExtension(file)
            If Not name.StartsWith("!") And name.Length > 0 Then lbRecipesList.Items.Add(name)
        Next
    End Sub

    Private Sub CookPad_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        IO.File.WriteAllText(_componentsFile, tbComponents.ToString)
        CloseRecipe()
    End Sub

    Private Sub lbRecipesList_MouseClick(sender As Object, e As MouseEventArgs) Handles lbRecipesList.MouseClick
        Dim name = lbRecipesList.Text
        If name > "" Then
            CloseRecipe()
            _receiptFile = IO.Path.Combine(_basePath, name + ".txt")
            tbRecipe.LoadFromString(IO.File.ReadAllText(_receiptFile))
        End If
    End Sub

    Private Sub mOpenFolder_Click(sender As Object, e As EventArgs) Handles mOpenFolder.Click
        Dim prc As New Process()
        prc.StartInfo.FileName = "explorer"
        prc.StartInfo.Arguments = "."
        prc.StartInfo.WorkingDirectory = _basePath
        prc.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        prc.Start()
    End Sub

    Private Sub mNewRecipe_Click(sender As Object, e As EventArgs) Handles mNewRecipe.Click
        CloseRecipe()
        tbRecipe.LoadFromString("")
        _receiptFile = ""
        _receiptChanged = False
    End Sub
End Class
