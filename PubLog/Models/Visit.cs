namespace PubLog.Models;

public class Visit
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PubId { get; set; }
    public DateTime VisitDate { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
    public Pub Pub { get; set; } = null!;
}
