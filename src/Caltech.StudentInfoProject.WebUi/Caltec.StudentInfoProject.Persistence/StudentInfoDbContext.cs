using Caltec.StudentInfoProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltec.StudentInfoProject.Persistence
{
    public class StudentInfoDbContext : DbContext
    {
        public StudentInfoDbContext()
        {
            
        }
        public StudentInfoDbContext(DbContextOptions<StudentInfoDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<SchoolFees> SchoolFees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
   
}
