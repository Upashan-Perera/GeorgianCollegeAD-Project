using GeorgianCollegeAD_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 

namespace GeorgianCollegeAD_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GeorgianCollegeAD_Project.Models.Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskType> TaskTypes{ get; set; }
        public DbSet<Employee_Task> Employee_Tasks { get; set; }
    }
}