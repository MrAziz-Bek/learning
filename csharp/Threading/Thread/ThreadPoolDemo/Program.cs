using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

        Employee employee = new Employee();
        employee.Name = "Azizbek Boboyev";
        employee.CompanyName = "Microsoft";

        ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

        var processorCount = Environment.ProcessorCount;
        Console.WriteLine("ProcessorCount: {0}", processorCount);
        ThreadPool.SetMaxThreads(processorCount * 2, processorCount * 2);

        int workerThreads = 0, completionPortThreads = 0;
        ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);

        ThreadPool.SetMaxThreads(workerThreads * 2, completionPortThreads * 2);

        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

        Console.ReadKey();
    }

    private static void DisplayEmployeeInfo(object state)
    {
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
        Employee emp = state as Employee;
        Console.WriteLine("Person name is {0} and company name is {1}", emp.Name, emp.CompanyName);
    }
}

public class Employee
{
    public string Name { get; set; }
    public string CompanyName { get; set; }
}