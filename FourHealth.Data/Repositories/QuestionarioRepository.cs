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
    internal class QuestionarioRepository : RepositoryBase, IQuestionarioRepository
    {
        public QuestionarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Questionario Create(Questionario questionario)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Questionario getById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Questionario> List(QuestionarioFilter filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Questionario questionario)
        {
            throw new NotImplementedException();
        }
    }
}
