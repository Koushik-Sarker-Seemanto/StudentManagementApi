using System.Collections.Generic;
using ModelsProject.Models;
using ServicesManager.Repositories;
using ServicesManager.ServiceInterfaces;

namespace ServicesManager.ServiceClasses
{
    public class StudentManager: IStudentManager
    {
        private readonly IStudentRepository _repository;
        
        public StudentManager(IStudentRepository repository)
        {
            _repository = repository;
        }
        
        public Student CreateStudent(Student student)
        {
            _repository.CreateStudent(student);
            return student;
        }

        public List<Student> RetrieveAllStudents()
        {
            return _repository.RetrieveAllStudents();
        }

        public Student RetrieveStudentById(int id)
        {
            return _repository.RetrieveStudentById(id);
        }

        public Student UpdateStudent(Student st)
        {
            return _repository.UpdateStudent(st);
        }

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
    }
}