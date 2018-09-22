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
    internal class PerguntaRepository : RepositoryBase, IPerguntaRepository
    {
        public PerguntaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Pergunta Create(Pergunta pergunta)
        {
            pergunta.Id = Connection.QueryFirst<int>("exec sp_create @Text, @IsCompleted", pergunta, transaction: transaction);
            return pergunta;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pergunta getById(int id)
        {
            var result = Connection.QueryFirstOrDefault<Pergunta>("exec sp_get @Id", new { Id = id }, transaction: transaction);
            return result;
        }

        public IEnumerable<Pergunta> List(PerguntaFilter filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pergunta pergunta)
        {
            throw new NotImplementedException();
        }
    }
}
