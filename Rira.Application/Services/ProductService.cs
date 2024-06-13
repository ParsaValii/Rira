using Rira.Application.Interfaces;
using Rira.Application.IRepository;
using Rira.Domain.Entities;
using Rira.Domain.Enums;

namespace Rira.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

    public IEnumerable<Product> GetProductsInCategoryOne()
    {
        //Query for returning all products that are in category one

        return from p in _productRepository.Products                                                            //Query expression syntax
                     where p.Category == Categories.Category1
                     select p;

        //return _productRepository.Products.Where(p => p.Category == Categories.Category1);                    //Query fluent syntax

    }

    public Product? HighestPriceProduct()
    {
        //Query for returning Product with highest price

        return (from p in _productRepository.Products                                                           //Query expression syntax
                     orderby p.Price descending
                     select p).FirstOrDefault();

        // return _productRepository.Products.OrderByDescending(p => p.Price).FirstOrDefault();                 //Query fluent syntax

    }
    public decimal TotalPriceOfProducts()
    {
        //Query for returning sum of all products prices

        return (from p in _productRepository.Products                                                           //Query expression syntax
                      select p.Price).Sum();


        // return _productRepository.Products.Sum(p => p.Price);                                                //Query fluent syntax

    }
    public IEnumerable<GroupedProduct> ProductsGroupedBySameCategory() 
    {
        // Query for returning Products in order of category

        return from p in _productRepository.Products                                                            //Query expression syntax
                 group p by p.Category into g
                 select new GroupedProduct
                 {
                     Category = g.Key,
                     Products = g.ToList()
                 };

        // return _productRepository.Products                                                                   //Query fluent syntax
        // .GroupBy(p => p.Category)
        // .Select(g => new GroupedProduct
        // {
        //     Category = g.Key,
        //     Products = g.ToList()
        // });

    }
    public decimal AvragePriceOfProducts()
    {
        //Query for return avrage of Products prices

        return (from p in _productRepository.Products                                                     //Query expression syntax
                      select p.Price).Average();

        
        // return _productRepository.Products.Average(p => p.Price);                                      //Query fluent syntax

    }
}