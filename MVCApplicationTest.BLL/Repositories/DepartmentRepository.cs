using Microsoft.EntityFrameworkCore;
using MVCApplicationTest.BLL.Interfaces;
using MVCApplicationTest.DAL.Contexts;
using MVCApplicationTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplicationTest.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly MVCApplicationDbContext _dbContext;
        public DepartmentRepository(MVCApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext= dbContext;
        }

        public IQueryable<Department> GetDepartmentByName(string name)
        {
            return _dbContext.Departments.Where(d => d.Name.ToLower().Contains(name.ToLower()));

        }
    }
}
