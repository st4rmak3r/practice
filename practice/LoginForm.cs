using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AppPractice
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (IsValidUser(username, password))
            {
                MessageBox.Show("Login successful!");
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM user_m WHERE login_user = @username AND password_user = @password";

            using (MySqlConnection con = Database.getConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // If count is greater than 0, the user exists
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing))
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerform = new RegisterForm();
            registerform.Show();
            this.Dispose(); 
        }

        // Rest of your code...
    }
}
