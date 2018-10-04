using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.SQLBuilderDemo
{
    public class Database
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];

        public Database(IDbConnection conn)
        {
            _conn = conn;
        }
        

        private IDbConnection _conn;
        
        public IDbCommand GetCommand(string sql, Dictionary<string, object> parameters = null)
        {
            var cmd = _conn.CreateCommand();

            cmd.CommandText = sql;

            if (parameters is null)
                return cmd;

            foreach (var p in parameters)
            {
                var parameter = cmd.CreateParameter();

                parameter.ParameterName = p.Key;
                parameter.Value = p.Value;

                cmd.Parameters.Add(parameter);
            }

            return cmd;
        }
    }
}
