using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.EfClasses
{
    public class UserQuizQuestionAnswer
    {
        public int UserQuizQuestionAnswerId { get; set; }
        public int UserQuizId { get; set; }
        public int QuizQuestionId { get; set; }
        public int QuestionAnswerId { get; set; }
        public QuestionAnswer QuestionAnswer {get;set;}
    public QuizQuestion QuizQuestion { get; set; }
    public UserQuiz UserQuiz { get; set; }
}
}
