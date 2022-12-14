namespace DelegatesChallenge;

// declare the delegate type used to calculate the fees
public delegate void ShippingFeesDelegate(decimal thePrice, ref decimal fee);

// This is a base class that is used as a foundation 
// for each of the destination zones
abstract class ShippingDestination
{
    public bool m_isHighRisk;
    public virtual void calcFees(decimal price, ref decimal fee) { }

    // This static method returns an actual ShippingDestination object
    // given the name of the destination, or null if none exists
    public static ShippingDestination getDestinationInfo(string dest)
        => dest switch
        {
            "zone1" => new Dest_Zone1(),
            "zone2" => new Dest_Zone2(),
            "zone3" => new Dest_Zone3(),
            "zone4" => new Dest_Zone4(),
            _ => null
        };
}

// Now we define implementation classes for each of the real shipping
// destinations. We can add as many as we like as the need arises

class Dest_Zone1 : ShippingDestination
{
    public Dest_Zone1()
    {
        this.m_isHighRisk = false;
    }
    public override void calcFees(decimal price, ref decimal fee)
    {
        fee = price * 0.25m;
    }
}

class Dest_Zone2 : ShippingDestination
{
    public Dest_Zone2()
    {
        this.m_isHighRisk = true;
    }
    public override void calcFees(decimal price, ref decimal fee)
    {
        fee = price * 0.12m;
    }
}

class Dest_Zone3 : ShippingDestination
{
    public Dest_Zone3()
    {
        this.m_isHighRisk = false;
    }
    public override void calcFees(decimal price, ref decimal fee)
    {
        fee = price * 0.08m;
    }
}

class Dest_Zone4 : ShippingDestination
{
    public Dest_Zone4()
    {
        this.m_isHighRisk = true;
    }
    public override void calcFees(decimal price, ref decimal fee)
    {
        fee = price * 0.04m;
    }
}
