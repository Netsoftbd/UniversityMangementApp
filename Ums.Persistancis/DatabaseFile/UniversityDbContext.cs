using System.Data.Entity;
using Ums.Core.Models;

namespace Ums.Persistancis.DatabaseFile
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}