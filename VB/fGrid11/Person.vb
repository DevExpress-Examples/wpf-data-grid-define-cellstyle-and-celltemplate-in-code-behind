Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace fGrid11
	Public Class Person
		Public Sub New(ByVal i As Integer)
			LastName = "LastName #" & i
			Age = i * 10
		End Sub
		Public Shared ReadOnly Property CreateList() As ObservableCollection(Of Person)
			Get
				Dim list As New ObservableCollection(Of Person)()
				For i As Integer = 0 To 9
					list.Add(New Person(i) With {.NameFontSize = 12 + (i Mod 6)})
				Next i
				Return list
			End Get
		End Property
		Public Property Age() As Integer
		Public Property LastName() As String
		Public Property NameFontSize() As Double
	End Class
End Namespace
