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
    public partial class spisok : Form
    {
        public spisok()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            kvartira1 kvartira1 = new kvartira1();
            kvartira1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            agent agent = new agent();
            agent.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            kvartira2 kvartira2 = new kvartira2();
            kvartira2.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            kvartira3 kvartira3 = new kvartira3();
            kvartira3.Show();
        }
    }
}
