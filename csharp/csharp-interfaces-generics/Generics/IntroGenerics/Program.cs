using System.Collections;
using System.Collections.Generic;

namespace IntorGenerics;

class Program
{
    static void Main(string[] args)
    {
        int total = 0;

        // ArrayList arrList = new ArrayList();
        // arrList.Add(1);
        // arrList.Add(2);
        // arrList.Add(3);
        //arrList.Add("four");

        List<int> arrList = new();
        arrList.Add(1);
        arrList.Add(2);
        arrList.Add(3);
        //arrList.Add("four");

        foreach (var i in arrList)
            total += i;

        Console.WriteLine("The total is {0}\n\n", total);
        
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }
}