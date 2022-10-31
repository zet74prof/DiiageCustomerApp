using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Caltec.StudentInfoProject.Persistence;
using Caltec.StudentInfoProject.Business;
using Caltec.StudentInfoProject.Business.Dto;

namespace Caltec.StudentInfoProject.WebUi.Pages.Students
{
    public class DetailsModel : StudentModelBase
    {
        private readonly SchoolFeesService _schoolFeesService;
        public DetailsModel(StudentService service, SchoolFeesService schoolFeesService) : base(service)
        {
            _schoolFeesService = schoolFeesService;
        }
     

      public StudentDto Student { get; set; }
        public List<SchoolFeesDto> SchoolFees { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _service.GetOne(id.Value, CancellationToken.None);
            
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            SchoolFees = await _schoolFeesService.GetSchoolFeesDtosByStudentIdAsync(id.Value, CancellationToken.None);
            return Page();
        }
    }
}
