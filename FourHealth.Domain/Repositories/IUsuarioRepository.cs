using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;

namespace FourHealth.Domain.Repositories
{
    
    public interface IUsuarioRepository
    {
        Usuario Find(string userID);
    }
}
