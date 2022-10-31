using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Caltec.StudentInfoProject.Domain;
using Caltec.StudentInfoProject.Persistence;

namespace Caltec.StudentInfoProject.WebUi.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly Caltec.StudentInfoProject.Persistence.StudentInfoDbContext _context;

        public DeleteModel(Caltec.StudentInfoProject.Persistence.StudentInfoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                Student = student;
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
