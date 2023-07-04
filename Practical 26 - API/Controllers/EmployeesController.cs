using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practical_26.Interface;
using Practical26.Dto;

namespace Practical_26___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeCommands _employeeCommands;
        private readonly IEmployeeQueries _employeeQueries;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeCommands employeeCommands, IEmployeeQueries employeeQueries, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _employeeCommands = employeeCommands;
            _employeeQueries = employeeQueries;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetStudentsAsync()
        {
            var employees = await _employeeQueries.FindEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet("{id:int}", Name = "GetEmployeeByIdAsync")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeQueries.FindEmployeeById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeDto createEmployee)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            await _employeeCommands.InsertEmployee(createEmployee);
            var createdEmployeeToReturn = _mapper.Map<EmployeeDto>(createEmployee);

            return CreatedAtRoute("GetEmployeeByIdAsync", new { id = createdEmployeeToReturn.Id }, createdEmployeeToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployee)
        {
            var employeeEntity = await _employeeQueries.FindEmployeeById(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            await _employeeCommands.UpdateEmployee(id, updateEmployee);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployeeAsync(int id)
        {
            var employeeEntity = await _employeeQueries.FindEmployeeById(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            await _employeeCommands.DeleteEmployee(employeeEntity);
            return NoContent();
        }
    }
}
