namespace BuildLab.Api.Models;

public class BuildPlan
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Game { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Scale { get; set; } = string.Empty;
    public string Status { get; set; } = "Draft";
    public string CoreElements { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}