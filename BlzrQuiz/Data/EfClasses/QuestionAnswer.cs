﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.EfClasses
{
    public class QuestionAnswer
    {
        public Answer Answer {get; set;}
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
    }
}