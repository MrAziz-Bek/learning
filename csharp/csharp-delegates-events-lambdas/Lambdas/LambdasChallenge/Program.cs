namespace EventsChallenge;

public delegate void BalanceEventHandler(decimal value);

class PiggyBank
{
    private decimal m_bankBalance;
    public event BalanceEventHandler balanceChanged;

    public decimal Balance
    {
        set
        {
            m_bankBalance = value;
            balanceChanged(value);
        }
        get
        {
            return m_bankBalance;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PiggyBank pb = new PiggyBank();

        pb.balanceChanged += (amount) => Console.WriteLine("The balance amount is {0}", amount);
        pb.balanceChanged += (amount) => { if (amount > 500.0M) Console.WriteLine("You reached your savings goal! You have "); };

        string input;

        do
        {
            Console.WriteLine("How much to deposit?");

            input = Console.ReadLine();
            if (!input.Equals("exit"))
                pb.Balance += decimal.Parse(input);

        } while (!input.Equals("exit"));
    }
}