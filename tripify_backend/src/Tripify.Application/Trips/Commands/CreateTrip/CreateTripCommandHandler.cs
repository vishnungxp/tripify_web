using MediatR;
using Tripify.Application.Common.Interfaces;
using Tripify.Domain.Entities;

namespace Tripify.Application.Trips.Commands.CreateTrip;

public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, CreateTripResponse>
{
    private readonly ITripRepository _tripRepository;

    public CreateTripCommandHandler(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<CreateTripResponse> Handle(CreateTripCommand request, CancellationToken cancellationToken)
    {
        var trip = new Trip
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Destination = request.Destination,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Budget = request.Budget,
            CreatedAt = DateTime.UtcNow
        };

        var createdTrip = await _tripRepository.AddAsync(trip, cancellationToken);

        return new CreateTripResponse
        {
            Id = createdTrip.Id,
            Name = createdTrip.Name,
            Destination = createdTrip.Destination,
            StartDate = createdTrip.StartDate,
            EndDate = createdTrip.EndDate
        };
    }
}
