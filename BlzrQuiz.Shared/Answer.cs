using System;

namespace BlzrQuiz
{
    public class Answer
    {
        public Answer(string text, bool isCorrect)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            IsCorrect = isCorrect;
        }

        public int AnswerId { get; }
        public string Text { get; }
        public bool IsCorrect { get; }
    }
}