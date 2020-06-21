<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CookPad
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CookPad))
        Me.lbRecipesList = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.РецептToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СистемаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mOpenFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbComponents = New Bwl.TextBoxEx.TextBoxEx()
        Me.tbRecipe = New Bwl.TextBoxEx.TextBoxEx()
        Me.mNewRecipe = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbRecipesList
        '
        Me.lbRecipesList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbRecipesList.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbRecipesList.FormattingEnabled = True
        Me.lbRecipesList.ItemHeight = 15
        Me.lbRecipesList.Location = New System.Drawing.Point(1, 27)
        Me.lbRecipesList.Name = "lbRecipesList"
        Me.lbRecipesList.Size = New System.Drawing.Size(142, 529)
        Me.lbRecipesList.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РецептToolStripMenuItem, Me.СистемаToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(960, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'РецептToolStripMenuItem
        '
        Me.РецептToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mNewRecipe})
        Me.РецептToolStripMenuItem.Name = "РецептToolStripMenuItem"
        Me.РецептToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.РецептToolStripMenuItem.Text = "Рецепт"
        '
        'СистемаToolStripMenuItem
        '
        Me.СистемаToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mOpenFolder})
        Me.СистемаToolStripMenuItem.Name = "СистемаToolStripMenuItem"
        Me.СистемаToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.СистемаToolStripMenuItem.Text = "Система"
        '
        'mOpenFolder
        '
        Me.mOpenFolder.Name = "mOpenFolder"
        Me.mOpenFolder.Size = New System.Drawing.Size(228, 22)
        Me.mOpenFolder.Text = "Открыть папку с рецептами"
        '
        'tbComponents
        '
        Me.tbComponents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbComponents.BackColor = System.Drawing.Color.White
        Me.tbComponents.BackgroundImage = CType(resources.GetObject("tbComponents.BackgroundImage"), System.Drawing.Image)
        Me.tbComponents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbComponents.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbComponents.Location = New System.Drawing.Point(571, 26)
        Me.tbComponents.Name = "tbComponents"
        Me.tbComponents.NewLineSpacesAsPreviousLine = True
        Me.tbComponents.Size = New System.Drawing.Size(388, 548)
        Me.tbComponents.TabIndex = 2
        Me.tbComponents.TabSize = 4
        '
        'tbRecipe
        '
        Me.tbRecipe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRecipe.BackColor = System.Drawing.Color.White
        Me.tbRecipe.BackgroundImage = CType(resources.GetObject("tbRecipe.BackgroundImage"), System.Drawing.Image)
        Me.tbRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbRecipe.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbRecipe.Location = New System.Drawing.Point(149, 27)
        Me.tbRecipe.Name = "tbRecipe"
        Me.tbRecipe.NewLineSpacesAsPreviousLine = True
        Me.tbRecipe.Size = New System.Drawing.Size(416, 547)
        Me.tbRecipe.TabIndex = 0
        Me.tbRecipe.TabSize = 4
        '
        'mNewRecipe
        '
        Me.mNewRecipe.Name = "mNewRecipe"
        Me.mNewRecipe.Size = New System.Drawing.Size(180, 22)
        Me.mNewRecipe.Text = "Новый"
        '
        'CookPad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 574)
        Me.Controls.Add(Me.tbComponents)
        Me.Controls.Add(Me.lbRecipesList)
        Me.Controls.Add(Me.tbRecipe)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "CookPad"
        Me.Text = "Bwl.CookPad"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbRecipe As TextBoxEx.TextBoxEx
    Friend WithEvents lbRecipesList As ListBox
    Friend WithEvents tbComponents As TextBoxEx.TextBoxEx
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents РецептToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents СистемаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mOpenFolder As ToolStripMenuItem
    Friend WithEvents mNewRecipe As ToolStripMenuItem
End Class
