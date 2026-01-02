using Tripify.Domain.Entities;

namespace Tripify.Application.Common.Interfaces;

public interface ITripRepository
{
    Task<Trip?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Trip>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Trip> AddAsync(Trip trip, CancellationToken cancellationToken = default);
    Task UpdateAsync(Trip trip, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
