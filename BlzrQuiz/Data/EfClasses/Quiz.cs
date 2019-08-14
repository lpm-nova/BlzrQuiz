using System.Collections.Generic;

namespace BlzrQuiz.Data.EfClasses
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int CertificationId { get; set; }
        public Certification Certification { get; set; }
        public List<Question> Questions { get; set; }
    }
}
