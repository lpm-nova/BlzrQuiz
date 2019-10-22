using BlzrQuiz.Data;
using BlzrQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.ServiceLayer
{
    public class QuizService
    {
        private readonly BlzrQuizContext _context;

        public QuizService(BlzrQuizContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuizQuestions()
        {
            return await _context.QuizQuestions.Include(a => a.Question.Answers).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuizQuestions(int quizId)
        {
            return await _context.QuizQuestions.Where(x => x.QuizId == quizId).Include(a => a.Question.Answers).Take(50).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserQuiz>> GetUserQuizzesById(string userId)
        {
            return await _context.UserQuizzes.Where(x => x.UserId == userId).Include(a => a.Quiz).ThenInclude(a => a.Certification).ToListAsync().ConfigureAwait(false);
        }

        public async Task<UserQuiz> GetUserQuizQuestions(int quizId)
        {
            return await _context.UserQuizzes.Include(a => a.Quiz).ThenInclude(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.QuizId == quizId).ConfigureAwait(false);
        }

        public async Task<UserQuiz> GetUserQuizQuestions(int userQuizId, string userId)
        {
            return await _context.UserQuizzes.Include(a => a.UserQuizQuestionAnswers).Include(a => a.Quiz).ThenInclude(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.UserQuizId == userQuizId && x.UserId == userId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserQuizQuestionAnswer>> GetUserQuizAnswers(int userQuizId)
        {
            return await _context.UserQuizQuestionAnswers.Where(x => x.UserQuizId == userQuizId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.Include(a => a.Answers).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Question> GetQuestion()
        {
            return await _context.Questions.Include(a => a.Answers).FirstAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Quiz>> GetQuizes()
        {
            return await _context.Quizes.ToListAsync().ConfigureAwait(false);
        }

        public void AddQuestion(Question question)
        {
            Debug.WriteLine($"Question: Id: {question.QuestionId}, Text: {question.Text}");
            _context.Questions.Add(question);
            _context.SaveChangesAsync();
        }

        public Task<Question> GetQuestion(int id)
        {
            return _context.Questions.SingleAsync<Question>(e => e.QuestionId == id);
        }

        public async Task<IEnumerable<Certification>> GetCertifications()
        {
            return await _context.Certifications.ToListAsync().ConfigureAwait(false);
        }

        public void DeleteQuestion(Question question)
        {
            Debug.WriteLine($"Question: Id: {question.QuestionId}, Text: {question.Text}");
            _context.Questions.Remove(question);
            _context.SaveChangesAsync();
        }

        public void UpdateQuestion(Question question)//#D
        {
            _context.Questions.Update(question);
            _context.SaveChanges(); //#G
        }

        public async Task<UserQuiz> CreateUserQuiz(int certId, string userName)
        {
            UserQuiz userQuiz = null;
            var quiz = await _context.Quizes.Include(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.CertificationId == certId).ConfigureAwait(false) ?? CreateQuiz();

            userQuiz = new UserQuiz { Quiz = quiz, UserId = userName, QuizId = quiz.QuizId };
            await _context.UserQuizzes.AddAsync(userQuiz);

            await _context.SaveChangesAsync();
            foreach (var q in userQuiz.Quiz.QuizQuestions)
            {
              await  CreateDefaultAnswersForNewUserQuiz(q, userQuiz.UserQuizId).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync();
            return userQuiz;
        }

        public async Task<UserQuiz> CreateMultipleSelectionUserQuiz(string userName)
        {
            var quiz = await CreateMultipleSelectionQuiz().ConfigureAwait(false);
            //var cert = await _context.Certifications.FirstAsync(x => x.Name == "CLF-C01");

            UserQuiz userQuiz = new UserQuiz { Quiz = quiz, UserId = userName, QuizId = quiz.QuizId };
            await _context.UserQuizzes.AddAsync(userQuiz);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            if (userQuiz.UserQuizQuestionAnswers is null)
                userQuiz.UserQuizQuestionAnswers = new List<UserQuizQuestionAnswer>();

            foreach (var q in userQuiz.Quiz.QuizQuestions)
            {
               await  CreateDefaultAnswersForNewUserQuiz(q, userQuiz.UserQuizId);
            }

            await _context.SaveChangesAsync();
            return userQuiz;
        }

        public async Task CreateAnswersForUser(UserQuiz userQuiz)
        {
            foreach (var q in userQuiz.Quiz.QuizQuestions)
            {
                foreach (var a in q.Question.Answers)
                {
                    var uqqa = new UserQuizQuestionAnswer
                    {
                        UserQuiz = userQuiz,
                        QuizQuestion = q,
                        Answer = a
                    };
                    await _context.UserQuizQuestionAnswers.AddAsync(uqqa).ConfigureAwait(false);
                }
            }
            _context.SaveChanges();
        }

        public async Task CreateDefaultAnswersForNewUserQuiz(QuizQuestion qQuestion, int userQuizId)
        {
            if (qQuestion.Question.NumberOfCorrectAnswers > 1)
            {
                Console.WriteLine($"QuestionId: {qQuestion.QuestionId}: Has Question: {qQuestion.Question != null}, Has Answers: {qQuestion?.Question.Answers != null}");
                var correctAnswerCount = qQuestion.Question.Answers.Count(x => x.IsCorrect);
                for (var i = 0; i < correctAnswerCount; i++)
                {
                    Console.WriteLine($"{i + 1} of {qQuestion.Question.NumberOfCorrectAnswers}: {qQuestion.Question.QuestionId}");
                   await _context.UserQuizQuestionAnswers.AddAsync(new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 }).ConfigureAwait(false);
                }
            }
            else
            {
               await _context.UserQuizQuestionAnswers.AddAsync(new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 }).ConfigureAwait(false);
            }
           await _context.SaveChangesAsync().ConfigureAwait(false);
            Console.WriteLine("Leaving");
        }

        public void AddOrUpdateAnswersForUserQuiz(QuizQuestion qQuestion, int userQuizId)
        {
            Console.WriteLine($"In CreateAnswersForUser UQQA Count: {qQuestion.UserQuizQuestionAnswers.Count}");
            var existing = _context.UserQuizQuestionAnswers.Where(x => x.UserQuizId == userQuizId && x.QuizQuestion == qQuestion).OrderBy(x => x.AnswerId);
            qQuestion.UserQuizQuestionAnswers.OrderBy(x => x.AnswerId);
            if (existing?.Count() > 0)
            {
                //if (qQuestion.Question.NumberOfCorrectAnswers > 1)
                //{
                //    var tempList = new List<UserQuizQuestionAnswer>();
                //    foreach (var a in existing)
                //    {

                //        if (!qQuestion.UserQuizQuestionAnswers.Remove(qQuestion.UserQuizQuestionAnswers.First(x => x.AnswerId == a.AnswerId)))
                //        {
                //            tempList.Add(a);
                //            //_context.UserQuizQuestionAnswers.Remove(a);
                //        }
                //    }
                //    foreach(var e in tempList)
                //    {
                //        var n = qQuestion.UserQuizQuestionAnswers[0];

                //        UpdateAnswer(e, n);
                //        qQuestion.UserQuizQuestionAnswers.Remove(n);
                //    }
                //    //_context.UserQuizQuestionAnswers.AddRange(qQuestion.UserQuizQuestionAnswers);
                //}
                //else
                //{
                //    var e = existing.FirstOrDefault();
                //    var n = qQuestion.UserQuizQuestionAnswers.FirstOrDefault();
                var i = 0;

                foreach (var e in existing)
                {
                    if ((qQuestion.UserQuizQuestionAnswers.Count) > i)
                    {
                        var n = qQuestion.UserQuizQuestionAnswers[i];
                        UpdateAnswer(e, n);
                    }
                    else
                    {
                        UpdateAnswer(e, new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 });
                    }
                    i++;
                }
                //if (existing.Count() < qQuestion.Question.NumberOfCorrectAnswers)
                //{
                //    var num = qQuestion.Question.NumberOfCorrectAnswers - existing.Count();
                //    for (var j = 0; j < num; j++)
                //    {
                //        _context.UserQuizQuestionAnswers.Add(new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 });
                //    }
                //}
            }
            else
            {
                if (qQuestion.UserQuizQuestionAnswers.Count > 0)
                {
                    _context.UserQuizQuestionAnswers.AddRange(qQuestion.UserQuizQuestionAnswers);
                }
                else if (qQuestion.Question.NumberOfCorrectAnswers > 1)
                {
                    var correctAnswerCount = qQuestion.Question.Answers.Count(x => x.IsCorrect);
                    for (var i = 0; i < correctAnswerCount; i++)
                    {
                        _context.UserQuizQuestionAnswers.Add(new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 });
                    }
                }
                else
                {
                    _context.UserQuizQuestionAnswers.Add(new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 });
                }
            }
            _context.SaveChanges();
        }

        private void UpdateAnswer(UserQuizQuestionAnswer e, UserQuizQuestionAnswer n)
        {
            if (e != null && n != null)
            {
                //if (e.AnswerId != n.AnswerId)
                //{
                e.AnswerId = n.AnswerId;
                e.QuizQuestion = n.QuizQuestion;
                e.UserQuizId = n.UserQuizId;
                _context.Entry(e).State = EntityState.Modified;
                //}
            }
        }

        public async Task CreateAnswersForUser(QuizQuestion qQuestion)
        {
            Console.WriteLine($"In CreateAnswersForUser UQQA Count: {qQuestion.UserQuizQuestionAnswers.Count}");
            foreach (var a in qQuestion.UserQuizQuestionAnswers)
            {
                await _context.UserQuizQuestionAnswers.AddAsync(a).ConfigureAwait(false);
            }
            _context.SaveChanges();
        }

        public async Task AddUserQuizQuestionAnswer(UserQuizQuestionAnswer entry)
        {
            await _context.UserQuizQuestionAnswers.AddAsync(entry).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public Quiz CreateQuiz()
        {
            var certId = _context.Certifications.First(x => x.Name == "CLF-C01").CertificationId;
            var questions = _context.Questions.Where(x => x.CertificationId == certId).Include(x => x.Answers).Take(50);

            if (questions.Count() == 0)
                throw new Exception("No questions for quiz");

            var quiz = new Quiz { CertificationId = certId, Name = "Test", DateCreated = DateTime.UtcNow };
            _context.Quizes.Add(quiz);
            _context.SaveChanges();
            byte questionNumber = 1;
            foreach (var q in questions)
            {
                _context.QuizQuestions.Add(
                     new QuizQuestion
                     {
                         QuizId = quiz.QuizId,
                         Question = q,
                         QuestionId = q.QuestionId,
                         QuestionNumber = questionNumber++
                     }
                 );

            }
            _context.SaveChanges();
            return quiz;
        }

        public async Task<Quiz> CreateMultipleSelectionQuiz()
        {
            var cert = await _context.Certifications.FirstAsync(x => x.Name == "CLF-C01");
            var questions = _context.Questions.Where(x => x.CertificationId == cert.CertificationId && x.NumberOfCorrectAnswers > 1).Include(x => x.Answers).Take(50);

            if (questions.Count() == 0)
                throw new Exception("No questions for quiz");

            var quiz = new Quiz { CertificationId = cert.CertificationId, Name = "MultiAnswer", DateCreated = DateTime.UtcNow };
            await _context.Quizes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            byte questionNumber = 1;
            foreach (var q in questions)
            {
                await _context.QuizQuestions.AddAsync(
                     new QuizQuestion
                     {
                         QuizId = quiz.QuizId,
                         Question = q,
                         QuestionId = q.QuestionId,
                         QuestionNumber = questionNumber++
                     }
                 );
            }
            await _context.SaveChangesAsync();
            return quiz;
        }
    }
}