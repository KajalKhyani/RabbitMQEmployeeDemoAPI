using RabbitMQEmployeeDemoAPI.Models;
using RabbitMQEmployeeDemoAPI.RabitMQ;
using RabbitMQEmployeeDemoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMQEmployeeDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public EmployeeController(IEmployeeService employeeService, IRabitMQProducer rabitMQProducer)
        {
            _employeeService = employeeService;
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpPost("addemployee")]
        public Employee AddEmployee(Employee employee)
        {
            var employeeData = _employeeService.AddEmployee(employee);
            _rabitMQProducer.SendEmployeeMessage   (employeeData);
            return employeeData;
        }

    }
}
