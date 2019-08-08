using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlzrQuiz.Data;
using BlzrQuiz.Data.EfClasses;

namespace BlzrQuiz.Pages.Answers
{
    public class IndexModel : PageModel
    {
        private readonly BlzrQuiz.Data.BlzrQuizContext _context;

        public IndexModel(BlzrQuiz.Data.BlzrQuizContext context)
        {
            _context = context;
        }

        public IList<Answer> Answer { get;set; }

        public async Task OnGetAsync()
        {
            Answer = await _context.Answers.ToListAsync();
        }
    }
}
