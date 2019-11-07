using System;
using BlzrQuiz.Data.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using EF = BlzrQuiz.Data.Entities;
using System.Threading.Tasks;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class QuizCarousel
    {

        [Parameter] public System.Security.Claims.ClaimsPrincipal User { get; set; }
        [Parameter] public Dictionary<int, bool> ButtonDisabled { get; set; } = new Dictionary<int, bool>();
        [Parameter] public Dictionary<int, string> ButtonsText { get; set; } = new Dictionary<int, string>();
        [Inject] protected NavigationManager NavManager { get; set; }


        protected override async Task OnInitializedAsync()
        {


        }
        private async Task CreateUserQuiz(int quizId)
        {
            var userQuiz = await QService.CreateUserQuizByQuizId(quizId, User.Identity.Name).ConfigureAwait(false);
            if (userQuiz != null)
            {
                NavManager.NavigateTo($"/userquiz/{userQuiz.UserQuizId}");
            }
        }



        private void AddNewButton(int quizId)
        {
            ButtonsText.Add(quizId, "Take This Quiz");
            ButtonDisabled.Add(quizId, false);
        }
    }
}
