using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.DomainServices.Interfaces;
using FourHealth.AppServices.DTOs;
using FourHealth.AppServices.Interfaces;
using FourHealth.AppServices.Extensions;
using FourHealth.Domain.Results;

namespace FourHealth.AppServices
{
    internal class BeneficiarioAppService : IBeneficiarioAppService
    {
        private readonly IBeneficiarioDomainService service;

        public BeneficiarioAppService(IBeneficiarioDomainService service)
        {
            this.service = service;
        }
        
        public GenericResult<BeneficiarioDTO> Create(BeneficiarioDTO beneficiario)
        {
            var result = service.Create(beneficiario.MapTo<Beneficiario>());
            return result.MapTo<GenericResult<BeneficiarioDTO>>();
        }

        
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BeneficiarioDTO getById(int id)
        {
            var result = service.getById(id);
            return result.MapTo<BeneficiarioDTO>();
        }

        public IEnumerable<BeneficiarioDTO> List(BeneficiarioFilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(BeneficiarioDTO beneficiario)
        {
            throw new NotImplementedException();
        }
    }
}
