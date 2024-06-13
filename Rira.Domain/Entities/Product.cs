using Rira.Domain.Enums;

namespace Rira.Domain.Entities;

public record Product(int Id, string Name, Categories Category, decimal Price);