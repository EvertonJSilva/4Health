using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;

namespace FourHealth.Domain.Repositories
{
    public interface IPerguntaRepository
    {
        Pergunta Create(Pergunta pergunta);

        IEnumerable<Pergunta> List(PerguntaFilter filter);

        Pergunta getById(int id);

        bool Update(Pergunta pergunta);
        bool Delete(int id);
    }
}
