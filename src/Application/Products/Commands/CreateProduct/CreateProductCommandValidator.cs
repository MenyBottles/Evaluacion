using Application.Products.Commands.CreateProduct;
using FluentValidation;

namespace Application.TodoItems.Commands.CreateProduct;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateTodoItemCommandValidator()
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