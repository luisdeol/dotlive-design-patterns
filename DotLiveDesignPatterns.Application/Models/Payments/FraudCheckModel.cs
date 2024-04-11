namespace DotLiveDesignPatterns.Application.Models.Payments;

public class FraudCheckModel
{
    public decimal TotalAmount { get; private set; }
    public Guid CustomerId { get; private set; }
    public string CustomerName { get; private set; }
    public string CustomerDocument { get; private set; }
}