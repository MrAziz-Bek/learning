using System.ComponentModel;

namespace NETInterfaces;

interface IStorable
{
    void Save();
    void Load();
    bool NeedsSave { get; set; }
}

class Document : IStorable, INotifyPropertyChanged
{
    private string _name;
    private bool mNeedsSave = false;

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropChanged(string propName)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }

    public Document(string name)
    {
        _name = name;
        Console.WriteLine("Created a document with name '{0}'", name);
    }

    public string DocName
    {
        get { return _name; }
        set
        {
            _name = value;
            NotifyPropChanged("DocName");
        }
    }

    public bool NeedsSave
    {
        get { return mNeedsSave; }
        set
        {
            mNeedsSave = value;
            NotifyPropChanged("NeedsSave");
        }
    }

    public void Load()
    {
        Console.WriteLine("Loading the document");

    }

    public void Save()
    {
        Console.WriteLine("Saving the document");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Document d = new Document("Test Document");

        d.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Document property changed: {0}", e.PropertyName);
        };

        d.DocName = "My Document";
        d.NeedsSave = true;

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}