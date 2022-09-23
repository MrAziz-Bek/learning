namespace BasicEvents;

public delegate void myEventHandler(string value);

class EventPublisher
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
        EventPublisher obj = new EventPublisher();
        //obj.valueChanged += new myEventHandler(obj_valueChanged);

        obj.valueChanged += delegate (string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        };

        string str;
        do
        {
            Console.Write("Enter a value: ");
            str = Console.ReadLine();

            if (!str.Equals("exit"))
                obj.Val = str;

        } while (!str.Equals("exit"));

        Console.WriteLine("Goodbye!");
    }

    static void obj_valueChanged(string str)
    {
        Console.WriteLine("The value changed to {0}", str);
    }
}