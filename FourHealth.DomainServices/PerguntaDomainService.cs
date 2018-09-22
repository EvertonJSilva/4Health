using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.Domain.Results;

using FourHealth.DomainServices.Interfaces;
using FourHealth.Domain.Repositories;
using FourHealth.Domain.Validators;
using FourHealth.Domain.Extensions;

namespace FourHealth.DomainServices
{
    internal class PerguntaDomainService : IPerguntaDomainService
    {
        private readonly IPerguntaRepository repository;
        private readonly PerguntaValidator validator;

        public PerguntaDomainService(IPerguntaRepository repository)
        {
            this.repository = repository;
            this.validator = new PerguntaValidator();
        }

        public GenericResult<Pergunta> Create(Pergunta pergunta)
        {
            var result = new GenericResult<Pergunta>();

            var validatorResult = validator.Validate(pergunta);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = this.repository.Create(pergunta);
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
                result.Errors = validatorResult.GetErrors();

            return result;
        }

        public bool Delete(int id)
        {
            return this.repository.Delete(id);
        }

        public Pergunta getById(int id)
        {
            return this.repository.getById(id);
        }

        public IEnumerable<Pergunta> List(PerguntaFilter filter)
        {
            return this.repository.List(filter);
        }

        public bool Update(Pergunta pergunta)
        {
            return this.repository.Update(pergunta);
        }
    }
}
