Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "About Flash Cards"

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Contact Me."

        Return View()
    End Function

    Function LearnMore() As ActionResult
        ViewData("Message") = "Learn More."

        Return View()
    End Function
End Class
