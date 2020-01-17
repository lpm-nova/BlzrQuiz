using System.ComponentModel.DataAnnotations;

namespace BlzrQuiz.Data.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}