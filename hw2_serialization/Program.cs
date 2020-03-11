using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace hw2_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Font font1 = new Font();
            font1.fontName = "Arial";
            font1.fontSize = 15;

            XmlSerializer serializer = new XmlSerializer(typeof(Font));
            FileStream stream = new FileStream("Serialization.xml",
                FileMode.Create, FileAccess.Write, FileShare.Read);
            serializer.Serialize(stream, font1);
            stream.Close();

            Console.WriteLine("Сериализация выполнена успешно.");
            Console.ReadKey();
        }
    }
}
