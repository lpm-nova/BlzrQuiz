using System.Collections.Generic;

namespace BlzrQuiz.Data.Entities
{
    public class QuestionTag
    {
        public int QuestionTagId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}