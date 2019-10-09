using System.Collections.Generic;

namespace BlzrQuiz.Data.EfClasses
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  int CertificationId { get; set; }
        public Certification Certification { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
