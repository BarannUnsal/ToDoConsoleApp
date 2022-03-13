using System;
using ToDo_App_Business_Abstract;
using ToDo_App_Methods;

namespace ToDo_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Method method = new Method();

            method.Start();
            int select = Convert.ToInt32(Console.ReadLine());
            while (method.CheckNumber(select))
            {
                if (select == 1)
                {
                    method.ListBoard();
                    break;
                }
                else if (select == 2)
                {
                    method.AddBoard();
                    break;
                }
                else if (select == 3)
                {
                    method.DeleteBoard();
                    break;
                }
                else if (select == 4)
                {
                    method.MoveCard();
                    break;
                }
                else if (select == 5)
                {
                    method.AddPerson();
                    break;
                }
                else if (select == 6)
                {
                    Console.WriteLine("Çıkış yapıyorsunuz.");
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı seçim yaptınız.");
                }
            }

            Console.WriteLine("ToDo Uygulaması Version 1.0");
            int saat = DateTime.Now.Hour;
            if (saat < 16)
                Console.WriteLine("İyi Günler!");
            else if (saat < 21)
                Console.WriteLine("İyi Akşamlar!");
            else if (saat < 5)
                Console.WriteLine("İyi Geceler!");
            Console.WriteLine("ToDo uygulamasından çıkıyorsunuz.");
        }
    }
}
