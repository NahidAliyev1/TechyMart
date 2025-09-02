using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Application.DTOs.OrderDTO;

public class OrderSummeryDto
{
    public string OrderNo { get; set; }
    public string CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public Status Status { get; set; }
}