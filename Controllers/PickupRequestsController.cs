using IWS.OperationsApi.Data;
using IWS.OperationsApi.Dtos;
using IWS.OperationsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWS.OperationsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PickupRequestsController : ControllerBase
{
    private readonly OperationsDbContext _db;

    public PickupRequestsController(OperationsDbContext db)
    {
        _db = db;
    }

    // GET /api/pickuprequests?status=Pending
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PickupRequestDto>>> GetAll(
        [FromQuery] string? status = null)
    {
        var query = _db.PickupRequests.AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(p => p.Status == status);
        }

        var results = await query
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new PickupRequestDto(
                p.Id, p.CustomerName, p.PickupAddress, p.WasteType,
                p.RequestedDate, p.Status, p.AssignedTruck, p.CreatedAt))
            .ToListAsync();

        return Ok(results);
    }

    // GET /api/pickuprequests/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PickupRequestDto>> GetById(int id)
    {
        var p = await _db.PickupRequests.FindAsync(id);
        if (p is null) return NotFound();

        return Ok(new PickupRequestDto(
            p.Id, p.CustomerName, p.PickupAddress, p.WasteType,
            p.RequestedDate, p.Status, p.AssignedTruck, p.CreatedAt));
    }

    // POST /api/pickuprequests
    [HttpPost]
    public async Task<ActionResult<PickupRequestDto>> Create(
        [FromBody] CreatePickupRequestDto dto)
    {
        var entity = new PickupRequest
        {
            CustomerName = dto.CustomerName,
            PickupAddress = dto.PickupAddress,
            WasteType = dto.WasteType,
            RequestedDate = dto.RequestedDate,
            AssignedTruck = dto.AssignedTruck,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _db.PickupRequests.Add(entity);
        await _db.SaveChangesAsync();

        var result = new PickupRequestDto(
            entity.Id, entity.CustomerName, entity.PickupAddress,
            entity.WasteType, entity.RequestedDate, entity.Status,
            entity.AssignedTruck, entity.CreatedAt);

        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, result);
    }

    // PUT /api/pickuprequests/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePickupRequestDto dto)
    {
        var entity = await _db.PickupRequests.FindAsync(id);
        if (entity is null) return NotFound();

        entity.CustomerName = dto.CustomerName;
        entity.PickupAddress = dto.PickupAddress;
        entity.WasteType = dto.WasteType;
        entity.RequestedDate = dto.RequestedDate;
        entity.Status = dto.Status;
        entity.AssignedTruck = dto.AssignedTruck;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /api/pickuprequests/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _db.PickupRequests.FindAsync(id);
        if (entity is null) return NotFound();

        _db.PickupRequests.Remove(entity);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}