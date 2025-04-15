using Ambev.DeveloperEvaluation.Application.Sales.GetAll;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, List<GetAllSalesResult>>
    {
        private readonly ISalesRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSalesHandler(ISalesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllSalesResult>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
        {
            var sales = await _repository.GetAllAsync(cancellationToken);

            var salesQuery = sales.AsQueryable();

            // Aplicando os filtros
            if (!string.IsNullOrEmpty(request.CustomerName))
            {
                salesQuery = salesQuery.Where(s => s.Customer.Contains(request.CustomerName));
            }

            if (request.MinSaleDate.HasValue)
            {
                salesQuery = salesQuery.Where(s => s.SaleDate >= request.MinSaleDate.Value);
            }

            if (request.MaxSaleDate.HasValue)
            {
                salesQuery = salesQuery.Where(s => s.SaleDate <= request.MaxSaleDate.Value);
            }

            if (request.MinPrice.HasValue)
            {
                salesQuery = salesQuery.Where(s => s.TotalAmount >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                salesQuery = salesQuery.Where(s => s.TotalAmount <= request.MaxPrice.Value);
            }

            salesQuery = ApplyOrdering(salesQuery, request.OrderBy, request.OrderDirection);

            salesQuery = salesQuery.Skip((request.Page - 1) * request.Size).Take(request.Size);

            var salesReturn = await salesQuery.ToListAsync(cancellationToken);

            return _mapper.Map<List<GetAllSalesResult>>(sales);
        }

        private IQueryable<Domain.Entities.Sales.Sale> ApplyOrdering(IQueryable<Domain.Entities.Sales.Sale> salesQuery, string orderBy, string orderDirection)
        {
            // Usando Reflection para obter a propriedade dinamicamente
            var propertyInfo = typeof(Domain.Entities.Sales.Sale).GetProperty(orderBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Invalid property name: {orderBy}");
            }

            if (orderDirection.ToLower() == "asc")
            {
                return salesQuery.OrderBy(x => propertyInfo.GetValue(x, null));
            }
            else
            {
                return salesQuery.OrderByDescending(x => propertyInfo.GetValue(x, null));
            }
        }
    }
}
