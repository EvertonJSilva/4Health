using FourHealth.DomainServices.Interfaces;
using FourHealth.Domain.Repositories;
using FourHealth.Domain.Validators;
using FourHealth.Domain.Extensions;
using FourHealth.Domain.Entities;

namespace FourHealth.DomainServices
{
    internal class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository repository;

        public UsuarioDomainService(IUsuarioRepository repository)
        {
            this.repository = repository;

        }

        public Usuario Find(string userID)
        {
            return repository.Find(userID);
        }
    }
}
