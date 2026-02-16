namespace PubLog.Models;

public class Pub
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string? ImageUrl { get; set; }
    public string? GooglePlaceId { get; set; }
    public string? TripAdvisorUrl { get; set; }
    public int AreaId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Area Area { get; set; } = null!;
    public List<Visit> Visits { get; set; } = [];
}
