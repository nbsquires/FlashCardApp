@ModelType FlashCardApp.FlashCard
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
