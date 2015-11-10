namespace _02.TradeCompany
{
    using System;
    using System.Text;

    public class Article : IComparable<Article>
    {
        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Vendor: " + this.Vendor);
            builder.AppendLine("Title: " + this.Title);
            builder.AppendLine("Barcode: " + this.Barcode);
            builder.AppendLine("Price: " + this.Price);

            return builder.ToString();
        }

        public int CompareTo(Article other)
        {
            return this.Barcode.CompareTo(other.Barcode);
        }
    }
}
