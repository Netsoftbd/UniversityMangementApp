using System.Collections.Generic;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.Repositories
{
    public class DepartmentRepository
    {
        private readonly UniversityDbContext _dbContext;

        public DepartmentRepository()
        {
            _dbContext = new UniversityDbContext();
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments;
        }
    }
}