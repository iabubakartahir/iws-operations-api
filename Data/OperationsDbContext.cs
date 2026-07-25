using IWS.OperationsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IWS.OperationsApi.Data;

public class OperationsDbContext : DbContext
{
    public OperationsDbContext(DbContextOptions<OperationsDbContext> options)
        : base(options) { }

    public DbSet<PickupRequest> PickupRequests => Set<PickupRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PickupRequest>().HasData(
            new PickupRequest
            {
                Id = 1,
                CustomerName = "Teaneck Medical Center",
                PickupAddress = "300 Frank W Burr Blvd, Teaneck, NJ",
                WasteType = "Medical",
                RequestedDate = new DateTime(2026, 5, 10),
                Status = "Scheduled",
                AssignedTruck = "T-204",
                CreatedAt = new DateTime(2026, 5, 1)
            },
            new PickupRequest
            {
                Id = 2,
                CustomerName = "Brooklyn Bagel Co.",
                PickupAddress = "1453 Bedford Ave, Brooklyn, NY",
                WasteType = "Commercial",
                RequestedDate = new DateTime(2026, 5, 8),
                Status = "Pending",
                CreatedAt = new DateTime(2026, 5, 2)
            },
            new PickupRequest
            {
                Id = 3,
                CustomerName = "Stamford Recycling Center",
                PickupAddress = "88 Long Ridge Rd, Stamford, CT",
                WasteType = "Recycling",
                RequestedDate = new DateTime(2026, 5, 12),
                Status = "Pending",
                CreatedAt = new DateTime(2026, 5, 3)
            }
        );
    }
}
