using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using hw2_serialization;
using System.IO;

namespace hw3_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Font));
            StreamReader stream = new StreamReader(@"C:\Users\e.koshmak\source\repos\C-adv-hw10\hw2_serialization\bin\Debug\Serialization.xml");
            Font font1;
            font1 = serializer.Deserialize(stream) as Font;
            stream.Close();
            Console.WriteLine("Результат десериализации:\n\n" +
                $"Имя шрифта: {font1.fontName}\t" +
                $"Размер шрифта: {font1.fontSize}.");
            Console.ReadKey();
        }

    }
}
