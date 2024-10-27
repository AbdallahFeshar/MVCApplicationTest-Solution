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
    public class EmployeeRepository :GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly MVCApplicationDbContext _dbContext;

        public EmployeeRepository(MVCApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetEmployeeByName(string name)
        {
           return _dbContext.Employees.Where(e=>e.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
