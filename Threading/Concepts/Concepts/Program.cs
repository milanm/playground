using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concepts
{
    class Program
    {
        static bool done;
        static readonly object locker = new object();

        static void Main()
        {
            new Thread(Go).Start();
            Go();

            new Thread(() =>
            {
                Console.WriteLine("I'm running on another thread!");
                Console.WriteLine("This is so easy!");
            }).Start();

            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                new Thread(() => Console.Write(temp)).Start();
            }

            Console.ReadLine();
        }

        static void Go()
        {
            lock (locker)
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }
    }
}
