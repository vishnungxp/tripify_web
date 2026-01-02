namespace Tripify.Application.Trips.Commands.CreateTrip;

public class CreateTripResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
