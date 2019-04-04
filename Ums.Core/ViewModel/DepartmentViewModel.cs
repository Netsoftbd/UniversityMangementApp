using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ums.Core.Models;

namespace Ums.Core.ViewModel
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Give Department Name")]
        [StringLength(50, ErrorMessage = "Department Name Must Be Less Then 50")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "Department Code Less Then 10")]
        public string Code { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}