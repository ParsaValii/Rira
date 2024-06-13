using Rira.Domain.Entities;

namespace Rira.Application.Interfaces;

public interface IProductService
{
    public IEnumerable<Product> GetProductsInCategoryOne();
    public Product? HighestPriceProduct();
    public decimal TotalPriceOfProducts();
    public IEnumerable<GroupedProduct> ProductsGroupedBySameCategory();
    public decimal AvragePriceOfProducts();
}