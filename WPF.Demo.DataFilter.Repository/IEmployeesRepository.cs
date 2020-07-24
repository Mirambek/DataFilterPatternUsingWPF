using System.Collections.Generic;
using System.Threading.Tasks;
using WPF.Demo.DataFilter.Model;

namespace WPF.Demo.DataFilter.Repository
{
    public interface IEmployeesRepository
    {
       Task<IEnumerable<Employee>> GetEmployeesAsync();

    }
}