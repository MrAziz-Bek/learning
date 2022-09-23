using System.Collections;
using System.Collections.Generic;

namespace GenericList;

class Employee
{
    public string mName;
    public int mSalary;

    public Employee(string name, int salary)
    {
        mName = name;
        mSalary = salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> empList = new(10);

        empList.Add(new Employee("John Doe", 50000));
        empList.Add(new Employee("Jane Smith", 60000));
        empList.Add(new Employee("Nick Slick", 55000));
        empList.Add(new Employee("Mildren Mintz", 70000));


        Console.WriteLine("empList Capacity is: {0}", empList.Capacity);
        Console.WriteLine("empList Count is: {0}", empList.Count);


        if (empList.Exists(HighPay))
            Console.WriteLine("\nHighly paid employee found!\n");

        Employee e = empList.Find(x => x.mName.StartsWith("J"));

        if (e is not null)
            Console.WriteLine("Found Employee whose name starts with J: {0}", e.mName);
        
        empList.ForEach(TotalSalaries);
        Console.WriteLine("Total payroll is: {0}\n", total);

        Console.WriteLine("\nPress Enter key to continue...");
        Console.ReadLine();
    }

    static int total = 0;
    static void TotalSalaries(Employee e)
    {
        total += e.mSalary;
    }

    static bool HighPay(Employee emp)
    {
        return emp.mSalary >= 65000;
    }
}