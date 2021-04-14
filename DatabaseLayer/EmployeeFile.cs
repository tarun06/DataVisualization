using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public static class EmployeeFile
    {
        static EmployeeFile()
        {
            EmployeeDataFilePath =
             Path.GetFullPath(
               Path.Combine(
                 System.AppDomain.CurrentDomain.BaseDirectory,
                 @"..\..\..\DatabaseLayer\EmployeeData.json"));
        }

        private static string EmployeeDataFilePath { get; }

        public static IEnumerable<Employee> GetData()
        {
            return new EmployeeDataLoader().GetData(EmployeeDataFilePath);
        }

        public async static Task<IEnumerable<Employee>> GetDataAsync()
        {
            return await new EmployeeDataLoader().GetDataAsync(EmployeeDataFilePath);
        }
    }
}