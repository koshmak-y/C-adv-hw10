using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hw4_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string login;
            string password;
            Regex regex;

            string login_pattern = @"^[a-z]+$";
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                regex = new Regex(login_pattern);
                if (!regex.IsMatch(login))
                {
                    Console.WriteLine("Неверный формат логина. Повторите попытку.\n");

                }
            } while (!regex.IsMatch(login));

            string password_pattern = "^[a-z0-9]+$";
            do
            {
                Console.Write("Введите параль: ");
                password = Console.ReadLine();
                regex = new Regex(password_pattern);
                if (!regex.IsMatch(password))
                {
                    Console.WriteLine("Неверный формат пароля. Повторите попытку.\n");

                }
            } while (!regex.IsMatch(password));

            Console.WriteLine($"\nДанные для входа:\nЛогин: {login}\nПароль: {password}");
            Console.ReadKey();
        }
    }
}
