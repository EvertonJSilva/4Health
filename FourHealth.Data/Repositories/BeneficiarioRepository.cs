using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.Domain.Repositories;
using Microsoft.Extensions.Configuration;

using Dapper;

namespace FourHealth.Data.Repositories
{
    internal class BeneficiarioRepository : RepositoryBase, IBeneficiarioRepository
    {
        public BeneficiarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Beneficiario Create(Beneficiario beneficiario)
        {
            beneficiario.Id = Connection.QueryFirst<int>("exec sp_create @Text, @IsCompleted", beneficiario, transaction: transaction);
            return beneficiario;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Beneficiario getById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Beneficiario>("exec sp_get @Id", new { Id = id }, transaction: transaction);
            return result;
        }

        public IEnumerable<Beneficiario> List(BeneficiarioFilter filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Beneficiario beneficiario)
        {
            throw new NotImplementedException();
        }
    }
}
