using System;
using System.Collections.Generic;
using System.Text;
using FourHealth.Domain.Entities;
using FourHealth.Domain.Filters;
using FourHealth.Domain.Repositories;
using Microsoft.Extensions.Configuration;

using Dapper;
using System.Data.SqlClient;

namespace FourHealth.Data.Repositories
 {
        internal class UsuarioRepository : RepositoryBase, IUsuarioRepository
        {
            public UsuarioRepository(IConfiguration configuration) : base(configuration)
            {
            }

            public Usuario Find(string userID)
            {
                return Connection.QueryFirstOrDefault<Usuario>(
                    "SELECT UserID, AccessKey " +
                    "FROM dbo.Users " +
                    "WHERE UserID = @UserID", new { UserID = userID });
            }

        }
    
}