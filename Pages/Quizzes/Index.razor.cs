using BlzrQuiz.ServiceLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class Index
    {
        [Inject] protected AuthenticationStateProvider Auth { get; set; }
        [Inject] protected QuizService QService { get; set; }

        public Dictionary<string, QuizCarousel> CarouselRows { get; set; } = new Dictionary<string, QuizCarousel>();
        public IList<EF.Quiz> Quizzes { get; set; } = new List<EF.Quiz>();
        public IList<EF.UserQuiz> UserQuizzes { get; set; } = new List<EF.UserQuiz>();
        public Dictionary<int, bool> ButtonDisabled { get; set; } = new Dictionary<int, bool>();
        public Dictionary<int, string> ButtonsText { get; set; } = new Dictionary<int, string>();
        private System.Security.Claims.ClaimsPrincipal User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Quizzes = await QService.GetQuizes().ConfigureAwait(false) as List<EF.Quiz>;
            UserQuizzes = await QService.GetUserQuizzesById(User.Identity.Name).ConfigureAwait(false) as List<EF.UserQuiz>;
            var authState = await Auth.GetAuthenticationStateAsync().ConfigureAwait(false);
            User = authState.User;
            await SetButtons().ConfigureAwait(false);
        }

        private async Task CreateNewQuiz()
        {
            var quiz = await QService.CreateQuizForCertification("CLF-C01");
            if (quiz != null)
            {
                Quizzes.Add(quiz);
                //AddNewButton(quiz.QuizId);
            }
        }

        private async Task SetButtons()
        {
            //ButtonDisabled.Clear();
            //ButtonsText.Clear();

            //foreach (var q in Quizzes)
            //{
            //    if (userQuizzes.Any(x => x.QuizId == q.QuizId))
            //    {
            //        ButtonsText.Add(q.QuizId, "In Your List");
            //        ButtonDisabled.Add(q.QuizId, true);
            //    }
            //    else
            //    {
            //        AddNewButton(q.QuizId);
            //    }
            //}
        }

    }
}
