using Microsoft.AspNetCore.Components;
using BlzrQuiz.ServiceLayer;
using EF = BlzrQuiz.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;

namespace BlzrQuiz.Pages
{
    public partial class QuizPage
    {
        [Parameter] public RenderFragment QuizFragments { get; set; }
        [Inject] protected QuizService QService { get; set; }
        [Inject] protected AuthenticationStateProvider Auth { get; set; }
        public  IList<EF.UserQuiz> UserQuizzes { get; set; } = new List<EF.UserQuiz>();
        private System.Security.Claims.ClaimsPrincipal User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await Auth.GetAuthenticationStateAsync().ConfigureAwait(false);
            User = authState.User;
            UserQuizzes = await QService.GetUserQuizzesById(User.Identity.Name).ConfigureAwait(false) as List<EF.UserQuiz>;
            await AddQuizzes();
        }

        private async Task AddQuizzes()
        {
           

            if (await CreateQuizes())
                UserQuizzes = await QService.GetUserQuizzesById(User.Identity.Name).ConfigureAwait(false) as List<EF.UserQuiz>;
        }

        private async Task<bool> CreateQuizes()
        {
            var quizzesAdded = await CreateDefaultMultipleChoiceQuiz();
            //If CreateMultiSelectQuiz returns true return true, if not, if quizzesAdded is true return that. 
            //If not, return false, as both creations failed
            return await CreateMultiSelectQuiz(quizzesAdded) ? true : quizzesAdded ? true : false;
        }

        private async Task<bool> CreateMultiSelectQuiz(bool quizzesAdded)
        {
            if (!UserQuizzes.Any(x => x.UserId == User.Identity.Name && x.Quiz.Name == "MultiAnswer"))
            {
                await QService.CreateMultipleSelectionUserQuiz(User.Identity.Name).ConfigureAwait(false);
                quizzesAdded = true;
            }

            return quizzesAdded;
        }

        private async Task<bool> CreateDefaultMultipleChoiceQuiz()
        {
            EF.UserQuiz quiz = null;
            if (!UserQuizzes.Any(x => x.UserId == User.Identity.Name && x.Quiz.Name == "Test"))
            {
                 quiz = await QService.CreateUserQuiz(3, User.Identity.Name).ConfigureAwait(false);
            }

            return quiz != null ? true : false;
        }
    }
}
