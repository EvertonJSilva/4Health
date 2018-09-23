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
    internal class QuestionarioAppService : IQuestionarioAppService
    {
        private readonly IQuestionarioDomainService service;

        public QuestionarioAppService(IQuestionarioDomainService service)
        {
            this.service = service;
        }

        public GenericResult<QuestionarioDTO> Create(QuestionarioDTO questionario)
        {
            var result = service.Create(questionario.MapTo<Questionario>());
            return result.MapTo<GenericResult<QuestionarioDTO>>();
        }


        public bool Delete(int id)
        {
            return service.Delete(id);
        }

        public QuestionarioDTO getById(int id)
        {
            var result = service.getById(id);
            return result.MapTo<QuestionarioDTO>();
        }

        public IEnumerable<QuestionarioDTO> List(QuestionarioFilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(QuestionarioDTO programa)
        {
            throw new NotImplementedException();
        }
    }
}
