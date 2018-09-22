using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;

namespace FourHealth.Domain.Repositories
{
    public interface IProgramaRepository
    {
        Programa Create(Programa programa);

        IEnumerable<Programa> List(ProgramaFilter filter);

        Programa getById(int id);

        bool Update(Programa programa);
        bool Delete(int id);
    }
}
