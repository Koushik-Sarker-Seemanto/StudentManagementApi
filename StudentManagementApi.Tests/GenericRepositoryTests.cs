// using System;
// using ModelsProject.Models;
// using ServicesManager.Repositories;
// using Xunit;
//
//
// namespace StudentManagementApi.Tests
// {
//     public class GenericRepositoryTests
//     {
//         [Fact]
//         public void Insert_Correctly()
//         {
//             Student student = new Student("1","k","swe","k@g.com",2016);
//             Student expectded = student;
//             
//             GenericRepository repository = new GenericRepository(new StudentDatabaseSettings());
//
//             Student actual = repository.Insert(student);
//             
//             Assert.Equal(expectded,actual);
//         }
//     }
// }