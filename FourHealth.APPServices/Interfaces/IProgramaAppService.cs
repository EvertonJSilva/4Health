using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;
using FourHealth.Domain.Results;

namespace FourHealth.AppServices.Interfaces
{
    public interface IProgramaAppService
    {
        GenericResult<ProgramaDTO> Create(ProgramaDTO programa);

        IEnumerable<ProgramaDTO> List(ProgramaFilterDTO filter);

        ProgramaDTO getById(int id);

        bool Update(ProgramaDTO programa);
        bool Delete(int id);
    }
}
