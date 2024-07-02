

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace NewDew
{

	enum RowState
	{
		Existed,
		New,
		Modified,
		ModifiedNew,
		Deleted,
		Archived

	}

	public partial class App : Form
	{
		DataBase database = new DataBase();
		int selectedRow;

		private string selectedFilePath_dogovor;
		private string selectedFilePath_act;
		private string selectedFilePath_bill;
		private string selectedFilePath_protocol;
		private string selectedFilePath_invoice;
		private string selectedFilePath_psc;
		private string PATH_END;

		public App()
		{
			InitializeComponent();

			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

			textBox_name_order.Text = "Введите название";//подсказка
			textBox_name_firm.Text = "Введите название организации";//подсказка
			textBox_name_contact.Text = "Введите ФИО";//подсказка
			textBox_phone_customers.Text = "+ 7(900)-000-00-00";//подсказка
			textBox_email_customers.Text = "email@example.com";//подсказка
			textBox_name_order.ForeColor = Color.Gray;
			textBox_name_firm.ForeColor = Color.Gray;
			textBox_name_contact.ForeColor = Color.Gray;
			textBox_phone_customers.ForeColor = Color.Gray;
			textBox_email_customers.ForeColor = Color.Gray;

			string query = $"SELECT name_firm FROM Customers_table";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				comboBox1.Items.Add(reader.GetString(0));
				
			}
			reader.Close();
			

		}

		private void App_Load(object sender, EventArgs e)
		{


			LoadData();
			LoadData_Client();
			LoadData_Archive();			

		}

		private void LoadData()
		{

			CreateColumns();
			RefreshDataGrid(dataGridView1);

			Users userInstance = Users.Instance;
			string permissions = userInstance.UserPermissions;

			if (permissions != "admin")
			{
				button_create.Enabled = false;
				button_delete.Enabled = false;
				button_archive.Enabled = false;
				button_dogovor.Enabled = false;
				button_psc.Enabled = false;
				button_bill.Enabled = false;

			}

		}

		private void LoadData_Client()
		{
			
			try
			{
				CreateColumns_Customers();
				RefreshDataGrid_Customers(dataGridView2);
				Users userInstance = Users.Instance;
				string permissions = userInstance.UserPermissions;

				if (permissions != "admin")
				{
					button_create_customers.Enabled = false;
					button_change_customers.Enabled = false;
					button_delete_customers.Enabled = false;
				   
					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} 

		private void LoadData_Archive()
		{
			CreateColumns_Archive();
			RefreshDataGrid_Archive(dataGridView3);

			
		} 

		private void CreateColumns()
		{
			dataGridView1.Columns.Add("id_order", "N");
			dataGridView1.Columns.Add("name_order", "Наименование заказа");

			DataGridViewButtonColumn buttonColumn_dogovor = new DataGridViewButtonColumn();
			buttonColumn_dogovor.HeaderText = "Договор";
			buttonColumn_dogovor.Name = "dogovor_file";
			buttonColumn_dogovor.UseColumnTextForButtonValue = false;

			DataGridViewButtonColumn buttonColumn_act = new DataGridViewButtonColumn();
			buttonColumn_act.HeaderText = "Акт";
			buttonColumn_act.Name = "act_file";
			buttonColumn_act.UseColumnTextForButtonValue = false;

			DataGridViewButtonColumn buttonColumn_bill = new DataGridViewButtonColumn();
			buttonColumn_bill.HeaderText = "Счет";
			buttonColumn_bill.Name = "bill_file";
			buttonColumn_bill.UseColumnTextForButtonValue = false;

			DataGridViewButtonColumn buttonColumn_invoice = new DataGridViewButtonColumn();
			buttonColumn_invoice.HeaderText = "Счет фактуры";
			buttonColumn_invoice.Name = "invoice_file";
			buttonColumn_invoice.UseColumnTextForButtonValue = false;

			DataGridViewButtonColumn buttonColumn_protocol = new DataGridViewButtonColumn();
			buttonColumn_protocol.HeaderText = "Протокол";
			buttonColumn_protocol.Name = "protocol_file";
			buttonColumn_protocol.UseColumnTextForButtonValue = false;

			DataGridViewButtonColumn buttonColumn_protocol_PSC = new DataGridViewButtonColumn();
			buttonColumn_protocol_PSC.HeaderText = "Протокол ПСЦ";
			buttonColumn_protocol_PSC.Name = "protocol_PSC_file";
			buttonColumn_protocol_PSC.UseColumnTextForButtonValue = false;

			dataGridView1.Columns.Add(buttonColumn_dogovor);
			dataGridView1.Columns.Add(buttonColumn_act);
			dataGridView1.Columns.Add(buttonColumn_bill);
			dataGridView1.Columns.Add(buttonColumn_invoice);
			dataGridView1.Columns.Add(buttonColumn_protocol);
			dataGridView1.Columns.Add(buttonColumn_protocol_PSC);
			dataGridView1.Columns.Add("IsNew", String.Empty);

			dataGridView1.Columns["IsNew"].Visible = false;


		} 

		private void CreateColumns_Customers()
		{
			dataGridView2.Columns.Add("id_customer", "N");
			dataGridView2.Columns.Add("name_firm", "Наименование организации");
			dataGridView2.Columns.Add("name_contact", "Представитель");
			dataGridView2.Columns.Add("phone", "Телефон");
			dataGridView2.Columns.Add("email", "Почта");
			dataGridView2.Columns.Add("actual", "Актуальность");

			
			dataGridView2.Columns.Add("IsNew", String.Empty);

			dataGridView2.Columns["IsNew"].Visible = false;


		} 

		private void CreateColumns_Archive()
		{
			dataGridView3.Columns.Add("id_archiwe", "N");
			dataGridView3.Columns.Add("name_order", "Название заказа");
			dataGridView3.Columns.Add("data_execution", "Дата архивирования");
			
			DataGridViewButtonColumn buttonColumn_package = new DataGridViewButtonColumn();
			buttonColumn_package.HeaderText = "Пакет документов";
			buttonColumn_package.Name = "package_doc";
			buttonColumn_package.Text = "Скачать";
			buttonColumn_package.UseColumnTextForButtonValue = false;

			dataGridView3.Columns.Add(buttonColumn_package);
			dataGridView3.Columns.Add("IsNew", String.Empty);


			dataGridView3.Columns["IsNew"].Visible = false;


		} 

		private void ReadSingleRow(DataGridView dgw, IDataRecord record)
		{
			dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetValue(2), record.GetValue(3), record.GetValue(4), record.GetValue(5), record.GetValue(6), record.GetValue(7), RowState.ModifiedNew);
		} 

		private void ReadSingleRow_Customers(DataGridView dgw, IDataRecord record)
		{
			dgw.Rows.Add(record.GetValue(0), record.GetString(1), record.GetValue(2), record.GetValue(3), record.GetValue(4), record.GetValue(5), RowState.ModifiedNew);
		} 

		private void ReadSingleRow_Archive(DataGridView dgw, IDataRecord record)
		{
			dgw.Rows.Add(record.GetValue(0), record.GetString(1), record.GetValue(2), record.GetValue(3), RowState.ModifiedNew);
		} 

		private void RefreshDataGrid(DataGridView dgw)
		{
			dgw.Rows.Clear();

			string query = $"SELECT * FROM dbo.Order_tabl";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				ReadSingleRow(dgw, reader);
			}
			reader.Close();
					

			dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

			Name_button_order();

		   



		} 

		private void RefreshDataGrid_Customers(DataGridView dgw)
		{
			dgw.Rows.Clear();

			string query = $"SELECT * FROM dbo.Customers_table";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				ReadSingleRow_Customers(dgw, reader);
			}
			reader.Close();


			dataGridView2.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			dataGridView2.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

			

		} 

		private void RefreshDataGrid_Archive(DataGridView dgw)
		{
			dgw.Rows.Clear();

			string query = $"SELECT * FROM dbo.Archive_tabl";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				ReadSingleRow_Archive(dgw, reader);
			}
			reader.Close();




			dataGridView3.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			dataGridView3.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);


		} 

		// ----------------- Методы работы кнопок на вкладке заказов в таблице ----------------------- //

		private void ChangeButtonCellText(int rowIndex, string columnName, string buttonText)
		{
			DataGridViewButtonCell buttonCell = dataGridView1.Rows[rowIndex].Cells[columnName] as DataGridViewButtonCell;

			buttonCell.Value = buttonText;
			dataGridView1.InvalidateCell(buttonCell.ColumnIndex, buttonCell.RowIndex);


		} 

		private void Name_button_order()
		{
			
			string query_dogovor = $"SELECT dogovor_file, act_file, bill_file, invoice_file, protocol_file, protocol_PSC_file FROM dbo.Order_tabl";

			SqlCommand command = new SqlCommand(query_dogovor, database.getConnection());

			database.openConnection();

			SqlDataReader reader = command.ExecuteReader();


			int index = 0;
			while (reader.Read())
			{
				if(reader.GetString(0).Length > 0)
					ChangeButtonCellText(index, "dogovor_file", "Загружено");
				else ChangeButtonCellText(index, "dogovor_file", "");
				if (reader.GetString(1).Length > 0)
					ChangeButtonCellText(index, "act_file", "Загружено");
				else ChangeButtonCellText(index, "act_file", "");
				if (reader.GetString(2).Length > 0)
					ChangeButtonCellText(index, "bill_file", "Загружено");
				else
					ChangeButtonCellText(index, "bill_file", "");
				if (reader.GetString(3).Length > 0)
					ChangeButtonCellText(index, "invoice_file", "Загружено");
				else
					ChangeButtonCellText(index, "invoice_file", "");
				if (reader.GetString(4).Length > 0)
					ChangeButtonCellText(index, "protocol_file", "Загружено");
				else
					ChangeButtonCellText(index, "protocol_file", "");
				if (reader.GetString(0).Length > 0)
					ChangeButtonCellText(index, "protocol_PSC_file", "Загружено");
				else
					ChangeButtonCellText(index, "protocol_PSC_file", "");


				index++;

			}
			reader.Close();
		} 

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
			if (e.ColumnIndex == 2)
			{
				string cell_for_query = dataGridView1.Rows[e.RowIndex].Cells["id_order"].Value.ToString();
				string query = $"SELECT dogovor_file FROM dbo.Order_tabl WHERE id_order = {cell_for_query}";
				string doc_for_cell = "";

				SqlCommand command = new SqlCommand(query, database.getConnection());

				database.openConnection();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					doc_for_cell = reader.GetString(0);
				}
				reader.Close();

				DataGridViewCell selectedCell = dataGridView1.CurrentCell;

				try
				{
					Process.Start("WINWORD.EXE", doc_for_cell);
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка");

				}
			}
			else if(e.ColumnIndex == 3)
			{
				string cell_for_query = dataGridView1.Rows[e.RowIndex].Cells["id_order"].Value.ToString();
				string query = $"SELECT act_file FROM dbo.Order_tabl WHERE id_order = {cell_for_query}";
				string doc_for_cell = "";

				SqlCommand command = new SqlCommand(query, database.getConnection());

				database.openConnection();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					doc_for_cell = reader.GetString(0);
				}
				reader.Close();

				DataGridViewCell selectedCell = dataGridView1.CurrentCell;

				try
				{
					Process.Start("WINWORD.EXE", doc_for_cell);

				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка");

				}
			}
			else if (e.ColumnIndex == 4)
			{
				string cell_for_query = dataGridView1.Rows[e.RowIndex].Cells["id_order"].Value.ToString();
				string query = $"SELECT bill_file FROM dbo.Order_tabl WHERE id_order = {cell_for_query}";
				string doc_for_cell = "";

				SqlCommand command = new SqlCommand(query, database.getConnection());

				database.openConnection();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					doc_for_cell = reader.GetString(0);
				}
				reader.Close();

				DataGridViewCell selectedCell = dataGridView1.CurrentCell;

				try
				{
					Process.Start("WINWORD.EXE", doc_for_cell);

				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка");

				}
			}
			else if (e.ColumnIndex == 5)
			{
				string cell_for_query = dataGridView1.Rows[e.RowIndex].Cells["id_order"].Value.ToString();
				string query = $"SELECT invoice_file FROM dbo.Order_tabl WHERE id_order = {cell_for_query}";
				string doc_for_cell = "";

				SqlCommand command = new SqlCommand(query, database.getConnection());

				database.openConnection();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					doc_for_cell = reader.GetString(0);
				}
				reader.Close();

				DataGridViewCell selectedCell = dataGridView1.CurrentCell;

				try
				{
					Process.Start("WINWORD.EXE", doc_for_cell);

				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка");

				}
			}
			else if (e.ColumnIndex == 6)
			{
				string cell_for_query = dataGridView1.Rows[e.RowIndex].Cells["id_order"].Value.ToString();
				string query = $"SELECT protocol_file FROM dbo.Order_tabl WHERE id_order = {cell_for_query}";
				string doc_for_cell = "";

				SqlCommand command = new SqlCommand(query, database.getConnection());

				database.openConnection();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					doc_for_cell = reader.GetString(0);
				}
				reader.Close();

				DataGridViewCell selectedCell = dataGridView1.CurrentCell;

				try
				{
					Process.Start("WINWORD.EXE", doc_for_cell);

				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка");

				}
			}
			else if (e.ColumnIndex == 5)
			{
				string cell_for_query = dataGridView1.Rows[e.RowIndex].Cells["id_order"].Value.ToString();
				string query = $"SELECT protocol_PSC_file FROM dbo.Order_tabl WHERE id_order = {cell_for_query}";
				string doc_for_cell = "";

				SqlCommand command = new SqlCommand(query, database.getConnection());

				database.openConnection();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					doc_for_cell = reader.GetString(0);
				}
				reader.Close();

				DataGridViewCell selectedCell = dataGridView1.CurrentCell;

				try
				{
					Process.Start("WINWORD.EXE", doc_for_cell);

				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message, "Ошибка");

				}
			}


		} 

		// ------------------------------------ Кнопки Заказов --------------------------------------- //

		private void button_dogovor_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFilePath_dogovor = openFileDialog.FileName;
				MessageBox.Show("Выбран файл: " + selectedFilePath_dogovor);
			}
		} 

		private void button_act_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFilePath_act = openFileDialog.FileName;
				MessageBox.Show("Выбран файл: " + selectedFilePath_act);
			}
		} 

		private void button_protocol_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFilePath_protocol = openFileDialog.FileName;
				MessageBox.Show("Выбран файл: " + selectedFilePath_protocol);
			}
		} 

		private void button_invoice_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFilePath_invoice = openFileDialog.FileName;
				MessageBox.Show("Выбран файл: " + selectedFilePath_invoice);
			}
		} 

		private void button_bill_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFilePath_bill = openFileDialog.FileName;
				MessageBox.Show("Выбран файл: " + selectedFilePath_bill);
			}
		} 

		private void button_psc_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFilePath_psc = openFileDialog.FileName;
				MessageBox.Show("Выбран файл: " + selectedFilePath_psc);
			}
		} 

		private void button_create_Click(object sender, EventArgs e)
		{
			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string query = $"insert into Order_tabl(name_order, dogovor_file, act_file, bill_file, invoice_file, protocol_file, protocol_PSC_file) values('{textBox_name_order.Text}','{selectedFilePath_dogovor}','{selectedFilePath_act}','{selectedFilePath_bill}','{selectedFilePath_invoice}','{selectedFilePath_protocol}','{selectedFilePath_psc}')";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);
			RefreshDataGrid(dataGridView1);
		} 

		private void button_change_Click(object sender, EventArgs e)
		{
			Change_order();



		} 

		private void button_delete_Click(object sender, EventArgs e)
		{
			Delete_Row_Order();
		} 

		private void button_save_order_Click(object sender, EventArgs e)
		{
			Update_order();
		} 

		private void button_archive_Click(object sender, EventArgs e)
		{
			var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
			string cell_for_id = dataGridView1.Rows[selectedRowIndex].Cells["id_order"].Value.ToString();
			var name_order = textBox_name_order.Text;



			if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
			{
				try
				{
					string outputFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MergedFilesFolder");
					Directory.CreateDirectory(outputFolderPath);

					string[] filesToArchive = {selectedFilePath_dogovor, selectedFilePath_act, selectedFilePath_bill, selectedFilePath_protocol, selectedFilePath_invoice, selectedFilePath_psc};

					foreach (string filePath in filesToArchive)
					{
						if (File.Exists(filePath))
						{
							string fileName = Path.GetFileName(filePath);
							string destFile = Path.Combine(outputFolderPath, fileName);
							File.Copy(filePath, destFile);
						}
					}

					string zipFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MergedFilesArchive.zip");
					ZipFile.CreateFromDirectory(outputFolderPath, zipFilePath);

					PATH_END = zipFilePath;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Проверьте корректность данных!");
				}
			}

			Archive_order();

		} 

		private void pictureBox_clear_order_Click(object sender, EventArgs e)
		{
			textBox_name_order.Text = "";
			textBox_name_order.ForeColor = Color.Gray;
			textBox_name_order.Text = "Введите название";//подсказка

			selectedFilePath_dogovor = "";
			selectedFilePath_act = "";
			selectedFilePath_bill = "";
			selectedFilePath_protocol = "";
			selectedFilePath_invoice = "";
			selectedFilePath_psc = "";

		} 

		private void pictureBox_refresh_orders_Click(object sender, EventArgs e)
		{
			RefreshDataGrid(dataGridView1);
		} 

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedRow = e.RowIndex;

			var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
			string cell_for_id = dataGridView1.Rows[selectedRowIndex].Cells["id_order"].Value.ToString();
			var name_order = textBox_name_order.Text;

			string cell_for_query = dataGridView1.Rows[selectedRowIndex].Cells["id_order"].Value.ToString();
			string query = $"SELECT * FROM dbo.Order_tabl WHERE id_order = {cell_for_query}";


			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				try
				{
					selectedFilePath_dogovor = reader.GetString(2);
					selectedFilePath_act = reader.GetString(3);
					selectedFilePath_bill = reader.GetString(4);
					selectedFilePath_invoice = reader.GetString(5);
					selectedFilePath_protocol = reader.GetString(6);
					selectedFilePath_psc = reader.GetString(7);
				}
				catch { 
				}
				
			}
			reader.Close();

			if (e.RowIndex > 0)
			{
				DataGridViewRow row = dataGridView1.Rows[selectedRow];
				textBox_name_order.ForeColor = Color.Black;
				textBox_name_order.Text = row.Cells[1].Value.ToString();
			}
		}

		private void Change_order()
		{
			var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
			string cell_for_id = dataGridView1.Rows[selectedRowIndex].Cells["id_order"].Value.ToString();
			var name_order = textBox_name_order.Text;



			if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
			{
				try
				{
					dataGridView1.Rows[selectedRowIndex].SetValues(cell_for_id, name_order);
					dataGridView1.Rows[selectedRowIndex].Cells[8].Value = RowState.Modified;

				}
				catch (Exception ex)
				{
					MessageBox.Show("Проверьте корректность данных!");
				}
			}
							   
		


		} 

		private void Update_order()
		{
			database.openConnection();

			for (int index = 0; index < dataGridView1.Rows.Count; index++)
			{
				var rowState = (RowState)dataGridView1.Rows[index].Cells[8].Value;

				if (rowState == RowState.Existed)
				{
					continue;
				}

				if (rowState == RowState.Deleted)
				{
					var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
					var delet_query = $"delete from dbo.Order_tabl where id_order = {id}";

					var command = new SqlCommand(delet_query, database.getConnection());
					command.ExecuteNonQuery();

				}
				if (rowState == RowState.Modified)
				{

					var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
					var name_order = dataGridView1.Rows[index].Cells[1].Value.ToString();


					string change_query = $"update Order_tabl set name_order = '{textBox_name_order.Text}', dogovor_file = '{selectedFilePath_dogovor}', act_file = '{selectedFilePath_act}', bill_file = '{selectedFilePath_bill}', invoice_file = '{selectedFilePath_invoice}', protocol_file = '{selectedFilePath_protocol}', protocol_PSC_file= '{selectedFilePath_psc}' where id_order = '{id}'";

					SqlCommand command = new SqlCommand(change_query, database.getConnection());
					command.ExecuteNonQuery();


					RefreshDataGrid(dataGridView1);

				}
				if (rowState == RowState.Archived)
				{
					var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
					DateTime currentDate = DateTime.Now;
					String data_archive = currentDate.ToString("dd.MM.yyyy"); 

					SqlDataAdapter adapter = new SqlDataAdapter();
					DataTable table = new DataTable();

					
					string query = $"insert into Archive_tabl(name_order, data_execution, package_doc) values('{dataGridView1.Rows[index].Cells[1].Value.ToString()}','{data_archive}','{PATH_END}') " +
						$"delete from dbo.Order_tabl where id_order = {id}";

					SqlCommand command = new SqlCommand(query, database.getConnection());

					adapter.SelectCommand = command;
					adapter.Fill(table);

					RefreshDataGrid(dataGridView1);
					RefreshDataGrid_Archive(dataGridView3);					

				}

			}

			database.closeConnection();
		} 

		private void Delete_Row_Order()
		{
			int index = dataGridView1.CurrentCell.RowIndex;

			dataGridView1.Rows[index].Visible = false;

			if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
			{
				dataGridView1.Rows[index].Cells[8].Value = RowState.Deleted;
				return;

			}

			dataGridView1.Rows[index].Cells[8].Value = RowState.Deleted;
		} 

		private void Search_order(DataGridView dgw)
		{
			dgw.Rows.Clear();

			
			string query = $"select * from Order_tabl where concat(id_order, name_order) like '%" + textBox_search_order.Text + "%'";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			SqlDataReader read = command.ExecuteReader();

			while(read.Read())
			{
				ReadSingleRow(dgw, read);
			}

			read.Close();
		} 

		private void Archive_order()
		{
			int index = dataGridView1.CurrentCell.RowIndex;

			dataGridView1.Rows[index].Visible = false;

			if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
			{
				dataGridView1.Rows[index].Cells[8].Value = RowState.Archived;
				return;

			}

			dataGridView1.Rows[index].Cells[8].Value = RowState.Archived;
		}

		private void textBox_search_order_TextChanged(object sender, EventArgs e)
		{
			Search_order(dataGridView1);
		} 

		// ------------------------------------ Кнопки Заказчиков ------------------------------------ //

		private void button_create_customers_Click(object sender, EventArgs e)
		{
			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string query = $"insert into Customers_table(name_firm, name_contact, phone, email, actual) values('{textBox_name_firm.Text}','{textBox_name_contact.Text}','{textBox_phone_customers.Text}','{textBox_email_customers.Text}','В работе')";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);
			RefreshDataGrid_Customers(dataGridView2);
		} 

		private void button_change_customers_Click(object sender, EventArgs e)
		{
			Change_customers();
		} 

		private void button_save_customers_Click(object sender, EventArgs e)
		{
			Update_costumers();

		} 

		private void button_delete_customers_Click(object sender, EventArgs e)
		{
			Delete_Row_Customer();
		} 

		private void Search_customer(DataGridView dgw)
		{
			dgw.Rows.Clear();


			string query = $"select * from Customers_table where concat(id_customer, name_firm, name_contact, phone, email, actual) like '%" + textBox_search_customers.Text + "%'";

			SqlCommand command = new SqlCommand(query, database.getConnection());

			database.openConnection();

			SqlDataReader read = command.ExecuteReader();

			while (read.Read())
			{
				ReadSingleRow(dgw, read);
			}

			read.Close();
		} 

		private void textBox_search_customers_TextChanged(object sender, EventArgs e)
		{
			Search_customer(dataGridView2);
		} 

		private void Change_customers()
		{
			var selectedRowIndex = dataGridView2.CurrentCell.RowIndex;
			string cell_for_id = dataGridView2.Rows[selectedRowIndex].Cells["id_customer"].Value.ToString();
			var name_firm = textBox_name_firm.Text;
			var name_contact = textBox_name_contact.Text;
			var phone = textBox_phone_customers.Text;
			var email = textBox_email_customers.Text;



			if (dataGridView2.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
			{
				try
				{
					dataGridView2.Rows[selectedRowIndex].SetValues(cell_for_id, name_firm);
					dataGridView2.Rows[selectedRowIndex].SetValues(cell_for_id, name_contact);
					dataGridView2.Rows[selectedRowIndex].SetValues(cell_for_id, phone);
					dataGridView2.Rows[selectedRowIndex].SetValues(cell_for_id, email);
					dataGridView2.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;

				}
				catch (Exception ex)
				{
					MessageBox.Show("Проверьте корректность данных!");
				}
			}




		} 

		private void Update_costumers()
		{
			database.openConnection();

			for (int index = 0; index < dataGridView2.Rows.Count; index++)
			{
				var rowState = (RowState)dataGridView2.Rows[index].Cells[6].Value;

				if (rowState == RowState.Existed)
				{
					continue;
				}

				if (rowState == RowState.Deleted)
				{
					var id = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
					var delet_query = $"delete from dbo.Customers_table where id_customer = {id}";

					var command = new SqlCommand(delet_query, database.getConnection());
					command.ExecuteNonQuery();

				}
				if (rowState == RowState.Modified)
				{

					var id = dataGridView2.Rows[index].Cells[0].Value.ToString();
					var name_firm = dataGridView2.Rows[index].Cells[1].Value.ToString();
					var name_contact = dataGridView2.Rows[index].Cells[2].Value.ToString();
					var phone = dataGridView2.Rows[index].Cells[3].Value.ToString();
					var email = dataGridView2.Rows[index].Cells[4].Value.ToString();


					string change_query = $"update Customers_table set name_firm = '{textBox_name_firm.Text}', name_contact = '{textBox_name_contact.Text}', phone = '{textBox_phone_customers.Text}', email = '{textBox_email_customers.Text}', actual = '{"dsdsds"}' where id_customer = '{id}'";

					SqlCommand command = new SqlCommand(change_query, database.getConnection());
					command.ExecuteNonQuery();


					RefreshDataGrid_Customers(dataGridView2);

				}
			}

			database.closeConnection();
		} 

		private void Delete_Row_Customer()
		{
			int index = dataGridView2.CurrentCell.RowIndex;

			dataGridView2.Rows[index].Visible = false;

			if (dataGridView2.Rows[index].Cells[0].Value.ToString() == string.Empty)
			{
				dataGridView2.Rows[index].Cells[6].Value = RowState.Deleted;
				return;

			}

			dataGridView2.Rows[index].Cells[6].Value = RowState.Deleted;
		} 

		private void pictureBox_clear_customers_Click(object sender, EventArgs e)
		{
			textBox_name_order.Text = null;
			textBox_name_order.ForeColor = Color.Gray;
			textBox_name_firm.Text = null;
			textBox_name_firm.ForeColor = Color.Gray;
			textBox_name_contact.Text = null;
			textBox_name_contact.ForeColor = Color.Gray;
			textBox_phone_customers.Text = null;
			textBox_phone_customers.ForeColor = Color.Gray;
			textBox_email_customers.Text = null;
			textBox_email_customers.ForeColor = Color.Gray;

			textBox_name_firm.Text = "Введите название организации";//подсказка
			textBox_name_contact.Text = "Введите ФИО";//подсказка
			textBox_phone_customers.Text = "+ 7(900)-000-00-00";//подсказка
			textBox_email_customers.Text = "email@example.com";//подсказка

		} 

		private void pictureBox_refresh_customers_Click(object sender, EventArgs e)
		{
			RefreshDataGrid_Customers(dataGridView2);
		}

        // ------------------------------------ Кнопки Архива ------------------------------------ //

        private void pictureBox_refresh_achive_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Archive(dataGridView3);
        }

        private void textBox_search_archive_TextChanged(object sender, EventArgs e)
        {
            Search_archive(dataGridView3);
        }

        private void Search_archive(DataGridView dgw)
        {
            dgw.Rows.Clear();


            string query = $"select * from Archive_tabl where concat(id_archive, name_order, data_execution) like '%" + textBox_search_archive.Text + "%'";

            SqlCommand command = new SqlCommand(query, database.getConnection());

            database.openConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }


        //-------------------------------------------------------------------------------------------//

        // методы измеения действия textBox при нажатии (изменение подсказки)

        private void textBox_name_order_MouseClick(object sender, MouseEventArgs e)
		{
			textBox_name_order.Text = null;
			textBox_name_order.ForeColor = Color.Black;
		}

		private void textBox_name_firm_MouseClick(object sender, MouseEventArgs e)
		{
			textBox_name_firm.Text = null;
			textBox_name_firm.ForeColor = Color.Black;
		}

		private void textBox_name_contact_MouseClick(object sender, MouseEventArgs e)
		{
			textBox_name_contact.Text = null;
			textBox_name_contact.ForeColor = Color.Black;
		}

		private void textBox_phone_customers_MouseClick(object sender, MouseEventArgs e)
		{
			textBox_phone_customers.Text = null;
			textBox_phone_customers.ForeColor = Color.Black;
		}

		private void textBox_email_customers_MouseClick(object sender, MouseEventArgs e)
		{
			textBox_email_customers.Text = null;
			textBox_email_customers.ForeColor = Color.Black;
		}

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}

