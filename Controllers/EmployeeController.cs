using EmployeePortal.Data;
using EmployeePortal.Data.Domain;
using EmployeePortal.Entities.DTO;
using EmployeePortal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(EmployeeDbContext dbContext, IEmployeeRepository employeeRepository)
        {
            this.dbContext = dbContext;
            this.employeeRepository = employeeRepository;
        }

        // Get all employess
        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(employeeRepository.GetAll());
        }

        // Get single record by id
        // GET: https://localhost:7019/api/Employee/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var employeeExisting = employeeRepository.GetById(id);
            if (employeeExisting == null)
            {
                return NotFound();
            }
            return Ok(employeeExisting);
        }

        // add employee
        // POST: api/Employee/
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] AddEmployeeRequestDto employeeDto)
        {
            var employeDomainModel = new Employee
            {
                Id = Guid.NewGuid(),
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary
            };
            employeDomainModel = employeeRepository.CreateEmployee(employeDomainModel);
            // map domain model back to dto
            var employeeDTOs = new EmployeeDto
            {
                Id = employeDomainModel.Id,
                Name = employeDomainModel.Name,
                Email = employeDomainModel.Email,
                PhoneNumber = employeDomainModel.PhoneNumber,
                Salary = employeDomainModel.Salary
            };
            return CreatedAtAction(nameof(GetById), new { id = employeeDTOs.Id }, employeeDto);
        }

        // Update a record
        // Put: api/employee/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id,
            [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            // Map DTO to Domain Model
            var empDomainModel = new Employee
            {
                Name = updateEmployeeDto.Name,
                Email = updateEmployeeDto.Email,
                Salary = updateEmployeeDto.Salary,
                PhoneNumber = updateEmployeeDto.PhoneNumber
            };
            // Check if domain model exists
            empDomainModel = employeeRepository.UpdateEmployee(id, empDomainModel);

            if (empDomainModel == null)
            {
                return NotFound();
            }

            // map domain model back to DTO
            var empDto = new EmployeeDto
            {
                Name = empDomainModel.Name,
                Email = empDomainModel.Email,
                PhoneNumber = empDomainModel.PhoneNumber,
                Salary = empDomainModel.Salary,
            };
            return Ok(empDto);

        }
        // Delete by Id of the emp
        // DELETE
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
           var employeeDomainModel= employeeRepository.DeleteEmployee(id);
            if (employeeDomainModel == null)
            {
                return NotFound();
            }
            // map domain model back to DTO
            var employeeDTO = new EmployeeDto
            {
                Id = employeeDomainModel.Id,
                Name = employeeDomainModel.Name,
                Email = employeeDomainModel.Email,
                Salary = employeeDomainModel.Salary,
                PhoneNumber = employeeDomainModel.PhoneNumber
            };
            return Ok(employeeDTO);
        }




    }
}
