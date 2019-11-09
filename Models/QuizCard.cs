using BlzrQuiz.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Models
{
    public class QuizCard
    {
        public Quiz Quiz { get; set; }
        public bool IsDisabled { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
