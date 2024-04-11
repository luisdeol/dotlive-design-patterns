using DotLiveDesignPatterns.Core.Enums;

namespace DotLiveDesignPatterns.Application.Infrastructure.Payments;

public interface IPaymentServiceFactory
{
    IPaymentService GetService(PaymentMethod paymentMethod);
}