using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlzrQuiz.Data;
using BlzrQuiz.Data.EfClasses;

namespace BlzrQuiz.Pages.Answers
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
        public Answer Answer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Answers.Add(Answer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}