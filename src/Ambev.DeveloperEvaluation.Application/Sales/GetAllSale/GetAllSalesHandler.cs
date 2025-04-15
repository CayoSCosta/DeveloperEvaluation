using Ambev.DeveloperEvaluation.Application.Sales.GetAll;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;

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

        return _mapper.Map<List<GetAllSalesResult>>(sales);
    }
}
