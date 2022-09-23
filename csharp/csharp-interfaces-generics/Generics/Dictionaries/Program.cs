using System.Collections;
using System.Collections.Generic;

namespace Dictionaries;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> fileTypes = new();

        fileTypes.Add(".txt", "Text File");
        fileTypes.Add(".htm", "HTML Web Page");
        fileTypes.Add(".html", "HTML Web Page");
        fileTypes.Add(".css", "Cascading Style Sheet");
        fileTypes.Add(".xml", "XML Data");


        Console.WriteLine("There are {0} key/value pairs\n", fileTypes.Count);


        try
        {
            fileTypes.Add(".htm", "Web Page");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Key already exists");
        }


        fileTypes.Remove(".css");
        Console.WriteLine("fileTypes contains CSS: {0}", fileTypes.ContainsKey(".css"));


        Console.WriteLine("Dumping dictionary contents:");
        foreach (KeyValuePair<string, string> kvp in fileTypes)
        {
            Console.WriteLine("Key={0}, Value={1}", kvp.Key, kvp.Value);
        }


        Console.WriteLine("\nHit Enter to continue...");
        Console.ReadLine();
    }
}