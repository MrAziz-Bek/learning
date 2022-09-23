using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Object customLock = new Object();
        Object anotherCustomLock = new Object();
        new Thread(() =>
        {
            lock (customLock)
            {
                Console.WriteLine("Custom Lock obtained");
                Thread.Sleep(2000);
                lock (anotherCustomLock)
                {
                    Console.WriteLine("Another Custom Lock obtained");
                }
            }
        }).Start();

        lock (anotherCustomLock)
        {
            Console.WriteLine("Main Thread obtained Another Custom Lock");
            Thread.Sleep(1000);
            lock (customLock)
            {
                Console.WriteLine("Main Thread obtained Custom Lock");
            }
        }
    }
}