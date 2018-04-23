Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Grid.Themes
Imports System
Imports System.IO
Imports System.Linq
Imports System.Windows.Markup

Namespace fGrid11
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub AddCellTemplateButton_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim ageBinding As String = "IsReadOnly=""{Binding RowData.EvenRow}"""
			Dim nameBinding As String = "FontSize=""{Binding RowData.Row.NameFontSize}"""
			Dim ageCellDataTemplate As DataTemplate = CreateDataTemplate(ageBinding)
			If ageCellDataTemplate IsNot Nothing Then
				gridControl1.Columns("Age").CellTemplate = ageCellDataTemplate
			End If
			Dim nameCellDataTemplate As DataTemplate = CreateDataTemplate(nameBinding)
			If nameCellDataTemplate IsNot Nothing Then
				gridControl1.Columns("LastName").CellTemplate = nameCellDataTemplate
			End If
		End Sub

		Private Sub AddStyleButton_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim _style As New Style()
            Dim baseStyle As Style = TryCast(FindResource(New GridRowThemeKeyExtension() With {
                .ResourceKey = GridRowThemeKeys.LightweightCellStyle,
                .ThemeName = ThemeManager.ApplicationThemeName
            }), Style)
            _style.BasedOn = baseStyle
            _style.TargetType = GetType(LightweightCellEditor)
            _style.Setters.Add(New Setter(LightweightCellEditor.BackgroundProperty, New SolidColorBrush(Colors.LightGreen)))
            gridControl1.Columns("LastName").CellStyle = _style
        End Sub

        Private myCellTemplate As String = "<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" " &
            "xmlns:dxe=""http://schemas.devexpress.com/winfx/2008/xaml/editors"">" &
            "<dxe:TextEdit Name=""PART_Editor"" HorizontalContentAlignment=""Center"" REPLACE/></DataTemplate>"

        Private Function CreateDataTemplate(ByVal markupPart As String) As DataTemplate
            Dim _template As String = myCellTemplate.Replace("REPLACE", markupPart)
            Dim dataTemplate As DataTemplate = TryCast(XamlReader.Load(GetStreamFromString(_template)), DataTemplate)
            Return dataTemplate
		End Function

		Public Shared Function GetStreamFromString(ByVal s As String) As Stream
			Dim stream = New MemoryStream()
			Dim writer = New StreamWriter(stream)
			writer.Write(s)
			writer.Flush()
			stream.Position = 0
			Return stream
		End Function
	End Class
End Namespace
