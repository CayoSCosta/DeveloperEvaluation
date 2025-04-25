using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale.TestData;

/// <summary>
/// Gera comandos válidos e variados para testes do CreateSaleHandler,
/// utilizando a biblioteca Bogus para simulação realista de dados.
/// </summary>
public static class CreateSaleHandlerTestData
{
    private static readonly Faker<CreateSaleItemRequest> itemFaker = new Faker<CreateSaleItemRequest>()
        .RuleFor(i => i.ProductId, f => Guid.NewGuid())
        .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 10))
        .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(1, 100));

    private static readonly Faker<CreateSaleCommand> commandFaker = new Faker<CreateSaleCommand>()
        .RuleFor(c => c.Customer, f => f.Company.CompanyName())
        .RuleFor(c => c.Branch, f => f.Address.City())
        .RuleFor(c => c.Date, f => f.Date.Recent())
        .RuleFor(c => c.Items, f => itemFaker.Generate(f.Random.Int(1, 5)));

    /// <summary>
    /// Gera um comando de venda válido com dados realistas.
    /// </summary>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return commandFaker.Generate();
    }
}
