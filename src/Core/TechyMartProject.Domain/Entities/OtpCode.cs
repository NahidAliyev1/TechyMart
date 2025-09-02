using TechyMartProject.Domain.Enums;

namespace TechyMartProject.Domain.Entities;
public class OtpCode:BaseEntity
{

    public string Email { get; set; }
    public string Code { get; set; }
    public DateTime ExpireAt { get; set; }
    public bool IsUsed { get; set; }
    public OtpType Type { get; set; }
}
