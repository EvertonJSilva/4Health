using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.Domain.Results;

namespace FourHealth.DomainServices.Interfaces
{
    public interface IPerguntaDomainService
    {
        GenericResult<Pergunta> Create(Pergunta pergunta);

        IEnumerable<Pergunta> List(PerguntaFilter filter);

        Pergunta getById(int id);

        bool Update(Pergunta pergunta);
        bool Delete(int id);
    }
}
