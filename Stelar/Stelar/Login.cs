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
            if (textBox1.Text == "admin" && textBox2.Text == "aezakmi")
            {
                Menu shit = new Menu();
                Hide();
                textBox1.Clear();
                textBox2.Clear();
                shit.ShowDialog();
                shit = null;
                Show();
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