namespace BlzrQuiz.Data.EfClasses
{
    public class Answer
    {
        //public Answer(string text, bool isCorrect)
        //{
        //    Text = text ?? throw new ArgumentNullException(nameof(text));
        //    IsCorrect = isCorrect;
        //}
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}