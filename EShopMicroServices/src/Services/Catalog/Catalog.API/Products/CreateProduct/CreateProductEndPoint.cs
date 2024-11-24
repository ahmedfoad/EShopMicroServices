namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(string Name, ICollection<string> Category, string Description, string ImageFile, decimal Price);
public record CreateProductResponse(Guid Id);
public class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products" , async(CreateProductRequest request, ISender sender) => { 
            var command = request.Adapt<CreateProductCommand>(); 
            var createProductResult = await sender.Send(command);
            var response = createProductResult.Adapt<CreateProductResponse>();
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(statusCode: StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Create a new product")
        .WithDescription("Create a new product");
    }
}
