using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class QuizCard
    {
        [Parameter] public EF.Quiz Quiz { get; set; }
    }
}
