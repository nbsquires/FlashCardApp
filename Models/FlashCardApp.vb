Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class FlashCardApp
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=FlashCardApp")
    End Sub

    Public Overridable Property Courses As DbSet(Of Courses)
    Public Overridable Property FlashCard As DbSet(Of FlashCard)
    Public Overridable Property Question As DbSet(Of Question)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Courses)() _
            .HasMany(Function(e) e.FlashCard) _
            .WithRequired(Function(e) e.Courses) _
            .HasForeignKey(Function(e) e.CourseID) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Question)() _
            .HasMany(Function(e) e.FlashCard) _
            .WithRequired(Function(e) e.Question) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
