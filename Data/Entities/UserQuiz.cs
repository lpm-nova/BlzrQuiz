using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlzrQuiz.Data.Entities
{
    public class UserQuiz
    {
        public int UserQuizId { get; set; }

        public int QuizId { get; set; }

        public string UserId { get; set; }

        [Range(0, 100)]
        public byte Score { get; set; }

        public Quiz Quiz { get; set; }

        public ICollection<UserQuizQuestionAnswer> UserQuizQuestionAnswers { get; set; }
    }
}
