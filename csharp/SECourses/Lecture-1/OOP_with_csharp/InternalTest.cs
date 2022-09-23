using System;

public class InternalTest
{
    public void internalTest()
    {
        MainProgram myProgram = new MainProgram();
        MainProgram.PrintToScreenRandomNumber anotherPrinter = new MainProgram.PrintToScreenRandomNumber();
        anotherPrinter.PrintToScreenInternal();
    }
}