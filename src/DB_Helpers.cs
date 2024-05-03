namespace Database_Difference_App;

internal static class DB_Helpers
{
    public static async Task<DataTable> GetDataTableAsync(string connString, string sqlQuery)
    {
        var dataTable = new DataTable();

        using (var connection = new SqlConnection(connString))
        {
            await connection.OpenAsync();

            using (var command = new SqlCommand(sqlQuery, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    dataTable.Load(reader);
                }
            }
        }

        return dataTable;
    }

}
