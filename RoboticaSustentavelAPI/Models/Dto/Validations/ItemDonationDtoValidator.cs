using FluentValidation;
using RoboticaSustentavelAPI.Models.Dto.ItemDonation;

namespace ProjetoLivrariaAPI.Models.Dtos.Validations
{
    public class CreateItemDonationDtoValidator : AbstractValidator<CreateItemDonationDto>
    {
        public CreateItemDonationDtoValidator()
        {
            RuleFor(x => x.ComputerId)
                 .NotEmpty().WithMessage("O ID do computador deve ser informado.")
                 .GreaterThan(0).WithMessage("O ID do computador deve ser maior que zero.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("A quantidade deve ser informada.")
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");

            RuleFor(x => x.DonationId)
                .GreaterThan(0)
                .WithMessage("O ID da doação deve ser maior que zero se informado.");
        }
    }
}
