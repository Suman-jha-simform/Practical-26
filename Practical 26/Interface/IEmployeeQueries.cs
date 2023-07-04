using Practical26.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Interface
{
    public interface IEmployeeQueries
    {
        Task<EmployeeDto?> FindEmployeeById(int id);
        Task<IEnumerable<EmployeeDto>> FindEmployees();
    }
}
