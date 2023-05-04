using MySql.Data.MySqlClient;
using Configuration;

namespace DataBaseTest.SqlHelper
{
    public static class SqlHelper
    {
        public static MySqlConnection DBConnection = new MySqlConnection($"server={TestConfig.Server};port={TestConfig.Port};database={TestConfig.Database};uid={TestConfig.User};pwd={TestConfig.Password}");

        public static void InsertInTable(string table_name, Dictionary<string, object> dict)
        {
            string sqlQuery = $"INSERT INTO {table_name} ({string.Join(", ", dict.Keys)}) VALUES({string.Join(", ", dict.Values)})";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, DBConnection);
            cmd.ExecuteNonQuery();
        }
        public static MySqlDataReader SelectFromTable(string table_name, List<string> fields, string condition)
        {
            string sqlQuery = $"SELECT {string.Join(", ", fields)} FROM {table_name} WHERE {condition}";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, DBConnection);
            return cmd.ExecuteReader();
        }
        public static MySqlDataReader SelectFromTable(string table_name, string field, string condition)
        {
            string sqlQuery = $"SELECT {field} FROM {table_name} WHERE {condition}";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, DBConnection);
            return cmd.ExecuteReader();
        }
        public static void DeleteFromTable(string table_name, string condition)
        {
            string sqlQuery = $"DELETE FROM {table_name} WHERE {condition}";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, DBConnection);
            cmd.ExecuteNonQuery();
        }
        public static void UpdateDataInTable(string table_name, Dictionary<string, object> dict, string condition)
        {
            string columns = string.Join(", ", dict.Keys.Select(k => $"{k}=@{k}"));
            string sqlQuery = $"UPDATE {table_name} SET {columns} WHERE {condition}";
            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, DBConnection))
            {
                foreach (var item in dict)
                {
                    cmd.Parameters.AddWithValue($"@{item.Key}", item.Value);
                }
                cmd.ExecuteNonQuery();
            }
        }
        public static Dictionary<string, object> GetRowAsDictionary(MySqlDataReader reader)
        {
            var row = new Dictionary<string, object>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                row[reader.GetName(i)] = reader.GetValue(i);
            }
            return row;
        }
        public static List<Dictionary<string, object>> GetRowsAsDictionaries(MySqlDataReader reader)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                var row = GetRowAsDictionary(reader);
                rows.Add(row);
            }
            reader.Close();

            return rows;
        }
    }
}
