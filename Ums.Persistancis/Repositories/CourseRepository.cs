using System.Collections.Generic;
using System.Linq;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.Repositories
{
    public class CourseRepository
    {
        private readonly UniversityDbContext _dbContext;

        public CourseRepository()
        {
            _dbContext = new UniversityDbContext();
        }

        public IEnumerable<Course> GetCoursesByDepartment(int departmentId)
        {
            return _dbContext.Courses.Where(c => c.DepartmentId == departmentId);
        }
    }
}