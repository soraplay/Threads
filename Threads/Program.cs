using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(TestRun));
            //t1.Start();
            Thread t2 = new Thread(new ThreadStart(TestRun));
            //t2.Start();

            t1 = new Thread(new ParameterizedThreadStart(TestParamRun));
            t2 = new Thread(new ParameterizedThreadStart(TestParamRun));

            t1.Start("Первый поток");
            t2.Start("Второй поток");

            Console.WriteLine($"Имя потока: {t1.Name}");
            t1.Name = "Моё имя";
            Console.WriteLine($"Имя потока: {t1.Name}");
            Console.WriteLine($"Статус: {t1.ThreadState}");
            Console.WriteLine($"Приоритет: {t1.Priority}");
            Console.WriteLine($"Поток запущен?: {t1.IsAlive}");


        }
        static void TestRun()
        {
            Random rnd = new Random();
            int delay = rnd.Next(2000);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Новый поток: " + i);
                Thread.Sleep(delay);
            }
        }
        static void TestParamRun(object obj)
        {
            Random rnd = new Random();
            int delay = rnd.Next(2000);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(obj + ":" + i);
                Thread.Sleep(delay);
            }
        }
    }
}
