using DelegatesChallenge;

namespace AnonymousDelegates;

class Program
{
    static void Main(string[] args)
    {
        ShippingFeesDelegate Del;
        ShippingDestination Dest;

        string zone;
        do
        {
            // get the destination zone
            Console.WriteLine("What is the destination zone?");
            zone = Console.ReadLine();

            // if the user wrote "exit" then terminate the program,
            // otherwise continue 
            if (!zone.Equals("exit"))
            {
                // given the zone, retrieve the associated shipping info
                Dest = ShippingDestination.getDestinationInfo(zone);

                // if there's no associated info, then the user entered
                // an invalid zone, otherwise continue
                if (Dest != null)
                {
                    // ask for the price and convert the string to a decimal number
                    Console.WriteLine("What is the item price?");
                    decimal itemPrice = decimal.Parse(Console.ReadLine());

                    // Each ShippingDestination object has a function called calcFees,
                    // use that as the delegate for calculating the fee
                    Del = Dest.calcFees;

                    // For high-risk zones, we tack on the delegate that adds more
                    if (Dest.m_isHighRisk)
                    {
                        Del += delegate (decimal thePrice, ref decimal itemFee)
                        {
                            itemFee += 25.0m;
                        };
                    }

                    // now all that is left to do is call the delegate and output
                    // the shipping fee to the Console
                    decimal fee = 0.0m;
                    Del(itemPrice, ref fee);
                    Console.WriteLine("The shipping fees are: {0}", fee);
                }

                else
                    Console.WriteLine("Hmm, you seem to have entered an uknown destination. Try again or 'exit'");
            }
        } while (zone != "exit");
    }
}