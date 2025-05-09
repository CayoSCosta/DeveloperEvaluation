﻿using Ambev.DeveloperEvaluation.Application.Sales.GetAll;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;

public class GetAllSalesCommand : IRequest<List<GetAllSalesResult>>
{
    public GetAllSalesCommand(int page, int size, string orderBy, string orderDirection, string? customerName = null, DateTime? minSaleDate = null, DateTime? maxSaleDate = null,
    decimal? minPrice = null, decimal? maxPrice = null)
    {
        Page = page;
        Size = size;
        OrderBy = orderBy;
        OrderDirection = orderDirection;
        CustomerName = customerName;
        MinSaleDate = minSaleDate;
        MaxSaleDate = maxSaleDate;
        MinPrice = minPrice;
        MaxPrice = maxPrice;
    }

    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string OrderBy { get; set; } = "SaleDate"; 
    public string OrderDirection { get; set; } = "asc";

    // Filtros
    public string? CustomerName { get; set; }
    public DateTime? MinSaleDate { get; set; }
    public DateTime? MaxSaleDate { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }


}
