using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;
using FourHealth.Domain.Results;

namespace FourHealth.AppServices.Interfaces
{
    public interface IPerguntaAppService
    {
        GenericResult<PerguntaDTO> Create(PerguntaDTO pergunta);

        IEnumerable<PerguntaDTO> List(PerguntaFilterDTO filter);

        PerguntaDTO getById(int id);

        bool Update(PerguntaDTO pergunta);
        bool Delete(int id);
    }
}
