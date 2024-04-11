using DotLiveDesignPatterns.Application.Models;
using DotLiveDesignPatterns.Core.Repositories;

namespace DotLiveDesignPatterns.Application.ChainOfResponsibility;

public class ValidateStockHandler : OrderHandlerBase, IOrderHandler
{
    private readonly IProductRepository _repository;
    public ValidateStockHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public override bool Handle(OrderInputModel model)
    {
        Console.WriteLine($"Invoking ValidateStockHandler.Handle");

        var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
        var hasStock = _repository.HasStock(itemsDictionary);

        return hasStock && base.Handle(model);
    }
}