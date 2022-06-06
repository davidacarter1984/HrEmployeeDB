using HrEmployeeDB.Shared;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace HrEmployeeDB.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var employees = db.GetCollection<Shared.Employee>("Employees");
                var departments = db.GetCollection<Shared.Department>("Departments");
                // Create some Departments if none exist
                if (departments.Count() == 0)
                {
                    departments.Insert(new Department { Name = "IT" });
                    departments.Insert(new Department { Name = "HR" });
                    departments.Insert(new Department { Name = "Service Desk" });
                }
                if (employees.Count() == 0)
                {
                    // Create some testEmployees
                    employees.Insert(new Employee
                    {
                        FirstName = "Kelly",
                        LastName = "Munroe",
                        DateOfBirth = new DateTime(1986, 06, 03),
                        Department = departments.FindOne(i => i.Name == "IT"),
                        Address = "Test Address",
                        City = "London"
                    });
                    employees.Insert(new Employee
                    {
                        FirstName = "Jack",
                        LastName = "Reacher",
                        DateOfBirth = new DateTime(1990, 02, 20),
                        Department = departments.FindOne(i => i.Name == "HR"),
                        Address = "Test Address",
                        City = "London"
                    });
                    employees.Insert(new Employee
                    {
                        FirstName = "James",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1975, 08, 09),
                        Department = departments.FindOne(i => i.Name == "Service Desk"),
                        Address = "Test Address",
                        City = "London"
                    });
                }
                // Insert new customer document (Id will be auto-incremented)



                var results = employees.Query().ToList();
                    return results;
                
            }

            return null;
        }
    }
}