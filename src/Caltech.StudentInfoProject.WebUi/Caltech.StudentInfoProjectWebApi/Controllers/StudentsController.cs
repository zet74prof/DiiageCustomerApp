using Caltec.Dependency.Dal;
using Caltec.Dependency.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltec.Dependency.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentInfoDbContext _studentInfoDbContext;
        public StudentsController(StudentInfoDbContext studentInfoDbContext)
        {
            _studentInfoDbContext = studentInfoDbContext;
        }

        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            // TODO: Implement logic to retrieve all students
            return _studentInfoDbContext.Students.ToList();
        }

        // GET api/students/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _studentInfoDbContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST api/students
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            // TODO: Implement logic to create a new student
            _studentInfoDbContext.Students.Add(student);
            _studentInfoDbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/students/{id}
        [HttpPut("{id}")]
        public ActionResult<Student> Put(int id, [FromBody] Student student)
        {
            var existingStudent = _studentInfoDbContext.Students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Address = student.Address;
            existingStudent.City = student.City;
            existingStudent.State = student.State;
            existingStudent.Zip = student.Zip;
            existingStudent.Phone = student.Phone;
            existingStudent.Email = student.Email;


            _studentInfoDbContext.SaveChanges();

            return existingStudent;
        }

        // DELETE api/students/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // TODO: Implement logic to delete a student by id
            _studentInfoDbContext.Students.RemoveRange(_studentInfoDbContext.Students.ToList());
            return Ok();
        }
    }
}
