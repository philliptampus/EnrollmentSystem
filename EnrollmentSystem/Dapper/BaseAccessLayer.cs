using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicketingAPI.Dapper
{
    public class BaseAccessLayer : IBaseAccessLayer
    {
        public string ConnectionString;
        private static IConfiguration _config;
        private static int timeoutSeconds => 500;


        public BaseAccessLayer(IConfiguration configuration)
        {
             _config = configuration;
            ConnectionString = _config.GetConnectionString("conn");
        }

        public string ConnString
        {
            get => ConnectionString;
            set
            {
                ConnectionString = value;
                // Test change
            }
        }

        private IDbConnection CreateOpenConnection(string ConnectionString)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            Console.Write("This change is for billing feature");
            Console.WriteLine("Test 2");
            return connection;
        }

        public async Task<int> ExecuteNonQueryAsync(string queryToExec, object parameters = null, CommandType commandType = CommandType.StoredProcedure, int? timeOut = 0)
        {
            using (var connection = CreateOpenConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string queryToExec, object parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = CreateOpenConnection(ConnectionString))
            {
                return await connection.ExecuteScalarAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }

        public async Task<IEnumerable<T>> QueryListAsync<T>(string queryToExec, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = CreateOpenConnection(ConnectionString))
            {
                return await connection.QueryAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }


        public async Task<T> QuerySingleOrDefaultAsync<T>(string queryToExec, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = CreateOpenConnection(ConnectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string queryToExec, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = CreateOpenConnection(ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }

        public string GenerateUpdateQueryById<T>(string tableName, T generateObject, string IdColumnName = null, List<string> SkipProperties = null)
        {
            string idColumn = IdColumnName ?? "Id";
            string updateQuery = $"UPDATE [{tableName}] SET ";
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList(); // Retrieves the properties of the Class
            StringBuilder columnsBuilder = new StringBuilder();

            // TODO: Change this way of skipping the property using custom attribute
            if (SkipProperties != null)
            {
                properties = properties.Where(x => !SkipProperties.Contains(x.Name)).ToList();
            }

            foreach (PropertyInfo property in properties) // iterates the properties to tag in update query
            {
                if (property.Name.ToString() != idColumn)
                {
                    var value = property.GetValue(generateObject, null) != null ? property.GetValue(generateObject, null) : null;
                    if (value != null)
                    {
                        columnsBuilder.Append($"[{property.Name.ToString()}] = @{property.Name.ToString()}, ");

                    }
                }
            }

            string query = updateQuery + $"{ columnsBuilder.ToString().TrimEnd(',', ' ')} ";
            query += $" where {idColumn} = @{idColumn} ;";
            return query;
        }

        public string GenerateInsertQuery<T>(string tableName, T generateObject, string keyProperty = null, List<string> SkipProperties = null)
        {
            string queryTable = $"insert into [{tableName}] ";
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList(); // Retrieves the properties of the Class


            StringBuilder columnsBuilder = new StringBuilder();
            StringBuilder valuesBuilder = new StringBuilder();

            // TODO: Change this way of skipping the property using custom attribute
            if (SkipProperties != null)
            {
                properties = properties.Where(x => !SkipProperties.Contains(x.Name)).ToList();
            }

            foreach (PropertyInfo property in properties) // iterates the properties to tag in update query
            {

                var value = property.GetValue(generateObject, null) != null ? property.GetValue(generateObject, null) : null;
                if (value != null)
                {
                    if (keyProperty != null && keyProperty == property.Name)
                    {
                        continue;
                    }

                    columnsBuilder.Append($"[{property.Name.ToString()}], ");
                    valuesBuilder.Append($"@{property.Name.ToString()}, ");

                }
            }

            string queryBuilder = queryTable + $"({ columnsBuilder.ToString().TrimEnd(',', ' ')}) VALUES ({ valuesBuilder.ToString().TrimEnd(',', ' ')}); ";
            return queryBuilder;
        }

        public string GenerateInsertOutputQuery<T>(string tableName, T generateObject)
        {
            string queryTable = $"insert into [{tableName}] ";
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList(); // Retrieves the properties of the Class


            StringBuilder columnsBuilder = new StringBuilder();
            StringBuilder valuesBuilder = new StringBuilder();

            List<PropertyInfo> booleanProps = new List<PropertyInfo>();
            foreach (PropertyInfo property in properties) // iterates the properties to tag in update query
            {

                var value = property.GetValue(generateObject, null) != null ? property.GetValue(generateObject, null) : null;
                if (value != null)
                {
                    columnsBuilder.Append($"[{property.Name.ToString()}], ");
                    valuesBuilder.Append($"@{property.Name.ToString()}, ");

                }
            }

            string queryBuilder = queryTable + $"({ columnsBuilder.ToString().TrimEnd(',', ' ')}) OUTPUT Inserted.* VALUES ({ valuesBuilder.ToString().TrimEnd(',', ' ')}); ";
            return queryBuilder;
        }

        public string GenerateSelectALLQuery(string tableName, string param = "", string orderBy = "", bool desc = false)
        {
            string query = $"Select * From [{tableName}] ";
            if (param != "")
            {
                query += $"Where [{param}] = @{param} ";
            }

            if (orderBy != "")
            {
                query += $" Order By [{orderBy}] {(desc ? "desc" : "")};";
            }

            return query;
        }

        public string GenerateDeleteQueryBySingleParameter(string tableName, string param)
        {
            string query = $"Delete from [{tableName}] where [{param}] = @{param}";
            return query;
        }

        public Task<T> QueryLastOrDefaultAsync<T>(string queryToExec, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }
    }
}
