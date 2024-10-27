using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCApplicationTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplicationTest.DAL.Contexts
{
    public class MVCApplicationDbContext : IdentityDbContext
    {
        public MVCApplicationDbContext(DbContextOptions<MVCApplicationDbContext> options) : base(options)
        {

        }

        //Old Way
        //public MVCApplicationDbContext()
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server=.;Database=MVCApp;Trusted_Connection=true;");

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        //public DbSet<IdentityUser>  users { get; set; }
        //public DbSet<IdentityRole> roles { get; set; }
    }
}
