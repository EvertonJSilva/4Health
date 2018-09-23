using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
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
            return service.Delete(id);
        }

        public BeneficiarioDTO getById(int id)
        {
            var result = service.getById(id);
            return result.MapTo<BeneficiarioDTO>();
        }

        public IEnumerable<BeneficiarioDTO> List(BeneficiarioFilterDTO filter)
        {
            return service.List(filter.MapTo<BeneficiarioFilter>()).EnumerableTo<BeneficiarioDTO>();
        }

        public GenericResult<BeneficiarioDTO> Update(BeneficiarioDTO beneficiario)
        {
            var result = service.Update(beneficiario.MapTo<Beneficiario>());
            return result.MapTo<GenericResult<BeneficiarioDTO>>();
            
        }
    }
}
