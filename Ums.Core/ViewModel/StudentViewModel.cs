using System.ComponentModel.DataAnnotations;
using Ums.Core.Models;

namespace Ums.Core.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please Give Student Name")]
        public string Name { get; set; }

        [Display(Name = "Student Roll")]
        [Required(ErrorMessage = "Please Give Roll No")]
        public string Roll { get; set; }

        [Required(ErrorMessage = "Please Give Reg No")]
        public string Reg { get; set; }

        public Department Department { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public Course Course { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }

    }
}