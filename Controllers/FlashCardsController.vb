Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports FlashCardApp

Namespace Controllers
    Public Class FlashCardsController
        Inherits System.Web.Mvc.Controller

        Private db As New FlashCardApp

        ' GET: FlashCards
        Function Index() As ActionResult
            Dim flashCard = db.FlashCard.Include(Function(f) f.Courses).Include(Function(f) f.Question)
            Return View(flashCard.ToList())
        End Function

        ' GET: FlashCards/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim flashCard As FlashCard = db.FlashCard.Find(id)
            If IsNothing(flashCard) Then
                Return HttpNotFound()
            End If
            Return View(flashCard)
        End Function

        ' GET: FlashCards/Create
        Function Create() As ActionResult
            ViewBag.CourseID = New SelectList(db.Courses, "ID", "name")
            ViewBag.QuestionID = New SelectList(db.Question, "ID", "questionText")
            Return View()
        End Function

        ' POST: FlashCards/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,QuestionID,CourseID")> ByVal flashCard As FlashCard) As ActionResult
            If ModelState.IsValid Then
                db.FlashCard.Add(flashCard)
                db.SaveChanges()
                Return RedirectToAction("CourseFlashCards", "Courses", New With {.id = flashCard.CourseID})
            End If
            ViewBag.CourseID = New SelectList(db.Courses, "ID", "name", flashCard.CourseID)
            ViewBag.QuestionID = New SelectList(db.Question, "ID", "questionText", flashCard.QuestionID)
            Return View(flashCard)
        End Function

        ' GET: FlashCards/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim flashCard As FlashCard = db.FlashCard.Find(id)
            If IsNothing(flashCard) Then
                Return HttpNotFound()
            End If
            ViewBag.CourseID = New SelectList(db.Courses, "ID", "name", flashCard.CourseID)
            ViewBag.QuestionID = New SelectList(db.Question, "ID", "questionText", flashCard.QuestionID)
            Return View(flashCard)
        End Function

        ' POST: FlashCards/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,QuestionID,CourseID")> ByVal flashCard As FlashCard) As ActionResult
            If ModelState.IsValid Then
                db.Entry(flashCard).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CourseID = New SelectList(db.Courses, "ID", "name", flashCard.CourseID)
            ViewBag.QuestionID = New SelectList(db.Question, "ID", "questionText", flashCard.QuestionID)
            Return View(flashCard)
        End Function

        ' GET: FlashCards/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim flashCard As FlashCard = db.FlashCard.Find(id)
            If IsNothing(flashCard) Then
                Return HttpNotFound()
            End If
            Return View(flashCard)
        End Function

        ' POST: FlashCards/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim flashCard As FlashCard = db.FlashCard.Find(id)
            db.FlashCard.Remove(flashCard)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
