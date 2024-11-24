
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(Guid Id, string Name, ICollection<string> Category, string Description, string ImageFile, decimal Price);
public record UpdateProductResponse(bool Result);
public class UpdateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var product = request.Adapt<UpdateProductCommand>();
            var result = await sender.Send(product);

            var response = result.Adapt<UpdateProductResponse>();
            return Results.Ok(result);
        })
        .WithName("UpdateProduct")
        .Produces<CreateProductResponse>(statusCode: StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Update product")
        .WithDescription("Update product");
    }
}
