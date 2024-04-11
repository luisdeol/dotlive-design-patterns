using DotLiveDesignPatterns.Application.Models;

namespace DotLiveDesignPatterns.Application.Infrastructure.Payments;

public interface IPaymentService
{
    object Process(OrderInputModel model);
}