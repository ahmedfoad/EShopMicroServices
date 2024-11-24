using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductsById;

public record GetProductByIdResponse(Product Product);
public class GetProductsByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            var response = result.Adapt(result);
            return Results.Ok(response);
        })
            .WithName("GetProductById")
            .Produces<GetProductsResult>(statusCode: StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
    }
}
