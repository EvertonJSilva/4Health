using FourHealth.Domain.Entities;
using FourHealth.DomainServices.Interfaces;
using FourHealth.AppServices.DTOs;
using FourHealth.AppServices.Interfaces;
using FourHealth.AppServices.Extensions;
using FourHealth.Domain.Results;

namespace FourHealth.AppServices
{
    internal class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService service;

        public UsuarioAppService(IUsuarioDomainService service)
        {
            this.service = service;
        }

        public UsuarioDTO Find(string userID)
        {
            var result =  service.Find(userID);
            return result.MapTo<UsuarioDTO>();
        }
    }
}
