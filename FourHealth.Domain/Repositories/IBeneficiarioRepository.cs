using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;

namespace FourHealth.Domain.Repositories
{
    public interface IBeneficiarioRepository
    {
        Beneficiario Create(Beneficiario beneficiario);

        IEnumerable<Beneficiario> List(BeneficiarioFilter filter);

        Beneficiario getById(int id);

        bool Update(Beneficiario beneficiario);
        bool Delete(int  id);
    }
}
