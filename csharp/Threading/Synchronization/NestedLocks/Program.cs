using System;
using System.Threading.Tasks;

class Program
{
    static Object customLock = new Object();
    static void Main(string[] args)
    {
        lock (customLock)
        {
            DoSth();
        }
    }

    private static void DoSth()
    {
        lock (customLock)
        {
            Task.Delay(2000);
            AnotherMethod();
        }
    }

    private static void AnotherMethod()
    {
        lock (customLock)
        {
        }
    }
}