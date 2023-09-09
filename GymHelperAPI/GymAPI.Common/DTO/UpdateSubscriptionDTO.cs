namespace GymAPI.Common.DTO;

public class UpdateSubscriptionDTO
{
    public string Type { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
}