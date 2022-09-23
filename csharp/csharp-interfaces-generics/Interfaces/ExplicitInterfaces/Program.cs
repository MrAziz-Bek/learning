namespace ExplicitInterfaces;

interface Intf1
{
    void SomeMethod();
}

interface Intf2
{
    void SomeMethod();
}

class InterfaceTest : Intf1, Intf2
{
    void Intf1.SomeMethod() 
    {
        Console.WriteLine("This is the Intf1 SomeMethod");
    }
    void Intf2.SomeMethod() 
    {
        Console.WriteLine("This is the Intf2 SomeMethod");
    }

    public void SomeMethod()
    {
        Console.WriteLine("This is the class SomeMethod");
    }
}

class Program
{
    static void Main(string[] args)
    {
        InterfaceTest testClass = new InterfaceTest();
        testClass.SomeMethod();

        Intf1 i1 = testClass as Intf1;
        i1.SomeMethod();

        Intf2 i2 = testClass as Intf2;
        i2.SomeMethod();

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}