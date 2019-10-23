using BlzrQuiz.ServiceLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages
{
    public partial class UserQuiz
    {
        [Parameter]
        public int QuizId { get; set; }

        [Parameter]
        public int CertId { get; set; }

        [Inject]
        private QuizService QService { get; set; }

        [Inject] private AuthenticationStateProvider Auth { get; set; }

        private const string Enabled = "btn btn-outline-secondary";
        private const string Disabled = "btn btn-outline-secondary disabled";
        private const string Invisible = " d-none";
        private const string AlertBase = "alert alert-success";
        private string BtnPreviousClasses { get; set; } = Disabled;
        private string BtnNextClasses { get; set; } = Enabled;
        private string BtnSubmitClasses { get; set; } = Disabled + Invisible;
        private string Alert { get; set; } = AlertBase + Invisible;
        private int Score { get; set; }

        private int QLCount;
        private int counter;
        private IEnumerable<EF.QuizQuestion> QuestionList { get; set; } = new List<EF.QuizQuestion>();
        public EF.QuizQuestion UQuestion { get; set; } = new EF.QuizQuestion();
        private EF.UserQuiz ThisUserQuiz { get; set; }
        public string UserName { get; set; } = "No One";

        protected override async Task OnInitializedAsync()
        {
            CertId = 3;
            try
            {
                await GetUserQuiz().ConfigureAwait(false);
                QuestionList = ThisUserQuiz.Quiz.QuizQuestions;
                QLCount = QuestionList.Count() - 1;
                counter = 0;
                UQuestion = QuestionList.ElementAt(0);
                counter = 0;
                SetButtons();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Exception caught in UserQuiz: {ex.Message}");
            }
        }

        protected async Task GetUserQuiz()
        {
            var authState = await Auth.GetAuthenticationStateAsync().ConfigureAwait(false);
            var user = authState.User;
            UserName = user.Identity.Name ?? "Nada";
            ThisUserQuiz = await QService.GetUserQuizQuestions(QuizId, user.Identity.Name).ConfigureAwait(false);

            if (ThisUserQuiz is null)
            {
                if (user.Identity.IsAuthenticated)
                {
                    ThisUserQuiz = await QService.CreateUserQuiz(CertId, user.Identity.Name).ConfigureAwait(false);
                }
            }

            if (ThisUserQuiz.UserQuizQuestionAnswers is null)
                ThisUserQuiz.UserQuizQuestionAnswers = new List<EF.UserQuizQuestionAnswer>();
        }

        private async Task Submit()
        {
            var userAnswers = await QService.GetUserQuizAnswers(ThisUserQuiz.UserQuizId).ConfigureAwait(false);
            userAnswers.OrderBy(x => x.QuizQuestion.QuestionNumber);
            QuestionList.OrderBy(x => x.QuestionNumber);
            var score = 0;
            for (var i = 0; i < QuestionList.Count(); i++)
            {
                var q = QuestionList.ElementAt(i);

                var n = q.Question.Answers.Where(a => a.IsCorrect).Select(x => x.AnswerId);
                var qAnswers = userAnswers.Where(x => x.QuizQuestion.QuestionNumber == q.QuestionNumber);
                foreach (var qa in qAnswers)
                {
                    if (n.Contains(qa.AnswerId))
                        score++;
                }
            }
            Alert = AlertBase;
        }

        private void NextQuestion()
        {
            if (QLCount > counter++)
            {
                UpdateDB();
            }
            else
            {
                --counter;
            }
            SetProperties();
            SetButtons();
            this.StateHasChanged();
        }

        private void UpdateDB()
        {
            if (UQuestion.UserQuizQuestionAnswers is null)
                UQuestion.UserQuizQuestionAnswers = new List<EF.UserQuizQuestionAnswer>();

            QService.AddOrUpdateAnswersForUserQuiz(UQuestion, ThisUserQuiz.UserQuizId);
        }

        private void PreviousQuestion()
        {
            if (counter-- > 0)
            {
                UpdateDB();
            }
            else
            {
                ++counter;
            }
            SetProperties();
            SetButtons();
            this.StateHasChanged();
        }

        private void SetButtons()
        {
            if (counter > 0 && counter < QLCount)
            {
                if (counter == 1)
                {
                    BtnPreviousClasses = Enabled;
                }
                else if (counter == QLCount - 1)
                {
                    BtnNextClasses = Enabled;
                    BtnSubmitClasses = Disabled + Invisible;
                }
            }
            else
            {
                if (counter == QLCount)
                {
                    BtnNextClasses = Disabled + Invisible;
                    BtnSubmitClasses = Enabled;
                    BtnPreviousClasses = Enabled;
                }
                else if (counter == 0)
                {
                    BtnPreviousClasses = Disabled;
                    BtnNextClasses = Enabled;
                }
            }
        }

        private void SetProperties()
        {
            UQuestion = QuestionList.ElementAt(counter);
        }
    }
}