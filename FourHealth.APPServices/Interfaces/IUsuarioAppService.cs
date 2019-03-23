using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.AppServices.DTOs;


namespace FourHealth.AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioDTO Find(string userID);
    }
}
