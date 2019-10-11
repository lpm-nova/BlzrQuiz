namespace BlzrQuiz.Data.EfClasses
{
    public class QuestionAnswer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
}
