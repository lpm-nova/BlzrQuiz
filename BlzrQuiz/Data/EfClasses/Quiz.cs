using System;
using System.Collections.Generic;
using System.Text;

namespace BlzrQuiz.Data.EfClasses
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

        public int GetScore() { return 0; }
    }
}
