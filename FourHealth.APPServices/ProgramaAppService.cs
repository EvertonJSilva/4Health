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
    internal class ProgramaAppService : IProgramaAppService
    {
        private readonly IProgramaDomainService service;

        public ProgramaAppService(IProgramaDomainService service)
        {
            this.service = service;
        }

        public GenericResult<ProgramaDTO> Create(ProgramaDTO programa)
        {
            var result = service.Create(programa.MapTo<Programa>());
            return result.MapTo<GenericResult<ProgramaDTO>>();
        }


        public bool Delete(int id)
        {
            return service.Delete(id);
        }

        public ProgramaDTO getById(int id)
        {
            var result = service.getById(id);
            return result.MapTo<ProgramaDTO>();
        }

        public IEnumerable<ProgramaDTO> List(ProgramaFilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProgramaDTO programa)
        {
            throw new NotImplementedException();
        }
    }
}
