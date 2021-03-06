using Application.Products.Commands.CreateProduct;
using Domain.Common.Enums;
using FluentValidation;

namespace Application.TodoItems.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
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