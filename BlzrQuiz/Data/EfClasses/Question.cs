using System.Collections.Generic;

namespace BlzrQuiz.Data.EfClasses
{
    public partial class Question
    {

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public List<QuestionTags> Tags { get; set; }
        public List<Answer> Answers { get; set; }
    }

    public enum QResult
    {
        NoResult,
        Correct,
        PartiallyCorrect,
        Incorrect
    }
}
