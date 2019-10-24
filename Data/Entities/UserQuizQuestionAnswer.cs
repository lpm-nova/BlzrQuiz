using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.Entities
{
    public class UserQuizQuestionAnswer
    {
        public int UserQuizQuestionAnswerId { get; set; }
        public int UserQuizId { get; set; }
        public UserQuiz UserQuiz { get; set; }
        public QuizQuestion QuizQuestion { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
