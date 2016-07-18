Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Courses
    Public Sub New()
        FlashCard = New HashSet(Of FlashCard)()
    End Sub

    Public Property ID As Integer

    <Required>
    <StringLength(50)>
    Public Property name As String

    Public Property description As String

    Public Overridable Property FlashCard As ICollection(Of FlashCard)
End Class
