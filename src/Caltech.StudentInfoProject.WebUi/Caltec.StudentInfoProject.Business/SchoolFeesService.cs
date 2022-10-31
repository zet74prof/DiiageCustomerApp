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
    public class SchoolFeesService : BaseService
    {
        public SchoolFeesService(StudentInfoDbContext studentInfoDbContext) : base(studentInfoDbContext)
        {
            
        }
        public async Task<List<SchoolFeesDto>> GetSchoolFeesDtosByStudentIdAsync(long studentId, CancellationToken cancellationToken)
        {
            return await StudentInfoDbContext.SchoolFees.Where(s => s.Student.Id == studentId).Select(s => new SchoolFeesDto()
            {
                Id = s.Id,
                Amount = s.Amount,
                PaymentDate = s.PaymentDate,
                PaymentMethod = s.PaymentMethod,
                PaymentNote = s.PaymentNote,
                PaymentReference = s.PaymentReference,
                PaymentStatus = s.PaymentStatus,
                ClassId = s.Class.Id,
                ClassName = s.Class.Name

            }).ToListAsync(cancellationToken);
        }
    }
}
