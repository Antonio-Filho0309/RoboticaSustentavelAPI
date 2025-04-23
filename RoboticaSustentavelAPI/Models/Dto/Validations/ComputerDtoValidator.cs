using FluentValidation;
using RoboticaSustentavelAPI.Models.Dto.Computer;

namespace ProjetoLivrariaAPI.Models.Dtos.Validations
{
    public class CreateComputerDtoValidator : AbstractValidator<CreateComputerDto>
    {
        public CreateComputerDtoValidator()
        {
            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage("A marca deve ser informada.")
                .MinimumLength(2).WithMessage("A marca deve ter pelo menos 2 caracteres.")
                .MaximumLength(50).WithMessage("A marca deve ter no máximo 50 caracteres.");

            RuleFor(c => c.Ram)
                .NotEmpty().WithMessage("A memória RAM deve ser informada.")
                .MaximumLength(20).WithMessage("A RAM deve ter no máximo 20 caracteres.");

            RuleFor(c => c.Storage)
                .NotEmpty().WithMessage("O armazenamento deve ser informado.")
                .MaximumLength(20).WithMessage("O armazenamento deve ter no máximo 20 caracteres.");

            RuleFor(c => c.CPU)
                .NotEmpty().WithMessage("O processador deve ser informado.")
                .MaximumLength(100).WithMessage("O processador deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
        }
    }


    namespace ProjetoLivrariaAPI.Models.Dtos.Validations
    {
        public class UpdateComputerDtoValidator : AbstractValidator<UpdateComputerDto>
        {
            public UpdateComputerDtoValidator()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0).WithMessage("O ID deve ser maior que zero.");

                RuleFor(c => c.Status)
                    .IsInEnum().WithMessage("Status inválido para o computador.");
            }
        }
    }

}
