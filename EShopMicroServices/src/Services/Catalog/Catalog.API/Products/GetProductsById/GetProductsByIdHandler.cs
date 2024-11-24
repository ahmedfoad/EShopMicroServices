namespace Catalog.API.Products.GetProductsById;

public record GetProductByIdQuery(Guid Id) : IRequest<GetProductByIdResponse>;

public class GetProductsByIdHandler(IDocumentSession documentSession, ILogger<GetProductsByIdHandler> logger) : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsByIdHandler.Handle called with {@Query}", query);
        var product = await documentSession.LoadAsync<Product>(query.Id, cancellationToken);
        if (product is null)
            throw new ProductNotFoundException(query.Id);

        return new GetProductByIdResponse(product);
    }
}
