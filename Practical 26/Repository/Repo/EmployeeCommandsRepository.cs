using Practical_26.Database;
using Practical_26.Interface;
using Practical_26.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Repository.Repo
{
    public class EmployeeCommandsRepository : IEmployeeCommandsRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            var employeeEntity = await _context.Employees.FindAsync(employee.Id);
            if (employeeEntity != null)
            {
                employeeEntity.DeleteStatus = true;
                _context.Employees.Update(employeeEntity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
