using FluentValidation;
using RoboticaSustentavelAPI.Models.Dto.ItemSale;

public class CreateItemSaleDtoValidator : AbstractValidator<CreateItemSaleDto>
{

    private bool HasMaxTwoDecimalPlaces(double value)
    {
        return Math.Abs(value * 100 - Math.Round(value * 100)) < 0.0001;
    }

    public CreateItemSaleDtoValidator()
    {
        RuleFor(x => x.ComputerId)
            .GreaterThan(0).WithMessage("O ID do computador deve ser maior que zero.");

        RuleFor(x => x.PriceSale)
      .GreaterThan(0).WithMessage("O preço da venda deve ser maior que zero.")
      .LessThanOrEqualTo(10000).WithMessage("O preço da venda não pode ultrapassar R$10.000.")
      .Must(HasMaxTwoDecimalPlaces).WithMessage("O preço deve ter no máximo 2 casas decimais.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.")
            .LessThanOrEqualTo(100).WithMessage("A quantidade não pode ser maior que 100 unidades.");
    }
}
