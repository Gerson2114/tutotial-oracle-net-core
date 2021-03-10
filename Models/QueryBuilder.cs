using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OracleApplication.Models
{
    public class QueryBuilder<T>
    {
        //public static IEnumerable<T> GetList(T entity)
        //{
        //    try
        //    {
        //        IDbConnection connection = ConnectionManager.GetConnection();
        //        //string sql = GetColumnList(entity);
        //        string sql = "Select * From usuario";
        //        var result = connection.Query<T>(sql);

        //        ConnectionManager.CloseConnection(connection);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var msn = ex.Message;
        //        throw;
        //    }
        //}

        //private static string GetColumnList(T entity)
        //{
        //    string selectedColumns = "Select ";
        //    foreach (var prop in entity.GetType().GetProperties())
        //    {
        //        if (!prop.Name.Contains("_"))
        //        {
        //            selectedColumns = selectedColumns + ConvertToPascalCase(prop.Name) + " AS " + prop.Name + ",";
        //        }
        //    }

        //    return selectedColumns + " From " + ConvertToPascalCase(entity.GetType().Name);
        //}

        //private static string ConvertToPascalCase(string str)
        //{
        //    return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        //}
    }
}
