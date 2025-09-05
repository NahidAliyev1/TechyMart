using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Domain.Entities;
public class Payment:BaseEntity
{
    public string OrderId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentIntentId { get; set; }
    public Status Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
