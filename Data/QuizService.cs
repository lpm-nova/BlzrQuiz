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
            return await _context.QuizQuestions.Include(x => x.Question.Answers).Include(x => x.Question.Explanation).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuizQuestions(int quizId)
        {
            return await _context.QuizQuestions.Where(x => x.QuizId == quizId).Include(x => x.Question.Answers).Include(x => x.Question.Explanation).Take(50).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserQuiz>> GetUserQuizzesById(string userId)
        {
            return await _context.UserQuizzes.Where(x => x.UserId == userId).Include(x => x.Quiz).ThenInclude(x => x.Certification).ToListAsync().ConfigureAwait(false);
        }

        public async Task<UserQuiz> GetUserQuizQuestions(int quizId)
        {
            return await _context.UserQuizzes.Include(x => x.Quiz).Include(x => x.Quiz.QuizQuestions).ThenInclude(x => x.Question).ThenInclude(x => x.Answers).FirstOrDefaultAsync(x => x.QuizId == quizId).ConfigureAwait(false);
        }

        public async Task<UserQuiz> GetUserQuizQuestions(int userQuizId, string userId)
        {
            return await _context.UserQuizzes.Include(x => x.UserQuizQuestionAnswers).Include(x => x.Quiz.QuizQuestions).ThenInclude(x => x.Question.Explanation).ThenInclude(x => x.Question.Answers).FirstOrDefaultAsync(x => x.UserQuizId == userQuizId && x.UserId == userId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserQuizQuestionAnswer>> GetUserQuizAnswers(int userQuizId)
        {
            return await _context.UserQuizQuestionAnswers.Where(x => x.UserQuizId == userQuizId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.Include(x => x.Answers).Include(x => x.Explanation).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Question> GetQuestion()
        {
            return await _context.Questions.Include(x => x.Answers).Include(x => x.Explanation).FirstAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Quiz>> GetQuizes()
        {
            return await _context.Quizes.Include(x => x.Certification).ToListAsync().ConfigureAwait(false);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void AddQuestion(Question question)
        {
            Debug.WriteLine($"Question: Id: {question.QuestionId}, Text: {question.Text}");
            _context.Questions.Add(question);
            _context.SaveChangesAsync();
        }

        public Task<Question> GetQuestion(int id)
        {
            return _context.Questions.Include(x => x.QuestionTags).ThenInclude(x => x.Tag).FirstOrDefaultAsync(x => x.QuestionId == id);
        }

        public async Task<IEnumerable<Certification>> GetCertifications()
        {
            return await _context.Certifications.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<CertificationTag>> GetCertificationTagsById(int certId)
        {
            return await _context.CertificationTags.Include(x => x.Tag).Where(x => x.CertificationId == certId).ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetTags()
        {
            return await _context.Tags.ToListAsync().ConfigureAwait(false);
        }

        public async Task AddQuestionTagAsync(int tagId, int questionId)
        {
            if (_context.QuestionTags.Any(x => x.TagId == tagId && x.QuestionId == questionId))
                return;

            var questionTag = new QuestionTag { TagId = tagId, QuestionId = questionId };
            await _context.QuestionTags.AddAsync(questionTag);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveQuestionTagAsync(QuestionTag questionTag)
        {
            _context.QuestionTags.Remove(questionTag);
            await _context.SaveChangesAsync();
        }
        public void DeleteQuestion(Question question)
        {
            Debug.WriteLine($"Question: Id: {question.QuestionId}, Text: {question.Text}");
            _context.Questions.Remove(question);
            _context.SaveChangesAsync();
        }

        public void UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public async Task<UserQuiz> CreateUserQuiz(int certId, string userName)
        {
            UserQuiz userQuiz = null;
            var quiz = await _context.Quizes.Include(x => x.QuizQuestions).ThenInclude(x => x.Question).ThenInclude(x => x.Answers).FirstOrDefaultAsync(x => x.CertificationId == certId).ConfigureAwait(false) ?? CreateQuiz();

            userQuiz = new UserQuiz { Quiz = quiz, UserId = userName, QuizId = quiz.QuizId };
            await _context.UserQuizzes.AddAsync(userQuiz);

            await _context.SaveChangesAsync();
            foreach (var q in userQuiz.Quiz.QuizQuestions)
            {
                await CreateDefaultAnswersForNewUserQuiz(q, userQuiz.UserQuizId).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync();
            return userQuiz;
        }

        public async Task<UserQuiz> CreateMultipleSelectionUserQuiz(string userName)
        {
            var quiz = await CreateMultipleSelectionQuiz().ConfigureAwait(false);

            UserQuiz userQuiz = new UserQuiz { Quiz = quiz, UserId = userName, QuizId = quiz.QuizId };
            await _context.UserQuizzes.AddAsync(userQuiz);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            foreach (var q in userQuiz.Quiz.QuizQuestions)
            {

                await CreateDefaultAnswersForNewUserQuiz(q, userQuiz.UserQuizId);
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
                var correctAnswerCount = qQuestion.Question.Answers.Count(x => x.IsCorrect);
                for (var i = 0; i < correctAnswerCount; i++)
                {
                    await _context.UserQuizQuestionAnswers.AddAsync(new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 }).ConfigureAwait(false);
                }
            }
            else
            {
                await _context.UserQuizQuestionAnswers.AddAsync(new UserQuizQuestionAnswer { UserQuizId = userQuizId, QuizQuestion = qQuestion, AnswerId = 1 }).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void AddOrUpdateAnswersForUserQuiz(QuizQuestion qQuestion, int userQuizId)
        {
            var existing = _context.UserQuizQuestionAnswers.Where(x => x.UserQuizId == userQuizId && x.QuizQuestion == qQuestion).OrderBy(x => x.AnswerId);
            qQuestion.UserQuizQuestionAnswers.OrderBy(x => x.AnswerId);
            _context.SaveChanges();
        }

        public async Task CreateAnswersForUser(QuizQuestion qQuestion)
        {
            foreach (var a in qQuestion.UserQuizQuestionAnswers)
            {
                await _context.UserQuizQuestionAnswers.AddAsync(a).ConfigureAwait(false);
            }
           await _context.SaveChangesAsync();
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