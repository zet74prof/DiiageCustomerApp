using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Caltec.StudentInfoProject.Domain;
using Caltec.StudentInfoProject.Persistence;

namespace Caltec.StudentInfoProject.WebUi.Pages.Students.SchoolFees
{
    public class DeleteModel : PageModel
    {
        private readonly Caltec.StudentInfoProject.Persistence.StudentInfoDbContext _context;

        public DeleteModel(Caltec.StudentInfoProject.Persistence.StudentInfoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Caltec.StudentInfoProject.Domain.SchoolFees SchoolFees { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.SchoolFees == null)
            {
                return NotFound();
            }

            var schoolfees = await _context.SchoolFees.FirstOrDefaultAsync(m => m.Id == id);

            if (schoolfees == null)
            {
                return NotFound();
            }
            else 
            {
                SchoolFees = schoolfees;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.SchoolFees == null)
            {
                return NotFound();
            }
            var schoolfees = await _context.SchoolFees.FindAsync(id);

            if (schoolfees != null)
            {
                SchoolFees = schoolfees;
                _context.SchoolFees.Remove(SchoolFees);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
