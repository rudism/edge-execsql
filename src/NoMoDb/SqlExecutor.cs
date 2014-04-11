namespace NoMoDb
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Threading.Tasks;

    public class SqlExecutor
    {
        public async Task<object> BulkInsert(object input)
        {
            var data = input as IDictionary<string, object>;
            var connstr = data["connectionString"] as string;
            var table = data["table"] as string;
            var file = data["file"] as string;
            var query = string.Format(@"BULK INSERT [{0}] FROM '{1}'", table, file);
            return ExecuteQuery(connstr, query);
        }

        public async Task<object> ExecuteScript(object input)
        {
            var data = input as IDictionary<string, object>;
            var connstr = data["connectionString"] as string;
            var scriptPath = data["scriptPath"] as string;
            var query = File.ReadAllText(scriptPath);
            return ExecuteQuery(connstr, query);
        }

        private async Task<int> ExecuteQuery(string connectionString, string query)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(query, conn))
                {
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
