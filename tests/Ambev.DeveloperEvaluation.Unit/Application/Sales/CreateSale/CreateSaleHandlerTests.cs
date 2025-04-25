using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using System.Linq.Expressions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale;

public class CreateSaleHandlerTests
{
    private class DummyMapper : IMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            if (source is CreateSaleCommand command && typeof(TDestination) == typeof(Sale))
            {
                var sale = new Sale(command.Date, command.Customer, command.Branch);
                foreach (var item in command.Items)
                {
                    sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
                }
                return (TDestination)(object)sale;
            }

            throw new NotSupportedException("Mapping not supported.");
        }

        // Implementações restantes podem ser vazias/explícitas lançando exceção se forem chamadas
        public IConfigurationProvider ConfigurationProvider => throw new NotImplementedException();
        public Func<Type, object> ServiceCtor => throw new NotImplementedException();
        public TDestination Map<TSource, TDestination>(TSource source) => throw new NotImplementedException();
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) => throw new NotImplementedException();
        public object Map(object source, Type sourceType, Type destinationType) => throw new NotImplementedException();
        public object Map(object source, object destination, Type sourceType, Type destinationType) => throw new NotImplementedException();
        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions<object, TDestination>> opts) => throw new NotImplementedException();
        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts) => throw new NotImplementedException();
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts) => throw new NotImplementedException();
        public IQueryable ProjectTo(IQueryable source, Type destinationType, IDictionary<string, object> parameters, params string[] membersToExpand) => throw new NotImplementedException();
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, object parameters, params Expression<Func<TDestination, object>>[] membersToExpand) => throw new NotImplementedException();
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, IDictionary<string, object> parameters, params string[] membersToExpand) => throw new NotImplementedException();

        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts)
        {
            throw new NotImplementedException();
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts)
        {
            throw new NotImplementedException();
        }
    }

    private class InMemorySalesRepository : ISalesRepository
    {
        public Sale LastAddedSale;

        public Task AddAsync(Sale sale, CancellationToken cancellationToken)
        {
            LastAddedSale = sale;
            return Task.CompletedTask;
        }

        public Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => Task.FromResult<Sale?>(null);
        public Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken) => Task.FromResult(new List<Sale>());
        public Task UpdateAsync(Sale sale, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task DeleteAsync(Sale sale, CancellationToken cancellationToken) => Task.CompletedTask;

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }

    [Fact]
    public async Task Handle_ShouldCreateSaleWithoutMocks()
    {
        var command = new CreateSaleCommand
        {
            Customer = "Cervejaria XPTO",
            Branch = "São Paulo",
            Date = DateTime.UtcNow,
            Items = new List<CreateSaleItemRequest>
            {
                new() { ProductId = Guid.NewGuid(), ProductName = "Latão 473ml", Quantity = 2, UnitPrice = 6.5m }
            }
        };

        var repository = new InMemorySalesRepository();
        var handler = new CreateSaleHandler(repository, new DummyMapper());

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Equal(repository.LastAddedSale.Id, result.SaleId);
        Assert.Equal("Cervejaria XPTO", repository.LastAddedSale.Customer);
        Assert.Single(repository.LastAddedSale.Items);
    }
}
