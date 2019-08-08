using BlzrQuiz.Data.EfClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlzrQuiz.Pages.Questions
{
    public class DeleteModel : PageModel
    {
        private readonly BlzrQuiz.Data.BlzrQuizContext _context;

        public DeleteModel(BlzrQuiz.Data.BlzrQuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Questions.FirstOrDefaultAsync(m => m.QuestionId == id);

            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Questions.FindAsync(id);

            if (Question != null)
            {
                _context.Questions.Remove(Question);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
