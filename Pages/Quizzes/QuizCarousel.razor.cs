using System;
using BlzrQuiz.Data.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using M = BlzrQuiz.Models;
using EF = BlzrQuiz.Data.Entities;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlzrQuiz.Pages.Quizzes
{
    public partial class QuizCarousel
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Parameter] 
        public System.Security.Claims.ClaimsPrincipal User { get; set; }
        //[Parameter]
        //public Dictionary<int, bool> ButtonDisabled { get; set; } = new Dictionary<int, bool>();
        //[Parameter] 
        //public Dictionary<int, string> ButtonsText { get; set; } = new Dictionary<int, string>();
        [Parameter]
        public List<M.QuizCard> Quizzes { get; set; } = new List<M.QuizCard>();
        public RenderFragment ChildContent { get; set; }


        //protected override async Task OnInitializedAsync()
        //{


        //}
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("initializeCarousel");
            }
        }



        //private void AddNewButton(int quizId)
        //{
        //    ButtonsText.Add(quizId, "Take This Quiz");
        //    ButtonDisabled.Add(quizId, false);
        //}
    }
}
