using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace investigation.DataBase
{
    public static class DalUserProgress
    {
        private const string connStr = "server=localhost;user=root;password=;database=sensorgame";

        public static int LoadProgress(string userName)
        {
            try
            {using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT currentAgentIndex FROM users WHERE username = @username", conn))
                    {
                        cmd.Parameters.AddWithValue("@username", userName);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }

                    using (var insertCmd = new MySqlCommand("INSERT INTO users (username, currentAgentIndex) VALUES (@username,1)", conn))
                    {
                        insertCmd.Parameters.AddWithValue("@username", userName);
                        insertCmd.ExecuteNonQuery();
                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading user progress " + ex.Message);
                return 1;
            }
            
        }

        public static void SaveProgress(string userName, int currentAgentIndex)
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("UPDATE users SET currentAgentIndex = @index WHERE username = @username",conn))
                    {
                        cmd.Parameters.AddWithValue("@index", currentAgentIndex);
                        cmd.Parameters.AddWithValue("@username", userName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving user progress" + ex.Message);
            }
        }
    }
}
