using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace hw1_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            /*----------    xml    ----------*/
            CarOwner person1 = new CarOwner();
            person1.Person = "Semen";

            CarOwner person2 = new CarOwner();
            person2.Person = "Egorka";


            car_xml car1 = new car_xml();
            car1.number = "AA2020KY";
            car1.name = "Toyota Prius";
            car1.Owner = person1;

            car_xml car2 = new car_xml();
            car2.number = "AA0000II";
            car2.name = "Toyota Prado";
            car2.Owner = person2;
            /*----------    xml_end    ----------*/

            /*----------    binary+soap   ----------*/
            car_binary bcar = new car_binary("AA1111AA", "Lexus");
            /*----------    binary+soap end   ----------*/

            int numb;
            choice:
            Console.Write("1. Выполнить xml сериализацию;\n" +
                "2. Выполнить xml десериализацию;\n" +
                "3. Выполнить Binary сериализацию;\n" +
                "4. Выполнить Binary десериализацию;\n" +
                "5. Выполнить SOAP сериализацию;\n" +
                "6. Выполнить SOAP десериализацию;\n" +
                "7. Выход.\n" +
                "Ваш выбор: ");
            try
            {
                numb = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nНеверное значение! Повторите ввод.\n");
                goto choice;
            }
            Console.WriteLine();
            switch (numb)
            {
                case (1):
                    {
                        xml_serialization();
                        goto choice;
                    }
                case (2):
                    {
                        xml_deserialize();
                        goto choice;
                    }
                case (3):
                    {
                        binary_serialization();
                        goto choice;
                    }
                case (4):
                    {
                        binary_deserialize();
                        goto choice;
                    }
                case (5):
                    {
                        soap_serialization();
                        goto choice;
                    }
                case (6):
                    {
                        soap_deserialize();
                        goto choice;
                    }

                case (7):
                    {
                        Environment.Exit(0);
                        break;
                    }
            }

            void xml_serialization()
            {
                XmlSerializer serializer = new XmlSerializer(typeof(car_xml));

                car_xml instance1 = new car_xml();
                instance1.Cars.Add(car1);
                instance1.Cars.Add(car2);

                FileStream stream = new FileStream("Serialization.xml",
                    FileMode.Create, FileAccess.Write, FileShare.Read);

                serializer.Serialize(stream, instance1);
                stream.Close();
                Console.WriteLine("Сериализация выполнена успешно.\n");
                Console.ReadKey();
            }

            void xml_deserialize()
            {
                try
                {
                    FileStream stream = new FileStream("Serialization.xml",
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read);

                    XmlSerializer serializer = new XmlSerializer(typeof(car_xml));

                    car_xml instance2 = serializer.Deserialize(stream) as car_xml;
                    Console.WriteLine("Десериализация выполнена успешно.\n\nВосстановленные данные:");
                    foreach (var car in instance2.Cars)
                    {
                        Console.WriteLine(car.number + "\t" + car.name + "\t" + car.Owner.Person);
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            void binary_serialization()
            {
                FileStream stream = File.Create("CarData.dat");
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, bcar);
                stream.Close();
                Console.WriteLine("Сериализация выполнена успешно.\n");
                Console.ReadKey();
            }

            void binary_deserialize()
            {
                FileStream stream = File.OpenRead("CarData.dat");
                BinaryFormatter formatter = new BinaryFormatter();
                car_binary car = formatter.Deserialize(stream) as car_binary;
                Console.WriteLine(car.number + "\t" + car.name);
                stream.Close();
                Console.WriteLine("Десериализация выполнена успешно.\n");
                Console.ReadKey();
            }

            void soap_serialization()
            {
                FileStream stream = File.Create("CarData.xml");
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, bcar);
                stream.Close();
                Console.WriteLine("Сериализация выполнена успешно.\n");
                Console.ReadKey();
            }

            void soap_deserialize()
            {
                FileStream stream = File.OpenRead("CarData.xml");
                BinaryFormatter bf = new BinaryFormatter();
                car_binary car = bf.Deserialize(stream) as car_binary;
                Console.WriteLine(car.number + "\t" + car.name);
                stream.Close();
                Console.WriteLine("Десериализация выполнена успешно.\n");
                Console.ReadKey();
            }

        }
    }
}
