using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class EmployeeDataLoader : IDataService<IEnumerable<Employee>>
    {
        public IEnumerable<Employee> GetData(string filePath)
        {
            var fileText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(fileText);
        }

        public async Task<IEnumerable<Employee>> GetDataAsync(string filePath)
        {
            using (var reader = File.OpenText(filePath))
            {
                var fileText = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Employee>>(fileText);
            }
        }
    }
}