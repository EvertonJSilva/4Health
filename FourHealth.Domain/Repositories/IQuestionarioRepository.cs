using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;

namespace FourHealth.Domain.Repositories
{
    public interface IQuestionarioRepository
    {
        Questionario Create(Questionario questionario);

        IEnumerable<Questionario> List(QuestionarioFilter filter);

        Questionario getById(int id);

        bool Update(Questionario questionario);
        bool Delete(int id);
    }
}
