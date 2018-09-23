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
    internal class BeneficiarioDomainServices : IBeneficiarioDomainService
    {
        private readonly IBeneficiarioRepository repository;
        private BeneficiarioValidator validator;

        public BeneficiarioDomainServices(IBeneficiarioRepository repository)
        {
            this.repository = repository;
            this.validator = new BeneficiarioValidator();
        }

        public GenericResult<Beneficiario> Create(Beneficiario beneficiario)
        {
            
            var result = new GenericResult<Beneficiario>();

            var validatorResult = validator.Validate(beneficiario);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = this.repository.Create(beneficiario);
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

        public Beneficiario getById(int id)
        {
            return this.repository.getById(id);
        }

        public IEnumerable<Beneficiario> List(BeneficiarioFilter filter)
        {
            return this.repository.List(filter);
        }

        public GenericResult<Beneficiario> Update(Beneficiario beneficiario)
        {
            var result = new GenericResult<Beneficiario>();

            var validatorResult = validator.Validate(beneficiario);
            if (validatorResult.IsValid)
            {
                try
                { 
                    result.Success = this.repository.Update(beneficiario);

                    if (!result.Success)
                    {
                        result.Errors = validatorResult.GetErrors("Registro não encontrado");
                    }
                    else
                    {
                        result.Result = this.repository.getById(beneficiario.Id);
                    }
                       
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
    }
}
