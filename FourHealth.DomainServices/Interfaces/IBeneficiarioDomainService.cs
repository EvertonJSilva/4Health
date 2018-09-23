using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.Domain.Results;

namespace FourHealth.DomainServices.Interfaces
{
    public interface IBeneficiarioDomainService
    {
        GenericResult<Beneficiario> Create(Beneficiario beneficiario);

        IEnumerable<Beneficiario> List(BeneficiarioFilter filter);

        Beneficiario getById(int id);

        GenericResult<Beneficiario> Update(Beneficiario beneficiario);
        bool Delete(int id);
    }
}
