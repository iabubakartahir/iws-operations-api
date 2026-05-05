namespace IWS.OperationsApi.Dtos;

public record PickupRequestDto(
    int Id,
    string CustomerName,
    string PickupAddress,
    string WasteType,
    DateTime RequestedDate,
    string Status,
    string? AssignedTruck,
    DateTime CreatedAt
);

public record CreatePickupRequestDto(
    string CustomerName,
    string PickupAddress,
    string WasteType,
    DateTime RequestedDate,
    string? AssignedTruck
);

public record UpdatePickupRequestDto(
    string CustomerName,
    string PickupAddress,
    string WasteType,
    DateTime RequestedDate,
    string Status,
    string? AssignedTruck
);