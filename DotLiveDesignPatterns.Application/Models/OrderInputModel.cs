namespace DotLiveDesignPatterns.Application.Models;

public class OrderInputModel
{
    public CustomerInputModel Customer { get; set; }
    public List<OrderItemInputModel> Items { get; set; }
    public DeliveryAddressInputModel DeliveryAddress { get; set; }
    public PaymentAddressInputModel PaymentAddress { get; set; }        
    public PaymentInfoInputModel PaymentInfo { get; set; }
    public bool? IsInternational { get; set; }
    public bool IsExternal { get; set; }
}