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
    Public Class QuestionsController
        Inherits System.Web.Mvc.Controller

        Private db As New FlashCardApp

        ' GET: Questions
        Function Index() As ActionResult
            Return View(db.Question.ToList())
        End Function

        ' GET: Questions/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim question As Question = db.Question.Find(id)
            If IsNothing(question) Then
                Return HttpNotFound()
            End If
            Return View(question)
        End Function

        ' GET: Questions/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Questions/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,questionText,answer")> ByVal question As Question) As ActionResult
            If ModelState.IsValid Then
                db.Question.Add(question)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(question)
        End Function

        ' GET: Questions/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim question As Question = db.Question.Find(id)
            If IsNothing(question) Then
                Return HttpNotFound()
            End If
            Return View(question)
        End Function

        ' POST: Questions/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,questionText,answer")> ByVal question As Question) As ActionResult
            If ModelState.IsValid Then
                db.Entry(question).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(question)
        End Function

        ' GET: Questions/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim question As Question = db.Question.Find(id)
            If IsNothing(question) Then
                Return HttpNotFound()
            End If
            Return View(question)
        End Function

        ' POST: Questions/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim question As Question = db.Question.Find(id)
            db.Question.Remove(question)
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
