using Caltec.StudentInfoProject.Business.Dto;
using Caltec.StudentInfoProject.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltec.StudentInfoProject.Business
{
    public class StudentService : BaseService
    {
        public StudentService(StudentInfoDbContext studentInfoDbContext) : base(studentInfoDbContext)
        {
            
        }
       
        public async Task<List<StudentDto>> GetStudentsAsync(CancellationToken cancellationToken)
        {
            return await StudentInfoDbContext.Students.Select(s => new StudentDto
            {
                Address = s.Address,
                City = s.City,
                ClassName = s.Class.Name,
                Country = s.FirstName,
                Email = s.Email,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Phone = s.Phone,
                State = s.State,
                Zip = s.Zip              
            }).ToListAsync(cancellationToken);
        }
            
    }
}
