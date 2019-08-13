using BlzrQuiz.Data.EfClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlzrQuiz.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly BlzrQuiz.Data.BlzrQuizContext _context;

        public IndexModel(BlzrQuiz.Data.BlzrQuizContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get; set; }

        public async Task OnGetAsync()
        {
            Question = await _context.Questions.ToListAsync();
        }
    }
}
