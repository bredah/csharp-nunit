using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSharp.DB
{
    /// <summary>
    /// Simple USER DAO
    /// </summary>
    public class UserDAO
    {
        /// <summary>
        /// Retrieve list with users registered in database
        /// </summary>
        /// <returns>List with users</returns>
        public List<User> listAll()
        {
            List<User> collection = new List<User>();
            MySqlConnection connection = new ConnectionFactory().getConnection();
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT id, login, name, email FROM user;";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            User user = new User
                            {
                                id = int.Parse(row["id"].ToString()),
                                login = row["login"].ToString(),
                                name = row["name"].ToString(),
                                email = row["email"].ToString(),
                            };
                            collection.Add(user);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return collection;
        }

        /// <summary>
        /// Add a new user in database
        /// </summary>
        /// <param name="user">A new user</param>
        public void addUser(User user)
        {
            String query = string.Format("INSERT INTO user (login, name, email) VALUES ('{0}', '{1}', '{2}');", user.login, user.name, user.email);
            MySqlConnection connection = new ConnectionFactory().getConnection();
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
