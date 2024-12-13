using System;
public interface IPayment
{
    public void ProcessPayment(decimal amount);
}
public class CreditCard : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using Credit Card.");
    }
}
public class PayPal : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using PayPal.");
    }
}
public class Crypto : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using Cryptocurrency.");
    }
}
public class PaymentContext
{
    private IPayment _paymentType; 

    public PaymentContext(IPayment paymentType)
    {
        _paymentType = paymentType; 
    }

    public void ProcessPayment(decimal amount)
    {
        _paymentType.ProcessPayment(amount);
    }
    public void SetStrategy(IPayment paymentType)
    {
       _paymentType=paymentType;
    }
}

// Client
public class Client
{
    public static void Main(string[] args)
    {
        IPayment paymentType=new PayPal();
        PaymentContext paymentContext = new PaymentContext(paymentType);
        paymentContext.ProcessPayment(100.50m);
        paymentType = new CreditCard();
        paymentContext.SetStrategy(paymentType);
        paymentContext.ProcessPayment(200.75m);
    }
}
