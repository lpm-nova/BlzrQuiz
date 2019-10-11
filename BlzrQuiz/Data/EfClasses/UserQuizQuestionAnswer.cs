using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.EfClasses
{
    public class UserQuizQuestionAnswer
    {
        public int UserQuizId { get; set; }
        public int QuizQuestionId { get; set; }
        public List<QuestionAnswer> QuestionAnswers { get; set; }
        public QuizQuestion QuizQuestion { get; set; }
        public UserQuiz UserQuiz { get; set; }
    }
}
