namespace Catalog.API.Exceptions;

public class ProductNotFoundException(Guid Id) : Exception($"Product not found with Id: {Id}")
{
}
