using BlzrQuiz.ServiceLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages.UserQuiz
{
    public partial class Index
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
        private const string ButtonBaseClass = "btn btn-outline-info btn-lg btn-block ";
        private const string ButtonActive = " active";
        private int questionListCount;
        private int counter;
        private string BtnPreviousClasses { get; set; } = Disabled;
        private string BtnNextClasses { get; set; } = Enabled;
        private string BtnSubmitClasses { get; set; } = Disabled + Invisible;
        private string Alert { get; set; } = AlertBase + Invisible;
        private MarkupString Explanation { get; set; }
        private List<string> ExplanationClasses { get; set; } = new List<string> { Invisible, "col-11" };
        private string ExplanationWindig { get; set; } = "+";
        private double Score { get; set; }
        private int CorrectAnswerCount { get; set; }
        private IEnumerable<EF.QuizQuestion> QuestionList { get; set; } = new List<EF.QuizQuestion>();
        public EF.QuizQuestion UQuestion { get; set; } = new EF.QuizQuestion();
        private EF.UserQuiz ThisUserQuiz { get; set; }
        private Dictionary<int, string> ButtonClasses { get; set; } = new Dictionary<int, string>();
        public string UserName { get; set; } = "No One";

        protected override async Task OnInitializedAsync()
        {
            CertId = 3;
            try
            {
                await GetUserQuiz().ConfigureAwait(false);
                QuestionList = ThisUserQuiz.Quiz.QuizQuestions.OrderBy(x => x.QuestionNumber);
                questionListCount = QuestionList.Count() - 1;
                counter = 0;
                SetUserQuizComponentProperties();
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
            if (Alert != AlertBase)
            {
                CorrectAnswerCount = 0;
                Score = 0;
                var userAnswers = await QService.GetUserQuizAnswers(ThisUserQuiz.UserQuizId).ConfigureAwait(false);
                userAnswers.OrderBy(x => x.QuizQuestion.QuestionNumber);
                QuestionList.OrderBy(x => x.QuestionNumber);
                for (var i = 0; i < QuestionList.Count(); i++)
                {
                    var q = QuestionList.ElementAt(i);

                    var n = q.Question.Answers.Where(a => a.IsCorrect).Select(x => x.AnswerId);
                    CorrectAnswerCount += n.Count();
                    var qAnswers = userAnswers.Where(x => x.QuizQuestion.QuestionNumber == q.QuestionNumber);
                    foreach (var qa in qAnswers)
                    {
                        if (n.Contains(qa.AnswerId))
                            Score++;
                    }
                }
                double truncatedScore = Math.Round((Score / (double)CorrectAnswerCount), 2);
                ThisUserQuiz.Score = truncatedScore;
                await QService.Save();
                Alert = AlertBase;
            }
        }

        private async Task NextQuestionAsync()
        {
            if (questionListCount > counter++)
            {
                await QService.Save();
            }
            else
            {
                --counter;
            }
            SetUserQuizComponentProperties();
            SetButtons();
            this.StateHasChanged();
        }

        private async Task PreviousQuestionAsync()
        {
            if (counter-- > 0)
            {
                await QService.Save();
            }
            else
            {
                ++counter;
            }
            SetUserQuizComponentProperties();
            SetButtons();
            if (Alert == AlertBase)
                Alert = AlertBase + Invisible;

            this.StateHasChanged();
        }

        private void SetButtons()
        {
            if (counter > 0 && counter < questionListCount)
            {
                if (counter == 1)
                {
                    BtnPreviousClasses = Enabled;
                }
                else if (counter == questionListCount - 1)
                {
                    BtnNextClasses = Enabled;
                    BtnSubmitClasses = Disabled + Invisible;
                }
            }
            else if (counter == questionListCount)
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

        private void SetUserQuizComponentProperties()
        {
            if (QuestionList != null && (QuestionList.Count() - 1) >= counter)
            {
                UQuestion = QuestionList.ElementAt(counter);
                Explanation = UQuestion.Question.Explanation != null ? UQuestion.Question.Explanation.ToMarkup() : new MarkupString("No explanation available");
                SetButtonClasses();
                if (ExplanationWindig == "-")
                    ToggleExplanation();
            }
        }

        private void SetButtonClasses()
        {
            ButtonClasses.Clear();
            foreach (var q in UQuestion.Question.Answers)
            {
                if (UQuestion.UserQuizQuestionAnswers.Any(x => x.AnswerId == q.AnswerId))
                {
                    ButtonClasses.Add(q.AnswerId, $"{ButtonBaseClass}{ButtonActive}");
                }
                else
                {
                    ButtonClasses.Add(q.AnswerId, ButtonBaseClass);
                }
            }
        }

        private void ToggleExplanation()
        {
            if (ExplanationClasses.Contains(Invisible))
            {
                ExplanationClasses.Remove(Invisible);
                ExplanationWindig = "-";
            }
            else
            {
                ExplanationClasses.Add(Invisible);
                ExplanationWindig = "+";
            }
        }
    }
}