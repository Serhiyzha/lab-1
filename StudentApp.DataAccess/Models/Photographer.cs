namespace StudentApp.DataAccess.Models
{
    public class Photographer : IPerson
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CameraModel { get; set; } = string.Empty;

        public void PerformAction()
        {
            
        }
    }
}