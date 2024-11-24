namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(a => a.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(a => a.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(a => a.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(a => a.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(a => a.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
