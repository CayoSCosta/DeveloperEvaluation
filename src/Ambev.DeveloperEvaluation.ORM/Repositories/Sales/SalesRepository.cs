using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories.Sales;

public class SalesRepository : ISalesRepository
{
    private readonly DefaultContext _context;

    public SalesRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale is not null)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
