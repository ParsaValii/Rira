using Rira.Domain.Enums;

namespace Rira.Domain.Entities;

public class GroupedProduct
{
    public Categories Category { get; set; }
    public IList<Product>? Products { get; set; }
}