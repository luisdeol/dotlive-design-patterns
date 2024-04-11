using DotLiveDesignPatterns.Application.Models;
using DotLiveDesignPatterns.Core.Repositories;

namespace DotLiveDesignPatterns.Application.ChainOfResponsibility;

public class ValidateCustomerHandler : OrderHandlerBase, IOrderHandler
{
    private readonly ICustomerRepository _repository;
    public ValidateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public override bool Handle(OrderInputModel model)
    {
        Console.WriteLine($"Invoking ValidateCustomerHandler.Handle");

        var customer = _repository.GetCustomerById(model.Customer.Id);
        var customerAllowedToBuy = customer.IsAllowedToBuy();

        return customerAllowedToBuy && base.Handle(model);
    }
}