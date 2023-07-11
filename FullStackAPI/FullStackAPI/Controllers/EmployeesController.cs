using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly StackDbContext _stackDbContext;

        public EmployeesController(StackDbContext stackDbContext)
        {
            _stackDbContext = stackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _stackDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await _stackDbContext.Employees.AddAsync(employeeRequest);
            await _stackDbContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
           var employee = await _stackDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id); 

            if (employee == null)
            {
                return NotFound();
            } 
            return Ok(employee);
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
        {
            var employee = await _stackDbContext.Employees.FindAsync(id);
            
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Departament = updateEmployeeRequest.Departament;

            await _stackDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _stackDbContext.Employees.FindAsync(id);
            
            if(employee == null)
            {
                return NotFound();
            }
            _stackDbContext.Employees.Remove(employee);
            await _stackDbContext.SaveChangesAsync();

            return Ok(employee);
        }

    }
}
