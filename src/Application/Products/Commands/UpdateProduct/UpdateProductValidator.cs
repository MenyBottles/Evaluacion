using Application.Products.Commands.UpdateProduct;
using FluentValidation;

namespace Application.TodoItems.Commands.CreateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(v => v.Dto.Name)
            .NotEmpty();
        RuleFor(v => v.Dto.StatusId)
            .NotNull()
            .IsInEnum();
        RuleFor(v => v.Dto.Price)
            .NotNull()
            .NotEmpty();
        RuleFor(v => v.Dto.Description)
            .NotEmpty();
        RuleFor(v => v.Dto.Stock)
            .NotNull();

    }
}