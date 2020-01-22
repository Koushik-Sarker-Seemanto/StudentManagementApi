using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementApi.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        public List<Student> studentList = new List<Student>();
        public MockStudentRepository()
        {
            Init();
        }

        public void Init()
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
                studentList.Add(student);
            }
        }

        public Student Insert(Student student)
        {
            student.Id = studentList.Max( e => e.Id) + 1;
            studentList.Add(student);
            return student;
        }

        public Student Update(Student student)
        {
            Student st = studentList.FirstOrDefault(e => e.Id == student.Id);
            int idx = studentList.IndexOf(st);
            studentList[idx] = student;
            return student;
        }

        public void Delete(int id)
        {
            Student st = studentList.FirstOrDefault(e => e.Id == id);
            studentList.Remove(st);
        }

        public Student GetById(int id)
        {
            return studentList.FirstOrDefault(e => e.Id == id);
        }

        public List<Student> GetAll()
        {
            return studentList;
        }
    }
}