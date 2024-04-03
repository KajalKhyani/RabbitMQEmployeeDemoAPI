using RabbitMQEmployeeDemoAPI.Models;

namespace RabbitMQEmployeeDemoAPI.Services
{
    public interface IEmployeeService
    {
        public Employee AddEmployee(Employee employee);

    }
}
