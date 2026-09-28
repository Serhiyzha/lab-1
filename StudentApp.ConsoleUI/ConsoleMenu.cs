using System;
using System.Collections.Generic;
using System.Linq;
using StudentApp.DataAccess.Models;
using StudentApp.DataAccess.Repositories;

namespace StudentApp.ConsoleUI
{
    public class ConsoleMenu
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly string _filePath = "students.json";

        public ConsoleMenu(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== МЕНЮ КЕРУВАННЯ ===");
                Console.WriteLine("1. Згенерувати та зберегти тестові дані у файл");
                Console.WriteLine("2. Показати всіх студентів з файлу");
                Console.WriteLine("3. Знайти студенток 5-го курсу з Києва");
                Console.WriteLine("0. Вихід");
                Console.Write("\nОберіть пункт: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GenerateAndSaveData();
                        break;
                    case "2":
                        ShowAllStudents();
                        break;
                    case "3":
                        FilterKievFemaleFifthCourseStudents();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Натисніть Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void GenerateAndSaveData()
        {
            var students = new List<Student>
            {
                new Student { FirstName = "Олена", LastName = "Коваль", Course = 5, StudentCard = "KB123456", Gender = "Жіноча", City = "Київ", RecordBook = "101-А" },
                new Student { FirstName = "Анна", LastName = "Шевченко", Course = 5, StudentCard = "KB123457", Gender = "Жіноча", City = "Київ", RecordBook = "102-А" },
                new Student { FirstName = "Марія", LastName = "Бондаренко", Course = 3, StudentCard = "KB123458", Gender = "Жіноча", City = "Київ", RecordBook = "103-Б" },
                new Student { FirstName = "Ірина", LastName = "Лисенко", Course = 5, StudentCard = "KB123459", Gender = "Жіноча", City = "Львів", RecordBook = "104-А" },
                new Student { FirstName = "Олег", LastName = "Петренко", Course = 5, StudentCard = "KB123460", Gender = "Чоловіча", City = "Київ", RecordBook = "105-В" }
            };

            _studentRepository.SaveToFile(_filePath, students);
            Console.WriteLine("\nТестові дані успішно збережено у файл!");
            Console.WriteLine("Натисніть Enter для продовження...");
            Console.ReadLine();
        }

        private void ShowAllStudents()
        {
            var students = _studentRepository.LoadFromFile(_filePath);
            Console.WriteLine("\n--- Список усіх студентів у файлі ---");
            PrintStudents(students);
            Console.WriteLine("\nНатисніть Enter для продовження...");
            Console.ReadLine();
        }

        private void FilterKievFemaleFifthCourseStudents()
        {
            var students = _studentRepository.LoadFromFile(_filePath);

            var filtered = students.Where(s =>
                s.Course == 5 &&
                s.Gender.Equals("Жіноча", StringComparison.OrdinalIgnoreCase) &&
                s.City.Equals("Київ", StringComparison.OrdinalIgnoreCase)
            ).ToList();

            Console.WriteLine($"\n--- Результати пошуку (Знайдено: {filtered.Count}) ---");
            PrintStudents(filtered);

            Console.WriteLine("\nНатисніть Enter для продовження...");
            Console.ReadLine();
        }

        private void PrintStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Дані відсутні або файл порожній.");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"[{s.RecordBook}] {s.LastName} {s.FirstName} | Курс: {s.Course} | Стать: {s.Gender} | Місто: {s.City} | Квиток: {s.StudentCard}");
            }
        }
    }
}