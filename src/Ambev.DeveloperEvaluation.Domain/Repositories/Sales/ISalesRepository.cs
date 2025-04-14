using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Repositories.Sales;

public interface ISalesRepository
{
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Sale sale, CancellationToken cancellationToken = default);
    Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
