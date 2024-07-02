using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NewDew
{
	public partial class LoginForm : Form

	{

		DataBase database = new DataBase();
		

		public LoginForm()
		{
			InitializeComponent();
			StartPosition= FormStartPosition.CenterScreen;
			
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			var PassUser = PassField.Text;
			var LoginUser = LoginField.Text;

			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string query = $"select id_user, login_user, password_user from register_users where login_user = '{LoginUser}' and password_user = '{PassUser}'";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
                Users userInstance = Users.Instance;
                if (LoginUser == "admin")
				{
                    
                    userInstance.UserPermissions = "admin";
                }
				else userInstance.UserPermissions = "user";

                this.Hide();
				App appForm = new App();
				appForm.ShowDialog();

			}
			else
				MessageBox.Show("No");

		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			PassField.PasswordChar = '●';
			LoginField.MaxLength = 50;
			PassField.MaxLength = 50;

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Hide();
			FormReg regForm = new FormReg();
			regForm.ShowDialog();

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
