using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.DeleteSale;

public class DeleteSaleHandlerTests
{
    private class InMemorySalesRepository : ISalesRepository
    {
        private readonly List<Sale> _sales = new();

        public Task AddAsync(Sale sale, CancellationToken cancellationToken)
        {
            _sales.Add(sale);
            return Task.CompletedTask;
        }

        public Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(_sales.FirstOrDefault(s => s.Id == id));

        public Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult(_sales.ToList());

        public Task UpdateAsync(Sale sale, CancellationToken cancellationToken) => Task.CompletedTask;

        public Task DeleteAsync(Sale sale, CancellationToken cancellationToken)
        {
            _sales.Remove(sale);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var sale = _sales.FirstOrDefault(s => s.Id == id);
            if (sale != null) _sales.Remove(sale);
            return Task.CompletedTask;
        }
    }

    [Fact]
    public async Task Handle_ShouldDeleteSaleSuccessfully()
    {
        var repository = new InMemorySalesRepository();
        var sale = new Sale(DateTime.UtcNow, "Cliente", "Filial");
        await repository.AddAsync(sale, CancellationToken.None);

        var handler = new DeleteSaleHandler(repository);

        var command = new DeleteSaleCommand(Guid.NewGuid());
        await handler.Handle(command, CancellationToken.None);

        var result = await repository.GetByIdAsync(sale.Id, CancellationToken.None);
        Assert.Null(result);
    }
}
