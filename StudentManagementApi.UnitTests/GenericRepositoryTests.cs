using System;
using ModelsProject.Models;
using MongoDB.Bson;
using ServicesManager.Repositories;
using Xunit;

namespace StudentManagementApi.UnitTests
{
    public class GenericRepositoryTests
    {
        [Fact]
        public void Insert_Correctly()
        {
            var student = new Student("9","s","swe","k@gmail.com",2016);
            var expected = student;
            IStudentDatabaseSettings settings = new StudentDatabaseSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "StudentDb";
            
            var repository = new GenericRepository(settings);
            var actual = repository.Insert<Student>(student);
            
            var jsonActual = actual.ToJson();
            var jsonExpected = expected.ToJson();
            Assert.Equal(jsonActual, jsonExpected);
            
        }
        
        [Fact]
        public void GetById_Correctly()
        {
            var student = new Student("5","k","swe","k@gmail.com",2016);
            var expected = student;
            IStudentDatabaseSettings settings = new StudentDatabaseSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "StudentDb";
            
            var repository = new GenericRepository(settings);
            Student actual = repository.GetById<Student>("5");
            // Assert.Equal(expected, actual);
            
            var jsonActual = actual.ToJson();
            var jsonExpected = expected.ToJson();
            Assert.Equal(jsonActual, jsonExpected);
            
        }
        
        [Fact]
        public void Update_Correctly()
        {
            var student = new Student("4","s","swe","k@gmail.com",2016);
            var expected = student;
            IStudentDatabaseSettings settings = new StudentDatabaseSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "StudentDb";
            
            var repository = new GenericRepository(settings);
            Student actual = repository.Update<Student>(student,"4");
            // Assert.Equal(expected, actual);
            
            var jsonActual = actual.ToJson();
            var jsonExpected = expected.ToJson();
            Assert.Equal(jsonActual, jsonExpected);
            
        }
        
        [Fact]
        public void Delete_Correctly()
        {
            var student = new Student("7","s","swe","k@gmail.com",2016);
            var expected = student;
            IStudentDatabaseSettings settings = new StudentDatabaseSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "StudentDb";
            
            var repository = new GenericRepository(settings);
            var actual = repository.Delete<Student>("7");
            var jsonActual = actual.ToJson();
            var jsonExpected = expected.ToJson();
            Assert.Equal(jsonActual, jsonExpected);
            // Assert.True(expected.Equals(actual));
        }
        
    }
}