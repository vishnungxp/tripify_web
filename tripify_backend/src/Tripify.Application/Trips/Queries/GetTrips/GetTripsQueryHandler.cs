using MediatR;
using Tripify.Application.Common.Interfaces;

namespace Tripify.Application.Trips.Queries.GetTrips;

public class GetTripsQueryHandler : IRequestHandler<GetTripsQuery, List<TripDto>>
{
    private readonly ITripRepository _tripRepository;

    public GetTripsQueryHandler(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<List<TripDto>> Handle(GetTripsQuery request, CancellationToken cancellationToken)
    {
        var trips = await _tripRepository.GetAllAsync(cancellationToken);

        return trips.Select(trip => new TripDto
        {
            Id = trip.Id,
            Name = trip.Name,
            Description = trip.Description,
            Destination = trip.Destination,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            Budget = trip.Budget,
            CreatedAt = trip.CreatedAt
        }).ToList();
    }
}
