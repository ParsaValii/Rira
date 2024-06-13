using Rira.Domain.Entities;

namespace Rira.Application.IRepository;

public interface IProductRepository
{
    IEnumerable<Product> Products { get; }
}