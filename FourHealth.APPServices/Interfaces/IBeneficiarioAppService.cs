using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;
using FourHealth.Domain.Results;

namespace FourHealth.AppServices.Interfaces
{
    public interface IBeneficiarioAppService
    {
        GenericResult<BeneficiarioDTO> Create(BeneficiarioDTO beneficiario);

        IEnumerable<BeneficiarioDTO> List(BeneficiarioFilterDTO filter);
        
        BeneficiarioDTO getById(int id);

        bool Update(BeneficiarioDTO beneficiario);
        bool Delete(int id);
    }
}
