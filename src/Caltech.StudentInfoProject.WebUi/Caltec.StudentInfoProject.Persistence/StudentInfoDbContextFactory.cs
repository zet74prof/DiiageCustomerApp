using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltec.StudentInfoProject.Persistence
{
    internal class StudentInfoDbContextFactory: IDesignTimeDbContextFactory<StudentInfoDbContext>
    {
        public StudentInfoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentInfoDbContext>();
            //string connexionString = "Server = localhost; Database = EduximTest; user=sa;password=SqlAdminPassword@123";
            string connexionString = @"Server=localhost\SQLEXPRESS; Database=studentinfodb; integrated security=true;";


            //string connexionString = "tcp:trainingmanagementsqlserver.Database.windows.net:1433;Initial Catalog=TrainingManagement;Persist Security Info=False;User ID=trainingadmin;Password=DevDb2019!;MultipleActiveResultsSets=False;Encrypt=True;ConnectionTimeout=30;";
            optionsBuilder.UseSqlServer(connexionString);

            return new StudentInfoDbContext(optionsBuilder.Options);
        }
    }
}
