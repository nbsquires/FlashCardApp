@ModelType FlashCardApp.FlashCard
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>FlashCard</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Courses.name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Courses.name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Question.questionText)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Question.questionText)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
