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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu form1 = new Menu();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                string loginUser = textBox1.Text;
                string passUser = textBox2.Text;

                DB dataBase = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login= @UL AND pass= @UP", dataBase.getConnection());
                command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = passUser;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Вы зашли на свой аккаунт");
                    this.Hide();
                    agent agent = new agent();
                    agent.Show();

                }
                else
                {
                    MessageBox.Show("Ошибка: Неправильно набран логин или пароль");
                }
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
