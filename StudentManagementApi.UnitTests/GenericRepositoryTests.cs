using System;
using System.Collections.Generic;
using System.Linq;
using ModelsProject.Models;
using MongoDB.Bson;
using ServicesManager.Repositories;
using Xunit;
using Moq;

namespace StudentManagementApi.UnitTests
{
    public class GenericRepositoryTests
    {
        
        public readonly IGenericRepository MockRepository;
        public GenericRepositoryTests()
        {
            // create some mock products to play with
            IList<Student> students = new List<Student>
            {
                new Student { Id = "10", Name = "koushik",
                    Dept = "swe", Email = "k@gmail.com", Batch = 2016},
                new Student { Id = "11", Name = "seemanto",
                    Dept = "swe", Email = "k@gmail.com", Batch = 2016},
                new Student { Id = "12", Name = "rahim",
                    Dept = "swe", Email = "k@gmail.com", Batch = 2016}
            };
 
            // Mock the Products Repository using Moq
            Mock<IGenericRepository> mockRepo = new Mock<IGenericRepository>();

            // Return all the products
            mockRepo.Setup(e => e.GetAll<Student>()).Returns(students);

            // return a product by Id
            mockRepo.Setup(e => e.GetById<Student>(
                It.IsAny<string>())).Returns((string id) => students.Single(x => x.Id == id));
            
            
            mockRepo.Setup(e => e.Insert<Student>(It.IsAny<Student>())).Returns(
                (Student target) =>
                {
                    students.Add(target);
                    return target;
                });
            
            mockRepo.Setup(e => e.Update(It.IsAny<Student>(), It.IsAny<string>())).Returns(
                (Student target, string id) =>
                {
                    var tempStudent = students.FirstOrDefault(e => e.Id == id);
                    int idx = students.IndexOf(tempStudent);
                    students[idx] = target;
                    return target;
                });
            
            mockRepo.Setup(e => e.Delete<Student>(It.IsAny<string>())).Returns(
                (string id) =>
                {
                    var tempStudent = students.FirstOrDefault(e => e.Id == id);
                    students.Remove(tempStudent);
                    return tempStudent;
                });

            this.MockRepository = mockRepo.Object;
        }
        
        
        
        [Fact]
        public void GetById_Mock()
        {
            var actual = this.MockRepository.GetById<Student>("11");
            var expected = new Student {Id = "11", Name = "seemanto", Dept = "swe", Email = "k@gmail.com", Batch = 2016};
            var jsonExpected = expected.ToJson();
            var jsonActual = actual.ToJson();
            Assert.Equal(jsonExpected, jsonActual);
        }
        
        [Fact]
        public void GetAll_Mock()
        {
            var actualStudents = this.MockRepository.GetAll<Student>();
            var jsonActual = actualStudents.ToJson();
            
            IList<Student> expected = new List<Student>
            {
                new Student { Id = "10", Name = "koushik",
                    Dept = "swe", Email = "k@gmail.com", Batch = 2016},
                new Student { Id = "11", Name = "seemanto",
                    Dept = "swe", Email = "k@gmail.com", Batch = 2016},
                new Student { Id = "12", Name = "rahim",
                    Dept = "swe", Email = "k@gmail.com", Batch = 2016}
            };
            
            var jsonExpected = expected.ToJson();
            Assert.Equal(jsonExpected, jsonActual);
        }

        [Fact]
        public void Insert_Mock()
        {
            var newStudent = new Student()
                {Id = "13", Name = "tamim", Dept = "swe", Email = "k@gmail.com", Batch = 2018};

            var actual = this.MockRepository.Insert<Student>(newStudent);
            var expected = newStudent;
            var jsonExpected = expected.ToJson();
            var jsonActual = actual.ToJson();
            Assert.Equal(jsonExpected, jsonActual);
        }
        
        [Fact]
        public void Update_Mock()
        {
            var newStudent = new Student()
                {Id = "12", Name = "wertyuio", Dept = "swe", Email = "k@gmail.com", Batch = 2018};

            var actual = this.MockRepository.Update<Student>(newStudent,"12");
            var expected = newStudent;
            var jsonExpected = expected.ToJson();
            var jsonActual = actual.ToJson();
            Assert.Equal(jsonExpected, jsonActual);
        }
        
        [Fact]
        public void Delete_Mock()
        {
            var actual = this.MockRepository.Delete<Student>("12");
            var expected = new Student {Id = "12", Name = "rahim", Dept = "swe", Email = "k@gmail.com", Batch = 2016};
            var jsonExpected = expected.ToJson();
            var jsonActual = actual.ToJson();
            Assert.Equal(jsonExpected, jsonActual);
        }
        
        
        
        
        
        //
        // [Fact]
        // public void Insert_Correctly()
        // {
        //     var student = new Student("9","s","swe","k@gmail.com",2016);
        //     var expected = student;
        //     IStudentDatabaseSettings settings = new StudentDatabaseSettings();
        //     settings.ConnectionString = "mongodb://localhost:27017";
        //     settings.DatabaseName = "StudentDb";
        //     
        //     var repository = new GenericRepository(settings);
        //     var actual = repository.Insert<Student>(student);
        //     
        //     var jsonActual = actual.ToJson();
        //     var jsonExpected = expected.ToJson();
        //     Assert.Equal(jsonActual, jsonExpected);
        //     
        // }
        //
        //
        // [Fact]
        // public void GetById_Correctly()
        // {
        //     var student = new Student("5","k","swe","k@gmail.com",2016);
        //     var expected = student;
        //     IStudentDatabaseSettings settings = new StudentDatabaseSettings();
        //     settings.ConnectionString = "mongodb://localhost:27017";
        //     settings.DatabaseName = "StudentDb";
        //     
        //     var repository = new GenericRepository(settings);
        //     Student actual = repository.GetById<Student>("5");
        //     // Assert.Equal(expected, actual);
        //     
        //     var jsonActual = actual.ToJson();
        //     var jsonExpected = expected.ToJson();
        //     Assert.Equal(jsonActual, jsonExpected);
        //     
        //     
        // }
        //
        // [Fact]
        // public void Update_Correctly()
        // {
        //     var student = new Student("4","s","swe","k@gmail.com",2016);
        //     var expected = student;
        //     IStudentDatabaseSettings settings = new StudentDatabaseSettings();
        //     settings.ConnectionString = "mongodb://localhost:27017";
        //     settings.DatabaseName = "StudentDb";
        //     
        //     var repository = new GenericRepository(settings);
        //     Student actual = repository.Update<Student>(student,"4");
        //     // Assert.Equal(expected, actual);
        //     
        //     var jsonActual = actual.ToJson();
        //     var jsonExpected = expected.ToJson();
        //     Assert.Equal(jsonActual, jsonExpected);
        //     
        // }
        //
        // [Fact]
        // public void Delete_Correctly()
        // {
        //     var student = new Student("7","s","swe","k@gmail.com",2016);
        //     var expected = student;
        //     IStudentDatabaseSettings settings = new StudentDatabaseSettings();
        //     settings.ConnectionString = "mongodb://localhost:27017";
        //     settings.DatabaseName = "StudentDb";
        //     
        //     var repository = new GenericRepository(settings);
        //     var actual = repository.Delete<Student>("7");
        //     var jsonActual = actual.ToJson();
        //     var jsonExpected = expected.ToJson();
        //     Assert.Equal(jsonActual, jsonExpected);
        //     // Assert.True(expected.Equals(actual));
        // }
        //
    }
}