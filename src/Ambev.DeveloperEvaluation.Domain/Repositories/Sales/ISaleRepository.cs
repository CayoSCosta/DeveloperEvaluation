using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Repositories.Sales;

public interface ISaleRepository
{
    Task<Sale?> GetByIdAsync(Guid id);
    Task<List<Sale>> GetAllAsync();
    Task AddAsync(Sale sale);
    Task UpdateAsync(Sale sale);
    Task DeleteAsync(Guid id);
}

