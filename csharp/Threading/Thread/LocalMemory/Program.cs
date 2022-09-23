using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        //Worker Thread
        new Thread(PrintOneToThirty).Start();

        //Main Thread
        PrintOneToThirty();
    }

    private static void PrintOneToThirty()
    {
        for (int i = 1; i <= 30; i++)
        {
            Console.Write(i + " ");
        }
    }
}