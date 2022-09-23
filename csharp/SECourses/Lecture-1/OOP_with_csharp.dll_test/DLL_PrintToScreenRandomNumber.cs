namespace OOP_with_csharp.dll_test;

public class DLL_PrintToScreenRandomNumber
{
    Random myRandGen = new Random();
    public void PrintToScreen()
    {
        Console.WriteLine(string.Concat("PrintToScreen: ", myRandGen.Next().ToString("N0")));
    }

    private void PrintToScreenPrivate()
    {
        Console.WriteLine(string.Concat("PrintToScreenPrivate: ", myRandGen.Next().ToString("N0")));
    }

    protected void PrintToScreenProtected()
    {
        Console.WriteLine(string.Concat("PrintToScreenProtected: ", myRandGen.Next().ToString("N0")));
    }

    public void PrintPrivately()
    {
        PrintToScreenPrivate();
    }

    internal void PrintToScreenInternal()
    {
        Console.WriteLine(string.Concat("PrintToScreenInternal: ", myRandGen.Next().ToString("N0")));
    }
}
