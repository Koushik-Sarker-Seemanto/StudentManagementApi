using System.Collections.Generic;
using ModelsProject.Models;
using MongoDB.Driver;
using ServicesManager.Repositories;
using ServicesManager.ServiceInterfaces;

namespace ServicesManager.ServiceClasses
{
    public class StudentManager: IStudentManager
    {
        // private readonly IStudentRepository _repository;
        private readonly IGenericRepository _repository;
        
        // private IMongoCollection<Student> _collection;
        // private IMongoClient _client;
        // private IMongoDatabase _database;
        
        public StudentManager( IGenericRepository repository)
        {
            _repository = repository;
        }
        
        public Student CreateStudent(Student student)
        {
            // _repository.CreateStudent(student);
            _repository.Insert(student);
            return student;
        }

        public IEnumerable<Student> RetrieveAllStudents()
        {
            // return _repository.RetrieveAllStudents();
            var temp = _repository.GetAll<Student>();
            return temp;
        }

        public Student RetrieveStudentById(string id)
        {
            return _repository.GetById<Student>(id);
        }

        public Student UpdateStudent(Student st)
        {
            string id = st.Id;
            return _repository.Update<Student>(st, id);
        }

        public void DeleteStudent(string id)
        {
            _repository.Delete<Student>(id);
        }
    }
}