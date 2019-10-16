using System.Collections.Generic;

namespace BlzrQuiz.Data.EfClasses
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public Certification Certification { get; set; }
        public int CertificationId { get; set; }
        public string Text { get; set; }
        public bool HasMultipleAnswers { get; set; }
        
        public virtual ICollection<Answer> Answers { get; set; }

        public ICollection<QuizQuestion> QuizQuestions { get; set; }
        //public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public enum QResult
    {
        NoResult,
        Correct,
        PartiallyCorrect,
        Incorrect
    }
}
