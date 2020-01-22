using System.Collections.Generic;

namespace ModelsProject.Models
{
    public interface IStudentRepository
    {
        Student Insert(Student student);
        void Delete(int id);
        Student Update(Student student);
        Student GetById(int id);
        List<Student> GetAll();
    }
}