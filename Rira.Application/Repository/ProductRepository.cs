using Rira.Application.IRepository;
using Rira.Domain.Entities;
using Rira.Domain.Enums;

namespace Rira.Application.Repository;

public class ProductRepository : IProductRepository
{
    public IEnumerable<Product> Products
    {
        get
        {
            yield return new Product(Id: 1, Name: "Product A", Category: Categories.Category1, Price: 100);
            yield return new Product(Id: 2, Name: "Product B", Category: Categories.Category1, Price: 150);
            yield return new Product(Id: 3, Name: "Product C", Category: Categories.Category2, Price: 120);
            yield return new Product(Id: 4, Name: "Product D", Category: Categories.Category3, Price: 200);
            yield return new Product(Id: 5, Name: "Product E", Category: Categories.Category1, Price: 80);
        }
    }

}