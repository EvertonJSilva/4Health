using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.Domain.Results;

namespace FourHealth.DomainServices.Interfaces
{
    public interface IProgramaDomainService
    {

        GenericResult<Programa> Create(Programa programa);

        IEnumerable<Programa> List(ProgramaFilter filter);

        Programa getById(int id);

        bool Update(Programa programa);
        bool Delete(int id);
    }
}
