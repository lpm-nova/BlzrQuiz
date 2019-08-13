using System.Collections.Generic;

namespace BlzrQuiz.Data.EfClasses
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int CertificationId { get; set; }
        public List<QuizQuestion> Questions { get; set; }
        public byte Score() { return 0; }
    }
}
