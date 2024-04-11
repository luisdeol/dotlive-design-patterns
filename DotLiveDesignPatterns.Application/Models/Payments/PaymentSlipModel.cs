namespace DotLiveDesignPatterns.Application.Models.Payments;

public class PaymentSlipModel
{
    public PaymentSlipModel()
    {
        
    }
    public PaymentSlipModel(string barCode, string ourNumber, DateTime expiresAt, DateTime processedAt, 
        decimal documentAmount, Payer payer, Receiver receiver)
    {
        BarCode = barCode;
        OurNumber = ourNumber;
        ExpiresAt = expiresAt;
        ProcessedAt = processedAt;
        DocumentAmount = documentAmount;
        Payer = payer;
        Receiver = receiver;
    }

    public string BarCode { get; set; }
    public string OurNumber { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime ProcessedAt { get; set; }
    public decimal DocumentAmount { get; set; }
    public Payer Payer { get; set; }
    public Receiver Receiver { get; set; }
}

public class Payer {
    public Payer(string fullName, string document, string fullAddress)
    {
        FullName = fullName;
        Document = document;
        FullAddress = fullAddress;
    }

    public string FullName { get; set; }
    public string Document { get; set; }
    public string FullAddress { get; set; }
}

public class Receiver {
    public Receiver(string fullName, string document, string fullAddress)
    {
        FullName = fullName;
        Document = document;
        FullAddress = fullAddress;
    }

    public string FullName { get; set; }
    public string Document { get; set; }
    public string FullAddress { get; set; }
}