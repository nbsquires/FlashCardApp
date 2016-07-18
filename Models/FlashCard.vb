Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("FlashCard")>
Partial Public Class FlashCard
    Public Property ID As Integer

    Public Property QuestionID As Integer

    Public Property CourseID As Integer

    Public Overridable Property Courses As Courses

    Public Overridable Property Question As Question
End Class
