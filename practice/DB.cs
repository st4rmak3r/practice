using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AppPractice
{
    static class Database
    {
        static private string connectionString = "database=military; username=root; password=12345678; server=localhost; port=3306";

        static public MySqlConnection getConnection()
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("MySqlError! " + exception.Message, "MySqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

            return con;
        }

        static public void OpenConnection(MySqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (MySqlException exception)
                {
                    MessageBox.Show("MySqlError! " + exception.Message, "MySqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        static public void CloseConnection(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    con.Close();
                }
                catch (MySqlException exception)
                {
                    MessageBox.Show("MySqlError! " + exception.Message, "MySqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Rest of your code...

        static public void databaseDataQueryUpdateInsertDelete(string query)
        {
            MySqlConnection con = getConnection();
            OpenConnection(con);

            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Execute had total fail! " + exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show("Query had total fail" + exception.Message);
            }
            finally
            {
                CloseConnection(con);
            }
        }

        static public DataTable selectStatementNotParameters(string query)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = getConnection();
            OpenConnection(con);

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();
                adapter.Fill(dt);
                return dt;
            }
            catch (MySqlException exception)
            {
                MessageBox.Show("Execute had total fail! " + exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show("DataTable had total fail" + exception.Message);
            }
            finally
            {
                CloseConnection(con);
            }

            return null;
        }
    }
}
