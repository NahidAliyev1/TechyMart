namespace TechyMartProject.Application.DTOs.PaymentDTO;

public class PaymentDto
{
    public int Id { get; set; }
    public string OrderId { get; set; } = null!;
    public decimal Amount { get; set; }
    public string PaymentIntentId { get; set; } = null!;
    public string Status { get; set; }=null!;


}