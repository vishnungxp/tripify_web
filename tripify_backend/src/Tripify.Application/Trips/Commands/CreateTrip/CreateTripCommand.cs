using MediatR;

namespace Tripify.Application.Trips.Commands.CreateTrip;

public record CreateTripCommand : IRequest<CreateTripResponse>
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Destination { get; init; } = string.Empty;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal Budget { get; init; }
}
