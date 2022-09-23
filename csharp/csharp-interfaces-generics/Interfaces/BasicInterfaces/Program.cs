namespace BasicInterfaces;

interface IStorable
{
    void Save();
    void Load();
    bool NeedsSave { get; set; }
}

class Document : IStorable
{
    private string _name;

    public Document(string name)
    {
        _name = name;
        Console.WriteLine("Created a document with name '{0}'", name);
    }

    public bool NeedsSave { get; set; }

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

        d.Load();
        d.Save();
        d.NeedsSave = false;

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}