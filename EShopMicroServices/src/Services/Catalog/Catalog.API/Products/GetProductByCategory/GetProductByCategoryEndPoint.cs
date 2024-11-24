
namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (ISender sender, string category) => { 
            var response = await sender.Send(new GetProductByCategoryQuery(category) ); 
                return TypedResults.Ok(response);
            });
        }
    }
}
