using RabbitMQEmployeeDemoAPI.Models;
using RabbitMQEmployeeDemoAPI.Data;

namespace RabbitMQEmployeeDemoAPI.Services
{

    public class EmployeeService:IEmployeeService
    {
        private readonly DbContextClass _dbContext;

        public EmployeeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }


        public Employee AddEmployee(Employee employee)
        {
            var result = _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();   
            return result.Entity;
        }
    }
}
