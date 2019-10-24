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
        public  IEnumerable<EF.UserQuiz> UserQuizzes { get; set; } = new List<EF.UserQuiz>();
        private System.Security.Claims.ClaimsPrincipal User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await Auth.GetAuthenticationStateAsync().ConfigureAwait(false);
            User = authState.User;

            UserQuizzes = await QService.GetUserQuizzesById(User.Identity.Name).ConfigureAwait(false);
            if (!UserQuizzes.Any())
            {
                await QService.CreateMultipleSelectionUserQuiz(User.Identity.Name).ConfigureAwait(false);
                await QService.CreateUserQuiz(3, User.Identity.Name).ConfigureAwait(false);
            }
        }
    }
}
