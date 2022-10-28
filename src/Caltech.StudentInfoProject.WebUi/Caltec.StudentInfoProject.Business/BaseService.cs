using Caltec.StudentInfoProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltec.StudentInfoProject.Business
{
    public abstract class BaseService
    {
        public readonly StudentInfoDbContext StudentInfoDbContext;

        public BaseService(StudentInfoDbContext studentInfoDbContext)
        {
            StudentInfoDbContext = studentInfoDbContext;
        }
        
    }
}
