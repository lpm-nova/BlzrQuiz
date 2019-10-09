using BlzrQuiz.Data;
using BlzrQuiz.Data.EfClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Core
{
    public class QuizCreator
    {
        readonly BlzrQuizContext context;
        public QuizCreator(BlzrQuizContext context)
        {
            this.context = context;
        }

        public bool Create()
        {
            var questions = context.Questions.Take(50);
            if (questions.Count() == 0)
                return false;
            var certId = context.Certifications.First(x => x.Name == "CLF-C01").CertificationId;
            var quiz = new Quiz { CertificationId = certId, Name = "Test", Description = "Desc field is gonna go awaaaaay" };
            context.Quizes.Add(quiz);
            context.SaveChanges();
            byte questionNumber = 1;
            foreach (var q in questions)
            {
                context.QuizQuestions.Add(
                    new QuizQuestion
                    {
                        QuizId = quiz.QuizId,
                        Question = q,
                        QuestionId = q.QuestionId,
                        QuestionNumber = questionNumber++
                    }
                );

            }
            context.SaveChanges();
            return true;
        }
    }
}
