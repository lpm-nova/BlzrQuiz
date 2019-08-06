using BlzrQuiz.Data.EfClasses;
using System;
using System.Collections.Generic;

namespace BlzrQuiz.Data.EfClasses
{
    public class Question
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
        public QResult Result { get; set; }
        public virtual void AddTag(string tag) { }
        public virtual void RemoveTag(string tag) { }
    }

    public enum QResult
    {
        Correct,
        PartiallyCorrect,
        Incorrect
    }
}
