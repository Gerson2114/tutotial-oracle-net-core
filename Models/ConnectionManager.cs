using Dapper;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OracleApplication.Models
{
    public class ConnectionManager
    {
        //public OracleDbContex(DbContextOptions<OracleDbContex> options)
        //            : base(options)
        //{
        //}
        //public DbSet<usuario> usuario { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //OracleConfiguration.TnsAdmin = @"C:\Users\gerson.alonso\Downloads\Wallet_DB202101231546\tnsnames.ora";
        //    //OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;
        //    optionsBuilder.UseOracle(@"User Id=ADMIN;Password=TL-sg1024TL-sg3424;Data Source=db202101231546_tp");
        //    //OracleConfiguration.OracleDataSources.Add("orclpdb", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=adb.us-ashburn-1.oraclecloud.com)(PORT=1522))(CONNECT_DATA=(SERVICE_NAME=kpbmxgz54jv17nf_db202101231546_tp.adb.oraclecloud.com)))");
        //}
        public ConnectionManager()
        {
            GetConnection();
        }
        public OracleConnection _conn { get; set; }
        public void GetConnection()
        {
            try
            {
                string conString = "User Id=ADMIN;Password=TL-sg1024TL-sg3424;Pooling=False;Connection Timeout=120;Data Source=orclpdb;";
                string ConWallet = "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=adb.us-ashburn-1.oraclecloud.com))(connect_data=(service_name=kpbmxgz54jv17nf_db202101231546_tp.adb.oraclecloud.com))(security=(ssl_server_cert_dn=\"CN=adwc.uscom-east-1.oraclecloud.com,OU=Oracle BMCS US,O=Oracle Corporation,L=Redwood City,ST=California,C=US\")))";
                OracleConfiguration.OracleDataSources.Add("orclpdb", ConWallet);
                OracleConfiguration.StatementCacheSize = 25;
                OracleConfiguration.SelfTuning = false;
                OracleConfiguration.BindByName = true;
                OracleConfiguration.CommandTimeout = 120;
                OracleConfiguration.FetchSize = 1024 * 1024;
                OracleConfiguration.SendBufferSize = 8192;
                OracleConfiguration.ReceiveBufferSize = 8192;
                OracleConfiguration.DisableOOB = true;
                var conn = new OracleConnection(conString);
                _conn = conn;
                //using (OracleConnection conn = new OracleConnection(conString))
                //{
                //    try
                //    {
                //        if (conn.State == ConnectionState.Closed)
                //        {
                //            //conn.Open();
                //            //string sql = "Select * From usuario";
                //            //var result = conn.Query<List<usuario>>(sql);
                //        }
                //        this._conn = conn;
                //    }
                //    catch (Exception ex)
                //    {
                //        var msn = ex.Message;
                //        conn.Close();
                //        throw;
                //    }
                //}
            }
            catch (Exception ex)
            {
                var msn = ex.Message;
                throw;
            }
        }
    }
}

