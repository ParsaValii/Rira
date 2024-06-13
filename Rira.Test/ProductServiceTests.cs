using Moq;
using Rira.Application.IRepository;
using Rira.Application.Services;
using Rira.Domain.Entities;
using Rira.Domain.Enums;

namespace Rira.Test;

public class ProductServiceTests
{
    [Fact]
    public void GetProductsInCategoryOne_ShouldReturnProductsInCategoryOne()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product(Id: 1, Name: "Product A", Category: Categories.Category1, Price: 100),
                new Product(Id: 2, Name: "Product B", Category: Categories.Category1, Price: 150),
                new Product(Id: 5, Name: "Product E", Category: Categories.Category2, Price: 80),
            });

        var service = new ProductService(mockRepository.Object);

        // Act
        var result = service.GetProductsInCategoryOne();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetProductsInCategoryOne_WhenNoProductIsInCategoryOne_ShouldReturnEmpty()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product(Id: 1, Name: "Product A", Category: Categories.Category2, Price: 100),
                new Product(Id: 2, Name: "Product B", Category: Categories.Category3, Price: 150),
                new Product(Id: 5, Name: "Product E", Category: Categories.Category2, Price: 80),
            });

        var service = new ProductService(mockRepository.Object);

        // Act
        var result = service.GetProductsInCategoryOne();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void HighestPriceProduct_ShouldReturnProductWithHighestPrice()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product(Id: 1, Name: "Product A", Category: Categories.Category2, Price: 100),
                new Product(Id: 2, Name: "Product B", Category: Categories.Category3, Price: 150),
                new Product(Id: 5, Name: "Product E", Category: Categories.Category2, Price: 80),
            });

        var service = new ProductService(mockRepository.Object);

        // Act
        var result = service.HighestPriceProduct();

        // Assert
        Assert.Equal(150, result?.Price);
    }

    [Fact]
    public void TotalPriceOfProducts_ShouldReturnTotalPriceOfAllProducts()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product(Id: 1, Name: "Product A", Category: Categories.Category2, Price: 100),
                new Product(Id: 2, Name: "Product B", Category: Categories.Category3, Price: 150),
                new Product(Id: 5, Name: "Product E", Category: Categories.Category2, Price: 80),
            });

        var service = new ProductService(mockRepository.Object);

        // Act
        var result = service.TotalPriceOfProducts();

        // Assert
        Assert.Equal(330, result);
    }

    [Fact]
    public void AvragePriceOfProducts_ShouldReturnAvragePriceOfAllProducts()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.Products).Returns(new List<Product>
            {
                new Product(Id: 1, Name: "Product A", Category: Categories.Category2, Price: 100),
                new Product(Id: 2, Name: "Product B", Category: Categories.Category3, Price: 150),
                new Product(Id: 5, Name: "Product E", Category: Categories.Category2, Price: 80),
            });

        var service = new ProductService(mockRepository.Object);

        // Act
        var result = service.AvragePriceOfProducts();

        // Assert
        Assert.Equal(110, result);
    }
}