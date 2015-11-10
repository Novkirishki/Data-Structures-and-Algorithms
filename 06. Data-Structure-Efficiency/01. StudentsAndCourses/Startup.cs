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
