@ModelType IEnumerable(Of FlashCardApp.FlashCard)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Courses.name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Question.questionText)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
           @Html.ActionLink(item.Courses.name, "CourseFlashCards/" & item.CourseID, "Courses")
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Question.questionText)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
