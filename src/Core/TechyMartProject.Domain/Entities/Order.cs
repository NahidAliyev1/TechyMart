using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Domain.Entities;
public class Order:BaseEntity
{

    public string OrderNo { get; set; }
    public string CustomerId { get; set; }
    public Address ShippingAddress { get; set; }
    public List<OrderItem> Items { get; set; }= new List<OrderItem>();

    public Status Status { get; set; }
}
