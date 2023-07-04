using AutoMapper;
using Practical_26.Interface;
using Practical_26.Model;
using Practical26.Dto;

namespace Practical_26.Repository.CQRS
{
    public class EmployeeCommands : IEmployeeCommands
    {
        private readonly IEmployeeCommandsRepository _employeeCommandsRepository;
        private readonly IMapper _mapper;

        public EmployeeCommands(IEmployeeCommandsRepository employeeCommandsRepository, IMapper mapper)
        {
            _employeeCommandsRepository = employeeCommandsRepository;
            _mapper = mapper;
        }

        public async Task<int> DeleteEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return await _employeeCommandsRepository.DeleteEmployeeAsync(employee);
        }

        public async Task<int> InsertEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return await _employeeCommandsRepository.CreateEmployeeAsync(employee);
        }
        public async Task<int> UpdateEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.Id = id;
            return await _employeeCommandsRepository.UpdateEmployeeAsync(employee);
        }
    }
}
