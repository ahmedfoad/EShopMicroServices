﻿namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery: IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);

public class GetProductsHandler(IDocumentSession documentSession) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var response = await documentSession.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductsResult(response);
    }
}
