using Ambev.DeveloperEvaluation.Application.Sales.GetAll;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using System.Linq.Expressions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetAllSales;

public class GetAllSalesHandlerTests
{
    private class DummyMapper : IMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            if (source is Sale sale && typeof(TDestination) == typeof(GetAllSalesResult))
            {
                return (TDestination)(object)new GetAllSalesResult(sale);
                //return (TDestination)(object)new GetAllSalesResult
                //{
                //    Id = sale.Id,
                //    Customer = sale.Customer,
                //    SaleDate = sale.SaleDate,
                //    TotalAmount = sale.TotalAmount,
                //    Branch = sale.Branch,                   
                   
                //};
            }

            if (source is List<Sale> sales && typeof(TDestination) == typeof(List<GetAllSalesResult>))
            {
                return (TDestination)(object)sales
                    .Select(s => (GetAllSalesResult)Map<GetAllSalesResult>(s))
                    .ToList();
            }

            throw new NotImplementedException();
        }

        // Os outros métodos podem lançar exceções como antes
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
        private readonly List<Sale> _sales = new();

        public Task AddAsync(Sale sale, CancellationToken cancellationToken)
        {
            _sales.Add(sale);
            return Task.CompletedTask;
        }

        public Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken) => Task.FromResult(_sales.ToList());

        public Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(_sales.FirstOrDefault(s => s.Id == id));

        public Task UpdateAsync(Sale sale, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task DeleteAsync(Sale sale, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    [Fact]
    public async Task Handle_ShouldReturnAllSales()
    {
        var repository = new InMemorySalesRepository();
        var mapper = new DummyMapper();

        var sale = new Sale(DateTime.UtcNow, "Cliente 1", "Filial 1");
        sale.AddItem(Guid.NewGuid(), "Produto A", 2, 10m);
        await repository.AddAsync(sale, CancellationToken.None);
        var handler = new GetAllSalesHandler(repository, mapper);

        var command = new GetAllSalesCommand(
            page: 1,
            size: 10,
            orderBy: "SaleDate",
            orderDirection: "asc",
            customerName: null,
            minSaleDate: null,
            maxSaleDate: null,
            minPrice: null,
            maxPrice: null
        );

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Single(result);
        Assert.Equal("Cliente 1", result.First().Customer);
    }
}
