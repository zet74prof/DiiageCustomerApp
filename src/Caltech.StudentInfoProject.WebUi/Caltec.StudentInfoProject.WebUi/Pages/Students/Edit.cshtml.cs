using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caltec.StudentInfoProject.Domain;
using Caltec.StudentInfoProject.Persistence;
using Caltec.StudentInfoProject.Business;
using Caltec.StudentInfoProject.Business.Dto;

namespace Caltec.StudentInfoProject.WebUi.Pages.Students
{
    public class EditModel : StudentModelBase
    {
        private readonly StudentClassService _studentClassService;
        public EditModel(StudentService service, StudentClassService studentClassService) : base(service)
        {
            _studentClassService = studentClassService;
        }

        [BindProperty]
        public StudentDto Student { get; set; } = default!;
        public List<SelectListItem> StudentClasses { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || ! await StudentExists(id.Value))
            {
                return NotFound();
            }

            var student = await _service.GetOne(id.Value, CancellationToken.None);
            var studentClassesDto = await _studentClassService.GetAllStudentClassesAsync(CancellationToken.None);
            StudentClasses = studentClassesDto.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _service.UpdateAsync(Student, CancellationToken.None);
            return RedirectToPage("./Index");
        }

        private async Task<bool> StudentExists(long id)
        {
            try
            {
                var t = await _service.GetOne(id, CancellationToken.None);
                    return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
