// Task 1

using System;
using System.Collections.Generic;
using System.Linq;

namespace FirmManagement
{
    // 1. Користувацький тип "Фірма"
    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }

        public Firm(string name, DateTime foundationDate, string businessProfile, string directorFullName, int employeeCount, string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            DirectorFullName = directorFullName;
            EmployeeCount = employeeCount;
            Address = address;
        }

        public override string ToString()
        {
            return $"Назва: \"{Name}\" | Профіль: {BusinessProfile} | Директор: {DirectorFullName} | " +
                   $"Співробітники: {EmployeeCount} | Дата заснування: {FoundationDate.ToShortDateString()} | Адреса: {Address}";
        }
    }

    class Program
    {
        static void Main(string[] join)
        {
            // Поточна дата для розрахунку часових інтервалів
            DateTime today = DateTime.Today;

            // Тестовий масив фірм
            List<Firm> firms = new List<Firm>
            {
                new Firm("Global IT Solutions", new DateTime(2020, 5, 10), "IT", "John Smith", 250, "London, Baker St. 221B"),
                new Firm("Fast Food Delivery", new DateTime(2025, 2, 1), "Catering", "Walter White", 45, "New York, Wall St. 12"),
                new Firm("Target Marketing Agency", new DateTime(2023, 11, 1), "Маркетинг", "Alice Brown", 120, "London, Piccadilly 45"),
                new Firm("White Tech & Media", new DateTime(2024, 1, 15), "IT", "Robert Black", 150, "Kyiv, Khreshchatyk 1"),
                new Firm("Food & Mood Co.", today.AddDays(-123), "Маркетинг", "James White", 310, "Manchester, Main St. 5"),
                new Firm("Eco Products", new DateTime(2018, 8, 24), "Production", "Anna Green", 80, "London, Green Rd. 8")
            };

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ================= ЗАПИТИ =================

            // Запит 1: Отримати інформацію про всі фірми
            Console.WriteLine("1. Інформація про всі фірми:");
            PrintFirms(firms);

            // Запит 2: Отримати фірми, у яких у назві є слово Food
            // (Використовуємо StringComparison.OrdinalIgnoreCase, щоб ігнорувати регістр)
            var foodFirms = firms.Where(f => f.Name.Contains("Food", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\n2. Фірми, у яких у назві є слово 'Food':");
            PrintFirms(foodFirms);

            // Запит 3: Отримати фірми, які працюють у галузі маркетингу
            var marketingFirms = firms.Where(f => f.BusinessProfile.Equals("Маркетинг", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\n3. Фірми, які працюють у галузі маркетингу:");
            PrintFirms(marketingFirms);

            // Запит 4: Отримати фірми, які працюють у галузі маркетингу або IT
            var marketingOrItFirms = firms.Where(f => f.BusinessProfile.Equals("Маркетинг", StringComparison.OrdinalIgnoreCase) ||
                                                      f.BusinessProfile.Equals("IT", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\n4. Фірми, які працюють у галузі маркетингу або IT:");
            PrintFirms(marketingOrItFirms);

            // Запит 5: Отримати фірми з кількістю співробітників, більшою за 100
            var moreThan100Employees = firms.Where(f => f.EmployeeCount > 100).ToList();
            Console.WriteLine("\n5. Фірми з кількістю співробітників > 100:");
            PrintFirms(moreThan100Employees);

            // Запит 6: Отримати фірми з кількістю співробітників у діапазоні від 100 до 300
            var rangeEmployees = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300).ToList();
            Console.WriteLine("\n6. Фірми з кількістю співробітників від 100 до 300:");
            PrintFirms(rangeEmployees);

            // Запит 7: Отримати фірми, які знаходяться в Лондоні
            var londonFirms = firms.Where(f => f.Address.Contains("London", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\n7. Фірми, які знаходяться в Лондоні:");
            PrintFirms(londonFirms);

            // Запит 8: Отримати фірми, у яких прізвище директора White
            // (Перевіряємо, чи повне ім'я закінчується на "White" або містить його як окреме слово)
            var directorWhite = firms.Where(f => f.DirectorFullName.EndsWith("White", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\n8. Фірми, у яких прізвище директора White:");
            PrintFirms(directorWhite);

            // Запит 9: Отримати фірми, які засновані більше двох років тому
            var olderThanTwoYears = firms.Where(f => f.FoundationDate < today.AddYears(-2)).ToList();
            Console.WriteLine("\n9. Фірми, які засновані більше двох років тому:");
            PrintFirms(olderThanTwoYears);

            // Запит 10: Отримати фірми, з дня заснування яких минуло рівно 123 дні
            var exactly123DaysAgo = firms.Where(f => (today - f.FoundationDate).Days == 123).ToList();
            Console.WriteLine("\n10. Фірми, з дня заснування яких минуло 123 дні:");
            PrintFirms(exactly123DaysAgo);

            // Запит 11: Отримати фірми, у яких прізвище директора Black і назва фірми містить слово White
            var blackDirectorWhiteFirm = firms.Where(f => f.DirectorFullName.EndsWith("Black", StringComparison.OrdinalIgnoreCase) &&
                                                          f.Name.Contains("White", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\n11. Фірми з директором Black та 'White' у назві:");
            PrintFirms(blackDirectorWhiteFirm);
        }

        // Допоміжний метод для виведення списку фірм на екран
        static void PrintFirms(List<Firm> targetList)
        {
            if (targetList == null || targetList.Count == 0)
            {
                Console.WriteLine("   [Нічого не знайдено]");
                return;
            }

            foreach (var firm in targetList)
            {
                Console.WriteLine($" * {firm}");
            }
        }
    }
}