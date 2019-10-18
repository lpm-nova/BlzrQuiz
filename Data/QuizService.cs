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

        public async Task<UserQuiz> GetUserQuizQuestions(int quizId)
        {
            return await _context.UserQuizes.Include(a => a.Quiz).ThenInclude(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.QuizId == quizId).ConfigureAwait(false);
        }

        public async Task<UserQuiz> GetUserQuizQuestions(int quizId, string userId)
        {
            return await _context.UserQuizes.Include(a => a.UserQuizQuestionAnswers).Include(a => a.Quiz).ThenInclude(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.QuizId == quizId && x.UserId == userId).ConfigureAwait(false);
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
            _context.UserQuizes.Add(userQuiz);
            _context.SaveChanges();

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

        public void AddOrUpdateAnswersForUserQuiz(QuizQuestion qQuestion, int userQuizId)
        {
            Console.WriteLine($"In CreateAnswersForUser UQQA Count: {qQuestion.UserQuizQuestionAnswers.Count}");
            var existing = _context.UserQuizQuestionAnswers.Where(x => x.UserQuizId == userQuizId && x.QuizQuestion == qQuestion);
            if (existing?.Count() > 0)
            {
                if (qQuestion.Question.HasMultipleAnswers)
                {
                    foreach (var a in existing)
                    {
                        if (qQuestion.UserQuizQuestionAnswers.Remove(qQuestion.UserQuizQuestionAnswers.Single(x => x.AnswerId == a.AnswerId)))
                        {
                            _context.UserQuizQuestionAnswers.Remove(a);
                        }
                    }
                    _context.UserQuizQuestionAnswers.AddRange(qQuestion.UserQuizQuestionAnswers);
                }
                else
                {
                    var e = existing.FirstOrDefault();
                    var n = qQuestion.UserQuizQuestionAnswers.FirstOrDefault();
                    if (e != null && n != null)
                    {
                        if (e.AnswerId != n.AnswerId)
                        {
                            e.AnswerId = n.AnswerId;
                            e.QuizQuestion = n.QuizQuestion;
                            _context.Entry(e).State = EntityState.Modified;
                        }
                    }
                }
            }
            else
            {
                if (qQuestion.UserQuizQuestionAnswers.Count > 0)
                {
                    _context.UserQuizQuestionAnswers.AddRange(qQuestion.UserQuizQuestionAnswers);
                }
                else if (qQuestion.Question.HasMultipleAnswers)
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
            var questions = _context.Questions.Where(x => x.CertificationId == certId).Take(50);

            if (questions.Count() == 0)
                throw new Exception("No questions for quiz");

            var quiz = new Quiz { CertificationId = certId, Name = "Test", Description = "Desc field is gonna go awaaaaay" };
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
    }
}