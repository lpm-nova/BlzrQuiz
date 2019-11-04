using BlzrQuiz.Data.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages.UserQuiz
{
    public partial class UserQuizQuestion
    {
        [Parameter] public QuizQuestion ThisQuestion { get; set; }
        [Parameter] public EF.UserQuiz ThisUserQuiz { get; set; }
        [Parameter] public int UserQuizId { get; set; }
        [Parameter] public Dictionary<int, string> ButtonClasses { get; set; }
        private const string ButtonBaseClass = "btn btn-outline-info btn-lg btn-block ";
        private const string ButtonActive = " active";
        //probably going to be a parameter soon

        private void UpdateAnswers(int answerId)
        {
            if (ThisQuestion.UserQuizQuestionAnswers is null)
                ThisQuestion.UserQuizQuestionAnswers = new List<UserQuizQuestionAnswer>();

            if (ThisQuestion.UserQuizQuestionAnswers.Any(x => x.AnswerId == answerId))
            {
                UpdateObject(answerId, 1);
                ButtonClasses[answerId] = ButtonBaseClass;
            }
            else if (ThisQuestion.Question.NumberOfCorrectAnswers > 1)
            {
                UpdateObject(1, answerId);
            }
            else if (ThisQuestion.UserQuizQuestionAnswers.Count == 1)
            {
                var existingAnswer = ThisQuestion.UserQuizQuestionAnswers[0];
                if (answerId != existingAnswer.AnswerId)
                {
                    ButtonClasses[existingAnswer.AnswerId] = ButtonBaseClass;
                    existingAnswer.AnswerId = answerId;
                    ButtonClasses[answerId] = ButtonBaseClass + ButtonActive;
                }
                else
                {
                    ButtonClasses[answerId] = ButtonBaseClass;
                }
            }
            else
            {
                var answer = new UserQuizQuestionAnswer { UserQuiz = ThisUserQuiz, AnswerId = answerId, QuizQuestion = ThisQuestion };
                ThisQuestion.UserQuizQuestionAnswers.Add(answer);
                ButtonClasses[answerId] = ButtonBaseClass + ButtonActive;
            }
        }

        private void UpdateObject(int existingId, int newId)
        {
            var keepLooping = true;
            while (keepLooping)
            {
                var x = ThisQuestion.UserQuizQuestionAnswers.Find(a => a.AnswerId == existingId);
                if (x != null)
                {
                    ButtonClasses[newId] = ButtonBaseClass;
                    x.AnswerId = newId;
                    ButtonClasses[newId] = ButtonBaseClass + ButtonActive;
                    if (existingId == 1)
                        keepLooping = false;
                }else
                {
                    keepLooping = false;
                }
            }
        }
    }
}
