﻿using BlzrQuiz.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using EF = BlzrQuiz.Data.Entities;

namespace BlzrQuiz.Pages
{
    public partial class UserQuizQuestion
    {
        [Parameter] public QuizQuestion ThisQuestion { get; set; }
        [Parameter] public EF.UserQuiz ThisUserQuiz { get; set; }
        [Parameter] public int UserQuizId { get; set; }
        [Parameter] public Dictionary<int, string> ButtonClasses { get; set; }
        public Action OnSomeEvent { get; set; }
        private const string ButtonBaseClass = "btn btn-outline-info btn-lg btn-block ";
        private const string ButtonActive = " active";
        //probably going to be a parameter soon

        private void UpdateAnswers(int answerId)
        {
            if (ThisQuestion.UserQuizQuestionAnswers is null)
                ThisQuestion.UserQuizQuestionAnswers = new List<UserQuizQuestionAnswer>();

            if (ThisQuestion.Question.NumberOfCorrectAnswers > 1)
            {
                if (ThisQuestion.UserQuizQuestionAnswers.Any(x => x.AnswerId == answerId))
                {
                    ThisQuestion.UserQuizQuestionAnswers = ThisQuestion.UserQuizQuestionAnswers.Except(ThisQuestion.UserQuizQuestionAnswers.Where(x => x.AnswerId == answerId)).ToList();
                    ButtonClasses[answerId] = ButtonBaseClass;
                }
                else
                {
                    if (ThisQuestion.UserQuizQuestionAnswers.Count < ThisQuestion.Question.NumberOfCorrectAnswers)
                    {
                        ThisQuestion.UserQuizQuestionAnswers.Add(new UserQuizQuestionAnswer { UserQuizId = UserQuizId, AnswerId = answerId, QuizQuestion = ThisQuestion });
                        ButtonClasses[answerId] = ButtonBaseClass + ButtonActive;
                    }
                    else
                    {
                        var x = ThisQuestion.UserQuizQuestionAnswers.Find(a => a.AnswerId == 1);
                        if (x != null)
                        {
                            x.AnswerId = answerId;
                        }
                    }
                }
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
            OnSomeEvent?.Invoke();
        }


    }
}