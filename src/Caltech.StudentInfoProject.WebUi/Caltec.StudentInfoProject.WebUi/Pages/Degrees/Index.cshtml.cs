using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Caltec.StudentInfoProject.Domain;
using Caltec.StudentInfoProject.Persistence;

namespace Caltec.StudentInfoProject.WebUi.Pages.Degrees
{
    public class IndexModel : PageModel
    {
        private readonly Caltec.StudentInfoProject.Persistence.StudentInfoDbContext _context;

        public IndexModel(Caltec.StudentInfoProject.Persistence.StudentInfoDbContext context)
        {
            _context = context;
        }

        public IList<Degree> Degree { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Degrees != null)
            {
                Degree = await _context.Degrees.ToListAsync();
            }
        }
    }
}
