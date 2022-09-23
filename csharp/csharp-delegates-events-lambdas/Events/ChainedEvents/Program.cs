namespace ChainedEvents;

public delegate void myEventHandler(string value);

class EventPublisher
{
    private string _val;

    public event myEventHandler valueChanged;

    public event EventHandler<ObjChangeEventArgs> objChanged;

    public string Val
    {
        set
        {
            this._val = value;
            this.valueChanged(_val);

            this.objChanged(this, new ObjChangeEventArgs()
            {
                propChanged = "Val"
            });
        }
    }
}

class ObjChangeEventArgs : EventArgs
{
    public string propChanged;
}

class Program
{
    static void Main(string[] args)
    {
        EventPublisher obj = new EventPublisher();
        obj.valueChanged += new myEventHandler(changeListener1);
        obj.valueChanged += new myEventHandler(changeListener2);


        obj.valueChanged += delegate (string s)
        {
            Console.WriteLine("This came from anonymous handler");
        };

        obj.objChanged += delegate(object sender, ObjChangeEventArgs e)
        {
            Console.WriteLine("{0} had the {1} property changed", sender.GetType(), e.propChanged);
        };

        string str;
        do
        {
            Console.WriteLine("Enter a value: ");
            str = Console.ReadLine();

            if (!str.Equals("exit"))
                obj.Val = str;

        } while (!str.Equals("exit"));

        Console.WriteLine("Goodbye!");
    }

    static void changeListener1(string value)
    {
        Console.WriteLine("The value changed to {0}", value);
    }
    static void changeListener2(string value)
    {
        Console.WriteLine("I also listen to the event, and got {0}", value);
    }
}