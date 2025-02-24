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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
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
            if(isUserExists())
            {
                return;
            }
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (FirstName, LastName, login, pass) VALUES(@FName, @LName, @Log, @Pass)", db.getConnection());

            command.Parameters.Add("@FName", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@LName", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@Log", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = textBox4.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Пользователь зарегистрирован");
                this.Hide();
                agent agent = new agent();
                agent.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не был зарегистрирован");
                return; 
            }
            db.closeConnection();
        }
       

        public Boolean isUserExists()
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login= @UL", dataBase.getConnection());
            command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = textBox3.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть, введите другой");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu form1 = new Menu();
            form1.Show();

        }
    }
}
