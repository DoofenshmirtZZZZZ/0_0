using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NewDew
{
	public partial class FormReg : Form
	{
        DataBase database = new DataBase();

        public FormReg()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void buttonReg_Click(object sender, EventArgs e)
		{
			var PassUser = PassField.Text;
			var LoginUser = LoginField.Text;
			var NameU = textName.Text;
			var SurnameU = textSurename.Text;

			string query = $"insert into register_users (login_user, password_user, name_user, surname_user) values ('{LoginUser}','{PassUser}', '{NameU}', '{SurnameU}')";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			if (command.ExecuteNonQuery() == 1)
			{
				MessageBox.Show("Пользователь добавлен");
				this.Hide();           
				LoginForm loginForm = new LoginForm();
				loginForm.ShowDialog();
			}
			else
				MessageBox.Show("Ошибка");

			database.closeConnection();

            if (checkuser())

            {
                return;
            }

        }

		private Boolean checkuser()
		{
            var PassUser = PassField.Text;
            var LoginUser = LoginField.Text;
            var NameU = textName.Text;
            var SurnameU = textSurename.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

			string query = $"select  id_user, login_user, password_user from register_users where login_user = '{LoginUser}' and password_user = '{PassUser}'";

            SqlCommand command = new SqlCommand(query, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой пользователь уже существует!");
				return true;

            }
            else
                return false;

        }

		private void label1_Click(object sender, EventArgs e)
		{
			PassField.PasswordChar = '●';
		}

        private void FormReg_Load(object sender, EventArgs e)
        {

        }
    }
}
