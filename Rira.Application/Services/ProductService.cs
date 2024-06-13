using Rira.Application.Interfaces;
using Rira.Application.IRepository;
using Rira.Domain.Entities;
using Rira.Domain.Enums;

namespace Rira.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository) => _productRepository = productRepository;



    //Query for returning all products that are in category one
    public IEnumerable<Product> GetProductsInCategoryOne() =>
        from p in _productRepository.Products                                                            //Query expression syntax
        where p.Category == Categories.Category1
        select p;

    // _productRepository.Products.Where(p => p.Category == Categories.Category1);                       //Query fluent syntax



    //Query for returning Product with highest price
    public Product? HighestPriceProduct() =>
        (from p in _productRepository.Products                                                           //Query expression syntax
         orderby p.Price descending
         select p).FirstOrDefault();

    // _productRepository.Products.OrderByDescending(p => p.Price).FirstOrDefault();                     //Query fluent syntax



    //Query for returning sum of all products prices
    public decimal TotalPriceOfProducts() =>
    (from p in _productRepository.Products                                                               //Query expression syntax
     select p.Price).Sum();

    // _productRepository.Products.Sum(p => p.Price);                                                    //Query fluent syntax



    // Query for returning Products in order of category
    public IEnumerable<GroupedProduct> ProductsGroupedBySameCategory() =>
        from p in _productRepository.Products                                                            //Query expression syntax
        group p by p.Category into g
        select new GroupedProduct
        {
            Category = g.Key,
            Products = g.ToList()
        };

    // _productRepository.Products                                                                      //Query fluent syntax
    // .GroupBy(p => p.Category)
    // .Select(g => new GroupedProduct
    // {
    //     Category = g.Key,
    //     Products = g.ToList()
    // });



    //Query for return avrage of Products prices
    public decimal AvragePriceOfProducts() =>
    (from p in _productRepository.Products                                                             //Query expression syntax
     select p.Price).Average();

    // _productRepository.Products.Average(p => p.Price);                                              //Query fluent syntax

}
