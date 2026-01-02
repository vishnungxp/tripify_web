using Microsoft.EntityFrameworkCore;
using Tripify.Application.Common.Interfaces;
using Tripify.Domain.Entities;
using Tripify.Infrastructure.Data;

namespace Tripify.Infrastructure.Repositories;

public class TripRepository : ITripRepository
{
    private readonly ApplicationDbContext _context;

    public TripRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Trip?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Trips.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Trip>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Trips.ToListAsync(cancellationToken);
    }

    public async Task<Trip> AddAsync(Trip trip, CancellationToken cancellationToken = default)
    {
        await _context.Trips.AddAsync(trip, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return trip;
    }

    public async Task UpdateAsync(Trip trip, CancellationToken cancellationToken = default)
    {
        trip.UpdatedAt = DateTime.UtcNow;
        _context.Trips.Update(trip);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var trip = await GetByIdAsync(id, cancellationToken);
        if (trip != null)
        {
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
