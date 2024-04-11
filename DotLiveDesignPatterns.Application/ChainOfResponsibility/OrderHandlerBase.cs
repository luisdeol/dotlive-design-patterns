using DotLiveDesignPatterns.Application.Models;

namespace DotLiveDesignPatterns.Application.ChainOfResponsibility;

public abstract class OrderHandlerBase : IOrderHandler
{
    private IOrderHandler? _nextHandler;
    public virtual bool Handle(OrderInputModel model)
    {
        if (_nextHandler == null)
            return true;
            
        var result = _nextHandler.Handle(model);

        return result;
    }

    public IOrderHandler SetNext(IOrderHandler step)
    {
        _nextHandler = step;

        return step;
    }
}