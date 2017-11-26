using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RedAlert.Common
{
    public class StoredProcedureParams
    {
        public SqlParameter[] AsSqlParameters()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            var properties = this.GetType().GetProperties();
            foreach (var p in properties)
            {
                object value = p.GetValue(this);
                SqlParameter parameter = new SqlParameter("@" + p.Name, value == null ? DBNull.Value : value);
                sqlParameters.Add(parameter);
            }

            return sqlParameters.ToArray();
        }

    }
}