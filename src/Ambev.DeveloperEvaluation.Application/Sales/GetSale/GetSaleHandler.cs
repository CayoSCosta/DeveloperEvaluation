using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using MediatR;
using FluentValidation;
using static Ambev.DeveloperEvaluation.Application.Sales.GetSale.GetSaleValidator;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISalesRepository _repository;
    private readonly IMapper _mapper;

    public GetSaleHandler(ISalesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found.");

        return _mapper.Map<GetSaleResult>(sale);
    }
}
