using BlzrQuiz.Data;
using BlzrQuiz.Data.EfClasses;
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
        private BlzrQuizContext _context;

        public QuizService(BlzrQuizContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QuizQuestion>> GetQuizQuestions()
        {
            return await _context.QuizQuestions.Include(a => a.Question.Answers).ToListAsync();
        }
        public async Task<IEnumerable<QuizQuestion>> GetQuizQuestions(int quizId)
        {
            return await _context.QuizQuestions.Where(x => x.QuizId == quizId).Include(a => a.Question.Answers).Take(50).ToListAsync();
        }
        public async Task<UserQuiz> GetUserQuizQuestions(int quizId)
        {
            return await _context.UserQuizes.Include(a => a.Quiz).ThenInclude(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.QuizId == quizId);
        }
        public async Task<UserQuiz> GetUserQuizQuestions(int quizId, string userId)
        {
           return await _context.UserQuizes.Include(a => a.Quiz).ThenInclude(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.QuizId == quizId && x.UserId == userId);
            //return await _context.UserQuizes.Include(a => a.Quiz).ThenInclude(a => a.QuizQuestions).FirstOrDefaultAsync(x => x.QuizId == quizId && x.UserId == userId);
        }
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.Include(a => a.Answers).ToListAsync();
        }
        public async Task<Question> GetQuestion()
        {
            return await _context.Questions.Include(a => a.Answers).FirstAsync();
        }
        public async Task<IEnumerable<Quiz>> GetQuizes()
        {
            return await _context.Quizes.ToListAsync();
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
            return await _context.Certifications.ToListAsync();
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
            var quiz = await _context.Quizes.Include(a => a.QuizQuestions).ThenInclude(a => a.Question).ThenInclude(a => a.Answers).FirstOrDefaultAsync(x => x.CertificationId == certId);

            if (quiz is null)
                quiz = CreateQuiz();

            userQuiz = new UserQuiz { Quiz = quiz, UserId = userName, QuizId = quiz.QuizId };
            _context.UserQuizes.Add(userQuiz);
            _context.SaveChanges();

            return userQuiz;
        }

        public async Task CreateAnswersForUser(UserQuiz userQuiz)
        {
            foreach(var q in userQuiz.Quiz.QuizQuestions)
            {
                foreach (var a in q.Question.Answers) {
                    var uqqa = new UserQuizQuestionAnswer
                    {
                        UserQuiz= userQuiz,
                        QuizQuestion = q,
                        Answer = a
                    };
                   await _context.UserQuizQuestionAnswers.AddAsync(uqqa);
                }
            }
            _context.SaveChanges();
        }
        public void AddOrUpdateAnswersForUserQuiz(QuizQuestion qQuestion, int userQuizId)
        {
            Console.WriteLine($"In CreateAnswersForUser UQQA Count: {qQuestion.UserQuizQuestionAnswers.Count()}");
            var existing = _context.UserQuizQuestionAnswers.Where(x => x.UserQuizId == userQuizId && x.QuizQuestion == qQuestion);
            if (qQuestion.Question.HasMultipleAnswers)
            {
                foreach (var a in existing)
                {
                    if (!qQuestion.UserQuizQuestionAnswers.Contains(a))
                    {
                        _context.UserQuizQuestionAnswers.Remove(a);
                        qQuestion.UserQuizQuestionAnswers.Remove(a);
                    }
                }
                _context.UserQuizQuestionAnswers.AddRange(qQuestion.UserQuizQuestionAnswers);
            }
            else
            {
                var e = existing.First();
                var n = qQuestion.UserQuizQuestionAnswers.First();
                if (e.AnswerId != n.AnswerId)
                {
                    e.AnswerId = n.AnswerId;
                    _context.UserQuizQuestionAnswers.Update(e);
                }
            }
            _context.SaveChanges();
        }
        public async Task CreateAnswersForUser(QuizQuestion qQuestion, int userQuizId)
        {
            Console.WriteLine($"In CreateAnswersForUser UQQA Count: {qQuestion.UserQuizQuestionAnswers.Count()}");
                foreach (var a in qQuestion.UserQuizQuestionAnswers)
                {
                  await _context.UserQuizQuestionAnswers.AddAsync(a);
                }
            _context.SaveChanges();
        }
        public async Task AddUserQuizQuestionAnswer(UserQuizQuestionAnswer entry)
        {
            await _context.UserQuizQuestionAnswers.AddAsync(entry);
           await _context.SaveChangesAsync();
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
