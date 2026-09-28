namespace StudentApp.DataAccess.Models
{
    public class Student : IPerson
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Course { get; set; }
        public string StudentCard { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string RecordBook { get; set; } = string.Empty;

        public void PerformAction()
        {
            
        }
    }
}