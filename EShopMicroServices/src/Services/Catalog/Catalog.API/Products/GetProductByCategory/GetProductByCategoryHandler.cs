
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IRequest<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);
public class GetProductByCategoryHandler(IDocumentSession documentSession, ILogger<GetProductByCategoryHandler> logger) : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting products by category {Category}", query.Category);

        var products = await documentSession.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync();

        return new GetProductByCategoryResult(products);
    }
}
