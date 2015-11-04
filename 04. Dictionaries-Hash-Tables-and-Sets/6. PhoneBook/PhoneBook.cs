namespace _6.PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PhoneBook
    {
        private HashSet<Record> records;

        public PhoneBook(string fileName)
        {
            records = new HashSet<Record>();
            this.ParseFile(fileName);
        }

        private void ParseFile(string fileName)
        {
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                var information = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var names = information[0].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var record = new Record
                {
                    Names = names,
                    City = information[1].Trim(),
                    Phone = information[2].Trim()
                };

                this.records.Add(record);
            }

            file.Close();
        }

        public IEnumerable<Record> Find(string name)
        {
            return this.records.Where(r => r.Names.Contains(name));            
        }

        public IEnumerable<Record> Find(string name, string town)
        {
            return this.Find(name).Where(r => r.City == town);
        }
    }
}
