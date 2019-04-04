using System.Collections.Generic;

namespace Ums.Core.Models
{
    public class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}