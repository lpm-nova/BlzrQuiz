using BlzrQuiz.Data;
using BlzrQuiz.Data.EfClasses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
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

            //return new Question{ QuestionId = question.QuestionId };
        }
    }
}
