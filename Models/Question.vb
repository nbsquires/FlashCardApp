Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Question")>
Partial Public Class Question
    Public Sub New()
        FlashCard = New HashSet(Of FlashCard)()
    End Sub

    Public Property ID As Integer

    <Required>
    <StringLength(50)>
    Public Property questionText As String

    <Required>
    <StringLength(50)>
    Public Property answer As String

    Public Overridable Property FlashCard As ICollection(Of FlashCard)
End Class
