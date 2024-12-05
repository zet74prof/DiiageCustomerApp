using Caltec.Dependency.Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltec.Dependency.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly StudentInfoDbContext _studentInfoDbContext;
        public AdminController(StudentInfoDbContext studentInfoDbContext)
        {
            _studentInfoDbContext = studentInfoDbContext;
        }

        [HttpPost]
        public IActionResult ExecuteSqlQuery([FromBody] string query)
        {
            try
            {
                _studentInfoDbContext.Database.ExecuteSqlRaw(query);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
