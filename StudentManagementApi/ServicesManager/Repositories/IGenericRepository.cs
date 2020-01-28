using System.Collections.Generic;

namespace ServicesManager.Repositories
{
    public interface IGenericRepository
    {
        IEnumerable<T> GetAll<T>();
        T GetById<T>(string id);
        T Insert<T>(T record);
        T Delete<T>(string id);
        T Update<T>(T record, string id);
    }
}