Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Grid
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace fGrid11

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            CreateList()
            DataContext = Me
        End Sub

        Public Property ListPerson As ObservableCollection(Of Person)

        Private Sub CreateList()
            ListPerson = New ObservableCollection(Of Person)()
            For i As Integer = 0 To 10 - 1
                ListPerson.Add(New Person(i))
            Next
        End Sub

        Private Sub AddCellTemplateButton_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim cellTemplate As DataTemplate = New DataTemplate()
            Dim factory As FrameworkElementFactory = New FrameworkElementFactory(GetType(TextEdit))
            factory.Name = "PART_Editor"
            factory.SetValue(HorizontalContentAlignmentProperty, HorizontalAlignment.Center)
            cellTemplate.VisualTree = factory
            Me.gridControl1.Columns("Age").CellTemplate = cellTemplate
        End Sub

        Private Sub AddStyleButton_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim style As Style = New Style()
            style.TargetType = GetType(CellContentPresenter)
            style.Setters.Add(New Setter(BackgroundProperty, New SolidColorBrush(Colors.Green)))
            Me.gridControl1.Columns("LastName").CellStyle = style
        End Sub
    End Class

    Public Class Person

        Public Sub New(ByVal i As Integer)
            LastName = "LastName" & i
            Age = i * 10
        End Sub

        Public Property LastName As String

        Public Property Age As Integer
    End Class
End Namespace
