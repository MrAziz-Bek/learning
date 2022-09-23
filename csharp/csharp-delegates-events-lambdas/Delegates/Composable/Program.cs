namespace BasicDelegates;

public delegate void MyDelegate(int arg1, int arg2);

class Program
{
    static void func1(int arg1, int arg2)
    {
        string result = (arg1 + arg2).ToString();
        Console.WriteLine("The number from func1 is {0}", result);
    }
    static void func2(int arg1, int arg2)
    {
        string result = (arg1 * arg2).ToString();
        Console.WriteLine("The number from func2 is {0}", result);
    }
    public static void Main(string[] args)
    {
        MyDelegate f1 = func1;
        MyDelegate f2 = func2;

        MyDelegate f1f2 = f1 + f2;

        int a = 10, b = 20;

        Console.WriteLine("Calling the first delegate");
        f1(a, b);
        Console.WriteLine("Calling the first delegate");
        f2(a, b);

        Console.WriteLine("\nCalling the chained delegates");
        f1f2(a, b);

        Console.WriteLine("\nCalling the unchained delegates");
        f1f2 -= f1;
        f1f2(b, b);
    }
}