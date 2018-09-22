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
    internal class ProgramaRepository : RepositoryBase, IProgramaRepository
    {
        public ProgramaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Programa Create(Programa programa)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Programa getById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Programa> List(ProgramaFilter filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Programa programa)
        {
            throw new NotImplementedException();
        }
    }
}
