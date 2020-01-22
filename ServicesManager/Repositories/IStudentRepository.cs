using System.Collections.Generic;
using ModelsProject.Models;

namespace ServicesManager.Repositories
{
    public interface IStudentRepository
    {
        Student CreateStudent(Student student);
        void DeleteStudent(int id);
        Student UpdateStudent(Student student);
        Student RetrieveStudentById(int id);
        List<Student> RetrieveAllStudents();
    }
}