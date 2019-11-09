using Microsoft.AspNetCore.Components;
using M = BlzrQuiz.Models;
using BlzrQuiz.ServiceLayer;
using System.Threading.Tasks;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class CarouselItem
    {
        [Inject] 
        protected QuizService QService { get; set; }
        [Inject] 
        protected NavigationManager NavManager { get; set; }
        [Parameter] 
        public M.QuizCard Card { get; set; }

        [Parameter]
        public System.Security.Claims.ClaimsPrincipal User { get; set; }

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
