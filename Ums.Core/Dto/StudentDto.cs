using Ums.Core.Models;

namespace Ums.Core.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public string Reg { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}