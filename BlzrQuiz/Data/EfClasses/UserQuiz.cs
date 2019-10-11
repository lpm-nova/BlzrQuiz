using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.EfClasses
{
    public class UserQuiz
    {
        public int UserQuizId { get; set; }
        public int QuizId { get; set; }
        public string UserId { get; set; }
        [Range(0, 100)]
        public byte Score { get; set; }
        public Quiz Quiz { get; set; }

 
    }
}
