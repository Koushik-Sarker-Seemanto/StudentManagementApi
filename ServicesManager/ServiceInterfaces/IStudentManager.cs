using System.Collections.Generic;
using ModelsProject.Models;

namespace ServicesManager.ServiceInterfaces
{
    public interface IStudentManager
    {
        Student Create(Student student);
        List<Student> RetriveAll();
        Student RetriveById(int id);
        Student Update(Student st);
        void Delete(int id);

    }
}