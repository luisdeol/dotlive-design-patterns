using DotLiveDesignPatterns.Application.ChainOfResponsibility;
using DotLiveDesignPatterns.Application.Infrastructure.Payments;
using DotLiveDesignPatterns.Application.Models;
using DotLiveDesignPatterns.Core.Enums;
using DotLiveDesignPatterns.Core.Repositories;

namespace DotLiveDesignPatterns.Application.Services;

public interface IOrdersService
{
    bool Create(OrderInputModel model);
}

public class OrdersService
{
    private readonly IOrderOrchestrator _orchestrator;
    private readonly IPaymentServiceFactory _factory;
    private readonly CreditCardService _cardService;
    private readonly PaymentSlipService _paymentSlipService;
    
    public OrdersService(
        IOrderOrchestrator orchestrator,
        IPaymentServiceFactory factory,
        CreditCardService cardService,
        PaymentSlipService paymentSlipService)
    {
        _orchestrator = orchestrator;
        _factory = factory;
        _cardService = cardService;
        _paymentSlipService = paymentSlipService;
    }
    
    public bool CreateOrderWithChain(OrderInputModel model)
    {
        // DEPOIS
        var success = _orchestrator.Execute(model);
        
        #region ANTES SEQUENCIA
        /* ANTES
        var customer = _customerRepository.GetCustomerById(model.Customer.Id);
        var customerAllowedToBuy = customer.IsAllowedToBuy();

        if (!customerAllowedToBuy)
            return false;
        
        var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
        var hasStock = _productRepository.HasStock(itemsDictionary);

        if (!hasStock)
            return false;
        
        var isFraud = _fraudCheckService.IsFraud(model);

        if (isFraud)
            return false;
        */
        
        #endregion
        
        //  DEPOIS
        var service = _factory.GetService(model.PaymentInfo.PaymentMethod);
        var result = service.Process(model);

        #region ANTES PAGAMENTOS

        /*object result;

        if (model.PaymentInfo.PaymentMethod == PaymentMethod.CreditCard)
        {
            result = _cardService.Process(model);
        } else if (model.PaymentInfo.PaymentMethod == PaymentMethod.PaymentSlip)
        {
            result = _paymentSlipService.Process(model);
        }
        else
        {
            throw new InvalidOperationException();
        }*/

        #endregion
        
        Console.WriteLine(result);
        
        return true;
    }
}