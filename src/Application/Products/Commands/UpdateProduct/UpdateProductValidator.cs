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
            .NotEmpty();
        RuleFor(v => v.Dto.Price)
            .NotEmpty();
        RuleFor(v => v.Dto.Description)
            .NotEmpty();
        RuleFor(v => v.Dto.Stock)
            .NotEmpty();

    }
}