using System;
using System.Collections.Generic;
using System.Linq;
using ModelsProject.Models;

namespace ServicesManager.Repositories
{
    public class MockStudentRepository : IStudentRepository
    {
        private readonly List<Student> _studentList = new List<Student>();
        public MockStudentRepository()
        {
            InitStudent();
        }
        private void InitStudent()
        {
            for (int i = 1; i <= 10; i++)
            {
                int id = i;
                string name = "Student" + Convert.ToString(i);
                string email = "student" + Convert.ToString(i) + "@gmail.com";
                string dept = "SWE";
                int batch = 2016;
                //Console.WriteLine(id+"    "+name+"    "+email);
                Student student = new Student(id, name, dept, email, batch);
                _studentList.Add(student);
            }
        }

        public Student CreateStudent(Student student)
        {
            student.Id = _studentList.Max( e => e.Id) + 1;
            _studentList.Add(student);
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            Student st = _studentList.FirstOrDefault(e => e.Id == student.Id);
            int idx = _studentList.IndexOf(st);
            _studentList[idx] = student;
            return student;
        }

        public void DeleteStudent(int id)
        {
            Student student = _studentList.FirstOrDefault(e => e.Id == id);
            _studentList.Remove(student);
        }

        public Student RetrieveStudentById(int id)
        {
            return _studentList.FirstOrDefault(e => e.Id == id);
        }

        public List<Student> RetrieveAllStudents()
        {
            return _studentList;
        }
    }
}