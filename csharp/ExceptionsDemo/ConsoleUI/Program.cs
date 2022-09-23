using ExceptionsLibrary;


DemoCode demo = new DemoCode();

try
{
	int result = demo.GrandparentMethod(4);
    Console.WriteLine($"The value at the givin position is {result}");
}
catch (ArgumentException ex)
{
    Console.WriteLine("You gave us bad information. Bad user!");
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);

    var inner = ex.InnerException;

    while(inner is not null)
    {
        Console.WriteLine(inner.StackTrace);
        inner = inner.InnerException;
    }
}

Console.ReadLine();