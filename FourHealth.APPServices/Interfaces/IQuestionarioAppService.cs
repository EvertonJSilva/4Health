using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;
using FourHealth.Domain.Results;

namespace FourHealth.AppServices.Interfaces
{
    public interface IQuestionarioAppService
    {
        GenericResult<QuestionarioDTO> Create(QuestionarioDTO questionario);

        IEnumerable<QuestionarioDTO> List(QuestionarioFilterDTO filter);

        QuestionarioDTO getById(int id);

        bool Update(QuestionarioDTO questionario);
        bool Delete(int id);
    }
}
