using Microsoft.AspNetCore.Mvc;
using Rira.Application.Interfaces;
using Rira.Domain.Entities;

namespace Rira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService) => _productService = productService;

    [HttpGet("GetCategoryOneProducts")]
    public ActionResult<IEnumerable<Product>> GetCategoryOneProducts()
    {
        var result = _productService.GetProductsInCategoryOne();
        return Ok(result);
    }
    
    [HttpGet("HighestPriceProduct")]
    public ActionResult<Product> HighestPriceProduct()
    {
        return _productService.HighestPriceProduct() switch
        {
            null => NotFound(),
            _ => Ok(_productService.HighestPriceProduct())
        };
    }

    [HttpGet("GetTotalPriceOfProducts")] 
    public ActionResult<decimal> GetTotalPriceOfProducts()
    {
        var result = _productService.TotalPriceOfProducts();
        return Ok(result);
    }

    [HttpGet("GroupedProducts")]
    public ActionResult<IEnumerable<GroupedProduct>> GroupedProducts()
    {
        var result = _productService.ProductsGroupedBySameCategory();
        return Ok(result);
    }

    [HttpGet("ProductsAvragePrice")]
    public ActionResult<decimal> ProductsAvragePrice()
    {
        var result = _productService.AvragePriceOfProducts();
        return Ok(result);
    }
}