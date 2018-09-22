using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.DomainServices.Interfaces;
using FourHealth.Domain.Repositories;
using FourHealth.Domain.Results;
using FourHealth.Domain.Validators;
using FourHealth.Domain.Extensions;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FourHealth.Tests")]
namespace FourHealth.DomainServices
{
    internal class ProgramaDomainService : IProgramaDomainService
    {
        private readonly IProgramaRepository repository;
        public ProgramaValidator validator;

        public ProgramaDomainService(IProgramaRepository repository)
        {
            this.repository = repository;
            this.validator = new ProgramaValidator();
        }

        public GenericResult<Programa> Create(Programa programa)
        {
     
            var result = new GenericResult<Programa>();

            var validatorResult = validator.Validate(programa);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = this.repository.Create(programa);
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

        public Programa getById(int id)
        {
            return this.repository.getById(id);
        }

        public IEnumerable<Programa> List(ProgramaFilter filter)
        {
            return this.repository.List(filter);
        }

        public bool Update(Programa programa)
        {
            return this.repository.Update(programa);
        }
    }
}
