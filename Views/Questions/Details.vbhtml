@ModelType FlashCardApp.Question
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Question</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.questionText)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.questionText)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.answer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.answer)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
