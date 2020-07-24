using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WPF.Demo.DataFilter.Model;
using WPF.Demo.DataFilter.Repository;

namespace WPF.Demo.DataFilter.DAL
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private const string EmployeeFilePath = "employees.json";
        public async Task<IEnumerable<Employee>>  GetEmployeesAsync()
        {
            
            TextReader jsonFileReader = new StreamReader(EmployeeFilePath);
            string text = await jsonFileReader.ReadToEndAsync();
            var employees = JsonConvert.DeserializeObject<Employee[]>(text);
            return employees;
        }
       
        public EmployeesRepository()
        {

        }
    }
}
