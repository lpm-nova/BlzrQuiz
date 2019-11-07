using Microsoft.AspNetCore.Components;
using EF = BlzrQuiz.Data.Entities;
using BlzrQuiz.ServiceLayer;
using System.Threading.Tasks;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class QuizCard
    {
        [Inject] 
        protected QuizService QService { get; set; }
        [Inject] 
        protected NavigationManager NavManager { get; set; }
        [Parameter] 
        public EF.Quiz Quiz { get; set; }
        [Parameter] 
        public bool IsDisabled { get; set; }
        private System.Security.Claims.ClaimsPrincipal User { get; set; }

        public string Text { get; set; }
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
