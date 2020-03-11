using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;

namespace hw5_text
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> Products = new List<Product>();
            Products.Add(new Product("Бананы", "10.12", new DateTime(2020, 1, 5)));
            Products.Add(new Product("Кокосы", "10.13", new DateTime(2020, 1, 6)));
            Products.Add(new Product("Арбуз", "10.14", new DateTime(2020, 1, 7)));

            RegionInfo regionInfo = RegionInfo.CurrentRegion;
            Console.WriteLine(regionInfo.NativeName);
            foreach (Product item in Products)
            {
                Console.WriteLine($"{item.name}\t {item.price} {regionInfo.CurrencyEnglishName}\t {item.date.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern)}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(new String('-', 43));
            Console.WriteLine(Environment.NewLine);

            CultureInfo USregion = CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine(USregion.NativeName);
            NumberFormatInfo USformat = (NumberFormatInfo)NumberFormatInfo.GetInstance(USregion);
            foreach (Product item in Products)
            {
                Console.WriteLine($"{item.name}\t {item.price} {USformat.CurrencySymbol}\t {item.date.ToString(USregion.DateTimeFormat.ShortDatePattern)}");
            }
            Console.ReadKey();
        }
    }

    public class Product
    {
        public string name { get; set;}
        public string price { get; set; }
        public DateTime date { get; set; }

        public Product(string name, string price, DateTime date)
        {
            this.name = name;
            this.price = price;
            this.date = date;
        }
    }
}
