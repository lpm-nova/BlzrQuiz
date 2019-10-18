using System;
using System.Collections.Generic;

namespace BlzrQuiz.Data.Entities
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public  int CertificationId { get; set; }
        public Certification Certification { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
