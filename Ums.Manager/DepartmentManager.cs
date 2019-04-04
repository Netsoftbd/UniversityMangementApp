using System.Collections.Generic;
using Ums.Core.Models;
using Ums.Persistancis.Repositories;

namespace Ums.Manager
{
    public class DepartmentManager
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentManager()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
    }
}