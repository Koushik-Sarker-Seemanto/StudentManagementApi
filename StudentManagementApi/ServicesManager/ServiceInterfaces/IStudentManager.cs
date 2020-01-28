using System.Collections.Generic;
using ModelsProject.Models;

namespace ServicesManager.ServiceInterfaces
{
    public interface IStudentManager
    {
        Student CreateStudent(Student student);
        IEnumerable<Student> RetrieveAllStudents();
        Student RetrieveStudentById(string id);
        Student UpdateStudent(Student st);
        void DeleteStudent(string id);

    }
}