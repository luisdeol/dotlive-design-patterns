using DotLiveDesignPatterns.Application.Models;

namespace DotLiveDesignPatterns.Application.ChainOfResponsibility;

public class OrderNotificationHandler : OrderHandlerBase, IOrderHandler
{
    public override bool Handle(OrderInputModel model)
    {
        Console.WriteLine($"Invoking OrderNotificationHandler.Handle");

        return true;
    }
}