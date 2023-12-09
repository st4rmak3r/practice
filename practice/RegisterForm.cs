using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppPractice
{
    
    public partial class RegisterForm : Form
    {

       
        public RegisterForm()
        {
            InitializeComponent();
   
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = Database.getConnection();
            
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;
            string confirm = confirmTextBox.Text;

            if (login == "" || password == "" || confirm == "")
            {
                MessageBox.Show("Пожалуйтса, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            // Проверка, что такого пользователя еще нет
            MySqlCommand checkCommand = new MySqlCommand("SELECT * FROM `user_m` WHERE `login_user` = @uL", Database.getConnection());
            checkCommand.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;

            MySqlDataAdapter checkAdapter = new MySqlDataAdapter();
            DataTable checkTable = new DataTable();
            checkAdapter.SelectCommand = checkCommand;
            checkAdapter.Fill(checkTable);

            if (checkTable.Rows.Count > 0)
            {
                MessageBox.Show("Такой пользователь уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Database.getConnection();
                return;
            }

            // Вставка нового пользователя
            MySqlCommand insertCommand = new MySqlCommand("INSERT INTO `user_m` (`login_user`, `password_user`) VALUES (@uL, @uP)", Database.getConnection());
            insertCommand.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            insertCommand.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            int result = insertCommand.ExecuteNonQuery();

            Database.getConnection();

            if (result == 1)
            {
                MessageBox.Show("Регистрация прошла успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Ошибка во время регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
      
          
                // Создайте новый экземпляр LoginForm и отобразите его
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Скрыть текущую форму (RegisterForm)
                this.Hide();
            
        }

   

 

        private void checkBox2_CheckedChanged_(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                confirmTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                confirmTextBox.UseSystemPasswordChar = true;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                passwordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordTextBox.UseSystemPasswordChar = true;
            }

        }

    

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing))
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }


 
    
}
