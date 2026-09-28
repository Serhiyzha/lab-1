namespace StudentApp.DataAccess.Models
{
    public class Joiner : IPerson
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int WorkshopNumber { get; set; }

        public void PerformAction()
        {
            
        }
    }
}