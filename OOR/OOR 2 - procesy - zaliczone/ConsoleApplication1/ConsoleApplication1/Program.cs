using System;
using System.Threading;

namespace CSharp_Samples
{
    public class SemaphoreSample
    {
        // tworzy objekt semaphore, tylko 3 miejsca dostepne

        static Semaphore semaphoreObject = new Semaphore(3, 4);

        private static void DoWork()
        {
            Console.WriteLine("{0} czeka w kolejce na slot", Thread.CurrentThread.Name);

            // watek czeka na dostepne miejsce
            semaphoreObject.WaitOne();

            Console.WriteLine("{0} Zajmuje slot", Thread.CurrentThread.Name);

            // symuluje prace przez czekanie 1 sek
            Thread.Sleep(1000);

            Console.WriteLine("{0} Opuszcza slot", Thread.CurrentThread.Name);

            // wykonuje miejsce
            semaphoreObject.Release();
        }

        public static void Main()
        {
            // tworzy 10 watkow, nazywa
            // startuje prace na watkach
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(DoWork);
                thread.Name = "Wątek_" + i;
                thread.Start();
            }
            Console.ReadLine();
        }
    }
}