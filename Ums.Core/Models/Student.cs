using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ums.Core.Models
{
    public class Student : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(50)]
        public string Roll { get; set; }
        public string Reg { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}