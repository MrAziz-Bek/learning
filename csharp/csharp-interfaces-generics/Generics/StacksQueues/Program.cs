using System.Collections;
using System.Collections.Generic;

namespace StacksQueues;

class Program
{
    static void Main(string[] args)
    {
        Stack<string> sportsStack = new();

        sportsStack.Push("Baseball");
        sportsStack.Push("Football");
        sportsStack.Push("Cricket");
        sportsStack.Push("Basketball");
        sportsStack.Push("Hockey");
        sportsStack.Push("Rugby");

        Console.WriteLine("There are {0} sports in the stack", sportsStack.Count);
        
        Console.WriteLine("The top item is {0}", sportsStack.Peek());
        
        sportsStack.Pop();
        sportsStack.Pop();
        Console.WriteLine("Stack contains Hockey: {0}", sportsStack.Contains("Hockey"));


        Queue<string> sportsQueue = new();

        sportsQueue.Enqueue("Baseball");
        sportsQueue.Enqueue("Football");
        sportsQueue.Enqueue("Cricket");
        sportsQueue.Enqueue("Basketball");
        sportsQueue.Enqueue("Hockey");
        sportsQueue.Enqueue("Rugby");

        Console.WriteLine("There are {0} sports in the queue", sportsQueue.Count);

        Console.WriteLine("The top item is {0}", sportsQueue.Peek());

        sportsQueue.Dequeue();
        sportsQueue.Dequeue();
        Console.WriteLine("Queue contains Hockey: {0}", sportsQueue.Contains("Hockey"));
    }
}