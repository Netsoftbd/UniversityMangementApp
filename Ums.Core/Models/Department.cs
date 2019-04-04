using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ums.Core.Models
{
    public class Department
    {
        public Department()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}