using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FourHealth.Domain.Entities;

namespace FourHealth.Domain.Validators
{
    public class ProgramaValidator : AbstractValidator<Programa>
    {
        //-	Nome do programa: mínimo de 10 caracteres e no máximo 150.
        //-	Descrição do programa: mínimo de 30 caracteres e no máximo 1000.
        //-	Questionário específico: deve informar um questionário já cadastrado(RF004)
        //-	Filtro de idade(opcional) : permite que um programa seja criado apenas para uma faixa de idade
        //-	Filtro de sexo(opcional) : permite que um programa seja criado apenas para um sexo específico
        //-	Filtro de cidade(opcional) : permite que programas sejam criadas apenas para um cidade


        public ProgramaValidator()
        {
            RuleFor(x => x.Nome).MinimumLength(10)
                .WithMessage("O campo 'Nome' deve ter pelo menos 10 caracteres");

            RuleFor(x => x.Nome).MaximumLength(150)
                .WithMessage("O campo 'Nome' deve ter no máximo 150 caracteres");

            RuleFor(x => x.Questionario.Id)
              .NotEmpty()
              .WithMessage("Questionário informado é inválido.");

            RuleFor(x => x).Custom((programa, context) =>
            {
                if (programa.IdadeMinima > programa.IdadeMaxima && !String.IsNullOrEmpty(programa.IdadeMaxima.ToString()))  
                    context.AddFailure("Idade mínima não pode maior que a máxima.");
            }
            );

          


        }
    }
}
