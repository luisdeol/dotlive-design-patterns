using DotLiveDesignPatterns.Application.Models;
using DotLiveDesignPatterns.Application.Models.Payments;

namespace DotLiveDesignPatterns.Application.Infrastructure.Payments;

public class PaymentSlipService : IPaymentService
{
    public object Process(OrderInputModel model)
    {
        // Recebe os dados de Boleto de uma API Externa, por exemplo

        var payer = new Payer("Pagador", "123.567.899-10", "Rua do Pagador");
        var receiver = new Receiver("Recebedor", "987.654.321-01", "Rua do Recebedor");
        
        var builder = new PaymentSlipBuilder();

        var paymentSlipModel = builder
            .Start()
            .WithPayer(payer)
            .WithReceiver(receiver)
            .WithPaymentDocument("12312.23214521-1.232152131", "12324124", 1234)
            .WithDates(DateTime.Now, DateTime.Now.AddDays(3))
            .Build();
        
        return "Dados do Boleto";
    }
}