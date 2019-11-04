using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class Index
    {
        [Inject] protected AuthenticationStateProvider Auth { get; set; }
        [Inject] protected NavigationManager NavManager { get; set; }
        public IList<EF.Quiz> Quizzes { get; set; } = new List<EF.Quiz>();
        private Dictionary<int, string> ButtonsText { get; set; } = new Dictionary<int, string>();
        [Parameter] public Dictionary<int, bool> ButtonDisabled { get; set; } = new Dictionary<int, bool>();
        private System.Security.Claims.ClaimsPrincipal User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Quizzes = await QService.GetQuizes().ConfigureAwait(false) as List<EF.Quiz>;
            var authState = await Auth.GetAuthenticationStateAsync().ConfigureAwait(false);
            User = authState.User;
            await SetButtons().ConfigureAwait(false);
        }

      

        private async Task SetButtons()
        {
            ButtonDisabled.Clear();
            ButtonsText.Clear();
            var userQuizzes = await QService.GetUserQuizzesById(User.Identity.Name).ConfigureAwait(false) as List<EF.UserQuiz>;
            foreach(var q in Quizzes)
            {
                if(userQuizzes.Any(x => x.QuizId == q.QuizId))
                {
                    ButtonsText.Add(q.QuizId, "In Your List");
                    ButtonDisabled.Add(q.QuizId, true);
                }else
                {
                    AddNewButton(q.QuizId);
                }
            }
        }

        private void AddNewButton(int quizId)
        {
            ButtonsText.Add(quizId, "Take This Quiz");
            ButtonDisabled.Add(quizId, false);
        }

        private async Task CreateNewQuiz()
        {
            var quiz = await QService.CreateQuizForCertification("CLF-C01");
            if (quiz != null)
            {
                Quizzes.Add(quiz);
                AddNewButton(quiz.QuizId);
            }
        }

        private async Task CreateUserQuiz(int quizId)
        {
            var userQuiz = await QService.CreateUserQuizByQuizId(quizId, User.Identity.Name).ConfigureAwait(false);
            if (userQuiz != null)
            {
                NavManager.NavigateTo($"/userquiz/{userQuiz.UserQuizId}");
            }
        }
    }
}
