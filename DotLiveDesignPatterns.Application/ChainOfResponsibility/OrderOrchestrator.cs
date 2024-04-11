using DotLiveDesignPatterns.Application.Infrastructure.Payments;
using DotLiveDesignPatterns.Application.Models;
using DotLiveDesignPatterns.Core.Repositories;

namespace DotLiveDesignPatterns.Application.ChainOfResponsibility;

public interface IOrderOrchestrator
{
    bool Execute(OrderInputModel model);
}

public class OrderOrchestrator : IOrderOrchestrator
{
    private readonly IProductRepository _productRepository;
    private readonly IPaymentFraudCheckService _fraudCheckService;
    private readonly ICustomerRepository _customerRepository;
    
    public OrderOrchestrator(
        IProductRepository productRepository,
        IPaymentFraudCheckService fraudCheckService,
        ICustomerRepository customerRepository)
    {
        _productRepository = productRepository;
        _fraudCheckService = fraudCheckService;
        _customerRepository = customerRepository;
    }

    public bool Execute(OrderInputModel model)
    {
        var validateCustomerHandler = new ValidateCustomerHandler(_customerRepository);
        var validateStockHandler = new ValidateStockHandler(_productRepository);
        var checkFraudHandler = new CheckForFraudHandler(_fraudCheckService);
        var notificationHandler = new OrderNotificationHandler();
        
        validateCustomerHandler
            .SetNext(validateStockHandler)
            .SetNext(checkFraudHandler)
            .SetNext(notificationHandler);

        var success = validateCustomerHandler.Handle(model);

        return success;
    }
}