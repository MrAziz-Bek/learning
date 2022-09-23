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

class BalanceLogger
{
    public void balanceLog(decimal amount)
    {
        Console.WriteLine("The balance amount is {0}", amount);
    }
}

class BalanceWatcher
{
    public void balanceWatch(decimal amount)
    {
        if (amount > 500.0M)
            Console.WriteLine("You reached your savings goal! You have ");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PiggyBank pb = new PiggyBank();
        BalanceLogger bl = new BalanceLogger();
        BalanceWatcher bw = new BalanceWatcher();

        pb.balanceChanged += bl.balanceLog;
        pb.balanceChanged += bw.balanceWatch;

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