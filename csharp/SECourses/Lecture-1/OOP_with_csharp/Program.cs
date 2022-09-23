using System.Text;
using System.Diagnostics;
using OOP_with_csharp.dll_test;
using System;

class MainProgram
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        var myCustomPrinter = new PrintToScreenRandomNumber();
        myCustomPrinter.PrintToScreen();
        myCustomPrinter.PrintPrivately();
        myCustomPrinter.PrintToScreenInternal();

        var myCustomPrinter_v2 = new PrintToScreenV2();
        myCustomPrinter_v2.PrintProtected();

        DLL_PrintToScreenRandomNumber myDLLObj = new DLL_PrintToScreenRandomNumber();
        myDLLObj.PrintPrivately();
        myDLLObj.PrintToScreen();

        PrintScreenStatic.PrintToScreenStatic();

        Console.Clear();

        Car myCar = new Car();
        Console.WriteLine($"My Car default Model is: {myCar.Model}");
        myCar.Model = "My 2nd Model Car";
        Console.WriteLine($"My changed Model is: {myCar.Model}");
        Console.WriteLine($"My Car default Price is: {myCar.Price}");
        myCar.Price = 359;
        Console.WriteLine($"My changed Price is: {myCar.Price}");
        Console.WriteLine($"My Car default Brand is: {myCar.SrBrand}");

        Console.WriteLine($"My Car default Year is: {myCar.Year}");
        myCar.Year = 2032;
        Console.WriteLine($"My changed Year is: {myCar.Year}");
        myCar.Year = 3032;
        Console.WriteLine($"My changed Year is: {myCar.Year}");

        // RandomNumberTest_Incorrect_Way();
        RandomNumberTest_Proper_Way();
        Random_Bigger_Dic_Test();
    }

    private static void RandomNumberTest_Incorrect_Way()
    {
        Random myRandom = new Random();
        Dictionary<int, int> dicNumbers = new Dictionary<int, int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < 100000; i++)
        {
            var randNum = myRandom.Next(0, 101);
            try
            {
                dicNumbers.Add(randNum, 1);
            }
            catch (Exception e)
            {
                dicNumbers[randNum]++;
            }
        }
        timer.Stop();
        Console.WriteLine($"Elapsed total milliseconds with Try Catch block: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
    }

    private static void RandomNumberTest_Proper_Way()
    {
        Random myRandom = new Random();
        Dictionary<int, int> dicNumbers = new Dictionary<int, int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < 100000; i++)
        {
            var randNum = myRandom.Next(0, 101);

            if (dicNumbers.ContainsKey(randNum))
                dicNumbers[randNum]++;
            else
                dicNumbers.Add(randNum, 1);
        }
        timer.Stop();
        Console.WriteLine($"Elapsed total milliseconds with Proper way: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
    }

    private static void Random_Bigger_Dic_Test()
    {
        Random myRandom = new Random();
        Dictionary<int, int> dicNumbers = new Dictionary<int, int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < 100000; i++)
        {
            var randNum = myRandom.Next();

            if (dicNumbers.ContainsKey(randNum))
                dicNumbers[randNum]++;
            else
                dicNumbers.Add(randNum, 1);
        }
        timer.Stop();
        Console.WriteLine($"Elapsed total milliseconds with Random_Bigger_Dic_Test: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
        WriteDictionaryToAFileProper(dicNumbers, "WriteDictionaryToAFileProper.txt");
        WriteDictionaryToAFile_Incorrect_Way(dicNumbers, "WriteDictionaryToAFile_Incorrect_Way.txt");
    }

    private static void WriteDictionaryToAFileProper(Dictionary<int, int> dicNumbers, string fileName)
    {
        StringBuilder strBuilder = new StringBuilder();

        Stopwatch timer = new Stopwatch();

        timer.Start();
        foreach (var pairNumber in dicNumbers)
        {
            strBuilder.Append($"number: {pairNumber.Key} has been randomly generated {pairNumber.ToString()} times");
        }
        File.WriteAllText(fileName, strBuilder.ToString());

        timer.Stop();

        Console.WriteLine($"Elapsed total milliseconds with WriteDictionaryToAFileProper: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
    }

    private static void WriteDictionaryToAFile_Incorrect_Way(Dictionary<int, int> dicNumbers, string fileName)
    {
        string str = string.Empty;
        int counter = 0;

        Stopwatch timer = new Stopwatch();

        timer.Start();
        foreach (var pairNumber in dicNumbers)
        {
            str += $"number: {pairNumber.Key} has been randomly generated {pairNumber.ToString()} times{Environment.NewLine}";
            
            if (counter % 1000 == 0)
                Console.Write($"{counter.ToString("N0")}/{dicNumbers.Count.ToString("N0")}\t");
            counter++;
        }
        File.WriteAllText(fileName, str);

        timer.Stop();

        Console.WriteLine($"Elapsed total milliseconds with WriteDictionaryToAFile_Incorrect_Way: {timer.Elapsed.TotalMilliseconds.ToString("N0")}");
    }

    static class PrintScreenStatic
    {
        static Random myRandGen = new Random();
        public static void PrintToScreenStatic()
        {
            for (int startNumber = 0; startNumber < 10; startNumber++)
            {
                Console.WriteLine(string.Concat("PrintToScreenStatic: ", myRandGen.Next(0, 2).ToString("N0")));
            }
        }
    }

    public class PrintToScreenRandomNumber
    {
        Random myRandGen = new Random();
        public void PrintToScreen()
        {
            Console.WriteLine(string.Concat("PrintToScreen: ", myRandGen.Next().ToString("N0")));
        }

        private void PrintToScreenPrivate()
        {
            Console.WriteLine(string.Concat("PrintToScreenPrivate: ", myRandGen.Next().ToString("N0")));
        }

        protected void PrintToScreenProtected()
        {
            Console.WriteLine(string.Concat("PrintToScreenProtected: ", myRandGen.Next().ToString("N0")));
        }

        public void PrintPrivately()
        {
            PrintToScreenPrivate();
        }

        internal void PrintToScreenInternal()
        {
            Console.WriteLine(string.Concat("PrintToScreenInternal: ", myRandGen.Next().ToString("N0")));
        }
    }

    class PrintToScreenV2 : PrintToScreenRandomNumber
    {
        public void PrintProtected()
        {
            PrintToScreenProtected();
            PrintToScreen();
        }
    }

    class Car
    {
        public string Model = "Default Car";
        public string SrBrand;
        public int Price { get; set; }

        private int _Year = 1999;
        public int Year
        {
            get
            {
                if (_Year < 2000)
                    return 2000;
                return _Year;
            }
            set
            {
                _Year = value - 10;
                if (_Year > 3000)
                    _Year = 3000;
            }
        }
    }
}