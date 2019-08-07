using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlzrQuiz.Data;
using BlzrQuiz.Data.EfClasses;

namespace BlzrQuiz.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly BlzrQuiz.Data.BlzrQuizContext _context;

        public IndexModel(BlzrQuiz.Data.BlzrQuizContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; }

        public async Task OnGetAsync()
        {
            Question = await _context.Questions.ToListAsync();
        }
    }
}
