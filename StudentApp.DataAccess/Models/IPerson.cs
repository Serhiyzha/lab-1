namespace StudentApp.DataAccess.Models
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        void PerformAction();
    }
}