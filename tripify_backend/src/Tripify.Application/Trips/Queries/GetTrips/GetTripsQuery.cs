using MediatR;

namespace Tripify.Application.Trips.Queries.GetTrips;

public record GetTripsQuery : IRequest<List<TripDto>>;
