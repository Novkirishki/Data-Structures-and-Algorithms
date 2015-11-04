namespace _6.PhoneBook
{
    using System.Collections.Generic;
    using System.Linq;

    public class Record
    {
        public List<string> Names { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            var name = this.Names.Aggregate((i, j) => i + " " + j);
            return string.Format("{0} | {1} | {2}", name, this.City, this.Phone);
        }
    }
}
