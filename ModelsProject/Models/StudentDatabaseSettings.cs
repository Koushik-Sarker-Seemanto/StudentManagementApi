namespace ModelsProject.Models
{
    public class StudentDatabaseSettings: IStudentDatabaseSettings
    {
        // public string StudentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStudentDatabaseSettings
    {
        // string StudentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
    
}