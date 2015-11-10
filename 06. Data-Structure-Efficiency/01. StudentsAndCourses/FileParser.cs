namespace _01.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileParser
    {
        public static SortedDictionary<string, List<Student>> Parse(string filename)
        {
            string line;
            var dictionary = new SortedDictionary<string, List<Student>>();

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                var values = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var course = values[2].Trim();
                var student = new Student()
                {
                    FirstName = values[0].Trim(),
                    LastName = values[1].Trim()
                };

                if (!dictionary.ContainsKey(course))
                {
                    var students = new List<Student>();
                    students.Add(student);
                    dictionary.Add(course, students);
                }
                else
                {
                    dictionary[course].Add(student);
                }
            }

            file.Close();

            return dictionary;
        }
    }
}
