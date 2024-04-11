using DotLiveDesignPatterns.Application.Models;

namespace DotLiveDesignPatterns.Application.ChainOfResponsibility;

public interface IOrderHandler
{
    bool Handle(OrderInputModel model);
    IOrderHandler SetNext(IOrderHandler handler);
}

