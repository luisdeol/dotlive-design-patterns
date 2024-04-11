using DotLiveDesignPatterns.Application.Models;

namespace DotLiveDesignPatterns.Application.Infrastructure.Payments;

public class CreditCardService : IPaymentService
{
    public object Process(OrderInputModel model)
    {
        return "Transação aprovada";
    }
}