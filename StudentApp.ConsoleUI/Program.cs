using StudentApp.DataAccess.Models;
using StudentApp.DataAccess.Repositories;

namespace StudentApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Student> repository = new JsonFileRepository<Student>();
            
            ConsoleMenu menu = new ConsoleMenu(repository);
            
            menu.Run();
        }
    }
}