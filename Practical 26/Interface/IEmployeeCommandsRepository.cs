using Practical_26.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Interface
{
    public interface IEmployeeCommandsRepository
    {
        public Task<int> CreateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);

    }
}
