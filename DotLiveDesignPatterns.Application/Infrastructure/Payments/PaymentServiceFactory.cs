using DotLiveDesignPatterns.Core.Enums;

namespace DotLiveDesignPatterns.Application.Infrastructure.Payments;

public class PaymentServiceFactory : IPaymentServiceFactory
{
    private readonly CreditCardService _creditCardService;
    private readonly PaymentSlipService _paymentSlipService;

    public PaymentServiceFactory(
        CreditCardService creditCardService, 
        PaymentSlipService paymentSlipService
    )
    {
        _creditCardService = creditCardService;
        _paymentSlipService = paymentSlipService;
    }

    public IPaymentService GetService(PaymentMethod paymentMethod)
    {
        IPaymentService paymentService;

        switch (paymentMethod) {
            case PaymentMethod.CreditCard: 
                paymentService = _creditCardService;
                    
                break;
            case PaymentMethod.PaymentSlip:
                paymentService = _paymentSlipService;

                break;
            default:
                throw new InvalidOperationException();
        }

        return paymentService;
    }
}