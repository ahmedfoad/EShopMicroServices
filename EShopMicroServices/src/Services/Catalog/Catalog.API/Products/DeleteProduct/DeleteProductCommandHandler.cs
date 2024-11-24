
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductCommandResult>;
    public record DeleteProductCommandResult(bool IsSuccess);
    public class DeleteProductCommandHandler(IDocumentSession documentSession, ILogger<DeleteProductCommandHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductCommandResult>
    {
        public async Task<DeleteProductCommandResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handle called with {@command}", command);

            var product = documentSession.LoadAsync<Product>(command.Id);
            documentSession.Delete(product);
            await documentSession.SaveChangesAsync();
            return new DeleteProductCommandResult(true);
        }
    }
}
