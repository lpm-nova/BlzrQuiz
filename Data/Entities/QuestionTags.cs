namespace BlzrQuiz.Data.Entities
{
    public class QuestionTags
    {
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public int QuestionId { get; set; }
    }
}