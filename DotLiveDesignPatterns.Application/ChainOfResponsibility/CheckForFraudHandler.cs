using DotLiveDesignPatterns.Application.Infrastructure.Payments;
using DotLiveDesignPatterns.Application.Models;

namespace DotLiveDesignPatterns.Application.ChainOfResponsibility;

public class CheckForFraudHandler : OrderHandlerBase, IOrderHandler
{
    private readonly IPaymentFraudCheckService _paymentFraudCheckService;
    public CheckForFraudHandler(IPaymentFraudCheckService paymentFraudCheckService)
    {
        _paymentFraudCheckService = paymentFraudCheckService;
    }

    public override bool Handle(OrderInputModel model)
    {
        Console.WriteLine($"Invoking CheckForFraudHandler.Handle");

        var isFraud = _paymentFraudCheckService.IsFraud(model);

        return !isFraud && base.Handle(model);
    }
}