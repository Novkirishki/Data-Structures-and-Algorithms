//A text file students.txt holds information about students and their courses in the following format:
//Using SortedDictionary<K, T> print the courses in alphabetical order and for each of them prints the 
//    students ordered by family and then by name:
//Kiril  | Ivanov   | C#
//Stefka | Nikolova | SQL
//Stela  | Mineva   | Java
//Milena | Petrova  | C#
//Ivan   | Grigorov | C#
//Ivan   | Kolev    | SQL
//C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
//Java: Stela Mineva
//SQL: Ivan Kolev, Stefka Nikolova

namespace _01.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static void PrintStudentsForCourse(SortedDictionary<string, List<Student>> dictionary)
        {
            foreach (var pair in dictionary)
            {
                var students = pair.Value.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
                Console.WriteLine("{0}: {1}", pair.Key, string.Join(",", students));
            }
        }

        public static void Main()
        {
            var dict = FileParser.Parse("../../students.txt");
            PrintStudentsForCourse(dict);
        }
    }
}
