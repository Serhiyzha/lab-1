using System.Collections.Generic;

namespace StudentApp.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        void SaveToFile(string filePath, List<T> data);
        List<T> LoadFromFile(string filePath);
    }
}