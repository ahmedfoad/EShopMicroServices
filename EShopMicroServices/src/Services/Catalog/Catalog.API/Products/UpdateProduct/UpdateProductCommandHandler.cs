
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, ICollection<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);
    public class UpdateProductCommandHandler(IDocumentSession documentSession, ILogger<UpdateProductCommandHandler> logger) : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommandHandler.Handle called ith {@Command}", command);

            var product = await documentSession.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null)
                throw new ProductNotFoundException(command.Id);

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            await documentSession.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult(true);
        }
    }
}
