using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tripify.Application.Trips.Commands.CreateTrip;
using Tripify.Application.Trips.Queries.GetTrips;

namespace Tripify.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TripsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<TripDto>>> GetTrips(CancellationToken cancellationToken)
    {
        var query = new GetTripsQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CreateTripResponse>> CreateTrip(
        [FromBody] CreateTripCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetTrips), new { id = result.Id }, result);
    }
}
