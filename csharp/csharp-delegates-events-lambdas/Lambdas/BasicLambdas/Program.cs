namespace BasicLambdas;

public delegate int MyDelegate(int x);
public delegate void MyDelegate2(int x, string prefix);
public delegate bool ExprDelegate(int x);

class Program
{
    static void Main(string[] args)
    {
        MyDelegate d1 = (x) => x * x;
        Console.WriteLine("The result of d1 is {0}", d1(5));   

        d1 = (x) => x * 10;
        Console.WriteLine("The result of d1 is {0}", d1(5));

        MyDelegate2 d2 = (x, y) => 
        {
            Console.WriteLine("The two-arg lambda: {1}, {0}", x * 10, y);
        };
        d2(25, "Some String");


        ExprDelegate d3 = (x) => x > 10;
        Console.WriteLine("Calling d3 with 5: {0}", d3(5));
        Console.WriteLine("Calling d3 with 15: {0}", d3(15));
    }
}