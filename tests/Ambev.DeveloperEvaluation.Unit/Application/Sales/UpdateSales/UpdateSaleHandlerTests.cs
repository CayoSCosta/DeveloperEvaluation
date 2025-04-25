using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using System.Linq.Expressions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.UpdateSale;

public class UpdateSaleHandlerTests
{
    private class DummyMapper : IMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            if (source is UpdateSaleCommand command && typeof(TDestination) == typeof(Sale))
            {
                var sale = new Sale(command.Date, command.Customer, command.Branch);
                foreach (var item in command.Items)
                {
                    sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
                }

                typeof(Sale).GetProperty(nameof(Sale.Id))!.SetValue(sale, command.SaleId);
                return (TDestination)(object)sale;
            }

            throw new NotSupportedException("Mapping not supported.");
        }

        // Demais membros: igual ao DummyMapper anterior
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
        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts) => throw new NotImplementedException();
        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts) => throw new NotImplementedException();
    }

    private class InMemorySalesRepository : ISalesRepository
    {
        public Sale? StoredSale;

        public Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => Task.FromResult(StoredSale);

        public Task UpdateAsync(Sale sale, CancellationToken cancellationToken)
        {
            StoredSale = sale;
            return Task.CompletedTask;
        }

        public Task AddAsync(Sale sale, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken) => Task.FromResult(new List<Sale>());
        public Task DeleteAsync(Sale sale, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    [Fact]
    public async Task Handle_ShouldUpdateSaleSuccessfully()
    {
        var saleId = Guid.NewGuid();
        var repository = new InMemorySalesRepository
        {
            StoredSale = new Sale(DateTime.UtcNow.AddDays(-1), "Antiga", "Filial") { }
        };

        typeof(Sale).GetProperty(nameof(Sale.Id))!.SetValue(repository.StoredSale, saleId);

        var command = new UpdateSaleCommand
        {
            SaleId = saleId,
            Customer = "Atualizada",
            Branch = "Nova Filial",
            Date = DateTime.UtcNow,
            Items = new List<UpdateSaleItemRequest>
            {
                new() { ProductId = Guid.NewGuid(), ProductName = "Produto Novo", Quantity = 1, UnitPrice = 9.9m }
            }
        };

        var handler = new UpdateSaleHandler(repository, new DummyMapper());

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Equal(saleId, result.SaleId);
        Assert.Equal("Atualizada", repository.StoredSale?.Customer);
        Assert.Single(repository.StoredSale?.Items);
    }
}
