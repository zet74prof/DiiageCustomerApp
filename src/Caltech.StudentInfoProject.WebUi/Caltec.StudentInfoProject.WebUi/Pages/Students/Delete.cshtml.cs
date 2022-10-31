using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Caltec.StudentInfoProject.Domain;
using Caltec.StudentInfoProject.Persistence;
using Caltec.StudentInfoProject.Business;
using Caltec.StudentInfoProject.Business.Dto;

namespace Caltec.StudentInfoProject.WebUi.Pages.Students
{
    public class DeleteModel : StudentModelBase
    {
        public DeleteModel(StudentService service) : base(service)
        {

        }

        [BindProperty]
      public StudentDto Student { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {


            var student = await _service.GetOne(id.Value, CancellationToken.None);

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
            if (id == null )
            {
                return NotFound();
            }
            await _service.DeleteStudentAsync(id.Value, CancellationToken.None);

            return RedirectToPage("./Index");
        }
    }
}
