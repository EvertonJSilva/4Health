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
            beneficiario.Id = Connection.QueryFirst<int>("exec beneficiario_sp_create @Nome, @CPF", beneficiario, transaction: transaction);
            return beneficiario;
        }

        public bool Delete(int id)
        {
            var affectedRows = Connection.Execute("Exec base_sp_delete @Id, [Beneficiario]", new { Id = id }, transaction: transaction);

            return affectedRows > 0;
        }

        public Beneficiario getById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Beneficiario>("exec base_sp_get @Id, [Beneficiario]", new { Id = id }, transaction: transaction);
            return result;
        }

        public IEnumerable<Beneficiario> List(BeneficiarioFilter filter)
        {
            var result = Connection.Query<Beneficiario>("exec beneficiario_sp_list @Nome, @cpf, @Id", filter, transaction: transaction);

            return result;
        }

        public bool Update(Beneficiario beneficiario)
        {
            var affectedRows = Connection.Execute("exec beneficiario_sp_update @Nome, @cpf, @Id", beneficiario, transaction: transaction);
            return affectedRows > 0;
        }
    }
}
