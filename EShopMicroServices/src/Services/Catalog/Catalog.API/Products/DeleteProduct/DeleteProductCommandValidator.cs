namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(a=>a.Id).NotEmpty().WithMessage("Id is required");
    }
}
