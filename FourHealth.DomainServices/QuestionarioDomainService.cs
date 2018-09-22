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
    internal class QuestionarioDomainService : IQuestionarioDomainService
    {
        private readonly IQuestionarioRepository repository;
        private readonly QuestionarioValidator validator;

        public QuestionarioDomainService(IQuestionarioRepository repository)
        {
            this.repository = repository;
            this.validator = new QuestionarioValidator();
        }

        public GenericResult<Questionario> Create(Questionario questionario)
        {
            var result = new GenericResult<Questionario>();

            var validatorResult = validator.Validate(questionario);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = this.repository.Create(questionario);
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

        public Questionario getById(int id)
        {
            return this.repository.getById(id);
        }

        public IEnumerable<Questionario> List(QuestionarioFilter filter)
        {
            return this.repository.List(filter);
        }

        public bool Update(Questionario questionario)
        {
            return this.repository.Update(questionario);
        }
    }
}
