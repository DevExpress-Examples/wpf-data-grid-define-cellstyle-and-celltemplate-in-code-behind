Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Grid.Themes
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace fGrid11
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			CreateList()
			DataContext = Me

		End Sub
		Private privateListPerson As ObservableCollection(Of Person)
		Public Property ListPerson() As ObservableCollection(Of Person)
			Get
				Return privateListPerson
			End Get
			Set(ByVal value As ObservableCollection(Of Person))
				privateListPerson = value
			End Set
		End Property
		Private Sub CreateList()
			ListPerson = New ObservableCollection(Of Person)()
			For i As Integer = 0 To 9
				ListPerson.Add(New Person(i))
			Next i
		End Sub

		Private Sub AddCellTemplateButton_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim cellTemplate As New DataTemplate()
			Dim factory As New FrameworkElementFactory(GetType(TextEdit))
			factory.Name = "PART_Editor"
			factory.SetValue(TextEdit.HorizontalContentAlignmentProperty, HorizontalAlignment.Center)

			cellTemplate.VisualTree = factory

			gridControl1.Columns("Age").CellTemplate = cellTemplate
		End Sub

		Private Sub AddStyleButton_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim style As New Style()

			'Style baseStyle = FindResource(new GridRowThemeKeyExtension() { ResourceKey = GridRowThemeKeys.CellStyle }) as Style;
			Dim baseStyle As Style = TryCast(FindResource(New GridRowThemeKeyExtension() With {.ResourceKey = GridRowThemeKeys.CellStyle, .ThemeName = ThemeManager.ApplicationThemeName}), Style)

			style.BasedOn = baseStyle
			style.TargetType = GetType(CellContentPresenter)
			style.Setters.Add(New Setter(BackgroundProperty, New SolidColorBrush(Colors.Green)))

			gridControl1.Columns("LastName").CellStyle = style
		End Sub


	End Class

	Public Class Person
		Public Sub New(ByVal i As Integer)

			LastName = "LastName" & i
			Age = i * 10

		End Sub

		Private privateLastName As String
		Public Property LastName() As String
			Get
				Return privateLastName
			End Get
			Set(ByVal value As String)
				privateLastName = value
			End Set
		End Property
		Private privateAge As Integer
		Public Property Age() As Integer
			Get
				Return privateAge
			End Get
			Set(ByVal value As Integer)
				privateAge = value
			End Set
		End Property

	End Class



End Namespace
