using DotLiveDesignPatterns.Application.ChainOfResponsibility;
using DotLiveDesignPatterns.Application.Infrastructure.Payments;
using DotLiveDesignPatterns.Application.Models;

namespace DotLiveDesignPatterns.Application.Services;

// builder.Services.AddScoped<OrdersDecoratorService, IOrdersService>();
public class OrdersDecoratorService : OrdersService, IOrdersService
{
    public OrdersDecoratorService(IOrderOrchestrator orchestrator,
        IPaymentServiceFactory factory,
        CreditCardService cardService,
        PaymentSlipService paymentSlipService)
    : base(orchestrator, factory, cardService, paymentSlipService)
    {
    }

    public bool Create(OrderInputModel model)
    {
        Console.WriteLine("Aqui está o decorator");
        
        var result = Create(model);

        return result;
    }
}