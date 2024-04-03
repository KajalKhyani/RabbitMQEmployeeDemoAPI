using RabbitMQEmployeeDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RabbitMQEmployeeDemoAPI.Data
{

    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
