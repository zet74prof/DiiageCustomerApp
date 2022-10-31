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
    public class StudentListModel : StudentModelBase
    {
        public StudentListModel(StudentService service) : base(service)
        {
            
        }

        public IList<StudentDto> Students { get;set; } = default!;

        public async Task OnGetAsync()
        {

            Students = await _service.GetStudentsAsync(CancellationToken.None);

        }
    }
}
