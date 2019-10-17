﻿using System.Collections.Generic;

namespace BlzrQuiz.Data.Entities
{
    public class QuizQuestion
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public Question Question { get; set; }
        public Quiz Quiz { get; set; }
        public byte QuestionNumber { get; set; }
        public ICollection<UserQuizQuestionAnswer> UserQuizQuestionAnswers { get; set; }
    }
}
