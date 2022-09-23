namespace MultipleInterfaces;

interface IStorable
{
    void Save();
    void Load();
    bool NeedsSave { get; set; }
}

interface IEncryptable
{
    void Encrypt();
    void Decrypt();
}

class Document : IStorable, IEncryptable
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

    public void Encrypt()
    {
        Console.WriteLine("Encrypting the document");
    }

    public void Decrypt()
    {
        Console.WriteLine("Decrypting the document");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Document d = new Document("Test Document");

        d.Load();
        d.Encrypt();
        d.Save();
        d.Decrypt();

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}