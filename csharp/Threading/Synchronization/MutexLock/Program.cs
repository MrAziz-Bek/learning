using System.Runtime.ConstrainedExecution;
using System;
using System.Threading;

class Program
{
    static Mutex mutex = new Mutex(false, "csharpMutex");
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread thread = new Thread(AcquireMutex);
            thread.Name = string.Format("Thread{0}", i);
            thread.Start();
        }
    }

    private static void AcquireMutex()
    {
        if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            return;
        }
        // mutex.WaitOne();
        DoSomething();
        mutex.ReleaseMutex();
        Console.WriteLine("Mutex released by {0}", Thread.CurrentThread.Name);
    }

    private static void DoSomething()
    {
        Thread.Sleep(3000);
    }
}