using DatabaseLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataVisualization.Model
{
    public class EmployeeModel
    {
        internal IEnumerable<Employee> GetEmployeeData()
        {
            return EmployeeFile.GetData();
        }

        internal async Task<IEnumerable<Employee>> GetEmployeeDataAsync()
        {
            return await EmployeeFile.GetDataAsync();
        }
    }
}