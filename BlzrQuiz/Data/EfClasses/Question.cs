using System.Collections.Generic;

namespace BlzrQuiz.Data.EfClasses
{
    public partial class Question
    {
        //protected Question(string text, List<string> tags, List<Answer> answers)
        //{
        //    Text = text ?? throw new ArgumentNullException(nameof(text));
        //    Tags = tags ?? throw new ArgumentNullException(nameof(tags));
        //    Answers = answers ?? throw new ArgumentNullException(nameof(answers));
        //}

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public List<QuestionTags> Tags { get; set; }
        public List<QuestionAnswer> Answers { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }

    public enum QResult
    {
        NoResult,
        Correct,
        PartiallyCorrect,
        Incorrect
    }
}
