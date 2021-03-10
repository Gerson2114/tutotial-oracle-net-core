using Oracle.ManagedDataAccess.Client;
using OracleApplication.Intefaces;
using OracleApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace OracleApplication.Services
{
    public class UsuariosService : IUsuario
    {
        private readonly ConnectionManager _ctx;
        public UsuariosService(ConnectionManager ctx)
        {
            this._ctx = ctx;
        }
        public List<usuario> usuarios()
        {
            try
            {
                IDbConnection conn = _ctx._conn;
                string sql = "GET_USUARIOS";
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    OracleParameter oracleParameter = new OracleParameter("USERS_",OracleDbType.RefCursor , ParameterDirection.Output);
                    //var user = SqlMapper.Query<usuario>(conn, "SELECT * FROM USUARIO",commandType: CommandType.Text).ToList();
                    var user = SqlMapper.Query<usuario>(conn, sql, param: oracleParameter, commandType: CommandType.StoredProcedure).ToList();
                }
                List<usuario> usuarios = new List<usuario>();
                return usuarios;
            }
            catch (Exception ex)
            {
                var msn = ex.Message;
                throw;
            }
        }
    }
}
