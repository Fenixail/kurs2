using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class kvartira2 : Form
    {
        public kvartira2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (textBox2.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (textBox3.Text == "Введите ваш город")
            {
                MessageBox.Show("Введите ваш город");
            }
            if (isUserExists())
            {
                return;
            }
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `2kvart` (FirstName, LastName, city) VALUES(@FName, @LName, @Cit)", db.getConnection());

            command.Parameters.Add("@FName", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@LName", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@Cit", MySqlDbType.VarChar).Value = textBox3.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы оставили заявку");
                this.Hide();
                agent agent = new agent();
                agent.Show();
            }
            else
            {
                MessageBox.Show("Ошибка");
                return;
            }
            db.closeConnection();
        }
        public Boolean isUserExists()
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM 2kvart WHERE FirstName= @FN", dataBase.getConnection());
            command.Parameters.Add("@FN", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Вы не можете повторно оставить запись!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            spisok spisok = new spisok();
            spisok.Show();
        }
        private int GetIdFromTable(string tablename, string fieldName, string value)
        {
            DB dataBase = new DB();

            string query = $"SELECT id FROM {tablename} WHERE {fieldName} = @value";
            using (MySqlCommand command = new MySqlCommand(query, dataBase.getConnection()))
            {
                dataBase.openConnection();
                command.Parameters.AddWithValue("@value", value);
                object result = command.ExecuteScalar();
                dataBase.closeConnection();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void polz(string FirstName)
        {
            int pokupId = GetIdFromTable("2kvart", "FirstName", FirstName);
            DB dataBase = new DB();
            string query = "DELETE FROM 2kvart WHERE `id` = @recordId";

            dataBase.openConnection();
            using (MySqlCommand command = new MySqlCommand(query, dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@recordId", pokupId);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Запись успешно удалена.");
                }
                else
                {
                    MessageBox.Show("Запись не удалена");
                }

            }
            dataBase.closeConnection();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            polz(textBox1.Text);
        }
    }
}
   
