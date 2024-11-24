﻿namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, ICollection<string> Category, string Description, string ImageFile, decimal Price)
    :ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);


public class CreateProductHandler(IDocumentSession documentSession) 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
           Name = command.Name,
           Category = command.Category,
           Description = command.Description,
           ImageFile = command.ImageFile,
           Price = command.Price
        };

        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);
      
        return new CreateProductResult(product.Id);
    }
}
