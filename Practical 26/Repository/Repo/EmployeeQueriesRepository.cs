using Microsoft.EntityFrameworkCore;
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
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id && emp.DeleteStatus == false);
            if (employee is not null)
            {
                _context.Entry(employee).State = EntityState.Detached;
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Where(emp => emp.DeleteStatus == false).ToListAsync();
        }
    }
}
