using Microsoft.AspNetCore.Components;
using M = BlzrQuiz.Models;
using BlzrQuiz.ServiceLayer;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class CarouselItem
    {
        [Inject]
        protected QuizService QService { get; set; }
        [Inject]
        protected NavigationManager NavManager { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Parameter]
        public List<M.QuizCard> Cards { get; set; }
        [Parameter]
        public System.Security.Claims.ClaimsPrincipal User { get; set; }
        [Parameter]
        public string IsActive { get; set; } = string.Empty;

        public string Text { get; set; }
  
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("initializeCarousel");
            }
        }

    }
}
