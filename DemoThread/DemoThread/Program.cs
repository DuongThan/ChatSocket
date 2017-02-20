using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DemoThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread a = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write(0);
                }
            });
            Thread b = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write(1);
                }
            });
            Thread c = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write(2);
                }
            });
            a.Start();
            b.Start();
            c.Start();

            Console.ReadKey();
        }
    }
}
