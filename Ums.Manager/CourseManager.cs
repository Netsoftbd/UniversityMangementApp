using System.Collections.Generic;
using Ums.Core.Models;
using Ums.Persistancis.Repositories;

namespace Ums.Manager
{
    public class CourseManager
    {
        private readonly CourseRepository _courseRepository;

        public CourseManager()
        {
            _courseRepository = new CourseRepository();
        }

        public IEnumerable<Course> GetCoursesByDepartment(int departmentId)
        {
            return _courseRepository.GetCoursesByDepartment(departmentId);
        }

        public IEnumerable<Course> Get()
        {
            return _courseRepository.Get();
        }

        public string Save(Course course)
        {
            return _courseRepository.Save(course);
        }
    }
}