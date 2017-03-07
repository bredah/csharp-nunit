using MySql.Data.MySqlClient;

namespace CSharp.DB
{
    /// <summary>
    ///  Connection factory
    /// </summary>
    public class ConnectionFactory
    {
        /// <summary>
        /// Create a connection to database
        /// </summary>
        /// <returns>Database connection</returns>
        public MySqlConnection getConnection()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = Settings.Default.CONNECTION_URL;
            connectionString.Port = uint.Parse(Settings.Default.CONNECTION_PORT);
            connectionString.Database = Settings.Default.DATABASE;
            connectionString.UserID = Settings.Default.USERNAME;
            connectionString.Password = Settings.Default.PASSWORD;
            return new MySqlConnection(connectionString.ToString());
        }
    }
}
