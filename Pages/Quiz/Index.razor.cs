using BlzrQuiz.ServiceLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages.Quiz
{
    public partial class Index
    {
        public IEnumerable<EF.Quiz> Quizzes {get;set;} = new List<EF.Quiz>();
        protected override async Task OnInitializedAsync()
        {
            Quizzes = await QService.GetQuizes();
        }
    }
}
