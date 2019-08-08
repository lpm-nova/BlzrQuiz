using BlzrQuiz.Data.EfClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BlzrQuiz.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly BlzrQuiz.Data.BlzrQuizContext _context;

        public CreateModel(BlzrQuiz.Data.BlzrQuizContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Questions.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}