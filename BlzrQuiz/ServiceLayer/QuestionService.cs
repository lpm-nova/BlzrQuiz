using BlzrQuiz.Data;
using BlzrQuiz.Data.EfClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.ServiceLayer
{
    public class QuestionService
    {
        private BlzrQuizContext _context;

        public QuestionService(BlzrQuizContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return new Question{ QuestionId = question.QuestionId };
        }
    }
}
