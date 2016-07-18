@ModelType FlashCardApp.Courses

@Code
    ViewData("Title") = "Course FlashCards"
End Code

<h2>Course FlashCards</h2>
<head>
    <script type="text/javascript">
        function reveal(item) {
            var parent = $(item).parent();
            var answerCard = $(parent).find(".card:hidden");
            var answerLink = $(parent).find(".btn-link:hidden");
            var questionCard = $(parent).find(".card:visible");
            var questionLink = $(parent).find(".btn-link:visible");
            answerCard.show();
            answerLink.show();
            questionCard.hide();
            questionLink.hide();
        }

    </script>
</head>
<body>
    @Html.ActionLink("Create Flashcard", "Create", "Flashcards")
    <div class="container">
        <div class="row">
            @For Each card In Model.FlashCard
                @<div class="col-sm-6">
                    <div class="card">
                        @Html.DisplayFor(Function(model) card.Question.questionText)
                    </div>
                    <button class="btn-link" value="clickme" onclick="reveal(this); return false;">Answer</button>
                    <div class="card" hidden>
                        @Html.DisplayFor(Function(model) card.Question.answer)
                    </div>
                    <button class="btn-link" onclick="reveal(this); return false;" hidden>Question</button>
                </div>
            Next
        </div>
    </div>
</body>
<p>
    >
    @Html.ActionLink("Back to List", "Index")
</p>
