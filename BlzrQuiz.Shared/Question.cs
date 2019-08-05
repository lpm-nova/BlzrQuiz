using System;
using System.Collections.Generic;

namespace BlzrQuiz
{
    public class Question
    {
        protected Question(string text, List<string> tags, List<Answer> answers)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Tags = tags ?? throw new ArgumentNullException(nameof(tags));
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
        }

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public List<string> Tags { get; }
        public List<Answer> Answers { get; }
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
