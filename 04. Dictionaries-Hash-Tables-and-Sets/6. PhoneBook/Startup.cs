namespace _6.PhoneBook
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            const string filename = "../../phones.txt";

            var phoneBook = new PhoneBook(filename);

            Console.WriteLine("All records by name - Kireto");
            var recordsByName = phoneBook.Find("Kireto");
            foreach (var record in recordsByName)
            {
                Console.WriteLine(record);
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("All records by name and town - Kireto, Varna");
            var recordsByNameAndTown = phoneBook.Find("Kireto", "Varna");
            foreach (var record in recordsByNameAndTown)
            {
                Console.WriteLine(record);
            }
        }
    }
}
