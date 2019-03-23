using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;

namespace FourHealth.DomainServices.Interfaces
{
    public interface IUsuarioDomainService
    {
        Usuario Find(string userID);
    }
}
