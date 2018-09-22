using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.Domain.Results;

namespace FourHealth.DomainServices.Interfaces
{
    public interface IQuestionarioDomainService
    {
        GenericResult<Questionario> Create(Questionario pergunta);

        IEnumerable<Questionario> List(QuestionarioFilter filter);

        Questionario getById(int id);

        bool Update(Questionario questionario);
        bool Delete(int id);
    }
}
