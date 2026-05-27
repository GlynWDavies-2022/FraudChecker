namespace FraudChecker.Domain;

public class BaseEntity
{
    public required int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "System";
    public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    public string UpdatedBy { get; set; } = "System";
    public bool IsActive { get; set; } = true;
}
