
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (ISender sender, string category) => { 
            var response = await sender.Send(new GetProductByCategoryQuery(category) ); 
                return TypedResults.Ok(response);
            })
            .WithName("GetProductsByCategory")
            .Produces<GetProductByCategoryResult>(statusCode: StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Get all products By Category")
            .WithDescription("Get all products By Category");
        }
    }
}
