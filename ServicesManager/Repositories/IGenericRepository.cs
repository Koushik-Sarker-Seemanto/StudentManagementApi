using System.Collections.Generic;

namespace ServicesManager.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Insert(T record);
        T Delete(string id);
        T Update(T record, string id);
    }
}