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
    internal class PerguntaAppService : IPerguntaAppService
    {
        private readonly IPerguntaDomainService service;

        public PerguntaAppService(IPerguntaDomainService service)
        {
            this.service = service;
        }

        public GenericResult<PerguntaDTO> Create(PerguntaDTO pergunta)
        {
            var result = service.Create(pergunta.MapTo<Pergunta>());
            return result.MapTo<GenericResult<PerguntaDTO>>();
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PerguntaDTO getById(int id)
        {
            var result = service.getById(id);
            return result.MapTo<PerguntaDTO>();
        }

        public IEnumerable<PerguntaDTO> List(PerguntaFilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(PerguntaDTO programa)
        {
            throw new NotImplementedException();
        }
    }
}
