using Moose.Encrypt;
using System;
using System.Windows.Forms;

namespace Stelar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password;
            Encrypt text = new Encrypt();
            password = text.sha256(textBox2.Text);

            if (textBox1.Text == "admin" && password == "3846af21a9f9841c6b5842a29df456986705fc5aae9dccc0ec7c9728e29a14cc")
            {
                Menu shit = new Menu();
                Hide();
                textBox1.Clear();
                textBox2.Clear();
                shit.Show();
                shit = null;
            }
            else
            {
                MessageBox.Show("Wrong Pasword", "What are you doing there buckaroo ?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Select();
            }
        }
    }
}