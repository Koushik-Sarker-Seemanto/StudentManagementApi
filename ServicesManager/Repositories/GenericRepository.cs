using System.Collections.Generic;
using ModelsProject.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ServicesManager.Repositories
{
    public class GenericRepository: IGenericRepository
    {
        // private IMongoCollection<> _collection;
        // private IMongoCollection<T> _collection;
        private IMongoClient _client;
        private IMongoDatabase _database;
        public GenericRepository(IStudentDatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
            
            // _collection = _database.GetCollection<T>("Students");
        }


        public IEnumerable<T> GetAll<T>()
        {
            string tableName = typeof(T).Name;
            IMongoCollection<T> _collection = _database.GetCollection<T>(tableName + "s");
            var all = _collection.Find(new BsonDocument());
            return all.ToEnumerable();
        }
        public T GetById<T>(string id)
        {
            string tableName = typeof(T).Name;
            IMongoCollection<T> _collection = _database.GetCollection<T>(tableName + "s");
            var filter = Builders<T>.Filter.Eq("Id", id);
            return  _collection.Find(filter).FirstOrDefault();
        }

        public T Insert<T>(T record)
        {
            string tableName = typeof(T).Name;
            IMongoCollection<T> _collection = _database.GetCollection<T>(tableName + "s");
            _collection.InsertOne(record);
            return record;
        }

        public T Delete<T>(string id)
        {
            string tableName = typeof(T).Name;
            IMongoCollection<T> _collection = _database.GetCollection<T>(tableName + "s");
            var filter = Builders<T>.Filter.Eq("Id", id);
            var record = _collection.FindOneAndDelete(filter);
            return record;
        }

        public T Update<T>(T record, string id)
        {
            string tableName = typeof(T).Name;
            IMongoCollection<T> _collection = _database.GetCollection<T>(tableName + "s");
            var filter = Builders<T>.Filter.Eq("Id", id);
            var updated = _collection.ReplaceOne(filter, record);
            return record;
        }
    }
}