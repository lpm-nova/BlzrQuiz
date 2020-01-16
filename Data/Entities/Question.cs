using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlzrQuiz.Data.Entities
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public Certification Certification { get; set; }
        [Required]
        public int CertificationId { get; set; }
        public Explanation Explanation { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Text { get; set; }
        public byte NumberOfCorrectAnswers { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
        public ICollection<QuestionTag> QuestionTags { get; set; }
        public MarkupString Markup
        {
            get
            {
                return new MarkupString(Text);
            }
        }
        public MarkupString ToMarkup()
        {
            return new MarkupString(Text);
        }
    }
}
