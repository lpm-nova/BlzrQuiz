using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlzrQuiz.Data.Entities
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public  int CertificationId { get; set; }
        public Certification Certification { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
        private string DebuggerDisplay
        {
            get
            {
                return string.Format($"QuizId: {QuizId}, Name: {Name}, CertificationId: {CertificationId}");
            }
        }
    }
}
