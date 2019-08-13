namespace BlzrQuiz.Data.EfClasses
{
    public class QuizQuestion
    {
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public bool IsAnswered { get; set; }
    }
}
