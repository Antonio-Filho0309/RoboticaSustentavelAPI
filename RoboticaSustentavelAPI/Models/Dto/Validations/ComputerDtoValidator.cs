﻿using FluentValidation;
using RoboticaSustentavelAPI.Models.Dto.Computer;

namespace ProjetoLivrariaAPI.Models.Dtos.Validations
{
    public class CreateComputerDtoValidator : AbstractValidator<CreateComputerDto>
    {
        public CreateComputerDtoValidator()

        {
            RuleFor(c => c.CPU)
            .NotEmpty().WithMessage("O processador deve ser informado.")
            .MaximumLength(20).WithMessage("A RAM deve ter no máximo 20 caracteres.");

            RuleFor(c => c.Ram)
                .NotEmpty().WithMessage("A memória RAM deve ser informada.")
                .MaximumLength(20).WithMessage("A RAM deve ter no máximo 20 caracteres.");

            RuleFor(c => c.Storage)
                .NotEmpty().WithMessage("O armazenamento deve ser informado.")
                .MaximumLength(20).WithMessage("O armazenamento deve ter no máximo 20 caracteres.");


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

                RuleFor(c => c.CPU)
                    .NotEmpty().WithMessage("O processador deve ser informado.")
                    .MaximumLength(20).WithMessage("A RAM deve ter no máximo 20 caracteres.");

                RuleFor(c => c.Ram)
                    .NotEmpty().WithMessage("A memória RAM deve ser informada.")
                    .MaximumLength(20).WithMessage("A RAM deve ter no máximo 20 caracteres.");

                RuleFor(c => c.Storage)
                    .NotEmpty().WithMessage("O armazenamento deve ser informado.")
                    .MaximumLength(20).WithMessage("O armazenamento deve ter no máximo 20 caracteres.");


                RuleFor(c => c.Quantity)
                    .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
            }
        }
    }

}
