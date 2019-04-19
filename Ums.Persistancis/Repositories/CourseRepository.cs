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

        public IEnumerable<Course> Get()
        {
            return _dbContext.Courses;
        }

        public string Save(Course course)
        {
            _dbContext.Courses.Add(course);
            var success = _dbContext.SaveChanges();
            if (success > 0)
            {
                return "Save Success";
            }

            return "Save Fail";
        }
    }
}