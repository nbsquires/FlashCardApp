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
    Public Class CoursesController
        Inherits System.Web.Mvc.Controller

        Private db As New FlashCardApp

        ' GET: Courses
        Function Index() As ActionResult
            Return View(db.Courses.ToList())
        End Function

        ' GET: Courses/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim courses As Courses = db.Courses.Find(id)
            If IsNothing(courses) Then
                Return HttpNotFound()
            End If
            Return View(courses)
        End Function

        ' GET: Courses/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Courses/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,name,description")> ByVal courses As Courses) As ActionResult
            If ModelState.IsValid Then
                db.Courses.Add(courses)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(courses)
        End Function

        ' GET: Courses/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim courses As Courses = db.Courses.Find(id)
            If IsNothing(courses) Then
                Return HttpNotFound()
            End If
            Return View(courses)
        End Function

        ' POST: Courses/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,name,description")> ByVal courses As Courses) As ActionResult
            If ModelState.IsValid Then
                db.Entry(courses).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(courses)
        End Function

        ' Get: Courses/Delete/5
        Function CourseFlashCards(ByVal id As Integer) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim course As Courses = db.Courses.Find(id)
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            Session("courseID") = course.ID.ToString
            Return View(course)
        End Function

        ' GET: Courses/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim courses As Courses = db.Courses.Find(id)
            If IsNothing(courses) Then
                Return HttpNotFound()
            End If
            Return View(courses)
        End Function

        ' POST: Courses/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim courses As Courses = db.Courses.Find(id)
            db.Courses.Remove(courses)
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
