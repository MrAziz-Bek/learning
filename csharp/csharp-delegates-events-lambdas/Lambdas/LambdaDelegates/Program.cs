namespace LambdaDelegates;

public delegate void myEventHandler(string value);

class MyClass
{
    private string _val;

    public event myEventHandler valueChanged;


    public string Val
    {
        set
        {
            this._val = value;
            this.valueChanged(_val);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass obj = new();

        obj.valueChanged += (x) =>
        {
            Console.WriteLine("The value changed to {0}", x);
        };

        string str;
        do
        {
            str = Console.ReadLine();
            if (!str.Equals("exit"))
                obj.Val = str;

        } while (!str.Equals("exit"));

        Console.WriteLine("Goodbye!");
    }
}