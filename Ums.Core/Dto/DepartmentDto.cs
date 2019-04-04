using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ums.Core.Models;

namespace Ums.Core.Dto
{
    public class DepartmentDto
    {
        public DepartmentDto()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}