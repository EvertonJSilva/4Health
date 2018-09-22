using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FourHealth.Domain.Entities;

namespace FourHealth.Domain.Validators
{
    public class BeneficiarioValidator : AbstractValidator<Beneficiario>
    {

        public BeneficiarioValidator()
        {
            RuleFor(x => x.Nome).MinimumLength(4)
                .WithMessage("O campo 'Nome' deve ser preenchido.");

            RuleFor(x => x.Cpf).Custom((Cpf, context) =>
            {
                if (!CPFValidator.Validar(Cpf))
                {
                    context.AddFailure("Cpf informado é inválido");
                }
            }
            );
        }
    }
}
