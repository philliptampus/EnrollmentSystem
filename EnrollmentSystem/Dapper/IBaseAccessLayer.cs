using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingAPI.Dapper
{
   public interface IBaseAccessLayer
    {
        string ConnString { get; set; }

        Task<int> ExecuteNonQueryAsync(string queryToExec, object parameters = null,
            CommandType commandType = CommandType.StoredProcedure, int? timeOut = 0);
        Task<T> ExecuteScalarAsync<T>(string queryToExec, object parameters, CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<T>> QueryListAsync<T>(string queryToExec, object parameters = null, CommandType commandType = CommandType.StoredProcedure);

        Task<T> QuerySingleOrDefaultAsync<T>(string queryToExec, object parameters = null,
            CommandType commandType = CommandType.StoredProcedure);

        Task<T> QueryFirstOrDefaultAsync<T>(string queryToExec, object parameters = null,
            CommandType commandType = CommandType.StoredProcedure);

        Task<T> QueryLastOrDefaultAsync<T>(string queryToExec, object parameters = null,
            CommandType commandType = CommandType.StoredProcedure);

        string GenerateUpdateQueryById<T>(string tableName, T generateObject, string IdColumnName = null, List<string> SkipProperties = null);
        string GenerateInsertQuery<T>(string tableName, T generateObject, string keyProperty = null, List<string> SkipProperties = null);
        string GenerateInsertOutputQuery<T>(string tableName, T generateObject);
        string GenerateSelectALLQuery(string tableName, string param = "", string orderBy = "", bool desc = false);
        string GenerateDeleteQueryBySingleParameter(string tableName, string param);
    }
}
