using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales
{
    public class GetAllSalesRequest
    {
        [FromQuery(Name = "_page")]
        public int Page { get; set; } = 1;

        [FromQuery(Name = "_size")]
        public int Size { get; set; } = 10;
    }
}
