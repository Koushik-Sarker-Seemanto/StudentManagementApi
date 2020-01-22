namespace ModelsProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        
        public string Email { get; set; }
        public int Batch { get; set; }
        
        public Student()
        {
            
        }

        public Student(int id, string name, string dept, string email, int batch)
        {
            this.Id = id;
            this.Name = name;
            this.Dept = dept;
            this.Email = email;
            this.Batch = batch;
        }
    }
}