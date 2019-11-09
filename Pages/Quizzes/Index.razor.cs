using BlzrQuiz.Data.Entities;
using BlzrQuiz.ServiceLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF = BlzrQuiz.Data.Entities;
using M = BlzrQuiz.Models;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class Index 
    {
        [Inject] 
        protected AuthenticationStateProvider Auth { get; set; }
        [Inject] 
        protected QuizService QService { get; set; }

        public Dictionary<string, List<M.QuizCard>> CarouselRows { get; set; } = new Dictionary<string, List<M.QuizCard>>();
        public IList<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public List<EF.UserQuiz> UserQuizzes { get; set; } = new List<EF.UserQuiz>();
        public Dictionary<int, bool> ButtonDisabled { get; set; } = new Dictionary<int, bool>();
        public Dictionary<int, string> ButtonsText { get; set; } = new Dictionary<int, string>();
        private System.Security.Claims.ClaimsPrincipal User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await Auth.GetAuthenticationStateAsync().ConfigureAwait(false);
            User = authState.User;
            if (User != null)
            {
                Quizzes = await QService.GetQuizes().ConfigureAwait(false) as List<EF.Quiz>;
                UserQuizzes = await QService.GetUserQuizzesById(User.Identity.Name).ConfigureAwait(false) as List<EF.UserQuiz>;
                CreateCarousels();
                await SetButtons().ConfigureAwait(false);
            }
        }
 
        public void CreateCarousels()
        {
            foreach(var quiz in Quizzes)
            {
                var quizCard = CreateQuizCard(quiz);
                if (!CarouselRows.ContainsKey(quiz.Certification.Name))
                {
                    CarouselRows.Add(quiz.Certification.Name, new List<M.QuizCard> { quizCard });
                }else
                {
                    CarouselRows[quiz.Certification.Name].Add(quizCard);
                }
            }
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
        private M.QuizCard CreateQuizCard(Quiz quiz)
        {
            var qz = new M.QuizCard
            {
                Quiz = quiz,
                IsDisabled = false
            };
            if (UserQuizzes.Any(x => x.QuizId == quiz.QuizId))
            {
                qz.Text = "In Your List";
                qz.IsDisabled = true;
            }
            else
            {
                qz.Text = "Take This Quiz";
                qz.IsDisabled = true;
            }
            return qz;
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
