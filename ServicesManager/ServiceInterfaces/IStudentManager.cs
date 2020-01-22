using System.Collections.Generic;
using ModelsProject.Models;

namespace ServicesManager.ServiceInterfaces
{
    public interface IStudentManager
    {
        Student CreateStudent(Student student);
        List<Student> RetrieveAllStudents();
        Student RetrieveStudentById(int id);
        Student UpdateStudent(Student st);
        void DeleteStudent(int id);

    }
}