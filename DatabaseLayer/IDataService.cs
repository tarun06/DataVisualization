using System.Threading.Tasks;

namespace DatabaseLayer
{
    internal interface IDataService<T>
    {
        T GetData(string filePath);

        Task<T> GetDataAsync(string filePath);
    }
}