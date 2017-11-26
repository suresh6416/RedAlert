using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RedAlert.Common
{
    public static class StoredProcedure<TEntity>
    {
        public static List<TEntity> Execute(string sp, StoredProcedureParams spParams)
        {
            using(APIContext _webcontext = new APIContext())
            {
                var sqlParams = spParams.AsSqlParameters();

                var paramNames = (from p in sqlParams
                                  select p.ParameterName).ToArray();

                return _webcontext.Database.SqlQuery<TEntity>("EXEC " + sp + " " + string.Join(",", paramNames), spParams.AsSqlParameters()).ToList();

            }
        }

        public static Task<List<TEntity>> ExecuteAsync(string sp, StoredProcedureParams spParams)
        {
            using (APIContext _webcontext = new APIContext())
            {
                var sqlParams = spParams.AsSqlParameters();
                var paramNames = (from p in sqlParams
                                  select p.ParameterName).ToArray();

                return _webcontext.Database.SqlQuery<TEntity>("EXEC " + sp + " " + string.Join(",", paramNames), spParams.AsSqlParameters()).ToListAsync();

            }
        }
    }    
}