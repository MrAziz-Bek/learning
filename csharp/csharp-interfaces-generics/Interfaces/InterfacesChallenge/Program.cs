namespace InterfacesChallenge;

interface IRandomizable
{
    double GetRandomNum(double dUpperBound);
}

class MyRandomizer : IRandomizable
{
    public double GetRandomNum(double dUpperBound)
    {
        return dUpperBound * (new System.Random()).NextDouble();
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyRandomizer mr = new MyRandomizer();

        string input;
        do
        {
            Console.WriteLine("Enter a number for the upper bound: ");
            input = Console.ReadLine();
            try
            {
                double upperBound = Convert.ToDouble(input);
                Console.WriteLine("Random number between 0 and {1}: {0}", mr.GetRandomNum(upperBound), upperBound);
            }
            catch (Exception e) { }

        } while (!input.Equals("exit"));
    }
}