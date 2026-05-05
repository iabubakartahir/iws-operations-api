using System.ComponentModel.DataAnnotations;

namespace IWS.OperationsApi.Models;

public class PickupRequest
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string CustomerName { get; set; } = string.Empty;

    [Required, MaxLength(250)]
    public string PickupAddress { get; set; } = string.Empty;

    [Required, MaxLength(40)]
    public string WasteType { get; set; } = string.Empty;
    // e.g. "Commercial", "Residential", "Recycling", "Medical"

    public DateTime RequestedDate { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "Pending";
    // Pending / Scheduled / Completed / Cancelled

    [MaxLength(20)]
    public string? AssignedTruck { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}