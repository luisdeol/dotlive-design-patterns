namespace DotLiveDesignPatterns.Application.Models.Payments;

public class PaymentSlipBuilder
{
    private PaymentSlipModel _paymentSlipModel;

    public PaymentSlipBuilder()
    {
    }

    public PaymentSlipBuilder Start() {
        _paymentSlipModel = new PaymentSlipModel();

        return this;
    }

    public PaymentSlipBuilder WithReceiver(Receiver receiver) {
        _paymentSlipModel.Receiver = receiver;

        return this;
    }

    public PaymentSlipBuilder WithPayer(Payer payer) {
        _paymentSlipModel.Payer = payer;

        return this;
    }

    public PaymentSlipBuilder WithPaymentDocument(string barCode, string ourNumber, decimal documentAmount) {
        _paymentSlipModel.BarCode = barCode;
        _paymentSlipModel.OurNumber = ourNumber;
        _paymentSlipModel.DocumentAmount = documentAmount;

        return this;
    }

    public PaymentSlipBuilder WithDates(DateTime processedAt, DateTime expiresAt) {
        _paymentSlipModel.ProcessedAt = processedAt;
        _paymentSlipModel.ExpiresAt = expiresAt;

        return this;
    }

    public PaymentSlipModel Build() {
        return _paymentSlipModel;
    }
}