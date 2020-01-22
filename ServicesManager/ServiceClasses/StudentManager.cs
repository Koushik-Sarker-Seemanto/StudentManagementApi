using System.Collections.Generic;
using ModelsProject.Models;
using ServicesManager.ServiceInterfaces;

namespace ServicesManager.ServiceClasses
{
    public class StudentManager: IStudentManager
    {
        private IStudentRepository _repository;
        
        public StudentManager(IStudentRepository repository)
        {
            _repository = repository;
        }
        
        public Student Create(Student student)
        {
            _repository.Insert(student);
            return student;
        }

        public List<Student> RetriveAll()
        {
            return _repository.GetAll();
        }

        public Student RetriveById(int id)
        {
            return _repository.GetById(id);
        }

        public Student Update(Student st)
        {
            return _repository.Update(st);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}